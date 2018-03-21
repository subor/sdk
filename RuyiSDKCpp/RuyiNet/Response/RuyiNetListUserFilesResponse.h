#pragma once

#include <list>

#include "../../RuyiString.h"
#include "boost/container/detail/json.hpp"

using json = nlohmann::json;

namespace Ruyi
{
	struct RuyiNetListUserFilesResponse
	{
		struct Data
		{
			struct FileDetails
			{
				long updatedAt;
				long uploadedAt;
				int fileSize;
				bool shareable;
				long createdAt;
				std::string profileId;
				std::string gameId;
				std::string cloudPath;
				std::string cloudFilename;
				std::string downloadUrl;
				std::string cloudLocation;
			};

			std::list<FileDetails> fileList;
		};

		Data data;
		int status;
	};

	void to_json(json & j, const RuyiNetListUserFilesResponse::Data::FileDetails & data);
	void from_json(const json & j, RuyiNetListUserFilesResponse::Data::FileDetails & data);
	void to_json(json & j, const RuyiNetListUserFilesResponse::Data & data);
	void from_json(const json & j, RuyiNetListUserFilesResponse::Data & data);
	void to_json(json & j, const RuyiNetListUserFilesResponse& data);
	void from_json(const json & j, RuyiNetListUserFilesResponse& data);
}