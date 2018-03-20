
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

	void RuyiNetMatchmakingService::EnableMatchmaking(int index, const RuyiNetTask<json>::CallbackType & callback)
	{
		EnqueueTask<json>([this, &index]() -> std::string
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

				json attributes = 
				{
					{ "appId", mClient->GetAppId() },
					{ "remoteIpAddress", remoteIpAddress },
					{ "port", "0" },
					{ "parentId", player->profileId },
					{ "gender", player->summaryFriendData.gender },
					{ "dob", player->summaryFriendData.dob },
					{ "location", player->summaryFriendData.location }
				};

				std::string response;
				mClient->GetBCService()->PlayerState_UpdateSummaryFriendData(response, attributes, index);
				mClient->GetBCService()->MatchMaking_EnableMatchMaking(response, index);
				return response;
			}
			catch (RuyiNetException e)
			{
				if (pAddresses != NULL)
				{
					FREE(pAddresses);
					pAddresses = NULL;
				}

				json response =
				{
					{ "status", 500 },
					{ "message", e.what() }
				};

				return response;
			}
		}, callback);
	}

	void RuyiNetMatchmakingService::DisableMatchmaking(int index, const RuyiNetTask<json>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<json>([&BCService, &index]() -> std::string
		{
			std::string response;
			BCService->MatchMaking_DisableMatchMaking(response, index);
			return response;
		}, callback);
	}

	void RuyiNetMatchmakingService::SetPlayerRating(int index, long playerRating, const RuyiNetTask<json>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<json>([&BCService, &index, &playerRating]() -> std::string
		{
			std::string response;
			BCService->MatchMaking_SetPlayerRating(response, playerRating, index);
			return response;
		}, callback);
	}

	void RuyiNetMatchmakingService::IncrementPlayerRating(int index, long increment, const RuyiNetTask<json>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<json>([&BCService, &index, &increment]() -> std::string
		{
			std::string response;
			BCService->MatchMaking_IncrementPlayerRating(response, increment, index);
			return response;
		}, callback);
	}

	void RuyiNetMatchmakingService::DecrementPlayerRating(int index, long decrement, const RuyiNetTask<json>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<json>([&BCService, &index, &decrement]() -> std::string
		{
			std::string response;
			BCService->MatchMaking_DecrementPlayerRating(response, decrement, index);
			return response;
		}, callback);
	}

	void RuyiNetMatchmakingService::ResetPlayerRating(int index, const RuyiNetTask<json>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<json>([&BCService, &index]() -> std::string
		{
			std::string response;
			BCService->MatchMaking_ResetPlayerRating(response, index);
			return response;
		}, callback);
	}

	void RuyiNetMatchmakingService::FindPlayers(int index, long rangeDelta, long numMatches,
		const RuyiNetTask<RuyiNetFindPlayersResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<json>([&BCService, &index, &rangeDelta, &numMatches]() -> std::string
		{
			std::string response;
			BCService->MatchMaking_FindPlayers(response, rangeDelta, numMatches, index);
			return response;
		}, callback);
	}
}