#include "RuyiNetUserFileService.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{	
	RuyiNetUserFileService::RuyiNetUserFileService(RuyiNetClient * client)
		: RuyiNetService(client)
	{
	}
	
	void RuyiNetUserFileService::UploadFile(int index, const std::string& cloudPath, const std::string& cloudFilename,
		bool shareable, bool replaceIfExists, const std::string& localPath,
		RuyiNetUploadFileResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->File_UploadFile(responseStr, cloudPath, cloudFilename, shareable, replaceIfExists, localPath, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
	
	void RuyiNetUserFileService::CancelUpload(int index, const std::string& uploadId)
	{
		mClient->GetBCService()->File_CancelUpload(uploadId, index);
	}

	int64_t RuyiNetUserFileService::GetUploadBytesTransferred(int index, const std::string& uploadId)
	{
		return mClient->GetBCService()->File_GetUploadBytesTransferred(uploadId, index);
	}

	double RuyiNetUserFileService::GetUploadProgress(int index, const std::string& uploadId)
	{
		return mClient->GetBCService()->File_GetUploadProgress(uploadId, index);
	}

	int64_t RuyiNetUserFileService::GetUploadTotalBytesToTransfer(int index, const std::string& uploadId)
	{
		return mClient->GetBCService()->File_GetUploadTotalBytesToTransfer(uploadId, index);
	}
	
	void RuyiNetUserFileService::ListUserFiles(int index, RuyiNetListUserFilesResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->File_ListUserFiles_SFO(responseStr, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}

	void RuyiNetUserFileService::ListUserFiles(int index, const std::string& cloudPath, bool recursive, RuyiNetListUserFilesResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->File_ListUserFiles_SNSFO(responseStr, cloudPath, recursive, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}

	void RuyiNetUserFileService::DeleteUserFile(int index, const std::string& cloudPath, const std::string& cloudFilename, RuyiNetUploadFileResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->File_DeleteUserFile(responseStr, cloudPath, cloudFilename, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
	
	void RuyiNetUserFileService::DeleteUserFiles(int index, const std::string& cloudPath, bool recursive, RuyiNetListUserFilesResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->File_DeleteUserFiles(responseStr, cloudPath, recursive, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
	
	void RuyiNetUserFileService::GetCDNUrl(int index, const std::string& cloudPath, const std::string& cloudFilename, RuyiNetGetCDNResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->File_GetCDNUrl(responseStr, cloudPath, cloudFilename, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}

	void RuyiNetUserFileService::DownloadFile(int index, const std::string cloudPath, const std::string& cloudFilename, RuyiNetResponse& response)
	{
		std::string responseStr;
		mClient->GetBCService()->File_DownloadFile(responseStr, cloudPath, cloudFilename, true, index);
		nlohmann::json responseJson = nlohmann::json::parse(responseStr);
		response.parseJson(responseJson);
	}
//}
}}} //namespace