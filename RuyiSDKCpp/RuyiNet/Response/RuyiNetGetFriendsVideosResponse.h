#pragma once

#include <list>
#include <string>

#include "boost/container/detail/json.hpp"

using nlohmann::json;

namespace Ruyi
{
	struct RuyiNetGetFriendsVideosResponse
	{
		int status;
		
		struct Data
		{
			struct Entity
			{
				struct RuyiNetAcl
				{
					int other;
				};

				struct RuyiNetVideo
				{
					std::string cloudFilename;
					std::string appServerUrl;
				};

				std::string entityId;
				std::string entityType;
				int version;
				RuyiNetVideo data;
				RuyiNetAcl acl;
				int createdAt;
				int updatedAt;
			};
			
			std::list<Entity> entities;
		};
		
		Data data;
	};

	void to_json(json & j, const RuyiNetGetFriendsVideosResponse & data);
	void from_json(const json & j, RuyiNetGetFriendsVideosResponse & data);
	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data & data);
	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data & data);
	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data::Entity & data);
	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data::Entity & data);
	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetAcl & data);
	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetAcl & data);
	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetVideo & data);
	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetVideo & data);
}