#include "RuyiNetCloudService.h"

#include <filesystem>
#include <strsafe.h>

#include "../../RuyiNetException.h"
#include "../../Response/RuyiNetListUserFilesResponse.h"

namespace Ruyi
{
	namespace fs = std::experimental::filesystem;

	RuyiNetCloudService::RuyiNetCloudService(RuyiNetClient * const client)
		: RuyiNetService(client)
	{
	}

	void RuyiNetCloudService::BackupData(int index, const RuyiString& persistentDataPath, RuyiNetResponse& response)
	{
		BackupData(index, persistentDataPath, false, response);
	}
	
	void RuyiNetCloudService::RestoreData(int index, const RuyiString& persistentDataPath, RuyiNetResponse& response)
	{
		TCHAR fullpath[MAX_PATH] = TEXT("");

		auto result = GetFullPathName(persistentDataPath.c_str(), MAX_PATH, fullpath, NULL);
		if (result == 0)
		{
			throw RuyiNetException("Could not get full path.");
		}

		fs::path localPath(fullpath);
		fs::path backupFolder(BACKUP_LOCATION);
		fs::path backupPath = localPath / backupFolder;
		if (fs::exists(backupPath))
		{
			fs::remove_all(backupPath);
		}

		ForeachFile(localPath.c_str(), [&localPath, &backupPath](const WIN32_FIND_DATA& fileData)
		{
			fs::path subdir(fileData.cFileName);
			fs::path oldfilepath = localPath / subdir;
			fs::path newfilepath = backupPath / subdir;

			if (fileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
			{
				fs::copy(oldfilepath, newfilepath);
				fs::remove_all(oldfilepath);
			}
			else
			{
				fs::copy_file(oldfilepath, newfilepath);
				fs::remove(oldfilepath);
			}
		});
		
		std::string responseData;
		mClient->GetBCService()->File_ListUserFiles_SNSFO(responseData, ToString(CLOUD_LOCATION), true, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseData);
		RuyiNetListUserFilesResponse response1;
		response1.parseJson(responseJson);

		std::for_each(response1.data.fileList.begin(), response1.data.fileList.end(), [&](RuyiNetListUserFilesResponse::Data::FileDetails& i)
		{
			size_t x = i.cloudPath.find(ToString(CLOUD_LOCATION));
			fs::path filePath(i.cloudPath.replace(x, CLOUD_LOCATION.length(), ""));
			fs::path fullFilePath = localPath / filePath;

			HRESULT hr = URLDownloadToFile(NULL, ToRuyiString(i.downloadUrl).c_str(), fullFilePath.c_str(), 0, NULL);
		});

		if (fs::exists(backupPath))
		{
			fs::remove_all(backupPath);
		}
	}

	void RuyiNetCloudService::BackupData(int index, const RuyiString& persistentDataPath, bool cleanMode, RuyiNetResponse& response)
	{	
		TCHAR fullpath[MAX_PATH] = TEXT("");

		auto result = GetFullPathName(persistentDataPath.c_str(), MAX_PATH, fullpath, NULL);
		if (result == 0)
		{
			throw RuyiNetException("Could not get full path.");
		}

		BackupPath(index, CLOUD_LOCATION, fullpath, response);

		if (cleanMode)
		{
			fs::path localdir(fullpath);

			ForeachFile(fullpath, [&localdir](const WIN32_FIND_DATA fileData)
			{
				fs::path subdir(fileData.cFileName);
				fs::path filepath = localdir / subdir;

				if (fileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
				{
					fs::remove_all(filepath);
				}
				else
				{
					fs::remove(filepath);
				}
			});
		}
	}

	void RuyiNetCloudService::BackupPath(int index, const RuyiString& cloudPath, const RuyiString& localPath, RuyiNetResponse& response)
	{
		fs::path clouddir(cloudPath);
		fs::path localdir(localPath);

		ForeachFile(localPath.c_str(), [&](const WIN32_FIND_DATA fileData)
		{
			if (fileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
			{
				fs::path subdir(fileData.cFileName);

				fs::path newCloudPath = clouddir / subdir;
				fs::path newLocalPath = localdir / subdir;

				BackupPath(index, newCloudPath.c_str(), newLocalPath.c_str(), response);
			} else
			{
				fs::path filename(fileData.cFileName);
				fs::path filepath = localdir / filename;

				std::string data;
				RuyiNetUploadFileResponse response1;
				mClient->GetBCService()->File_UploadFile(data, ToString(cloudPath), filepath.string(), true, true, ToString(localPath), index);
				nlohmann::json responseJson = nlohmann::json::parse(data);
				response1.parseJson(responseJson);
				if (response1.status != 200)
				{
					char buffer[MAX_PATH];
					sprintf_s(buffer, MAX_PATH, "Failed to upload file: %s", ToString(fileData.cFileName).c_str());

					response.status = responseJson["status"];

					throw RuyiNetException(buffer);
				}
			}
		});

		response.status = STATUS_OK;
	}

	void RuyiNetCloudService::ForeachFile(const wchar_t * fullPath, std::function<void(const WIN32_FIND_DATA & fileData)> action)
	{
		size_t localPathLength;
		StringCchLength(fullPath, MAX_PATH, &localPathLength);
		if (localPathLength > (MAX_PATH - 3))
		{
			throw RuyiNetException("Directory path is too long.");
		}

		TCHAR szDir[MAX_PATH];
		StringCchCopy(szDir, MAX_PATH, fullPath);
		StringCchCat(szDir, MAX_PATH, TEXT("\\*"));

		WIN32_FIND_DATA ffd;
		HANDLE hFind = FindFirstFile(szDir, &ffd);
		if (INVALID_HANDLE_VALUE == hFind)
		{
			throw RuyiNetException("FindFirstFile failed.");
		}

		fs::path localdir(fullPath);

		do
		{
			action(ffd);
		} while (FindNextFile(hFind, &ffd) != 0);

		DWORD dwError = GetLastError();

		FindClose(hFind);

		if (dwError != ERROR_NO_MORE_FILES)
		{
			char buffer[MAX_PATH];
			sprintf_s(buffer, MAX_PATH, "Crawl path failed with error %lu: %s", dwError, ToString(fullPath).c_str());

			throw RuyiNetException(buffer);
		}
	}
}