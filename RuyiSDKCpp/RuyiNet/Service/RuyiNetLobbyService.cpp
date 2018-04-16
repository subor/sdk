#include "RuyiNetLobbyService.h"

namespace Ruyi
{
	void RuyiNetLobbyService::CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType)
	{
		CreateLobby(index, maxSlots, lobbyType, "{}");
	}

	void RuyiNetLobbyService::CreateLobby(int index, int maxSlots, RuyiNetLobbyType lobbyType, std::string customAttributes)
	{
		nlohmann::json payloadJson;

		payloadJson["appId"] = mClient->GetAppId();
		payloadJson["maxSlots"] = maxSlots;
		payloadJson["ranked"] = (lobbyType == RuyiNetLobbyType::RANKED);
		payloadJson["customAttributes"] = customAttributes;

		std::string responseStr = RunParentScript(index, "Lobby_Create", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		RuyiNetLobbyResponse response;
		response.parseJson(retJson);

		InitLobby(response.data.response);
	}

	void RuyiNetLobbyService::CloseLobby(int index, std::string lobbyId, RuyiNetResponse& response)
	{
		DeleteLobby();

		nlohmann::json payloadJson;

		payloadJson["applobbyIdId"] = lobbyId;

		std::string responseStr = RunParentScript(index, "Lobby_Close", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetLobbyService::FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, std::list<RuyiNetLobby*>& lobbyList)
	{
		FindLobbies(index, numResults, lobbyType, 0, lobbyList);
	}

	void RuyiNetLobbyService::FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, std::list<RuyiNetLobby*>& lobbyList)
	{
		FindLobbies(index, numResults, lobbyType, freeSlots, "{}", lobbyList);
	}

	void RuyiNetLobbyService::FindLobbies(int index, int numResults, RuyiNetLobbyType lobbyType, int freeSlots, std::string searchCriteria, std::list<RuyiNetLobby*>& lobbyList)
	{
		nlohmann::json payloadJson;

		payloadJson["appId"] = mClient->GetAppId();
		payloadJson["numResults"] = numResults;
		payloadJson["freeSlots"] = freeSlots;
		payloadJson["ranked"] = (lobbyType == RuyiNetLobbyType::RANKED);
		payloadJson["searchCriteria"] = searchCriteria;

		std::string responseStr = RunParentScript(index, "Lobby_Find", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		RuyiNetLobbyFindResponse response;
		response.parseJson(retJson);

		std::for_each(response.data.response.results.items.begin(), response.data.response.results.items.end(), [&](RuyiNetResponseGroup& groupResponse) 
		{
			RuyiNetLobby* pLobby = new RuyiNetLobby(groupResponse);
			lobbyList.push_back(pLobby);
		});	
	}

	void RuyiNetLobbyService::JoinLobby(int index, std::string lobbyId)
	{
		nlohmann::json payloadJson;

		payloadJson["lobbyId"] = lobbyId;

		std::string responseStr = RunParentScript(index, "Lobby_Join", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		RuyiNetLobbyResponse response;
		response.parseJson(retJson);

		InitLobby(response.data.response);
	}

	void RuyiNetLobbyService::LeaveLobby(int index, std::string lobbyId, RuyiNetResponse& response)
	{
		nlohmann::json payloadJson;

		payloadJson["lobbyId"] = lobbyId;

		std::string responseStr = RunParentScript(index, "Lobby_Leave", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetLobbyService::StartGame(int index, std::string lobbyId, std::string connectionString, RuyiNetResponse& response)
	{
		nlohmann::json payloadJson;

		payloadJson["lobbyId"] = lobbyId;
		payloadJson["connectionString"] = connectionString;

		std::string responseStr = RunParentScript(index, "Lobby_StartGame", payloadJson);
		nlohmann::json retJson = nlohmann::json::parse(responseStr);
		response.parseJson(retJson);
	}

	void RuyiNetLobbyService::UpdateLobby()
	{
		if (nullptr != mCurrentLobby)
		{
			nlohmann::json payloadJson;

			payloadJson["lobbyId"] = mCurrentLobby->GetLobbyId();

			std::string responseStr = RunParentScript(mClient->ActivePlayerIndex(), "Lobby_Update", payloadJson);
			nlohmann::json retJson = nlohmann::json::parse(responseStr);
			RuyiNetLobbyResponse response;
			response.parseJson(retJson);

			RuyiNetLobby* pUpdatedLobby = new RuyiNetLobby(response.data.response);
			if (nullptr != pUpdatedLobby)
			{
				std::list<std::string> newPlayers; //in UpdatedLobby but not in CurrentLobby
				std::list<std::string> leftPlayers; //in currentLobby but not in UpdatedLobby which means they've left

				bool lobbyClosed = (0 != mCurrentLobby->GetState().compare("CLOSED")) && (0 == pUpdatedLobby->GetState().compare("CLOSED"));
				bool lobbyStarted = (0 != mCurrentLobby->GetState().compare("STARTED")) && (0 == pUpdatedLobby->GetState().compare("STARTED"));
				std::list<const std::string*>& updatedMemberIds = (std::list<const std::string*>&)pUpdatedLobby->GetMemberProfileIds();
				std::list<const std::string*>& currentMemberIds = (std::list<const std::string*>&)mCurrentLobby->GetMemberProfileIds();
				std::list<const std::string*>::iterator it_update;
				std::list<const std::string*>::iterator it_current;

				//find new players which are not in currentMemberIds but in updatedMemberIds
				for (it_update = updatedMemberIds.begin(); it_update != updatedMemberIds.end(); ++it_update)
				{
					bool isNew = true;

					for (it_current = currentMemberIds.begin(); it_current != currentMemberIds.end(); ++it_current)
					{
						if (0 == (*it_update)->compare(**it_current)) 
						{
							isNew = false;
							break;
						}
					}

					if (isNew)
					{
						newPlayers.push_back(**it_update);
					}
				}
				
				//find left players which are not in updatedMemberIds but in currentMemberIds
				for (it_current = currentMemberIds.begin(); it_current != currentMemberIds.end(); ++it_current)
				{
					bool isOld = true;

					for (it_update = updatedMemberIds.begin(); it_update != updatedMemberIds.end(); ++it_update)
					{
						if (0 == (*it_current)->compare(**it_update))
						{
							isOld = false;
							break;
						}
					}

					if (isOld)
					{
						leftPlayers.push_back(**it_current);
					}
				}

				for (std::list<std::string>::iterator it = newPlayers.begin(); it != newPlayers.end(); ++it)
				{
				
				}
			}
		}
	}

	void RuyiNetLobbyService::InitLobby(RuyiNetResponseGroup& response)
	{
		DeleteLobby();

		mCurrentLobby = new RuyiNetLobby(response);
	}

	void RuyiNetLobbyService::DeleteLobby()
	{
		if (nullptr != mCurrentLobby)
		{
			delete mCurrentLobby;
			mCurrentLobby = nullptr;
		}
	}
}