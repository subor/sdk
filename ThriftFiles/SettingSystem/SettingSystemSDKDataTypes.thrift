include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.SettingSystem.Api
namespace csharp Ruyi.SDK.SettingSystem.Api
namespace java Ruyi.SDK.SettingSystem.Api
namespace netcore Ruyi.SDK.SettingSystem.Api
namespace rs Ruyi.SDK.SettingSystem.Api

typedef string JSON
typedef i32 _int

/** @NodeType_desc */
enum NodeType {
    Category = 1,
    SettingItem = 2,
    All = 3,
}


/** @RuyiNetworkSettingNameValue_desc */
struct RuyiNetworkSettingNameValue {
    /** @RuyiNetworkSettingNameValue_name_desc */
	1: string name,
    /** @RuyiNetworkSettingNameValue_value_desc */
	2: string value,
}

/** @RuyiNetworkTestItem_desc */
struct RuyiNetworkTestItem {
    /** @RuyiNetworkTestItem_item_desc */
	1: RuyiNetworkSettingNameValue item,
    /** @RuyiNetworkTestItem_result_desc */
	2: bool result,
}

/** @RuyiNetworkSettings_desc */
struct RuyiNetworkSettings {
    /** @RuyiNetworkSettings_connection_desc */
	1: RuyiNetworkSettingNameValue connection,
    /** @RuyiNetworkSettings_networkType_desc */
	2: RuyiNetworkSettingNameValue networkType,
    /** @RuyiNetworkSettings_quality_desc */
	3: RuyiNetworkSettingNameValue quality,
    /** @RuyiNetworkSettings_SSID_desc */
	4: RuyiNetworkSettingNameValue SSID,
    /** @RuyiNetworkSettings_BSSID_desc */
	5: RuyiNetworkSettingNameValue BSSID,
    /** @RuyiNetworkSettings_Authentication_desc */
	6: RuyiNetworkSettingNameValue Authentication,
    /** @RuyiNetworkSettings_DHCPEnabled_desc */
	7: RuyiNetworkSettingNameValue DHCPEnabled,
    /** @RuyiNetworkSettings_IpAddress_desc */
	8: RuyiNetworkSettingNameValue IpAddress,
    /** @RuyiNetworkSettings_SubMask_desc */
	9: RuyiNetworkSettingNameValue SubMask,
    /** @RuyiNetworkSettings_Gateway_desc */
	10: RuyiNetworkSettingNameValue Gateway,
    /** @RuyiNetworkSettings_MainDNS_desc */
	11: RuyiNetworkSettingNameValue MainDNS,
    /** @RuyiNetworkSettings_SubDNS_desc */
	12: RuyiNetworkSettingNameValue SubDNS,
    /** @RuyiNetworkSettings_MacAddress_desc */
	13: RuyiNetworkSettingNameValue MacAddress,
    /** @RuyiNetworkSettings_Proxy_desc */
	14: RuyiNetworkSettingNameValue Proxy,
}

/** @RuyiNetworkStatus_desc */
struct RuyiNetworkStatus {
    /** @RuyiNetworkStatus_isWifi_desc */
	1: bool isWifi,
    /** @RuyiNetworkStatus_Name_desc */
	2: string Name,
    /** @RuyiNetworkStatus_AdapterStatus_desc */
	3: bool AdapterStatus,
    /** @RuyiNetworkStatus_InternetStatus_desc */
	4: bool InternetStatus,
}

/** @RuyiNetworkTestResult_desc */
struct RuyiNetworkTestResult {
    /** @RuyiNetworkTestResult_localconnection_desc */
	1: RuyiNetworkTestItem localconnection,
    /** @RuyiNetworkTestResult_ipaddress_desc */
	2: RuyiNetworkTestItem ipaddress,
    /** @RuyiNetworkTestResult_internetconnection_desc */
	3: RuyiNetworkTestItem internetconnection,
}

