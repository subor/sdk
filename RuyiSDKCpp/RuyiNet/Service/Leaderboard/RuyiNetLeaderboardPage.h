#pragma once

#include "Response/RuyiNetGetGlobalLeaderboardPageResponse.h"
#include "Response/RuyiNetGetGroupSocialLeaderboardResponse.h"
#include "Response/RuyiNetGetSocialLeaderboardResponse.h"
#include "RuyiNetLeaderboardEntry.h"

namespace Ruyi { namespace SDK { namespace Online {

	/// <summary>
	/// Represents a single page retrieved from a leaderboard.
	/// </summary>
	class RuyiNetLeaderboardPage 
	{
	public:
		RuyiNetLeaderboardPage(){}

		RuyiNetLeaderboardPage(RuyiNetGetGlobalLeaderboardPageResponse::Data& data)
		{			
			std::for_each(data.leaderboard.begin(), data.leaderboard.end(), [&](RuyiNetGetGlobalLeaderboardPageResponse::Data::LeaderboardEntry& entry)
			{
				Entries.push_back(new RuyiNetLeaderboardEntry(entry));
			});

			MoreAfter = data.moreAfter;
			MoreBefore = data.moreBefore;
			TimeBeforeReset = data.timeBeforeReset;
			ServerTime = data.server_time;
		}

		RuyiNetLeaderboardPage(RuyiNetGetGroupSocialLeaderboardResponse::Data& data)
		{			
			std::for_each(data.leaderboard.begin(), data.leaderboard.end(), [&](RuyiNetGetGroupSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
			{
				Entries.push_back(new RuyiNetLeaderboardEntry(entry));
			});

			TimeBeforeReset = data.timeBeforeReset;
			ServerTime = data.server_time;
		}

		RuyiNetLeaderboardPage(RuyiNetGetSocialLeaderboardResponse::Data& data)
		{
			std::for_each(data.social_leaderboard.begin(), data.social_leaderboard.end(), [&](RuyiNetGetSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
			{
				Entries.push_back(new RuyiNetLeaderboardEntry(entry));
			});

			TimeBeforeReset = data.timeBeforeReset;
			ServerTime = data.server_time;
		}
		
		void GetData(RuyiNetGetGlobalLeaderboardPageResponse::Data& data)
		{
			std::for_each(data.leaderboard.begin(), data.leaderboard.end(), [&](RuyiNetGetGlobalLeaderboardPageResponse::Data::LeaderboardEntry& entry)
			{
				Entries.push_back(new RuyiNetLeaderboardEntry(entry));
			});

			MoreAfter = data.moreAfter;
			MoreBefore = data.moreBefore;
			TimeBeforeReset = data.timeBeforeReset;
			ServerTime = data.server_time;
		}

		void GetData(RuyiNetGetGroupSocialLeaderboardResponse::Data& data)
		{
			std::for_each(data.leaderboard.begin(), data.leaderboard.end(), [&](RuyiNetGetGroupSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
			{
				Entries.push_back(new RuyiNetLeaderboardEntry(entry));
			});

			TimeBeforeReset = data.timeBeforeReset;
			ServerTime = data.server_time;
		}

		void GetData(RuyiNetGetSocialLeaderboardResponse::Data& data)
		{
			std::for_each(data.social_leaderboard.begin(), data.social_leaderboard.end(), [&](RuyiNetGetSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
			{
				Entries.push_back(new RuyiNetLeaderboardEntry(entry));
			});

			TimeBeforeReset = data.timeBeforeReset;
			ServerTime = data.server_time;
		}

		std::vector<RuyiNetLeaderboardEntry*>& GetEntries() { return Entries; }
		bool GetMoreAfter() { return MoreAfter; }
		bool GetMoreBefore() { return MoreBefore; }
		int GetTimeBeforeReset() { return TimeBeforeReset; }
		long GetServerTime() { return ServerTime; }

		///<summary>
		/// Rescord status of response
		///</summary>
		int Status;

	private:
		/// <summary>
		/// The list of entries for this leaderboard page.
		/// </summary>
		std::vector<RuyiNetLeaderboardEntry*> Entries;

		/// <summary>
		/// True if there are more entries after this page.
		/// </summary>
		bool MoreAfter;

		/// <summary>
		/// True if there are more entries before this page.
		/// </summary>
		bool MoreBefore;

		/// <summary>
		/// How long before the next time this leaderboard is reset.
		/// </summary>
		int TimeBeforeReset;

		/// <summary>
		/// The server time when this leaderboard was retrieved (UNIX timestamp).
		/// </summary>
		long ServerTime;
	};
}}}