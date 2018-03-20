#pragma once

#include "../Response/RuyiNetGetCDNResponse.h"
#include "../Response/RuyiNetListUserFilesResponse.h"
#include "../Response/RuyiNetUploadFileResponse.h"
#include "RuyiNetService.h"

namespace Ruyi
{
	class RuyiNetUserFileService : public RuyiNetService
	{
	public:
		RuyiNetUserFileService(RuyiNetClient * client);

		void UploadFile(int index, const RuyiString & cloudPath, const RuyiString & cloudFilename,
			bool shareable, bool replaceIfExists, const RuyiString & localPath,
			const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback);
		void CancelUpload(int index, const RuyiString & uploadId);
		int64_t GetUploadBytesTransferred(int index, const RuyiString & uploadId);
		double GetUploadProgress(int index, const RuyiString & uploadId);
		int64_t GetUploadTotalBytesToTransfer(int index, const RuyiString & uploadId);
		void ListUserFiles(int index, const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback);
		void ListUserFiles(int index, const RuyiString & cloudPath, bool recursive,
			const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback);
		void DeleteUserFile(int index, const RuyiString & cloudPath, const RuyiString & cloudFilename,
			const RuyiNetTask<RuyiNetUploadFileResponse>::CallbackType & callback);
		void DeleteUserFiles(int index, const RuyiString & cloudPath, bool recursive,
			const RuyiNetTask<RuyiNetListUserFilesResponse>::CallbackType & callback);
		void GetCDNUrl(int index, const RuyiString & cloudPath, const RuyiString & cloudFilename,
			const RuyiNetTask<RuyiNetGetCDNResponse>::CallbackType & callback);
	};
}