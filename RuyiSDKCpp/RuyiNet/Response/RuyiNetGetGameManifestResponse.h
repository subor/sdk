#pragma once

#include "../RuyiNetClient.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// Response from making a call to brainCloud.
	/// </summary>
	struct RuyiNetGetGameManifestResponse
	{
		/// <summary>
		/// Response data.
		/// </summary>
		struct Data 
		{
			/// <summary>
			/// The Game ID this manifest represents.
			/// </summary>
			std::string gameId;

			/// <summary>
			/// The latest version of the game.
			/// </summary>
			std::string latestVersion;

			/// <summary>
			/// Represents a game patch.
			/// </summary>
			struct Patch 
			{
				/// <summary>
				/// Which version this patch can be applied to.
				/// </summary>
				std::string fromVersion;

				/// <summary>
				/// The version of the game after the patch is applied.
				/// </summary>
				std::string toVersion;

				/// <summary>
				/// Location of the release notes for this patch.
				/// </summary>
				std::string releaseNotesLocation;

				/// <summary>
				/// Location of the patch file.
				/// </summary>
				std::string patchLocation;

				/// <summary>
				/// MD5 hash of the patch file.
				/// </summary>
				std::string patchMd5;

				void parseJson(nlohmann::json& j) 
				{
					if (!j["fromVersion"].is_null()) fromVersion = j["fromVersion"];
					if (!j["toVersion"].is_null()) toVersion = j["toVersion"];
					if (!j["releaseNotesLocation"].is_null()) releaseNotesLocation = j["releaseNotesLocation"];
					if (!j["patchLocation"].is_null()) patchLocation = j["patchLocation"];
					if (!j["patchMd5"].is_null()) patchMd5 = j["patchMd5"];

				}
			};

			/// <summary>
			/// A list of patches for this game.
			/// </summary>
			std::vector<Patch> patchInfo;

			void parseJson(nlohmann::json& j)
			{
				if (!j["gameId"].is_null()) gameId = j["gameId"];
				if (!j["latestVersion"].is_null()) latestVersion = j["latestVersion"];
				if (!j["patchInfo"].is_null())
				{ 
					nlohmann::json patchInfoJson = j["patchInfo"]; 

					if (patchInfoJson.is_array()) 
					{
						for (auto _patchInfo : patchInfoJson)
						{
							Patch _patch;

							_patch.parseJson(_patchInfo);

							patchInfo.push_back(_patch);
						}
					}
				}
			}
		};

		/// <summary>
		/// The patch data.
		/// </summary>
		Data data;

		/// <summary>
		/// The status of the response.
		/// </summary>
		int status;

		void parseJson(nlohmann::json& j) 
		{
			if (!j["status"].is_null()) status = j["status"];
			if (!j["data"].is_null()) 
			{
				nlohmann::json dataJson = j["data"];
				
				data.parseJson(dataJson);			
			}
		}
	};
}}}