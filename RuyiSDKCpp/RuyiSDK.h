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
#include "Generated/BrainCloudService/BrainCloudServiceSDKDataTypes_types.h"
#include "Generated/LocalizationService/LocalizationServiceSDKDataTypes_types.h"
#include "Generated/UserServiceExternal/UserServiceExternalSDKDataTypes_types.h"

#include "PubSub/SubscribeClient.h"

#include "RuyiNet/RuyiNetClient.h"

using namespace apache::thrift::transport;
using namespace apache::thrift::protocol;

namespace Ruyi
{
	/// <summary>
	/// context used to create RuyiSDK instance
	/// </summary>
	class RuyiSDKContext
	{
		friend class RuyiSDK;

	public:
		/// <summary>
		/// from which endpoint the SDK is running.
		/// </summary>
		enum Endpoint
		{
			/// <summary>
			/// default to notset
			/// </summary>
			Notset,
			/// <summary>
			/// running from console
			/// </summary>
			Console,
			/// <summary>
			/// running from mobile
			/// </summary>
			Mobile,
			/// <summary>
			/// running from pc
			/// </summary>
			PC,
			/// <summary>
			/// running from web
			/// </summary>
			Web,
		};

	private:
		/// <summary>
		/// set the running end point
		/// </summary>
		Endpoint endpoint;

		/// <summary>
		/// remote address of layer0
		/// </summary>
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
		std::shared_ptr<TSocket> sharedLowTrans;
		std::shared_ptr<TSocket> sharedHighTrans;

		RuyiSDKContext* context;
		SDK::SDKValidator::ValidatorServiceClient* validator;

	public:
		/// <summary>
		/// to access the ruyi platform storage interface
		/// </summary>
		SDK::StorageLayer::StorageLayerServiceClient* Storage;
		/// <summary>
		/// to access the setting system
		/// </summary>
		SDK::SettingSystem::Api::SettingSystemServiceClient* SettingSys;

		/// <summary>
		/// to access the l10n service from Ruyi
		/// </summary>
		SDK::LocalizationService::LocalizationServiceClient* L10NService;

		/// <summary>
		/// User-related services
		/// </summary>
		SDK::UserServiceExternal::UserServExternalClient* UserService;
		
		/// <summary>
		/// to subscribe to a topic
		/// </summary>
		SDK::SubscribeClient* Subscriber;

		/// <summary>
		/// to access the ruyi platform back end service interface
		/// </summary>
		Ruyi::RuyiNetClient* RuyiNet;

		__declspec(deprecated("Use RuyiNet instead, BCService is deprecated and will be removed in future release"))
		SDK::BrainCloudApi::BrainCloudServiceClient* BCService;

	private:
		RuyiSDK();

		bool Init();
		bool ValidateVersion();
		std::string GetProductAndVersion();

		std::string SetAddress(std::string address);

	public:
		~RuyiSDK();

		/// <summary>
		/// Create a new SDK instance with the given context.
		/// </summary>
		/// <param name="cont">context used to create the sdk instance</param>
		/// <returns>the created instance, null if context is not valid</returns>
		static RuyiSDK* CreateSDKInstance(RuyiSDKContext& jsc);
	};
}

