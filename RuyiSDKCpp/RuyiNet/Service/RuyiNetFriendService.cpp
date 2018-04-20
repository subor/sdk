#include "RuyiNetFriendService.h"

namespace Ruyi
{
	RuyiNetFriendService::RuyiNetFriendService(RuyiNetClient * client)
		: RuyiNetService(client)
	{}

	void RuyiNetFriendService::AddFriend(int index, const std::string& profileId, RuyiNetAddRemoveFriendResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;

			payloadJson["profileId"] = profileId;

			std::string responseStr = RunParentScript(index, "AddFriend", payloadJson);
			nlohmann::json retJson = nlohmann::json::parse(responseStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetFriendService::RemoveFriend(int index, const std::string& profileId, RuyiNetAddRemoveFriendResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			payloadJson["profileId"] = profileId;
			std::string responseStr = RunParentScript(index, "RemoveFriend", payloadJson);
			nlohmann::json retJson = nlohmann::json::parse(responseStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetFriendService::ListFriends(int index, RuyiNetFriendListResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			std::string strResponse = RunParentScript(index, "ListFriends", payloadJson);
			nlohmann::json retJson = nlohmann::json::parse(strResponse);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetFriendService::GetProfile(int index, const std::string & profileId, RuyiNetGetProfileResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			payloadJson["profileId"] = profileId;
			std::string strResponse = RunParentScript(index, "GetProfile", payloadJson);
			nlohmann::json retJson = nlohmann::json::parse(strResponse);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
	
	void RuyiNetFriendService::GetProfiles(int index, const std::list<std::string>& profileIds, RuyiNetGetProfilesResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			
			payloadJson["profileId"] = profileIds;
			std::string strResponse = RunParentScript(index, "GetProfiles", payloadJson);
			nlohmann::json retJson = nlohmann::json::parse(strResponse);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
}