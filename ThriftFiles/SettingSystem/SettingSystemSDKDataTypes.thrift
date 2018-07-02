include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.SettingSystem.Api
namespace csharp Ruyi.SDK.SettingSystem.Api
namespace java Ruyi.SDK.SettingSystem.Api
namespace netcore Ruyi.SDK.SettingSystem.Api
namespace rs Ruyi.SDK.SettingSystem.Api

typedef string JSON

enum NodeType {
    Category = 1,
    SettingItem = 2,
    All = 3,
}


struct RuyiNetworkSettingNameValue {
    1: string name,
    2: string value,
}

struct RuyiNetworkSettings {
    1: RuyiNetworkSettingNameValue connection,
    2: RuyiNetworkSettingNameValue networkType,
    3: RuyiNetworkSettingNameValue quality,
    4: RuyiNetworkSettingNameValue SSID,
    5: RuyiNetworkSettingNameValue BSSID,
    6: RuyiNetworkSettingNameValue Authentication,
    7: RuyiNetworkSettingNameValue DHCPEnabled,
    8: RuyiNetworkSettingNameValue IpAddress,
    9: RuyiNetworkSettingNameValue SubMask,
    10: RuyiNetworkSettingNameValue Gateway,
    11: RuyiNetworkSettingNameValue MainDNS,
    12: RuyiNetworkSettingNameValue SubDNS,
    13: RuyiNetworkSettingNameValue MacAddress,
    14: RuyiNetworkSettingNameValue Proxy,
}

struct RuyiNetworkStatus {
    1: bool isWifi,
    2: string Name,
}

struct CategoryNode {
    1: string id,
    2: string categoryId,
    3: i32 sortingPriority,
    4: list<CategoryNode> children,
}

struct SettingSearchResult {
    1: string Version,
    2: list<CommonTypeSDKDataTypes.SettingItem> SettingItems,
}

struct SettingTree {
    1: CategoryNode CateNode,
    2: map<string, CommonTypeSDKDataTypes.SettingCategory> SettingCategories,
    3: map<string, CommonTypeSDKDataTypes.SettingItem> SettingItems,
}

struct NodeList {
    1: list<CommonTypeSDKDataTypes.SettingCategory> SettingCategories,
    2: list<CommonTypeSDKDataTypes.SettingItem> SettingItems,
}

/** Notification of setting item from layer0 */
struct SettingItemNotification {
    /** The item's ID */
	1: string key,
    /** Optional. The arguments of the notification. In json string format */
	2: JSON contents = "{}",
}


