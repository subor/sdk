#pragma once

#include "../../Response/RuyiNetGetCDNResponse.h"
#include "../../Response/RuyiNetListUserFilesResponse.h"
#include "../../Response/RuyiNetUploadFileResponse.h"
#include "../../Response/RuyiNetResponse.h"
#include "../RuyiNetService.h"

namespace Ruyi { namespace SDK { namespace Online {

//namespace Ruyi{
	/// <summary>
	/// Allows users to upload files to their individual accounts
	/// </summary>
	class RuyiNetUserFileService : public RuyiNetService
	{
	public:
		RuyiNetUserFileService(RuyiNetClient * client);
		
		/// <summary>
		/// Prepares a user file upload.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudPath">The desired cloud path of the file.</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>
		/// <param name="shareable">True if the file is shareable.</param>
		/// <param name="replaceIfExists">Whether to replace file if it exists.</param>
		/// <param name="localPath">The path and fileName of the local file.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void UploadFile(int index, const std::string& cloudPath, const std::string& cloudFilename,
			bool shareable, bool replaceIfExists, const std::string& localPath,
			RuyiNetUploadFileResponse& response);
		
		/// <summary>
		/// Cancels an upload.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="uploadId">The ID of the upload.</param>
		void CancelUpload(int index, const std::string& uploadId);

		/// <summary>
		/// Returns the number of bytes uploaded or -1 if upload not found.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="uploadId">The ID of the upload.</param>
		int64_t GetUploadBytesTransferred(int index, const std::string& uploadId);
		
		/// <summary>
		/// Returns the progress of the given upload from 0.0 to 1.0 or -1 if upload not found.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="uploadId">The ID of the upload.</param>
		double GetUploadProgress(int index, const std::string& uploadId);

		/// <summary>
		/// Returns the total number of bytes that will be uploaded or -1 if upload not found.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="uploadId">The ID of the upload.</param>
		int64_t GetUploadTotalBytesToTransfer(int index, const std::string& uploadId);
		
		/// <summary>
		/// List all user files.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void ListUserFiles(int index, RuyiNetListUserFilesResponse& response);
		
		/// <summary>
		/// List all user files.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudPath">File path.</param>
		/// <param name="recursive">Whether to recurse into sub-directories</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void ListUserFiles(int index, const std::string& cloudPath, bool recursive, RuyiNetListUserFilesResponse& response);

		/// <summary>
		/// Deletes a single user file.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudPath">The desired cloud path of the file.</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void DeleteUserFile(int index, const std::string& cloudPath, const std::string& cloudFilename, RuyiNetUploadFileResponse& response);

		/// <summary>
		/// Deletes multiple user files.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudPath">The desired cloud path of the file.</param>
		/// <param name="recursive">Whether to recurse into sub-directories</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void DeleteUserFiles(int index, const std::string& cloudPath, bool recursive, RuyiNetListUserFilesResponse& response);
		
		/// <summary>
		/// Returns the CDN url for a file object.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudPath">The desired cloud path of the file.</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void GetCDNUrl(int index, const std::string& cloudPath, const std::string& cloudFilename, RuyiNetGetCDNResponse& response);

		/// <summary>
		/// Prepares a user file download.
		/// </summary>
		/// <param name="index">The index of user</param>
		/// <param name="cloudPath">The desired cloud path of the file.</param>
		/// <param name="cloudFilename">The desired cloud fileName of the file.</param>
		/// <param name="response">The parsed data struct of return json.</param>
		void DownloadFile(int index, const std::string cloudPath, const std::string& cloudFilename, RuyiNetResponse& response);
	};
//}
	}}} //namespace