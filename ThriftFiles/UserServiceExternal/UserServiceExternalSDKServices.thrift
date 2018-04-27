include "UserServiceExternalSDKDataTypes.thrift"
include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace csharp Ruyi.SDK.UserServiceExternal
namespace cpp Ruyi.SDK.UserServiceExternal

service UserServExternal {
	UserServiceExternalSDKDataTypes.UserInfo_Public GetPlayingUserInfo(1: string appId, 2: string userId) throws (1: CommonTypeSDKDataTypes.ErrorException error1),
}

