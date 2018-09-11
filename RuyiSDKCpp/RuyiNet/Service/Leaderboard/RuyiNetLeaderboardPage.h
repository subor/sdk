#pragma once

#include "Response/RuyiNetGetGlobalLeaderboardPageResponse.h"
#include "Response/RuyiNetGetGroupSocialLeaderboardResponse.h"
#include "Response/RuyiNetGetSocialLeaderboardResponse.h"
#include "RuyiNetLeaderboardEntry.h"

namespace Ruyi { namespace SDK { namespace Online {

	class RuyiNetLeaderboardEntry;

	/// <summary>
	/// Represents a single page retrieved from a leaderboard.
	/// </summary>
	class RuyiNetLeaderboardPage 
	{
	public:
		RuyiNetLeaderboardPage();

		RuyiNetLeaderboardPage(RuyiNetGetGlobalLeaderboardPageResponse::Data& data);

		RuyiNetLeaderboardPage(RuyiNetGetGroupSocialLeaderboardResponse::Data& data);

		RuyiNetLeaderboardPage(RuyiNetGetSocialLeaderboardResponse::Data& data);
		
		void GetData(RuyiNetGetGlobalLeaderboardPageResponse::Data& data);

		void GetData(RuyiNetGetGroupSocialLeaderboardResponse::Data& data);

		void GetData(RuyiNetGetSocialLeaderboardResponse::Data& data);

		std::vector<RuyiNetLeaderboardEntry*>& GetEntries();
		bool GetMoreAfter();
		bool GetMoreBefore();
		int GetTimeBeforeReset();
		long GetServerTime();

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