include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.SettingSystem.Api
namespace csharp Ruyi.SDK.SettingSystem.Api
namespace java Ruyi.SDK.SettingSystem.Api
namespace netcore Ruyi.SDK.SettingSystem.Api
namespace rs Ruyi.SDK.SettingSystem.Api

typedef string JSON
typedef i32 _int

enum NodeType {
    Category = 1,
    SettingItem = 2,
    All = 3,
}


struct RuyiNetworkSettingNameValue {
    1: string name,
    2: string value,
}

struct RuyiNetworkTestItem {
    1: RuyiNetworkSettingNameValue item,
    2: bool result,
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
    3: bool AdapterStatus,
    4: bool InternetStatus,
}

struct RuyiNetworkTestResult {
    1: RuyiNetworkTestItem localconnection,
    2: RuyiNetworkTestItem ipaddress,
    3: RuyiNetworkTestItem internetconnection,
}

struct RuyiNetworkSpeed {
    1: RuyiNetworkTestItem downloadspeed,
    2: RuyiNetworkTestItem uploadspeed,
}

struct ZPBluetoothDeviceInfo {
    1: string DeviceName,
    2: string DeviceAddress,
    3: i32 DeviceClass,
    4: bool Connected,
    5: bool Authenticated,
}

struct ZPBluetoothDeviceList {
    1: list<ZPBluetoothDeviceInfo> DeviceList,
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

struct WifiEntity {
    1: string Name,
    2: string MacAddress,
    3: _int Channel,
    4: _int CenterFrequancy,
    5: _int Rssi,
    6: bool Connected,
    7: bool SecurityEnabled,
    8: bool HasProfile,
}