/** @NetworkConnectionStatus_desc */
struct NetworkConnectionStatus {
    /** @NetworkConnectionStatus_preLanAdapter_desc */
	1: bool preLanAdapter,
    /** @NetworkConnectionStatus_curLanAdapter_desc */
	2: bool curLanAdapter,
    /** @NetworkConnectionStatus_preWlanAdapter_desc */
	3: bool preWlanAdapter,
    /** @NetworkConnectionStatus_curWlanAdapter_desc */
	4: bool curWlanAdapter,
    /** @NetworkConnectionStatus_preInternetConnection_desc */
	5: bool preInternetConnection,
    /** @NetworkConnectionStatus_curInternetConnection_desc */
	6: bool curInternetConnection,
}

/** @NetworkSettings_desc */
struct NetworkSettings {
    /** @NetworkSettings_isWifi_desc */
	1: bool isWifi,
    /** @NetworkSettings_proxyUsed_desc */
	2: bool proxyUsed,
    /** @NetworkSettings_DHCPEnabled_desc */
	3: bool DHCPEnabled,
    /** @NetworkSettings_NetworkName_desc */
	4: string NetworkName,
    /** @NetworkSettings_AuthType_desc */
	5: string AuthType,
    /** @NetworkSettings_IPAddress_desc */
	6: string IPAddress,
    /** @NetworkSettings_SubMask_desc */
	7: string SubMask,
    /** @NetworkSettings_GateWay_desc */
	8: string GateWay,
    /** @NetworkSettings_mainDNS_desc */
	9: string mainDNS,
    /** @NetworkSettings_subDNS_desc */
	10: string subDNS,
    /** @NetworkSettings_proxyServer_desc */
	11: string proxyServer,
    /** @NetworkSettings_proxyPort_desc */
	12: string proxyPort,
}

/** @CategoryNode_desc */
struct CategoryNode {
    /** @CategoryNode_id_desc */
	1: string id,
    /** @CategoryNode_categoryId_desc */
	2: string categoryId,
    /** @CategoryNode_sortingPriority_desc */
	3: i32 sortingPriority,
    /** @CategoryNode_children_desc */
	4: list<CategoryNode> children,
}

/** @SettingSearchResult_desc */
struct SettingSearchResult {
    /** @SettingSearchResult_Version_desc */
	1: string Version,
    /** @SettingSearchResult_SettingItems_desc */
	2: list<CommonTypeSDKDataTypes.SettingItem> SettingItems,
}

/** @SettingTree_desc */
struct SettingTree {
    /** @SettingTree_CateNode_desc */
	1: CategoryNode CateNode,
    /** @SettingTree_SettingCategories_desc */
	2: map<string, CommonTypeSDKDataTypes.SettingCategory> SettingCategories,
    /** @SettingTree_SettingItems_desc */
	3: map<string, CommonTypeSDKDataTypes.SettingItem> SettingItems,
}

/** @NodeList_desc */
struct NodeList {
    /** @NodeList_SettingCategories_desc */
	1: list<CommonTypeSDKDataTypes.SettingCategory> SettingCategories,
    /** @NodeList_SettingItems_desc */
	2: list<CommonTypeSDKDataTypes.SettingItem> SettingItems,
}

/** @WifiEntity_desc */
struct WifiEntity {
    /** @WifiEntity_Name_desc */
	1: string Name,
    /** @WifiEntity_MacAddress_desc */
	2: string MacAddress,
    /** @WifiEntity_Channel_desc */
	3: _int Channel,
    /** @WifiEntity_CenterFrequancy_desc */
	4: _int CenterFrequancy,
    /** @WifiEntity_Rssi_desc */
	5: _int Rssi,
    /** @WifiEntity_Connected_desc */
	6: bool Connected,
    /** @WifiEntity_SecurityEnabled_desc */
	7: bool SecurityEnabled,
    /** @WifiEntity_HasProfile_desc */
	8: bool HasProfile,
}


