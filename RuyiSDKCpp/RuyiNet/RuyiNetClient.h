#pragma once

#include "../Generated/BrainCloudService/BrainCloudService.h"
#include "../RuyiString.h"
#include "RuyiNetException.h"

#include "thrift/protocol/TMultiplexedProtocol.h"
#include "boost/container/detail/json.hpp"

using TProtocol1 = apache::thrift::protocol::TMultiplexedProtocol;

namespace Ruyi
{
	#define STATUS_OK 200
	
	class RuyiNetCloudService;
	class RuyiNetFriendService;
	class RuyiNetLeaderboardService;
	class RuyiNetPartyService;
	class RuyiNetProfileService;
	class RuyiNetUserFileService;
	class RuyiNetVideoService;
	class RuyiNetMatchmakingService;
	class RuyiNetLobbyService;
	class RuyiNetTelemetryService;

	class RuyiNetClient
	{
	public:
		RuyiNetClient(const boost::shared_ptr<TProtocol1> & protocol);
		~RuyiNetClient();

		/// <summary>
		/// Initialise the RUYI net client and switch to the game context.
		/// </summary>
		/// <param name="appId">The App ID of the game to initialise for.</param>
		/// <param name="appSecret">The App secret of the game. NOTE: This is a password and should be treated as such.</param>
		void Initialise(const std::string& appId, const std::string& appSecret);
		
		/**
		* return appId of the game
		*/
		const std::string & GetAppId() { return mAppId; }
		
		/** 
		* return appSecret of the game
		*/
		const std::string & GetAppSecret() { return mAppSecret; }

		/**
		* return pointer of player profile data by index
		* 
		* @param index range from 0~3, if the player profile doesn't exit,
		* it'll return nullptr, please check safety before using the pointer
		* if index is not inside 0~3, it'll return 0 index player profile
		*/
		const struct RuyiNetProfile* GetPlayer(int index) 
		{ 
			if (index < 0 || index > 3) index = 0;
			return mCurrentPlayers[index]; 
		}

		/// <summary>
		/// Returns the index of the first active player available.
		/// </summary>
		int ActivePlayerIndex();

		SDK::BrainCloudApi::BrainCloudServiceClient * const GetBCService() { return BCService; }
		/// <summary>
		/// Handles backing up data to the cloud.
		/// </summary>
		RuyiNetCloudService* const GetCloudService() { return mCloudService; }
		/// <summary>
		/// Provides operations for managing Friend Lists.
		/// </summary>
		RuyiNetFriendService* const GetFriendService() { return mFriendService; }
		/// <summary>
		/// Provides operations to retrieve leaderboard data and submit scores.
		/// </summary>
		RuyiNetLeaderboardService* const GetLeaderboardService() { return mLeaderboardService; }
		/// <summary>
		/// Allows players to gather together in a party.
		/// </summary>
		RuyiNetPartyService* const GetPartyService() { return mPartyService; }
		/// <summary>
		/// Allows users to upload files to their individual accounts
		/// </summary>
		RuyiNetUserFileService* const GetUserFileService() { return mUserFileService; }
		/// <summary>
		/// Allows users to upload videos to their individual accounts.
		/// </summary>
		RuyiNetVideoService* const GetVideoService() { return mVideoService; }
		/// <summary>
		/// Allows users to locate players to play against each other.
		/// </summary>
		RuyiNetMatchmakingService* const GetMatchmakingService() { return mMatchmakingService; }
		/// <summary>
		/// Manages lobbies for network games.
		/// </summary>
		RuyiNetLobbyService* const GetLobbyService() { return mLobbyService; }
		/// <summary>
		/// Handles pushing telemetry data to the cloud.
		/// </summary>
		RuyiNetTelemetryService* const GetTelemetryService() { return mTelemetryService; }

		static const int MAX_PLAYERS = 4;

		struct SwitchToChildProfileResponse
		{
			struct Data
			{
				std::string parentProfileId;
				std::string playerName;
				//bool newUser; //no param in return json
			};

			Data data;
			int status;

			void parseJson(nlohmann::json& j)
			{
				if (!j["status"].is_null())
				{
					status = j["status"];
				}
				if (!j["data"].is_null())
				{
					nlohmann::json dataJson = j["data"];
					if (!dataJson["parentProfileId"].is_null()) 
					{
						data.parentProfileId = dataJson["parentProfileId"];
					}
					if (!dataJson["playerName"].is_null()) 
					{
						data.playerName = dataJson["playerName"];
					}
				}
			}
		};

	private:
		SDK::BrainCloudApi::BrainCloudServiceClient* BCService;
		RuyiNetCloudService* mCloudService;
		RuyiNetFriendService* mFriendService;
		RuyiNetLeaderboardService* mLeaderboardService;
		RuyiNetPartyService* mPartyService;
		RuyiNetProfileService* mProfileService;
		RuyiNetUserFileService* mUserFileService;
		RuyiNetVideoService* mVideoService;
		RuyiNetMatchmakingService* mMatchmakingService;
		RuyiNetLobbyService* mLobbyService;
		RuyiNetTelemetryService* mTelemetryService;

		struct RuyiNetProfile* mCurrentPlayers[MAX_PLAYERS];

		std::string mAppId;
		std::string mAppSecret;
		bool mInitialised;
	};
}