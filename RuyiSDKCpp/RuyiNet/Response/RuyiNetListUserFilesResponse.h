#pragma once

#include <list>

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	/// <summary>
	/// The response from a List User Files request.
	/// </summary>
	struct RuyiNetListUserFilesResponse
	{
		/// <summary>
		/// The response data.
		/// </summary>
		struct Data
		{
			/// <summary>
			/// The details of the file to upload.
			/// </summary>
			struct FileDetails
			{
				/// <summary>
				/// When the file was last updated.
				/// </summary>
				long updatedAt;
				/// <summary>
				/// When the file was uploaded.
				/// </summary>
				long uploadedAt;
				/// <summary>
				/// The size of the file.
				/// </summary>
				int fileSize;
				/// <summary>
				/// Whether or not the file is shareable.
				/// </summary>
				bool shareable;
				/// <summary>
				/// When the file was created.
				/// </summary>
				long createdAt;
				/// <summary>
				/// The profile ID of the owning player.
				/// </summary>
				std::string profileId;
				/// <summary>
				/// The ID of the game the file relates to.
				/// </summary>
				std::string gameId;
				/// <summary>
				/// The path to the file.
				/// </summary>
				std::string cloudPath;
				/// <summary>
				/// The filename.
				/// </summary>
				std::string cloudFilename;
				/// <summary>
				/// The URL to download the file.
				/// </summary>
				std::string downloadUrl;
				/// <summary>
				/// The location of the file on the cloud.
				/// </summary>
				std::string cloudLocation;
			};
			/// <summary>
			/// The list of files.
			/// </summary>
			std::list<FileDetails> fileList;
		};

		/// <summary>
		/// The response data.
		/// </summary>
		Data data;
		/// <summary>
		/// The status of the response.
		/// </summary>
		int status;

		///the parse method from nlohmann::json to struct data
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

				if (!dataJson["fileList"].is_null())
				{
					nlohmann::json fileListJson = dataJson["fileList"];
					if (fileListJson.is_array())
					{
						for (auto fileJson : fileListJson)
						{
							Data::FileDetails fileDetail;

							if (!fileJson["updatedAt"].is_null())
							{
								fileDetail.updatedAt = fileJson["updatedAt"];
							}
							if (!fileJson["uploadedAt"].is_null())
							{
								fileDetail.updatedAt = fileJson["uploadedAt"];
							}
							if (!fileJson["fileSize"].is_null())
							{
								fileDetail.updatedAt = fileJson["fileSize"];
							}
							if (!fileJson["shareable"].is_null())
							{
								fileDetail.updatedAt = fileJson["shareable"];
							}
							if (!fileJson["createdAt"].is_null())
							{
								fileDetail.updatedAt = fileJson["createdAt"];
							}
							if (!fileJson["profileId"].is_null())
							{
								fileDetail.updatedAt = fileJson["profileId"];
							}
							if (!fileJson["gameId"].is_null())
							{
								fileDetail.updatedAt = fileJson["gameId"];
							}
							if (!fileJson["cloudPath"].is_null())
							{
								fileDetail.updatedAt = fileJson["cloudPath"];
							}
							if (!fileJson["cloudFilename"].is_null())
							{
								fileDetail.updatedAt = fileJson["cloudFilename"];
							}
							if (!fileJson["downloadUrl"].is_null())
							{
								fileDetail.updatedAt = fileJson["downloadUrl"];
							}
							if (!fileJson["cloudLocation"].is_null())
							{
								fileDetail.updatedAt = fileJson["cloudLocation"];
							}

							data.fileList.push_back(fileDetail);
						}
					}
				}
			}
		}
	};
//}
}}} //namespace