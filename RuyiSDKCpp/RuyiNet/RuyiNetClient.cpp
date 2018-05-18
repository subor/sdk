
#include "RuyiNetClient.h"
#include "Service/RuyiNetCloudService.h"
#include "Service/RuyiNetFriendService.h"
#include "Service/RuyiNetLeaderboardService.h"
#include "Service/RuyiNetPartyService.h"
#include "Service/RuyiNetProfileService.h"
#include "Service/RuyiNetUserFileService.h"
#include "Service/RuyiNetVideoService.h"
#include "Service/RuyiNetMatchmakingService.h"
#include "Service/RuyiNetLobbyService.h"
#include "Service/RuyiNetTelemetryService.h"

#include "Response/RuyiNetGetProfileResponse.h"
#include "Response/RuyiNetProfile.h"

namespace Ruyi
{
	

	RuyiNetClient::RuyiNetClient(const boost::shared_ptr<TProtocol1> & protocol)
		: BCService(nullptr), mCloudService(nullptr), mFriendService(nullptr), mLeaderboardService(nullptr),
		mPartyService(nullptr), mProfileService(nullptr), 
		mVideoService(nullptr), mMatchmakingService(nullptr), mLobbyService(nullptr), mTelemetryService(nullptr), mInitialised(false)
	{
		BCService = new SDK::BrainCloudApi::BrainCloudServiceClient(protocol);

		mCloudService = new RuyiNetCloudService(this);
		mFriendService = new RuyiNetFriendService(this);
		mLeaderboardService = new RuyiNetLeaderboardService(this);
		mPartyService = new RuyiNetPartyService(this);
		mProfileService = new RuyiNetProfileService(this);
		mUserFileService = new RuyiNetUserFileService(this);
		mVideoService = new RuyiNetVideoService(this);
		mMatchmakingService = new RuyiNetMatchmakingService(this);
		mLobbyService = new RuyiNetLobbyService(this);
		mTelemetryService = new RuyiNetTelemetryService(this);

		for (int i = 0; i < MAX_PLAYERS; ++i)
		{ 
			mCurrentPlayers[i] = nullptr;
		}
	}

	RuyiNetClient::~RuyiNetClient()
	{
		ExitAccount();

		delete mTelemetryService;
		mTelemetryService = nullptr;

		delete mLobbyService;
		mLobbyService = nullptr;

		delete mMatchmakingService;
		mMatchmakingService = nullptr;

		delete mVideoService;
		mVideoService = nullptr;

		delete mUserFileService;
		mUserFileService = nullptr;

		delete mProfileService;
		mProfileService = nullptr;

		delete mPartyService;
		mPartyService = nullptr;

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

	void RuyiNetClient::Initialise(const std::string& appId, const std::string& appSecret)
	{
		mAppId = appId;
		mAppSecret = appSecret;
		try 
		{
			for (int i = 0; i < MAX_PLAYERS; ++i)
			{
				std::string jsonResponse;
				BCService->Identity_SwitchToSingletonChildProfile(jsonResponse, mAppId, true, i);

				auto retJson = nlohmann::json::parse(jsonResponse);

				SwitchToChildProfileResponse childProfile;
				childProfile.parseJson(retJson);

				if (STATUS_OK != childProfile.status)
				{
					continue;
				}

				nlohmann::json payloadJson;
				payloadJson["profileId"] = childProfile.data.parentProfileId;
				std::string scriptData = payloadJson.dump();
				BCService->Script_RunParentScript(jsonResponse, "GetProfile", scriptData, "RUYI", i);

				RuyiNetGetProfileResponse profileData;
				retJson = nlohmann::json::parse(jsonResponse);
				profileData.parseJson(retJson);
				if (profileData.status != 200 || profileData.data.success == false)
				{
					continue;
				}

				mCurrentPlayers[i] = new RuyiNetProfile(profileData.data.response);
			}
		} catch(std::exception e)
		{
			throw e;
		}
	}

	void RuyiNetClient::ExitAccount()
	{
		for (int i = 0; i < MAX_PLAYERS; ++i)
		{
			if (nullptr != mCurrentPlayers[i])
			{
				std::string response;
				BCService->Script_RunParentScript(response, "RUYI_Cleanup", "", "RUYI", i);
				BCService->Identity_SwitchToParentProfile(response, "RUYI", i);
			}
		}
	}

	int RuyiNetClient::ActivePlayerIndex()
	{
		for (int i = 0; i < MAX_PLAYERS; ++i)
		{
			if (nullptr != mCurrentPlayers[i])
				return i;
		}

		return 0;
	}

}