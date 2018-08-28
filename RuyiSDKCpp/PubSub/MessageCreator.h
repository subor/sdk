#pragma once

#include "thrift/TBase.h"

#include "../Generated/InputManager/InputManagerSDKDataTypes_types.h"
#include "../Generated/StorageLayer/StorageLayerSDKDataTypes_types.h"
#include "../Generated/SettingSystem/SettingSystemSDKDataTypes_types.h"
#include "../Generated/BrainCloudService/BrainCloudServiceSDKDataTypes_types.h"
#include "../Generated/LocalizationService/LocalizationServiceSDKDataTypes_types.h"
#include "../Generated/UserServiceExternal/UserServiceExternalSDKDataTypes_types.h"
#include "../Generated/OverlayManager/OverlayManagerSDKDataTypes_types.h"
#include "../RuyiSDK.h"

using namespace std;
using namespace apache::thrift;

#ifndef REGIST_CREATION_FUNCTION

typedef TBase* (*MessageCreatorFunc)();

#define REGIST_CREATION_FUNCTION(msgName, msgType) \
	{\
		MessageCreatorFunc p = &CreateMessagePtr<msgType>; \
		ccs.insert(std::make_pair(msgName, p));\
	}

template<class T>
TBase* CreateMessagePtr()
{
	return dynamic_cast<TBase*>(new T());
}
#endif

namespace Ruyi
{
	class MessageCreator
	{
		friend class RuyiSDK;

	public:
		static TBase* CreateMessage(string mt)
		{
			std::map<string, MessageCreatorFunc>::iterator itr = ccs.find(mt);
			if (itr == ccs.end())
				return NULL;

			MessageCreatorFunc mcf = itr->second;
			return mcf();
		}

	private:
		static void Initialize();

		static std::map<string, MessageCreatorFunc> ccs;
	};
}
