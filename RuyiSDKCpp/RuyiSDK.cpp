#include <iostream>
#include <boost/algorithm/string/predicate.hpp>
#include <boost/lexical_cast.hpp>
#include <boost/algorithm/string/replace.hpp>

#include "resource.h"
#include "RuyiSDK.h"

#include "PubSub\MessageCreator.h"

#include "version.info"

using namespace Ruyi;
using namespace Ruyi::SDK;
using namespace Ruyi::SDK::SDKValidator;
using namespace Ruyi::SDK::Constants;
using namespace Ruyi::SDK::StorageLayer;
using namespace Ruyi::SDK::SettingSystem;
using namespace Ruyi::SDK::SettingSystem::Api;
using namespace Ruyi::SDK::BrainCloudApi;

bool RuyiSDKContext::IsValid()
{
	if (endpoint == RuyiSDKContext::Endpoint::Notset)
		return false;

	return true;
}

RuyiSDK* RuyiSDK::CreateSDKInstance(RuyiSDKContext& jsc)
{
	if (!jsc.IsValid())
		return NULL;

	RuyiSDK* ret = new RuyiSDK();
	ret->context = new RuyiSDKContext(jsc.endpoint, jsc.remoteAddress);

	if (!ret->Init())
		return NULL;

	return ret;
}

RuyiSDK::RuyiSDK()
	: Storage(NULL)
	, Subscriber(NULL)
	, SettingSys(NULL)
	, BCService(NULL)
	, UserService(NULL)
	, context(NULL)
	, validator(NULL)
	//, RuyiNet(NULL)
{
}


RuyiSDK::~RuyiSDK()
{
	delete Subscriber;
	Subscriber = NULL;

	delete Storage;
	Storage = NULL;

	delete SettingSys;
	SettingSys = NULL;

	delete BCService;
	BCService = NULL;

	delete UserService;
	UserService = NULL;

	delete context;
	context = NULL;

	delete validator;
	validator = NULL;

	//delete RuyiNet;
	//RuyiNet = NULL;

	if (sharedLowTrans != NULL)
		sharedLowTrans->close();

	if (sharedHighTrans != NULL)
		sharedHighTrans->close();
}

bool RuyiSDK::Init()
{
	int lowTimeout = 10000;		// 10s
	// init and open high/low latency transport, create protocols
	sharedLowTrans = boost::shared_ptr<TSocket>(new TSocket(context->remoteAddress, g_ConstantsSDKDataTypes_constants.low_latency_socket_port));
	sharedLowTrans->setSendTimeout(lowTimeout);
	sharedLowTrans->setRecvTimeout(lowTimeout);
	boost::shared_ptr<TBinaryProtocol> sharedLowProto(new TBinaryProtocol(sharedLowTrans));

	int highTimeout = 20000;	// 20s
	sharedHighTrans = boost::shared_ptr<TSocket>(new TSocket(context->remoteAddress, g_ConstantsSDKDataTypes_constants.high_latency_socket_port));
	sharedHighTrans->setSendTimeout(highTimeout);
	sharedHighTrans->setRecvTimeout(highTimeout);
	boost::shared_ptr<TBinaryProtocol> sharedHighProto(new TBinaryProtocol(sharedHighTrans));

	sharedLowTrans->open();
	sharedHighTrans->open();

	auto validationProtocol = boost::shared_ptr<TMultiplexedProtocol>(new TMultiplexedProtocol(sharedLowProto, "SER_VALIDATOR"));
	validator = new SDK::SDKValidator::ValidatorServiceClient(validationProtocol);
	if (!ValidateVersion())
		return false;

	// init pub-sub
	MessageCreator::Initialize();
	auto pubout = SetAddress(g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri);
	Subscriber = SubscribeClient::CreateInstance(pubout);

	// init storage layer
	boost::shared_ptr<TMultiplexedProtocol> stoProtocol = boost::shared_ptr<TMultiplexedProtocol>(new TMultiplexedProtocol(sharedHighProto, "SER_STORAGELAYER"));
	Storage = new SDK::StorageLayer::StorageLayerServiceClient(stoProtocol);

	// init brain cloud service
	boost::shared_ptr<TMultiplexedProtocol> bcProtocal = boost::shared_ptr<TMultiplexedProtocol>(new TMultiplexedProtocol(sharedHighProto, "SER_BCSERVICE"));
	BCService = new SDK::BrainCloudApi::BrainCloudServiceClient(bcProtocal);

	// init setting system
	boost::shared_ptr<TMultiplexedProtocol> proto = boost::shared_ptr<TMultiplexedProtocol>(new TMultiplexedProtocol(sharedLowProto, "SER_L0SETTINGSYSTEM_EXTERNAL"));
	SettingSys = new SDK::SettingSystem::Api::SettingSystemServiceClient(proto);

	// init localization service
	boost::shared_ptr<TMultiplexedProtocol> locProtocol = boost::shared_ptr<TMultiplexedProtocol>(new TMultiplexedProtocol(sharedLowProto, "SER_L10NSERVICE"));
	L10NService = new SDK::LocalizationService::LocalizationServiceClient(locProtocol);

	// init user service 
	boost::shared_ptr<TMultiplexedProtocol> userProtocol = boost::shared_ptr<TMultiplexedProtocol>(new TMultiplexedProtocol(sharedHighProto, "SER_USER_SERVICE_EXTERNAL"));
	UserService = new SDK::UserServiceExternal::UserServExternalClient(userProtocol);
	return true;

	// init Ruyi Net
	//boost::shared_ptr<TMultiplexedProtocol> ruyiNetClientProtocol = boost::shared_ptr<TMultiplexedProtocol>(new TMultiplexedProtocol(sharedHighProto, "SER_BCSERVICE"));
	//RuyiNet = new Ruyi::RuyiNetClient(ruyiNetClientProtocol);
}

