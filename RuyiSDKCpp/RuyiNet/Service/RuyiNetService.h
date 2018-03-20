#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi
{
	class RuyiNetService
	{
	protected:
		RuyiNetService(RuyiNetClient * client);

		template<typename Data>
		void EnqueueTask(const RuyiNetTaskBase::ExecuteType & onExecute,
			const typename RuyiNetTask<Data>::CallbackType & callback)
		{
			mClient->EnqueueTask<Data>(onExecute, callback);
		}

		template<typename Data>
		void EnqueuePlatformTask(int index, const RuyiNetTaskBase::ExecuteType & onExecute,
			const typename RuyiNetTask<Data>::CallbackType & callback)
		{
			mClient->EnqueuePlatformTask<Data>(index, onExecute, callback);
		}

		std::string RunParentScript(int index, const std::string & scriptName, json payload);

		RuyiNetClient * mClient;
	};
}