
#include <WinSock2.h>
#include <iphlpapi.h>
//#include <stdio.h>
//#include <stdlib.h>

#include "../RuyiNetException.h"
#include "RuyiNetMatchmakingService.h"

#define WORKING_BUFFER_SIZE 15000
#define MAX_TRIES 3

#define MALLOC(x) HeapAlloc(GetProcessHeap(), 0, (x))
#define FREE(x) HeapFree(GetProcessHeap(), 0, (x))

namespace Ruyi
{
	RuyiNetMatchmakingService::RuyiNetMatchmakingService(RuyiNetClient * client)
		: RuyiNetService(client)
	{
	}

	void RuyiNetMatchmakingService::EnableMatchmaking(int index, RuyiNetResponse& response)
	{
		PIP_ADAPTER_ADDRESSES pAddresses = NULL;
		try
		{

			auto player = mClient->GetPlayer(index);
			if (player == nullptr)
			{
				throw new RuyiNetException("Player is not signed in.");
			}

			ULONG outBufLen = WORKING_BUFFER_SIZE;
			ULONG family = AF_INET;	//	IPv4 only
			ULONG flags = GAA_FLAG_INCLUDE_PREFIX;
			ULONG Iterations = 0;
			DWORD dwRetVal = 0;

			do
			{
				pAddresses = (IP_ADAPTER_ADDRESSES *)MALLOC(outBufLen);
				if (pAddresses == NULL)
				{
					throw new RuyiNetException("Memory allocation failed for IP_ADAPTER_ADDRESSES struct\n");
				}

				dwRetVal = GetAdaptersAddresses(family, flags, NULL, pAddresses, &outBufLen);

				if (dwRetVal == ERROR_BUFFER_OVERFLOW)
				{
					FREE(pAddresses);
					pAddresses = NULL;
				}
				else
				{
					break;
				}

				Iterations++;
			} while ((dwRetVal == ERROR_BUFFER_OVERFLOW) && (Iterations < MAX_TRIES));

			PIP_ADAPTER_ADDRESSES adapter = NULL;
			std::string remoteIpAddress;
			for (adapter = pAddresses; NULL != adapter; adapter = adapter->Next)
			{
				// Skip loopback adapters
				if (IF_TYPE_SOFTWARE_LOOPBACK == adapter->IfType)
				{
					continue;
				}

				// Parse all IPv4 addresses
				for (
					IP_ADAPTER_UNICAST_ADDRESS* address = adapter->FirstUnicastAddress;
					NULL != address;
					address = address->Next)
				{
					auto family = address->Address.lpSockaddr->sa_family;
					if (AF_INET == family)
					{
						// IPv4
						SOCKADDR_IN* ipv4 = reinterpret_cast<SOCKADDR_IN*>(address->Address.lpSockaddr);
						char str_buffer[INET_ADDRSTRLEN] = { 0 };
						inet_ntop(AF_INET, &(ipv4->sin_addr), str_buffer, INET_ADDRSTRLEN);
						remoteIpAddress = str_buffer;
						break;
					}
					else
					{
						// Skip all other types of addresses
						continue;
					}
				}

				break;
			}

			if (pAddresses != NULL)
			{
				FREE(pAddresses);
				pAddresses = NULL;
			}

			nlohmann::json payloadJson;
			payloadJson["appId"] = mClient->GetAppId();
			payloadJson["remoteIpAddress"] = remoteIpAddress;
			payloadJson["port"] = "0";
			payloadJson["parentId"] = player->profileId;
			payloadJson["gender"] = player->summaryFriendData.gender;
			payloadJson["dob"] = player->summaryFriendData.dob;
			payloadJson["location"] = player->summaryFriendData.location;
			
			std::string payloadStr = payloadJson.dump();

			std::string retStr;
			mClient->GetBCService()->PlayerState_UpdateSummaryFriendData(retStr, payloadStr, index);
			mClient->GetBCService()->MatchMaking_EnableMatchMaking(retStr, index);
			nlohmann::json retJson = nlohmann::json::parse(retStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			if (pAddresses != NULL)
			{
				FREE(pAddresses);
				pAddresses = NULL;
			}
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			if (pAddresses != NULL)
			{
				FREE(pAddresses);
				pAddresses = NULL;
			}
			throw new RuyiNetException(e.what());
		} catch (RuyiNetException e)
		{
			if (pAddresses != NULL)
			{
				FREE(pAddresses);
				pAddresses = NULL;
			}
		}
	}

	void RuyiNetMatchmakingService::DisableMatchmaking(int index, RuyiNetResponse& response)
	{
		try
		{
			std::string retStr;
			mClient->GetBCService()->MatchMaking_DisableMatchMaking(retStr, index);
			nlohmann::json retJson = nlohmann::json::parse(retStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetMatchmakingService::SetPlayerRating(int index, long playerRating, RuyiNetResponse& response)
	{
		try
		{
			std::string retStr;
			mClient->GetBCService()->MatchMaking_SetPlayerRating(retStr, playerRating, index);
			nlohmann::json retJson = nlohmann::json::parse(retStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetMatchmakingService::IncrementPlayerRating(int index, long increment, RuyiNetResponse& response)
	{
		try
		{
			std::string retStr;
			mClient->GetBCService()->MatchMaking_IncrementPlayerRating(retStr, increment, index);
			nlohmann::json retJson = nlohmann::json::parse(retStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetMatchmakingService::DecrementPlayerRating(int index, long decrement, RuyiNetResponse& response)
	{
		try
		{
			std::string retStr;
			mClient->GetBCService()->MatchMaking_DecrementPlayerRating(retStr, decrement, index);
			nlohmann::json retJson = nlohmann::json::parse(retStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetMatchmakingService::ResetPlayerRating(int index, RuyiNetResponse& response)
	{
		try
		{
			std::string retStr;
			mClient->GetBCService()->MatchMaking_ResetPlayerRating(retStr, index);
			nlohmann::json retJson = nlohmann::json::parse(retStr);
			response.parseJson(retJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetMatchmakingService::FindPlayers(int index, long rangeDelta, long numMatches, RuyiNetFindPlayersResponse& response)
	{
		try
		{
			std::string retStr;
			mClient->GetBCService()->MatchMaking_FindPlayers(retStr, rangeDelta, numMatches, index);
			nlohmann::json retJson = nlohmann::json::parse(retStr);
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