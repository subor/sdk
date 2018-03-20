#pragma once

#include "thrift/transport/TSocket.h"
#include "thrift/protocol/TBinaryProtocol.h"
#include "thrift/protocol/TMultiplexedProtocol.h"

#include "Generated/StorageLayer/StorageLayerService.h"
#include "Generated/BrainCloudService/BrainCloudService.h"
#include "Generated/SettingSystem/SettingSystemService.h"
#include "Generated/SDKValidator/ValidatorService.h"
#include "Generated/LocalizationService/LocalizationService.h"
#include "Generated/UserServiceExternal/UserServExternal.h"

#include "Generated/Constants/ConstantsSDKDataTypes_constants.h"
#include "Generated/InputManager/InputManagerSDKDataTypes_types.h"
#include "Generated/StorageLayer/StorageLayerSDKDataTypes_types.h"
#include "Generated/SettingSystem/SettingSystemSDKDataTypes_types.h"
#include "Generated/GlobalInputDefine/GlobalInputDefineSDKDataTypes_types.h"
#include "Generated/BrainCloudService/BrainCloudServiceSDKDataTypes_types.h"
#include "Generated/LocalizationService/LocalizationServiceSDKDataTypes_types.h"
#include "Generated/UserServiceExternal/UserServiceExternalSDKDataTypes_types.h"

#include "PubSub/SubscribeClient.h"

//#include "RuyiNet/RuyiNetClient.h"

using namespace apache::thrift::transport;
using namespace apache::thrift::protocol;

namespace Ruyi
{
	class RuyiSDKContext
	{
		friend class RuyiSDK;

	public:
		enum Endpoint
		{
			Notset,
			Console,
			Mobile,
			PC,
			Web,
		};

	private:
		Endpoint endpoint;

		std::string remoteAddress;

	public:
		RuyiSDKContext(Endpoint ep, std::string ra)
			: endpoint(ep)
		{
			remoteAddress = ra;
		}

		~RuyiSDKContext()
		{
		}

		bool IsValid();
	};

	class RuyiSDK
	{
	private:
		boost::shared_ptr<TSocket> sharedLowTrans;
		boost::shared_ptr<TSocket> sharedHighTrans;

		RuyiSDKContext* context;
		SDK::SDKValidator::ValidatorServiceClient* validator;

	public:
		SDK::StorageLayer::StorageLayerServiceClient* Storage;
		SDK::BrainCloudApi::BrainCloudServiceClient* BCService;
		SDK::SettingSystem::Api::SettingSystemServiceClient* SettingSys;
		SDK::LocalizationService::LocalizationServiceClient* L10NService;
		SDK::UserServiceExternal::UserServExternalClient* UserService;

		SDK::SubscribeClient* Subscriber;

		//Ruyi::RuyiNetClient* RuyiNet;

	private:
		RuyiSDK();

		bool Init();
		bool ValidateVersion();
		std::string GetProductAndVersion();

		std::string SetAddress(std::string address);

	public:
		~RuyiSDK();

		static RuyiSDK* CreateSDKInstance(RuyiSDKContext& jsc);
	};
}

