#include "RuyiNetUserFileService.h"

namespace Ruyi
{	
	RuyiNetUserFileService::RuyiNetUserFileService(RuyiNetClient * client)
		: RuyiNetService(client)
	{
	}
	
	void RuyiNetUserFileService::UploadFile(int index, const std::string& cloudPath, const std::string& cloudFilename,
		bool shareable, bool replaceIfExists, const std::string& localPath,
		RuyiNetUploadFileResponse& response)
	{
		try 
		{
			std::string responseStr;
			mClient->GetBCService()->File_UploadFile(responseStr, cloudPath, cloudFilename, shareable, replaceIfExists, localPath, index);
			nlohmann::json responseJson = nlohmann::json::parse(responseStr);
			response.parseJson(responseJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
	
	void RuyiNetUserFileService::CancelUpload(int index, const std::string& uploadId)
	{
		try 
		{
			mClient->GetBCService()->File_CancelUpload(uploadId, index);
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	int64_t RuyiNetUserFileService::GetUploadBytesTransferred(int index, const std::string& uploadId)
	{
		try 
		{
			return mClient->GetBCService()->File_GetUploadBytesTransferred(uploadId, index);
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	double RuyiNetUserFileService::GetUploadProgress(int index, const std::string& uploadId)
	{
		try 
		{
			return mClient->GetBCService()->File_GetUploadProgress(uploadId, index);
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	int64_t RuyiNetUserFileService::GetUploadTotalBytesToTransfer(int index, const std::string& uploadId)
	{
		try 
		{
			return mClient->GetBCService()->File_GetUploadTotalBytesToTransfer(uploadId, index);
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
	
	void RuyiNetUserFileService::ListUserFiles(int index, RuyiNetListUserFilesResponse& response)
	{
		try
		{
			std::string responseStr;
			mClient->GetBCService()->File_ListUserFiles_SFO(responseStr, index);
			nlohmann::json responseJson = nlohmann::json::parse(responseStr);
			response.parseJson(responseJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetUserFileService::ListUserFiles(int index, const std::string& cloudPath, bool recursive, RuyiNetListUserFilesResponse& response)
	{
		try
		{
			std::string responseStr;
			mClient->GetBCService()->File_ListUserFiles_SNSFO(responseStr, cloudPath, recursive, index);
			nlohmann::json responseJson = nlohmann::json::parse(responseStr);
			response.parseJson(responseJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetUserFileService::DeleteUserFile(int index, const std::string& cloudPath, const std::string& cloudFilename, RuyiNetUploadFileResponse& response)
	{
		try
		{
			std::string responseStr;
			mClient->GetBCService()->File_DeleteUserFile(responseStr, cloudPath, cloudFilename, index);
			nlohmann::json responseJson = nlohmann::json::parse(responseStr);
			response.parseJson(responseJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
	
	void RuyiNetUserFileService::DeleteUserFiles(int index, const std::string& cloudPath, bool recursive, RuyiNetListUserFilesResponse& response)
	{
		try
		{
			std::string responseStr;
			mClient->GetBCService()->File_DeleteUserFiles(responseStr, cloudPath, recursive, index);
			nlohmann::json responseJson = nlohmann::json::parse(responseStr);
			response.parseJson(responseJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
	
	void RuyiNetUserFileService::GetCDNUrl(int index, const std::string& cloudPath, const std::string& cloudFilename, RuyiNetGetCDNResponse& response)
	{
		try
		{
			std::string responseStr;
			mClient->GetBCService()->File_GetCDNUrl(responseStr, cloudPath, cloudFilename, index);
			nlohmann::json responseJson = nlohmann::json::parse(responseStr);
			response.parseJson(responseJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}

	void RuyiNetUserFileService::DownloadFile(int index, const std::string cloudPath, const std::string& cloudFilename, RuyiNetResponse& response)
	{
		try
		{
			std::string responseStr;
			mClient->GetBCService()->File_DownloadFile(responseStr, cloudPath, cloudFilename, true, index);
			nlohmann::json responseJson = nlohmann::json::parse(responseStr);
			response.parseJson(responseJson);
		} catch (nlohmann::detail::exception& e)
		{
			throw new RuyiNetException(e.what());
		} catch (::apache::thrift::TApplicationException& e)
		{
			throw new RuyiNetException(e.what());
		}
	}
}