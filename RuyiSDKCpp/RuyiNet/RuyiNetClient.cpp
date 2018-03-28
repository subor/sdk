
#include "RuyiNetClient.h"
#include "Service/RuyiNetCloudService.h"
#include "Service/RuyiNetFriendService.h"
#include "Service/RuyiNetLeaderboardService.h"
#include "Service/RuyiNetMatchmakingService.h"
#include "Service/RuyiNetPartyService.h"
#include "Service/RuyiNetProfileService.h"
#include "Service/RuyiNetUserFileService.h"
#include "Service/RuyiNetVideoService.h"
#include "Response/RuyiNetGetProfileResponse.h"

namespace Ruyi
{
	RuyiNetClient::RuyiNetClient(const boost::shared_ptr<TProtocol1> & protocol)
		: BCService(nullptr), mCloudService(nullptr), mFriendService(nullptr), mLeaderboardService(nullptr),
		mMatchmakingService(nullptr), mPartyService(nullptr), mProfileService(nullptr), 
		mVideoService(nullptr), mInitialised(false)
	{
		BCService = new SDK::BrainCloudApi::BrainCloudServiceClient(protocol);

		mCloudService = new RuyiNetCloudService(this);
		mFriendService = new RuyiNetFriendService(this);
		mLeaderboardService = new RuyiNetLeaderboardService(this);
		mMatchmakingService = new RuyiNetMatchmakingService(this);
		mPartyService = new RuyiNetPartyService(this);
		mProfileService = new RuyiNetProfileService(this);
		mUserFileService = new RuyiNetUserFileService(this);
		mVideoService = new RuyiNetVideoService(this);
	}

	RuyiNetClient::~RuyiNetClient()
	{
		delete mVideoService;
		mVideoService = nullptr;

		delete mUserFileService;
		mUserFileService = nullptr;

		delete mProfileService;
		mProfileService = nullptr;

		delete mPartyService;
		mPartyService = nullptr;

		delete mMatchmakingService;
		mMatchmakingService = nullptr;

		delete mLeaderboardService;
		mLeaderboardService = nullptr;

		delete mFriendService;
		mFriendService = nullptr;

		delete mCloudService;
		mCloudService = nullptr;

		if (BCService != nullptr)
		{
			for (int i = 0; i < MAX_PLAYERS; ++i)
			{
				if (mCurrentPlayers[i] != nullptr)
				{
					std::string jsonResponse;
					BCService->MatchMaking_DisableMatchMaking(jsonResponse, i);
					BCService->Identity_SwitchToParentProfile(jsonResponse, "RUYI", i);
				}
			}

			delete BCService;
			BCService = nullptr;
		}

		for (int i = 0; i < MAX_PLAYERS; ++i)
		{
			if (mCurrentPlayers[i] != nullptr)
			{
				delete mCurrentPlayers[i];
				mCurrentPlayers[i] = nullptr;
			}
		}
	}

	void RuyiNetClient::Initialise(const RuyiString & appId, const RuyiString & appSecret, const std::function<void()> & onInitialised)
	{
		if (mInitialised)
		{
			if (onInitialised != nullptr)
			{
				onInitialised();
			}

			return;
		}

		mAppId = appId;
		mAppSecret = appSecret;

		EnqueueTask<json>([&mCurrentPlayers = mCurrentPlayers, &BCService = BCService, &mAppId = mAppId, &mNewUser = mNewUser]() -> std::string
		{
			for (int i = 0; i < MAX_PLAYERS; ++i)
			{
				if (mCurrentPlayers[i] != nullptr)
				{
					delete mCurrentPlayers[i];
					mCurrentPlayers[i] = nullptr;
				}

				std::string jsonResponse;
				BCService->Identity_SwitchToSingletonChildProfile(jsonResponse, ToString(mAppId), true, i);
				SwitchToChildProfileResponse childProfile = json::parse(jsonResponse);
				if (childProfile.status != 200)
				{
					continue;
				}

				auto profileId = childProfile.data.parentProfileId;
				auto profileName = childProfile.data.playerName;

				mNewUser = childProfile.data.newUser;

				json payload = { "profileId", profileId };
				BCService->Script_RunParentScript(jsonResponse, "GetProfile", payload, "RUYI", i);

				RuyiNetGetProfileResponse profileData = json::parse(jsonResponse);
				if (profileData.status != 200 ||
					profileData.data.success == false)
				{
					continue;
				}

				mCurrentPlayers[i] = new RuyiNetProfile(profileData.data.response);
			}

			json response = { "status", 200 };
			return response;
		},
		[&mInitialised = mInitialised, &onInitialised](json response)
		{
			mInitialised = true;
			if (onInitialised != nullptr)
			{
				onInitialised();
			}
		});
	}

	void RuyiNetClient::Update()
	{
		mTaskQueue.Update();
	}
	
	void to_json(json & j, const RuyiNetClient::SwitchToChildProfileResponse & data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetClient::SwitchToChildProfileResponse & data)
	{
		data.data = j.at("data").get<RuyiNetClient::SwitchToChildProfileResponse::Data>();
		data.status = j.at("status").get<int>();
	}

	void to_json(json & j, const RuyiNetClient::SwitchToChildProfileResponse::Data & data)
	{
		j = json
		{
			{ "parentProfileId", data.parentProfileId },
			{ "playerName", data.playerName },
			{ "newUser", data.newUser }
		};
	}

	void from_json(const json & j, RuyiNetClient::SwitchToChildProfileResponse::Data & data)
	{
		data.parentProfileId = j.at("parentProfileId").get<std::string>();
		data.playerName = j.at("playerName").get<std::string>();
		data.newUser = j.at("newUser").get<bool>();
	}
}