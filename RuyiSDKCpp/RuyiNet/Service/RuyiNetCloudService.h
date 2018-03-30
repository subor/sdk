#pragma once

#include "RuyiNetService.h"

namespace Ruyi
{

	class RuyiNetCloudService : public RuyiNetService
	{
	public:
		RuyiNetCloudService(RuyiNetClient * const client);

		void BackupData(int index, const RuyiString & persistentDataPath, const RuyiNetTask<json>::CallbackType & callback);
		void RestoreData(int index, const RuyiString & persistentDataPath, const RuyiNetTask<json>::CallbackType & callback);

	private:
		void BackupData(int index, const RuyiString & persistentDataPath, bool cleanMode,
			const RuyiNetTask<json>::CallbackType & callback);
		void BackupPath(int index, const RuyiString & cloudPath, const RuyiString & localPath);
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