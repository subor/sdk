#pragma once

#include "RuyiNetService.h"
#include "../Response/RuyiNetListUserFilesResponse.h"
#include "../Response/RuyiNetUploadFileResponse.h"

namespace Ruyi
{
	/// <summary>
	/// Handles backing up data to the cloud.
	/// </summary>
	class RuyiNetCloudService : public RuyiNetService
	{
	public:
		RuyiNetCloudService(RuyiNetClient * const client);

		// <summary>
		/// Manually backup the save data up to this point.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="persistentDataPath">backup data of the path from storageLayerService </param>
		/// <param name="success">wheter the operation is a success or not</param>
		void BackupData(int index, const RuyiString& persistentDataPath, bool& success);
		/// <summary>
		/// Manually restore the save data up to this point.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="persistentDataPath">restore data of the path from storageLayerService</param>
		/// <param name="response">The response after restoring data</param>
		void RestoreData(int index, const RuyiString& persistentDataPath, RuyiNetListUserFilesResponse& response);

	private:
		void BackupData(int index, const RuyiString& persistentDataPath, bool cleanMode, bool& success);
		void BackupPath(int index, const RuyiString& cloudPath, const RuyiString& localPath, bool& success);
		void ForeachFile(const wchar_t * fullPath, std::function<void(const WIN32_FIND_DATA & fileData)> action);

		const RuyiString CLOUD_LOCATION = RUYI_STR("cloud");
		const RuyiString BACKUP_LOCATION = RUYI_STR("ruyiBackup");
		const RuyiString IGNORED[3] =
		{
			RUYI_STR("Crashes"),
			RUYI_STR("Unity"),
			RUYI_STR("output_log.txt")
		};
	};
}