bool RuyiSDK::ValidateVersion()
{
	// Do version check with layer0
	std::string valid;
	std::string ver = STR_VERSION; //GetProductAndVersion();
	validator->ValidateSDK(valid, ver);
	std::cout << "layer0 version info: " << valid << std::endl;
	if (boost::starts_with(valid, "err:"))
	{
		std::cout << "RuyiSDK version " << ver << " != jade version: " << valid << std::endl;
		return false;
	}
	else if (boost::starts_with(valid, "warn:"))
	{
		std::cout << "RuyiSDK version " << ver << " != jade version: " << valid << std::endl;
	}
	else
	{
		std::cout << "RuyiSDK version validated." << std::endl;
	}

	return true;
}

std::string RuyiSDK::SetAddress(std::string address)
{
	boost::replace_all(address, "{addr}", context->remoteAddress);
	return address;
}

std::string RuyiSDK::GetProductAndVersion()
{
	// get the filename of the executable containing the version resource
	TCHAR szFilename[MAX_PATH + 1] = { 0 };
	if (GetModuleFileName(NULL, szFilename, MAX_PATH) == 0)
	{
		std::cout << "GetModuleFileName failed with error %d\n" << GetLastError() << std::endl;
		return NULL;
	}

	// allocate a block of memory for the version info
	DWORD dummy;
	DWORD dwSize = GetFileVersionInfoSize(szFilename, &dummy);
	if (dwSize == 0)
	{
		std::cout << "GetFileVersionInfoSize failed with error %d\n" << GetLastError() << std::endl;
		return NULL;
	}
	std::vector<BYTE> data(dwSize);

	// load the version info
	if (!GetFileVersionInfo(szFilename, NULL, dwSize, &data[0]))
	{
		std::cout << "GetFileVersionInfo failed with error %d\n" << GetLastError() << std::endl;
		return NULL;
	}

	// get the name and version strings
	LPVOID pvProductName = NULL;
	unsigned int iProductNameLen = 0;
	LPVOID pvProductVersion = NULL;
	unsigned int iProductVersionLen = 0;

	UINT                uiVerLen = 0;
	VS_FIXEDFILEINFO*   pFixedInfo = 0;     // pointer to fixed file info structure
											// get the fixed file info (language-independent) 
	if (VerQueryValue(&data[0], TEXT("\\"), (void**)&pFixedInfo, (UINT *)&uiVerLen) == 0)
	{
		return NULL;
	}

	char sver[64];
	sprintf(sver, "%d.%d.%d.%d", HIWORD(pFixedInfo->dwProductVersionMS), LOWORD(pFixedInfo->dwProductVersionMS),
		HIWORD(pFixedInfo->dwProductVersionLS), HIWORD(pFixedInfo->dwProductVersionLS));

	return std::string(sver);
}
