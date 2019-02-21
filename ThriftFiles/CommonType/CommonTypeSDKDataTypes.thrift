namespace cpp Ruyi.SDK.CommonType
namespace csharp Ruyi.SDK.CommonType
namespace java Ruyi.SDK.CommonType
namespace netcore Ruyi.SDK.CommonType
namespace rs Ruyi.SDK.CommonType

typedef string JSON

/** @PowerOperations_desc */
enum PowerOperations {
    /** @PowerOperations_None */
	None = 0,
    /** Restart the device's OS */
	RestartDevice = 2,
    ShutdownDevice = 3,
    ShutdownLayer0 = 4,
    /** Restart layer0 */
	RestartLayer0 = 5,
    /** Switch to low-power mode */
	SwitchToLowPower = 8,
    /** Switch to high-power mode */
	SwitchToHighPower = 9,
    SleepDevice = 10,
    ShutdownLayer1 = 12,
    Cancel = 15,
    Ping = 16,
    FakeUserLogout = 17,
}

/** @UserType_desc */
enum UserType {
    Guest = 0,
    RuyiUser = 1,
    Developer = 2,
}

/** @LoginState_desc */
enum LoginState {
    /** This state means that the user needs to go through authentication if he wants to use the console. His save date is still in the console and safe. He can access it after authentication (log in process). The portrait is black and white. */
	Logout = 0,
    /** @LoginState_Login */
	Login = 1,
}

/** @TitleMainIconNotificationType_desc */
enum TitleMainIconNotificationType {
    FriendRequest = 0,
    FriendAccept = 1,
    BluetoothDeviceStatusChanged = 2,
    NetworkStatusChanged = 3,
    SMSCodeHasBeenSent = 4,
}

/** @InputCategory_desc */
enum InputCategory {
    GamePad = 0,
    Keyboard = 1,
    Mouse = 2,
    JoyStick = 3,
    MaxCount = 4,
}

/** @RuyiGamePadButtonFlags_desc */
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

/** @ePlatform_desc */
enum ePlatform {
    None = 0,
    PC = 1,
    Console = 2,
    All = 3,
}

/** @eUIType_desc */
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


/** @ErrorException_desc */
exception ErrorException {
	/** @ErrorException_errId_desc */
	1: i32 errId,
	/** @ErrorException_errMsg_desc */
	2: string errMsg,
}

/** @range_desc */
struct range {
    /** @range_minimum_desc */
	1: double minimum,
    /** @range_maximum_desc */
	2: double maximum,
}

/** @InputModifier_desc */
struct InputModifier {
    /** @InputModifier_DeadZone_desc */
	1: optional range DeadZone,
    /** @InputModifier_Scale_desc */
	2: double Scale,
}

/** @ActionTrigger_desc */
struct ActionTrigger {
    /** @ActionTrigger_Id_desc */
	1: i32 Id,
    /** @ActionTrigger_InputCagetory_desc */
	2: InputCategory InputCagetory,
    /** @ActionTrigger_TriggerButtons_desc */
	3: list<i32> TriggerButtons,
    /** @ActionTrigger_TriggerValue_desc */
	4: list<i32> TriggerValue,
}

/** @notification_desc */
struct notification {
    /** @notification_title_desc */
	1: string title,
    /** @notification_detail_desc */
	2: string detail,
    /** @notification_option_desc */
	3: list<string> option,
}

/** @dataListItem_desc */
struct dataListItem {
    /** @dataListItem_elementType_desc */
	1: string elementType,
    /** @dataListItem_values_desc */
	2: list<string> values,
    /** @dataListItem_removeNotification_desc */
	3: notification removeNotification,
}

/** @activeDependency_desc */
struct activeDependency {
    /** @activeDependency_name_desc */
	1: string name,
    /** @activeDependency_condition_desc */
	2: string condition,
}

/** @SettingValue_desc */
struct SettingValue {
    /** @SettingValue_dataType_desc */
	1: string dataType,
    /** @SettingValue_dataValue_desc */
	2: string dataValue,
}

