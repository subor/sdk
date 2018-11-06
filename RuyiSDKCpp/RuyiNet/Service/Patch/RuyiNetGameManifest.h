#pragma once

#include "../../Response/RuyiNetGetGameManifestResponse.h"

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// A Game Manifest that includes patch information.
	/// </summary>
	class RuyiNetGameManifest 
	{
	public:
		RuyiNetGameManifest()
		{
			GameId = "";			
			LatestVersion = "";
			PatchInfo.clear();
			Status = 0;
		}

		/// <summary>
		/// Construction from a response
		/// </summary>
		/// <param name="response">The response class to convert from.</param>
		RuyiNetGameManifest(RuyiNetGetGameManifestResponse& response)
		{
			GetDataFromGameManifestResponse(response);
		}

		/// <summary>
		/// Get Data from JSON response class.
		/// </summary>
		/// <param name="other"></param>
		void GetDataFromGameManifestResponse(RuyiNetGetGameManifestResponse& response)
		{
			Status = response.status;			

			if (RuyiNetHttpStatus::OK == Status) 
			{
				GameId = response.data.gameId;
				LatestVersion = response.data.latestVersion;

				PatchInfo.clear();

				std::for_each(response.data.patchInfo.begin(), response.data.patchInfo.end(), [&](RuyiNetGetGameManifestResponse::Data::Patch& _patch) 
				{
					Patch patch;
					patch.FromVersion = _patch.fromVersion;
					patch.ToVersion = _patch.toVersion;
					patch.ReleaseNotesLocation = _patch.releaseNotesLocation;
					patch.PatchLocation = _patch.patchLocation;
					patch.PatchMd5 = _patch.patchMd5;
					PatchInfo.push_back(patch);
				});
			}
		}

		/// <summary>
		/// Represents a game patch.
		/// </summary>
		struct Patch
		{
			/// <summary>
			/// Which version this patch can be applied to.
			/// </summary>
			std::string FromVersion;

			/// <summary>
			/// The version of the game after the patch is applied.
			/// </summary>
			std::string ToVersion;

			/// <summary>
			/// Location of the release notes for this patch.
			/// </summary>
			std::string ReleaseNotesLocation;

			/// <summary>
			/// Location of the patch file.
			/// </summary>
			std::string PatchLocation;

			/// <summary>
			/// MD5 hash of the patch file.
			/// </summary>
			std::string PatchMd5;
		};

		/// <summary>
		/// The Game ID this manifest represents.
		/// </summary>
		std::string GameId;

		/// <summary>
		/// The latest version of the game.
		/// </summary>
		std::string LatestVersion;

		/// <summary>
		/// A list of patches for this game.
		/// </summary>
		std::vector<Patch> PatchInfo;

		/// <summary>
		/// The status of the response data (compare to RuyiNetHttpStatus.OK).
		/// </summary>
		int Status;
	};
}}}