namespace cpp Ruyi.SDK.CommonType
namespace csharp Ruyi.SDK.CommonType
namespace java Ruyi.SDK.CommonType
namespace netcore Ruyi.SDK.CommonType
namespace rs Ruyi.SDK.CommonType

typedef string JSON

enum LoginState {
    /** Logout state */
	Logout = 0,
    /** Login state */
	Login = 1,
}

enum TitleMainIconNotificationType {
    FriendRequest = 0,
    FriendAccept = 1,
    BluetoothDeviceStatusChanged = 2,
    NetworkStatusChanged = 3,
}

enum InputCategory {
    GamePad = 0,
    Keyboard = 1,
    Mouse = 2,
    JoyStick = 3,
    MaxCount = 4,
}

enum RuyiGamePadButtonFlags {
    GamePad_Up = 1,
    GamePad_Down = 2,
    GamePad_Left = 4,
    GamePad_Right = 8,
    GamePad_Start = 16,
    GamePad_Back = 32,
    GamePad_L3 = 64,
    GamePad_R3 = 128,
    GamePad_LB = 256,
    GamePad_RB = 512,
    GamePad_A = 4096,
    GamePad_B = 8192,
    GamePad_X = 16384,
    GamePad_Y = 32768,
    GamePad_LT = 131072,
    GamePad_RT = 262144,
    GamePad_LJoyX = 524288,
    GamePad_LJoyY = 1048576,
    GamePad_RJoyX = 2097152,
    GamePad_RJoyY = 4194304,
}

enum ePlatform {
    None = 0,
    PC = 1,
    Console = 2,
    All = 3,
}

enum eUIType {
    None = 0,
    Toggle = 1,
    Text = 2,
    Slider = 3,
    CheckList = 4,
    OptionList = 5,
    DateTime = 6,
    InputTextWithLabel = 7,
    Button = 8,
    InputText = 9,
}


exception ErrorException {
	1: i32 errId,
	2: string errMsg,
}

struct range {
    1: double minimum,
    2: double maximum,
}

struct InputModifier {
    1: optional range DeadZone,
    2: double Scale,
}

struct ActionTrigger {
    1: i32 Id,
    2: InputCategory InputCagetory,
    3: list<i32> TriggerButtons,
    4: list<i32> TriggerValue,
}

struct notification {
    1: string title,
    2: string detail,
    3: list<string> option,
}

struct dataListItem {
    1: string elementType,
    2: list<string> values,
    3: notification removeNotification,
}

struct activeDependency {
    1: string name,
    2: string condition,
}

struct SettingValue {
    1: string dataType,
    2: string dataValue,
}

struct SettingItem {
    1: string id,
    2: string display,
    3: string dataType,
    4: string dataValue,
    5: optional dataListItem dataList,
    6: optional ePlatform platform,
    7: optional string summary,
    8: optional string description,
    9: optional eUIType UIType,
    10: optional bool devModeOnly,
    11: optional bool internalOnly,
    12: optional bool readOnly,
    13: bool isValid,
    14: bool isActive,
    15: optional string validation,
    16: optional list<activeDependency> activeDependencies,
    17: optional string ActionName,
    18: optional string ActionObject,
    19: optional string ActionOnSetValue,
    20: optional string ActionOnGetValue,
}

struct SettingCategory {
    1: string id,
    2: string display,
    3: optional string summary,
    4: optional string description,
    5: string icon,
    6: i32 sortingPriority,
    7: bool isSystemCategory,
    8: map<string, i32> items,
    9: bool enable,
    10: bool showInUI,
    11: string script,
}

struct ModuleBaseInfo {
    1: string name,
    2: string version,
    3: i32 configHash,
}

struct ModuleSetting {
    1: ModuleBaseInfo baseInfo,
    2: list<SettingItem> settings,
    3: list<SettingCategory> categories,
}

struct AppDataRecord {
    /** The record ID */
	1: string id,
    /** The record value */
	2: SettingValue content,
}

struct AppDataCollection {
    /** The category of the records */
	1: string category,
    /** The records of the collection. See AppDataRecord */
	2: list<AppDataRecord> records,
}

struct AppData {
    /** The App ID */
	1: string appId,
    /** The user data of the App. See AppDataCollection */
	2: list<AppDataCollection> data,
}

struct TitleMainIconNotification {
    1: string title,
    2: string mainIcon,
    3: TitleMainIconNotificationType NotificationType,
}

struct EventNotification {
    1: string key,
    2: JSON contents = "{}",
}


