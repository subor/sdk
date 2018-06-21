#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	/// <summary>
	/// The response from GetFriendsVideos
	/// </summary>
	struct RuyiNetGetFriendsVideosResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// A single returned entity.
			/// </summary>
			struct Entity
			{
				/// <summary>
				/// Determines the permissions others have to access a players entities 
				/// (0 = no access, 1 = read-only, 2 = read/write).
				/// </summary>
				struct RuyiNetAcl
				{
					/// <summary>
					/// Permissions for other users.
					/// </summary>
					int other;
				};

				/// <summary>
				/// Represents a video entity.
				/// </summary>
				struct RuyiNetVideo
				{
					/// <summary>
					/// The cloud filename of the video.
					/// </summary>
					std::string cloudFilename;
					/// <summary>
					/// The URL of the video.
					/// </summary>
					std::string appServerUrl;
				};

				/// <summary>
				/// The ID of the entity.
				/// </summary>
				std::string entityId;
				/// <summary>
				/// The type of entity.
				/// </summary>
				std::string entityType;
				/// <summary>
				/// The current version of the entity.
				/// </summary>
				int version;
				/// <summary>
				/// The actual net video data.
				/// </summary>
				RuyiNetVideo data;
				/// <summary>
				/// The access control list of the video.
				/// </summary>
				RuyiNetAcl acl;
				/// <summary>
				/// When the video was created.
				/// </summary>
				int createdAt;
				/// <summary>
				/// When the video was last updated.
				/// </summary>
				int updatedAt;
			};
			
			/// <summary>
			/// The list of video entities.
			/// </summary>
			std::list<Entity> entities;
		};
	
		/// <summary>
		/// The status of the response.
		/// </summary>
		int status;

		/// <summary>
		/// The response data.
		/// </summary>
		Data data;

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

				if (!dataJson["entities"].is_null())
				{
					nlohmann::json entitiesJson = dataJson["entities"];
					
					if (!entitiesJson.is_object()) return;

					if (entitiesJson.is_array())
					{
						for (auto entities : entitiesJson)
						{
							Data::Entity entity;
							
							if (!entities["entityId"].is_null())
							{
								entity.entityId = entities["entityId"];
							}
							if (!entities["entityType"].is_null())
							{
								entity.entityType = entities["entityType"];
							}
							if (!entities["version"].is_null())
							{
								entity.version = entities["version"];
							}
							if (!entities["data"].is_null())
							{
								nlohmann::json entityData = entities["data"];
								if (!entityData["cloudFilename"].is_null())
								{
									entity.data.cloudFilename = entityData["cloudFilename"];
								}
								if (!entityData["appServerUrl"].is_null())
								{
									entity.data.appServerUrl = entityData["appServerUrl"];
								}
							}
							if (!entities["acl"].is_null())
							{
								nlohmann::json entityAcl = entities["acl"];
								if (!entityAcl["other"].is_null())
								{
									entity.acl.other = entityAcl["other"];
								}
							}
							if (!entities["createdAt"].is_null())
							{
								entity.createdAt = entities["createdAt"];
							}
							if (!entities["updatedAt"].is_null())
							{
								entity.updatedAt = entities["updatedAt"];
							}

							data.entities.push_back(entity);
						}
					}
				}
			}
		}
	};
	
//}
}}} //namespace