/** @SettingItem_desc */
struct SettingItem {
    /** @SettingItem_id_desc */
	1: string id,
    /** @SettingItem_display_desc */
	2: string display,
    /** @SettingItem_dataType_desc */
	3: string dataType,
    /** @SettingItem_dataValue_desc */
	4: string dataValue,
    /** @SettingItem_dataList_desc */
	5: optional dataListItem dataList,
    /** @SettingItem_platform_desc */
	6: optional ePlatform platform,
    /** @SettingItem_summary_desc */
	7: optional string summary,
    /** @SettingItem_description_desc */
	8: optional string description,
    /** @SettingItem_UIType_desc */
	9: optional eUIType UIType,
    /** @SettingItem_devModeOnly_desc */
	10: optional bool devModeOnly,
    /** @SettingItem_internalOnly_desc */
	11: optional bool internalOnly,
    /** @SettingItem_readOnly_desc */
	12: optional bool readOnly,
    /** @SettingItem_isValid_desc */
	13: bool isValid,
    /** @SettingItem_isActive_desc */
	14: bool isActive,
    /** @SettingItem_hasNew_desc */
	15: bool hasNew,
    /** @SettingItem_validation_desc */
	16: optional string validation,
    /** @SettingItem_activeDependencies_desc */
	17: optional list<activeDependency> activeDependencies,
    /** @SettingItem_ActionName_desc */
	18: optional string ActionName,
    /** @SettingItem_ActionObject_desc */
	19: optional string ActionObject,
    /** @SettingItem_ActionOnSetValue_desc */
	20: optional string ActionOnSetValue,
    /** @SettingItem_ActionOnGetValue_desc */
	21: optional string ActionOnGetValue,
    /** @SettingItem_Tags_desc */
	22: optional list<string> Tags,
}

/** @SettingCategory_desc */
struct SettingCategory {
    /** @SettingCategory_id_desc */
	1: string id,
    /** @SettingCategory_display_desc */
	2: string display,
    /** @SettingCategory_summary_desc */
	3: optional string summary,
    /** @SettingCategory_description_desc */
	4: optional string description,
    /** @SettingCategory_icon_desc */
	5: string icon,
    /** @SettingCategory_sortingPriority_desc */
	6: i32 sortingPriority,
    /** @SettingCategory_isSystemCategory_desc */
	7: bool isSystemCategory,
    /** @SettingCategory_items_desc */
	8: map<string, i32> items,
    /** @SettingCategory_enable_desc */
	9: bool enable,
    /** @SettingCategory_showInUI_desc */
	10: bool showInUI,
    /** @SettingCategory_script_desc */
	11: string script,
    /** @SettingCategory_Tags_desc */
	12: optional list<string> Tags,
}

/** @ModuleBaseInfo_desc */
struct ModuleBaseInfo {
    /** @ModuleBaseInfo_name_desc */
	1: string name,
    /** @ModuleBaseInfo_version_desc */
	2: string version,
    /** @ModuleBaseInfo_configHash_desc */
	3: i32 configHash,
}

/** @ModuleSetting_desc */
struct ModuleSetting {
    /** @ModuleSetting_baseInfo_desc */
	1: ModuleBaseInfo baseInfo,
    /** @ModuleSetting_settings_desc */
	2: list<SettingItem> settings,
    /** @ModuleSetting_categories_desc */
	3: list<SettingCategory> categories,
}

/** @AppDataRecord_desc */
struct AppDataRecord {
    /** @AppDataRecord_id_desc */
	1: string id,
    /** @AppDataRecord_content_desc */
	2: SettingValue content,
}

/** @AppDataCollection_desc */
struct AppDataCollection {
    /** @AppDataCollection_category_desc */
	1: string category,
    /** @AppDataCollection_records_desc */
	2: list<AppDataRecord> records,
}

/** @AppData_desc */
struct AppData {
    /** @AppData_appId_desc */
	1: string appId,
    /** @AppData_data_desc */
	2: list<AppDataCollection> data,
}

/** @TitleMainIconNotification_desc */
struct TitleMainIconNotification {
    /** @TitleMainIconNotification_Title */
	1: string title,
    /** @TitleMainIconNotification_MainIcon */
	2: string mainIcon,
    /** @enum.NotificationType_Desc */
	3: TitleMainIconNotificationType NotificationType,
}

/** @AppBaseInfo_desc */
struct AppBaseInfo {
    /** @AppBaseInfo_appId_desc */
	1: string appId,
    /** @AppBaseInfo_name_desc */
	2: string name,
    /** @AppBaseInfo_icon_hd_desc */
	3: string icon_hd,
    /** @AppBaseInfo_icon_ld_desc */
	4: string icon_ld,
    /** @AppBaseInfo_description_desc */
	5: string description,
    /** @AppBaseInfo_properties_desc */
	6: list<string> properties,
    /** @AppBaseInfo_platform_desc */
	7: list<string> platform,
    /** @AppBaseInfo_size_desc */
	8: i32 size,
    /** @AppBaseInfo_languages_desc */
	9: list<string> languages,
}

/** @EventNotification_Summary */
struct EventNotification {
    /** @EventNotification_key_desc */
	1: string key,
    /** @EventNotification_contents_desc */
	2: JSON contents = "{}",
}


