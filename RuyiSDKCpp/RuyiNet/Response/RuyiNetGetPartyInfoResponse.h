#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// The response when getting party information.
	/// </summary>
	struct RuyiNetGetPartyInfoResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The response.
			/// </summary>
			struct Response
			{
				/// <summary>
				/// Information on a group.
				/// </summary>
				struct Group
				{
					/// <summary>
					/// The type of this group (should be "PARTY")
					/// </summary>
					std::string groupType;

					/// <summary>
					/// The ID of the group.
					/// </summary>
					std::string groupId;
					
					/// <summary>
					/// Whether or not the group is open.
					/// </summary>
					bool isOpenGroup;

					/// <summary>
					/// Number of players requesting membership.
					/// </summary>
					int requestingPendingMemberCount;

					/// <summary>
					/// Number of players invited to the group.
					/// </summary>
					int invitedPendingMemberCount;

					/// <summary>
					/// The profile ID of the owner
					/// </summary>
					std::string ownerId;

					/// <summary>
					/// The name of the group (should be the owner's username)
					/// </summary>
					std::string name;

					/// <summary>
					/// Number of people in the group.
					/// </summary>
					int memberCount;
				};
				
				/// <summary>
				/// Groups the player has requested membership of.
				/// </summary>
				std::list<Group> requested;

				/// <summary>
				/// Groups the player has been invited to.
				/// </summary>
				std::list<Group> invited;

				/// <summary>
				/// Groups the player is a member of.
				/// </summary>
				std::list<Group> groups;
			};

			/// <summary>
			/// The response.
			/// </summary>
			Response response;

			/// <summary>
			/// Whether or not the server-side script ran successfully.
			/// </summary>
			bool success;
		};
		
		/// <summary>
		/// The response data.
		/// </summary>
		Data data;

		/// <summary>
		/// The status of the response.
		/// </summary>
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

				if (!dataJson.is_object()) return;

				if (!dataJson["success"].is_null())
				{
					data.success = dataJson["success"];
				}

				if (!dataJson["response"].is_null())
				{
					nlohmann::json responseJson = dataJson["response"];

					if (!responseJson.is_object()) return;
					
					if (!responseJson["requested"].is_null())
					{
						nlohmann::json requestedJson = responseJson["requested"];
						parseGroup(requestedJson, data.response.requested);
					}

					if (!responseJson["invited"].is_null())
					{
						nlohmann::json invitedJson = responseJson["invited"];
						parseGroup(invitedJson, data.response.invited);
					}

					if (!responseJson["groups"].is_null())
					{
						nlohmann::json groupsJson = responseJson["groups"];
						parseGroup(groupsJson, data.response.groups);
					}
				}
			}
		}

		void parseGroup(nlohmann::json& groupJ, std::list<Data::Response::Group>& groupList)
		{
			if (groupJ.is_array())
			{
				for (auto requested : groupJ)
				{
					Data::Response::Group requestedData;
					if (!requested["groupType"].is_null())
					{
						requestedData.groupType = requested["groupType"];
					}
					if (!requested["groupId"].is_null())
					{
						requestedData.groupId = requested["groupId"];
					}
					if (!requested["isOpenGroup"].is_null())
					{
						requestedData.isOpenGroup = requested["isOpenGroup"];
					}
					if (!requested["requestingPendingMemberCount"].is_null())
					{
						requestedData.requestingPendingMemberCount = requested["requestingPendingMemberCount"];
					}
					if (!requested["invitedPendingMemberCount"].is_null())
					{
						requestedData.invitedPendingMemberCount = requested["invitedPendingMemberCount"];
					}
					if (!requested["ownerId"].is_null())
					{
						requestedData.ownerId = requested["ownerId"];
					}
					if (!requested["name"].is_null())
					{
						requestedData.name = requested["name"];
					}
					if (!requested["memberCount"].is_null())
					{
						requestedData.memberCount = requested["memberCount"];
					}
					groupList.push_back(requestedData);
				}
			}
		}
	};

}}} 
