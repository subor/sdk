#include "RuyiNetLeaderboardPage.h"

namespace Ruyi { namespace SDK { namespace Online {

	RuyiNetLeaderboardPage::RuyiNetLeaderboardPage() {}

	RuyiNetLeaderboardPage::RuyiNetLeaderboardPage(RuyiNetGetGlobalLeaderboardPageResponse::Data& data)
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

	RuyiNetLeaderboardPage::RuyiNetLeaderboardPage(RuyiNetGetGroupSocialLeaderboardResponse::Data& data)
	{
		std::for_each(data.leaderboard.begin(), data.leaderboard.end(), [&](RuyiNetGetGroupSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
		{
			Entries.push_back(new RuyiNetLeaderboardEntry(entry));
		});

		TimeBeforeReset = data.timeBeforeReset;
		ServerTime = data.server_time;
	}

	RuyiNetLeaderboardPage::RuyiNetLeaderboardPage(RuyiNetGetSocialLeaderboardResponse::Data& data)
	{
		std::for_each(data.social_leaderboard.begin(), data.social_leaderboard.end(), [&](RuyiNetGetSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
		{
			Entries.push_back(new RuyiNetLeaderboardEntry(entry));
		});

		TimeBeforeReset = data.timeBeforeReset;
		ServerTime = data.server_time;
	}

	void RuyiNetLeaderboardPage::GetData(RuyiNetGetGlobalLeaderboardPageResponse::Data& data)
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

	void RuyiNetLeaderboardPage::GetData(RuyiNetGetGroupSocialLeaderboardResponse::Data& data)
	{
		std::for_each(data.leaderboard.begin(), data.leaderboard.end(), [&](RuyiNetGetGroupSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
		{
			Entries.push_back(new RuyiNetLeaderboardEntry(entry));
		});

		TimeBeforeReset = data.timeBeforeReset;
		ServerTime = data.server_time;
	}

	void RuyiNetLeaderboardPage::GetData(RuyiNetGetSocialLeaderboardResponse::Data& data)
	{
		std::for_each(data.social_leaderboard.begin(), data.social_leaderboard.end(), [&](RuyiNetGetSocialLeaderboardResponse::Data::LeaderboardEntry& entry)
		{
			Entries.push_back(new RuyiNetLeaderboardEntry(entry));
		});

		TimeBeforeReset = data.timeBeforeReset;
		ServerTime = data.server_time;
	}

	std::vector<RuyiNetLeaderboardEntry*>& RuyiNetLeaderboardPage::GetEntries() { return Entries; }
	bool RuyiNetLeaderboardPage::GetMoreAfter() { return MoreAfter; }
	bool RuyiNetLeaderboardPage::GetMoreBefore() { return MoreBefore; }
	int RuyiNetLeaderboardPage::GetTimeBeforeReset() { return TimeBeforeReset; }
	long RuyiNetLeaderboardPage::GetServerTime() { return ServerTime; }

}}}