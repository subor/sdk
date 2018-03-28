#include "RuyiNetUploadFileResponse.h"

namespace Ruyi
{
	void to_json(json & j, const RuyiNetUploadFileResponse::Data::FileDetails & data)
	{
		j = json
		{
			{ "updatedAt", data.updatedAt },
			{ "fileSize", data.fileSize },
			{ "fileType", data.fileType },
			{ "expiresAt", data.expiresAt },
			{ "shareable", data.shareable },
			{ "uploadId", data.uploadId },
			{ "createdAt", data.createdAt },
			{ "profileId", data.profileId },
			{ "gameId", data.gameId },
			{ "path", data.path },
			{ "filename", data.filename },
			{ "replaceIfExists", data.replaceIfExists },
			{ "cloudPath", data.cloudPath }
		};
	}

	void from_json(const json & j, RuyiNetUploadFileResponse::Data::FileDetails & data)
	{
		data.updatedAt = j.at("updatedAt").get<long>();
		data.fileSize = j.at("fileSize").get<int>();
		data.fileType = j.at("fileType").get<std::string>();
		data.expiresAt = j.at("expiresAt").get<long>();
		data.shareable = j.at("shareable").get<bool>();
		data.uploadId = j.at("uploadId").get<std::string>();
		data.createdAt = j.at("createdAt").get<long>();
		data.profileId = j.at("profileId").get<std::string>();
		data.gameId = j.at("gameId").get<std::string>();
		data.path = j.at("path").get<std::string>();
		data.filename = j.at("filename").get<std::string>();
		data.replaceIfExists = j.at("replaceIfExists").get<bool>();
		data.cloudPath = j.at("cloudPath").get<std::string>();
	}

	void to_json(json & j, const RuyiNetUploadFileResponse::Data & data)
	{
		j = json
		{
			{ "fileDetails", data.fileDetails }
		};
	}

	void from_json(const json & j, RuyiNetUploadFileResponse::Data & data)
	{
		data.fileDetails = j.at("fileDetails").get<RuyiNetUploadFileResponse::Data::FileDetails>();
	}

	void to_json(json & j, const RuyiNetUploadFileResponse& data)
	{
		j = json
		{
			{ "data", data.data },
			{ "status", data.status }
		};
	}

	void from_json(const json & j, RuyiNetUploadFileResponse& data)
	{
		data.data = j.at("data").get<RuyiNetUploadFileResponse::Data>();
		data.status = j.at("status").get<int>();
	}
}