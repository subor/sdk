include "UserServiceExternalSDKDataTypes.thrift"
include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.UserServiceExternal
namespace csharp Ruyi.SDK.UserServiceExternal
namespace java Ruyi.SDK.UserServiceExternal
namespace netcore Ruyi.SDK.UserServiceExternal
namespace rs Ruyi.SDK.UserServiceExternal


service UserServExternal {
	UserServiceExternalSDKDataTypes.UserInfo_Public GetPlayingUserInfo(1: string userId) throws (1: CommonTypeSDKDataTypes.ErrorException error1),
}

