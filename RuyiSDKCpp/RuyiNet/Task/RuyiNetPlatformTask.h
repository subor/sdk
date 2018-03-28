#pragma once

#include "../../Generated/BrainCloudService/BrainCloudService.h"
#include "RuyiNetTask.h"

namespace Ruyi
{
	template<typename Data>
	class RuyiNetPlatformTask : public RuyiNetTask<Data>
	{
	public:
		RuyiNetPlatformTask(int index, SDK::BrainCloudApi::BrainCloudServiceClient * const BCService, std::string appId,
			ExecuteType onExecute, CallbackType onCallback);

		void Execute() override;

	private:
		SDK::BrainCloudApi::BrainCloudServiceClient * const mBCService;
		std::string mAppId;
		int mIndex;
	};

	template<typename Data>
	RuyiNetPlatformTask<Data>::RuyiNetPlatformTask(int index, SDK::BrainCloudApi::BrainCloudServiceClient * const BCService, std::string appId,
		ExecuteType onExecute, CallbackType onCallback)
		: RuyiNetTask(onExecute, onCallback), mBCService(BCService), mAppId(appId), mIndex(index)
	{}

	template<typename Data>
	void RuyiNetPlatformTask<Data>::Execute()
	{
		std::string response;
		mCompleted = false;
		mBCService->Identity_SwitchToParentProfile(response, "RUYI", mIndex);
		mResponse = mOnExecute();
		mBCService->Identity_SwitchToSingletonChildProfile(response, mAppId, false, mIndex);
		mCompleted = true;
	}
}