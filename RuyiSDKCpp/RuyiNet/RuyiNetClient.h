#pragma once

#include "../Generated/BrainCloudService/BrainCloudService.h"
#include "../RuyiString.h"
#include "Response/RuyiNetProfile.h"
#include "Task/RuyiNetPlatformTask.h"
#include "Task/RuyiNetTaskQueue.h"
#include "thrift/protocol/TMultiplexedProtocol.h"

using TProtocol1 = apache::thrift::protocol::TMultiplexedProtocol;

namespace Ruyi
{
	class RuyiNetCloudService;
	class RuyiNetFriendService;
	class RuyiNetLeaderboardService;
	class RuyiNetMatchmakingService;
	class RuyiNetPartyService;
	class RuyiNetProfileService;
	class RuyiNetUserFileService;
	class RuyiNetVideoService;

	class RuyiNetClient
	{
	public:
		RuyiNetClient(const boost::shared_ptr<TProtocol1> & protocol);
		~RuyiNetClient();

		void Initialise(const RuyiString & appId, const RuyiString & appSecret, const std::function<void()> & onInitialised);

		template<typename Data>
		void EnqueueTask(const RuyiNetTaskBase::ExecuteType & onExecute,
			const typename RuyiNetTask<Data>::CallbackType & callback);

		template<typename Data>
		void EnqueuePlatformTask(int index, const RuyiNetTaskBase::ExecuteType & onExecute,
			const typename RuyiNetTask<Data>::CallbackType & callback);

		void Update();

		const RuyiString & GetAppId() { return mAppId; }
		const RuyiString & GetAppSecret() { return mAppSecret; }
		const RuyiNetProfile * GetPlayer(int index) { return mCurrentPlayers[index]; }
		bool GetNewUser() { return mNewUser; }

		SDK::BrainCloudApi::BrainCloudServiceClient * const GetBCService() { return BCService; }
		RuyiNetCloudService * const GetCloudService() { return mCloudService; }
		RuyiNetFriendService * const GetFriendService() { return mFriendService; }
		RuyiNetLeaderboardService * const GetLeaderboardService() { return mLeaderboardService; }
		RuyiNetMatchmakingService * const GetMatchmakingService() { return mMatchmakingService; }
		RuyiNetPartyService * const GetPartyService() { return mPartyService; }
		RuyiNetUserFileService * const GetUserFileService() { return mUserFileService; }
		RuyiNetVideoService * const GetVideoService() { return mVideoService; }

		static const int MAX_PLAYERS = 4;

		struct SwitchToChildProfileResponse
		{
			struct Data
			{
				std::string parentProfileId;
				std::string playerName;
				bool newUser;
			};

			Data data;
			int status;
		};

	private:
		SDK::BrainCloudApi::BrainCloudServiceClient * BCService;
		RuyiNetCloudService * mCloudService;
		RuyiNetFriendService * mFriendService;
		RuyiNetLeaderboardService * mLeaderboardService;
		RuyiNetMatchmakingService * mMatchmakingService;
		RuyiNetPartyService * mPartyService;
		RuyiNetProfileService * mProfileService;
		RuyiNetUserFileService * mUserFileService;
		RuyiNetVideoService * mVideoService;
		RuyiNetProfile * mCurrentPlayers[MAX_PLAYERS];
		RuyiNetTaskQueue mTaskQueue;
		RuyiString mAppId;
		RuyiString mAppSecret;
		bool mInitialised;
		bool mNewUser;
	};

	template<typename Data>
	void RuyiNetClient::EnqueueTask(const RuyiNetTaskBase::ExecuteType & onExecute, 
		const typename RuyiNetTask<Data>::CallbackType & callback)
	{
		auto task = new RuyiNetTask<Data>(onExecute, callback);
		mTaskQueue.Enqueue(task);
	}

	template<typename Data>
	void RuyiNetClient::EnqueuePlatformTask(int index, const RuyiNetTaskBase::ExecuteType & onExecute, 
		const typename RuyiNetTask<Data>::CallbackType & callback)
	{
		auto task = new RuyiNetPlatformTask<Data>(index, BCService, ToString(mAppId), onExecute, callback);
		mTaskQueue.Enqueue(task);
	}

	void to_json(json & j, const RuyiNetClient::SwitchToChildProfileResponse & data);
	void from_json(const json & j, RuyiNetClient::SwitchToChildProfileResponse & data);
	void to_json(json & j, const RuyiNetClient::SwitchToChildProfileResponse::Data & data);
	void from_json(const json & j, RuyiNetClient::SwitchToChildProfileResponse::Data & data);
}