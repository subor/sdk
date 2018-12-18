include "UserServiceExternalSDKDataTypes.thrift"
include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.UserServiceExternal
namespace csharp Ruyi.SDK.UserServiceExternal
namespace java Ruyi.SDK.UserServiceExternal
namespace netcore Ruyi.SDK.UserServiceExternal
namespace rs Ruyi.SDK.UserServiceExternal


service UserServExternal {
	/** @GetPlayingUserInfo_Summary */
	UserServiceExternalSDKDataTypes.UserInfo_Public GetPlayingUserInfo(
		/** @GetPlayingUserInfo_userId_desc */
		1: string userId
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),
}

