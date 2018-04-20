include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace csharp Ruyi.SDK.UserServiceExternal
namespace cpp Ruyi.SDK.UserServiceExternal

typedef string JSON

enum UserGender {
    Unknown = 0,
    Male = 1,
    Female = 2,
}


struct InputActionEvent {
    1: string userId,
    2: string action,
    3: i64 timestamp,
}

struct UserEvent {
    1: string userId,
    2: string action,
    3: JSON jsonData = "{}",
}

struct UserInfo_Public {
    1: string userId,
    2: string nickname,
    3: string portrait,
    4: UserGender gender,
}

