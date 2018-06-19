include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace csharp Ruyi.SDK.SettingSystem.Api
namespace cpp Ruyi.SDK.SettingSystem.Api

typedef i32 _int
typedef string JSON

enum NodeType {
    Category = 1,
    SettingItem = 2,
    All = 3,
}


struct RuyiNetworkSettings {
    1: bool connection,
    2: bool connectionType,
    3: _int quality,
    4: string SSID,
    5: string BSSID,
    6: string Authentication,
    7: bool DHCPEnabled,
    8: string IpAddress,
    9: string SubMask,
    10: string Gateway,
    11: string MainDNS,
    12: string SubDNS,
    13: string MacAddress,
    14: string Proxy,
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


