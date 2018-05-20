include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace * Ruyi.SDK.UserServiceExternal

typedef string JSON

enum UserGender {
    Unknown = 0,
    Male = 1,
    Female = 2,
}


struct TriggerKeys {
    1: i8 DeviceType,
    2: i32 Key,
    3: i8 NewValue,
    4: i8 OldValue,
}

struct InputActionEvent {
    1: string userId,
    2: string action,
    3: i64 timestamp,
    4: list<TriggerKeys> Triggers,
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


