#include "RuyiNetGetFriendsVideosResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetGetFriendsVideosResponse & data)
	{
		j = json
		{
			{ "status", data.status },
			{ "data", data.data }
		};
	}

	void from_json(const json & j, RuyiNetGetFriendsVideosResponse & data)
	{
		data.status = j.at("status").get<int>();
		data.data = j.at("data").get<RuyiNetGetFriendsVideosResponse::Data>();
	}

	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data & data)
	{
		j = json
		{
			{ "entities", data.entities },
		};
	}

	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data & data)
	{
		data.entities = j.at("entities").get<std::list<RuyiNetGetFriendsVideosResponse::Data::Entity>>();
	}

	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data::Entity & data)
	{
		j = json
		{
			{ "entityId", data.entityId },
			{ "entityType", data.entityType },
			{ "version", data.version },
			{ "data", data.data },
			{ "acl", data.acl },
			{ "createdAt", data.createdAt },
			{ "updatedAt", data.updatedAt },
		};
	}

	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data::Entity & data)
	{
		data.entityId = j.at("entityId").get<std::string>();
		data.entityType = j.at("entityType").get<std::string>();
		data.version = j.at("version").get<int>();
		data.data = j.at("data").get<RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetVideo>();
		data.acl = j.at("acl").get<RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetAcl>();
		data.createdAt = j.at("createdAt").get<int>();
		data.updatedAt = j.at("updatedAt").get<int>();
	}

	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetAcl & data)
	{
		j = json
		{
			{ "other", data.other },
		};
	}

	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetAcl & data)
	{
		data.other = j.at("other").get<int>();
	}

	void to_json(json & j, const RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetVideo & data)
	{
		j = json
		{
			{ "cloudFilename", data.cloudFilename },
			{ "appServerUrl", data.appServerUrl },
		};
	}

	void from_json(const json & j, RuyiNetGetFriendsVideosResponse::Data::Entity::RuyiNetVideo & data)
	{
		data.cloudFilename = j.at("cloudFilename").get<std::string>();
		data.appServerUrl = j.at("appServerUrl").get<std::string>();
	}
}