#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi
{
	struct RuyiNetResponse
	{
		/// <summary>
		/// Resultant status code from an API call.
		/// </summary>
		int status;

		/// <summary>
		/// Message accompanying the result - can be used to determine errors.
		/// </summary>
		std::string message;

		void parseJson(nlohmann::json& j)
		{
			if (!j["status"].is_null())
			{
				status = j["status"];
			}
			if (!j["message"].is_null())
			{
				message = j["message"];
			}
		}
	};

	/// <summary>
	/// A group received from a response.
	/// </summary>
	struct RuyiNetResponseGroup
	{
		/// <summary>
		/// Access Control List
		/// </summary>
		struct ACL
		{
			/// <summary>
			/// Access privileges of everyone else.
			/// </summary>
			int other;

			/// <summary>
			/// Access privileges of members.
			/// </summary>
			int member;

			void parseJson(nlohmann::json& j)
			{
				if (!j["other"].is_null())
				{
					other = j["other"];
				}
				if (!j["member"].is_null())
				{
					member = j["member"];
				}
			}
		};

		/// <summary>
		/// The default attributes for members.
		/// </summary>
		struct DefaultMemberAttributes { };

		/// <summary>
		/// A group member.
		/// </summary>
		struct Member
		{
			/// <summary>
			/// The role of the member.
			/// </summary>
			std::string role;

			/// <summary>
			/// Attributes that can be attached to the member.
			/// </summary>
			struct Attributes { };

			/// <summary>
			/// Attributes attached to the member.
			/// </summary>
			Attributes attributes;

			void parseJson(nlohmann::json& j)
			{
				if (!j["role"].is_null())
				{
					role = j["role"];
				}
			}
		};

		/// <summary>
		/// Extra custom data
		/// </summary>
		struct Data
		{
			/// <summary>
			/// A connection string used to connect to the host.
			/// </summary>
			std::string connectionString;

			/// <summary>
			/// The maximum number of players that can join this lobby.
			/// </summary>
			int maxSlots;

			/// <summary>
			/// The number of players needed to fill this lobby.
			/// </summary>
			int freeSlots;

			/// <summary>
			/// Whether or not this game is a RANKED MATCH.
			/// </summary>
			bool ranked;

			void parseJson(nlohmann::json& j)
			{
				if (!j["connectionString"].is_null())
				{
					connectionString = j["connectionString"];
				}
				if (!j["maxSlots"].is_null())
				{
					maxSlots = j["maxSlots"];
				}
				if (!j["freeSlots"].is_null())
				{
					freeSlots = j["freeSlots"];
				}
				if (!j["ranked"].is_null())
				{
					ranked = j["ranked"];
				}
			}
		};

		/// <summary>
		/// Extra custom data
		/// </summary>
		Data data;

		/// <summary>
		/// The Access Control List
		/// </summary>
		ACL acl;

		/// <summary>
		/// The default attributes for members.
		/// </summary>
		DefaultMemberAttributes defaultMemberAttributes;

		/// <summary>
		/// A list of players that have either been invited or requested to join
		/// the lobby.
		/// </summary>
		std::map<std::string, Member> pendingMembers;

		/// <summary>
		/// The players who are in this lobby.
		/// </summary>
		std::map<std::string, Member> members;

		/// <summary>
		/// The App ID of the game this lobby belongs to.
		/// </summary>
		std::string gameId;

		/// <summary>
		/// The type of this group.
		/// </summary>
		std::string groupType;

		/// <summary>
		/// The unique ID of the group.
		/// </summary>
		std::string groupId;

		/// <summary>
		/// The profile ID of the group's owner.
		/// </summary>
		std::string ownerId;

		/// <summary>
		/// The name of the group.
		/// </summary>
		std::string name;

		/// <summary>
		/// When the group was created.
		/// </summary>
		long createdAt;

		/// <summary>
		/// When the lobby was last updated.
		/// </summary>
		long updatedAt;

		/// <summary>
		/// The number of players in the lobby.
		/// </summary>
		int memberCount;

		/// <summary>
		/// The number of players that have requested to join the lobby.
		/// </summary>
		int requestingPendingMemberCount;

		/// <summary>
		/// The current version of the lobby.
		/// </summary>
		int version;

		/// <summary>
		/// The number of players that have been invited to join the lobby.
		/// </summary>
		int invitedPendingMemberCount;

		/// <summary>
		/// Whether or not the group is open to other players.
		/// </summary>
		bool isOpenGroup;

		void parseJson(nlohmann::json& j) 
		{
			if (!j["data"].is_null())
			{
				nlohmann::json dataJson = j["data"];
				data.parseJson(dataJson);
			}
			if (!j["acl"].is_null())
			{
				nlohmann::json aclJson = j["acl"];
				data.parseJson(aclJson);
			}
			if (!j["pendingMembers"].is_null())
			{
				nlohmann::json dataJson = j["pendingMembers"];
				data.parseJson(dataJson);
			}
		}
	};
}