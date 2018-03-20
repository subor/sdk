#include "RuyiNetUserFileService.h"

namespace Ruyi
{	
	RuyiNetUserFileService::RuyiNetUserFileService(RuyiNetClient * client)
		: RuyiNetService(client)
	{
	}

	void RuyiNetUserFileService::UploadFile(int index, const RuyiString & cloudPath, const RuyiString & cloudFilename,
		bool shareable, bool replaceIfExists, const RuyiString & localPath,
		const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<RuyiNetUploadFileResponse>(
			[&BCService, &index, &cloudPath, &cloudFilename, &shareable, &replaceIfExists, &localPath]() -> std::string
		{
			std::string response;
			BCService->File_UploadFile(response, ToString(cloudPath), ToString(cloudFilename),
				shareable, replaceIfExists, ToString(localPath), index);
			return response;
		}, callback);
	}

	void RuyiNetUserFileService::CancelUpload(int index, const RuyiString & uploadId)
	{
		mClient->GetBCService()->File_CancelUpload(ToString(uploadId), index);
	}

	int64_t RuyiNetUserFileService::GetUploadBytesTransferred(int index, const RuyiString & uploadId)
	{
		return mClient->GetBCService()->File_GetUploadBytesTransferred(ToString(uploadId), index);
	}

	double RuyiNetUserFileService::GetUploadProgress(int index, const RuyiString & uploadId)
	{
		return mClient->GetBCService()->File_GetUploadProgress(ToString(uploadId), index);
	}

	int64_t RuyiNetUserFileService::GetUploadTotalBytesToTransfer(int index, const RuyiString & uploadId)
	{
		return mClient->GetBCService()->File_GetUploadTotalBytesToTransfer(ToString(uploadId), index);
	}

	void RuyiNetUserFileService::ListUserFiles(int index, const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<RuyiNetListUserFilesResponse>(
			[&BCService, &index]() -> std::string
		{
			std::string response;
			BCService->File_ListUserFiles_SFO(response, index);
			return response;
		}, callback);
	}

	void RuyiNetUserFileService::ListUserFiles(int index, const RuyiString & cloudPath, bool recursive,
		const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<RuyiNetListUserFilesResponse>(
			[&BCService, &index, &cloudPath, &recursive]() -> std::string
		{
			std::string response;
			BCService->File_ListUserFiles_SNSFO(response, ToString(cloudPath), recursive, index);
			return response;
		}, callback);
	}

	void RuyiNetUserFileService::DeleteUserFile(int index, const RuyiString & cloudPath, const RuyiString & cloudFilename,
		const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<RuyiNetUploadFileResponse>(
			[&BCService, &index, &cloudPath, &cloudFilename]() -> std::string
		{
			std::string response;
			BCService->File_DeleteUserFile(response, ToString(cloudPath), ToString(cloudFilename), index);
			return response;
		}, callback);
	}

	void RuyiNetUserFileService::DeleteUserFiles(int index, const RuyiString & cloudPath, bool recursive,
		const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<RuyiNetListUserFilesResponse>(
			[&BCService, &index, &cloudPath, &recursive]() -> std::string
		{
			std::string response;
			BCService->File_DeleteUserFiles(response, ToString(cloudPath), recursive, index);
			return response;
		}, callback);
	}

	void RuyiNetUserFileService::GetCDNUrl(int index, const RuyiString & cloudPath, const RuyiString & cloudFilename,
		const RuyiNetTask<RuyiNetGetCDNResponse>::CallbackType & callback)
	{
		auto BCService = mClient->GetBCService();
		EnqueueTask<RuyiNetGetCDNResponse>(
			[&BCService, &index, &cloudPath, &cloudFilename]() -> std::string
		{
			std::string response;
			BCService->File_GetCDNUrl(response, ToString(cloudPath), ToString(cloudFilename), index);
			return response;
		}, callback);
	}
}