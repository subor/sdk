include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.UserServiceExternal
namespace csharp Ruyi.SDK.UserServiceExternal
namespace java Ruyi.SDK.UserServiceExternal
namespace netcore Ruyi.SDK.UserServiceExternal
namespace rs Ruyi.SDK.UserServiceExternal

typedef string JSON

/** @UserGender_desc */
enum UserGender {
    /** @UserGender_Unknown */
	Unknown = 0,
    /** @UserGender_Male */
	Male = 1,
    /** @UserGender_Female */
	Female = 2,
}


/** @TriggerKeys_summary */
struct TriggerKeys {
    /** @TriggerKeys_DeviceType_desc */
	1: i8 DeviceType,
    /** @TriggerKeys_Key_desc */
	2: i32 Key,
    /** @TriggerKeys_NewValue_desc */
	3: i8 NewValue,
    /** @TriggerKeys_OldValue_desc */
	4: i8 OldValue,
}

/** @InputActionEvent_summary */
struct InputActionEvent {
    /** @InputActionEvent_deviceId_desc */
	1: string userId,
    /** @InputActionEvent_action_desc */
	2: string action,
    /** @InputActionEvent_timestamp_desc */
	3: i64 timestamp,
    /** @InputActionEvent_timestamp_desc */
	4: list<TriggerKeys> Triggers,
}

/** @UserEvent_summary */
struct UserEvent {
    /** @UserEvent_userId_desc */
	1: string userId,
    /** @UserEvent_action_desc */
	2: string action,
    /** @UserEvent_parameters_desc */
	3: JSON jsonData = "{}",
}

/** @UserInfo_Public_desc */
struct UserInfo_Public {
    /** @UserInfo_Public_userId_desc */
	1: string userId,
    /** @UserInfo_Public_nickname_desc */
	2: string nickname,
    /** @UserInfo_Public_portrait_desc */
	3: string portrait,
    /** @UserInfo_Public_gender_desc */
	4: UserGender gender,
}


