#pragma once

#include <string>
#include "boost/container/detail/json.hpp"

using json = nlohmann::json;

namespace Ruyi
{
	struct RuyiNetUploadFileResponse
	{
		struct Data
		{
			struct FileDetails
			{
				long updatedAt;
				int fileSize;
				std::string fileType;
				long expiresAt;
				bool shareable;
				std::string uploadId;
				long createdAt;
				std::string profileId;
				std::string gameId;
				std::string path;
				std::string filename;
				bool replaceIfExists;
				std::string cloudPath;
			};
			
			FileDetails fileDetails;
		};
		
		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetUploadFileResponse::Data::FileDetails & data);
	void from_json(const json & j, RuyiNetUploadFileResponse::Data::FileDetails & data);
	void to_json(json & j, const RuyiNetUploadFileResponse::Data & data);
	void from_json(const json & j, RuyiNetUploadFileResponse::Data & data);
	void to_json(json & j, const RuyiNetUploadFileResponse& data);
	void from_json(const json & j, RuyiNetUploadFileResponse& data);
}