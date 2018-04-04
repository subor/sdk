#include "RuyiNetPartyService.h"

namespace Ruyi
{
	RuyiNetPartyService::RuyiNetPartyService(RuyiNetClient * client)
		:RuyiNetService(client)
	{
	}
	
	void RuyiNetPartyService::GetPartyInfo(int index, RuyiNetGetPartyInfoResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			std::string strResponse = RunParentScript(index, "GetPartyInfo", payloadJson);
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

	void RuyiNetPartyService::GetPartyMembersInfo(int index, RuyiNetGetProfilesResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			std::string strResponse = RunParentScript(index, "GetPartyMembers", payloadJson);
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
	
	void RuyiNetPartyService::SendPartyInvitation(int index, const std::string& profileId, RuyiNetResponse& response)
	{
		try 
		{
			nlohmann::json payloadJson;
			payloadJson["profileId"] = profileId;
			std::string strResponse = RunParentScript(index, "SendPartyInvitation", payloadJson);
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
	
	void RuyiNetPartyService::AcceptPartyInvitation(int index, const std::string& groupId, RuyiNetResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			payloadJson["groupId"] = groupId;
			std::string strResponse = RunParentScript(index, "AcceptPartyInvitation", payloadJson);
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
	
	void RuyiNetPartyService::RejectPartyInvitation(int index, const std::string& groupId, RuyiNetResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			payloadJson["groupId"] = groupId;
			std::string strResponse = RunParentScript(index, "RejectPartyInvitation", payloadJson);
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
	
	void RuyiNetPartyService::JoinParty(int index, const std::string& groupId, RuyiNetResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			payloadJson["groupId"] = groupId;
			std::string strResponse = RunParentScript(index, "JoinParty", payloadJson);
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
	
	void RuyiNetPartyService::LeaveParty(int index, const std::string& groupId, RuyiNetResponse& response)
	{
		try
		{
			nlohmann::json payloadJson;
			payloadJson["groupId"] = groupId;
			std::string strResponse = RunParentScript(index, "LeaveParty", payloadJson);
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