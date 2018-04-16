#include "RuyiNetListUserFilesResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetListUserFilesResponse::Data::FileDetails & data)
	{
		j = json
		{
			{ "updatedAt", data.updatedAt },
			{ "uploadedAt", data.uploadedAt },
			{ "fileSize", data.fileSize },
			{ "shareable", data.shareable },
			{ "createdAt", data.createdAt },
			{ "profileId", data.profileId },
			{ "gameId", data.gameId },
			{ "cloudPath", data.cloudPath },
			{ "cloudFilename", data.cloudFilename },
			{ "downloadUrl", data.downloadUrl },
			{ "cloudLocation", data.cloudLocation }
		};
	}

	void from_json(const json & j, RuyiNetListUserFilesResponse::Data::FileDetails & data)
	{
		data.updatedAt = j.at("updatedAt").get<long>();
		data.uploadedAt = j.at("uploadedAt").get<long>();
		data.fileSize = j.at("fileSize").get<int>();
		data.shareable = j.at("shareable").get<bool>();
		data.createdAt = j.at("createdAt").get<long>();
		data.profileId = j.at("profileId").get<std::string>();
		data.gameId = j.at("gameId").get<std::string>();
		data.cloudPath = j.at("cloudPath").get<std::string>();
		data.cloudFilename = j.at("cloudFilename").get<std::string>();
		data.downloadUrl = j.at("downloadUrl").get<std::string>();
		data.cloudLocation = j.at("cloudLocation").get<std::string>();
	}

	void to_json(json & j, const RuyiNetListUserFilesResponse::Data & data)
	{
		j = json
		{
			{ "fileList", data.fileList }
		};
	}

	void from_json(const json & j, RuyiNetListUserFilesResponse::Data & data)
	{
		data.fileList = j.at("fileList").get<std::list<RuyiNetListUserFilesResponse::Data::FileDetails>>();
	}

	void to_json(json & j, const RuyiNetListUserFilesResponse& data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetListUserFilesResponse& data)
	{
		data.data = j.at("data").get<RuyiNetListUserFilesResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}