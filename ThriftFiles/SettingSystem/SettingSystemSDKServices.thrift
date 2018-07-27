include "SettingSystemSDKDataTypes.thrift"
include "../../../commons/Config/SDKDesc/ServiceCommon/thrift/CommonType/CommonTypeSDKDataTypes.thrift"

namespace cpp Ruyi.SDK.SettingSystem.Api
namespace csharp Ruyi.SDK.SettingSystem.Api
namespace java Ruyi.SDK.SettingSystem.Api
namespace netcore Ruyi.SDK.SettingSystem.Api
namespace rs Ruyi.SDK.SettingSystem.Api


service SettingSystemService {
	/** Get a setting data of the module. */
	CommonTypeSDKDataTypes.SettingItem GetSettingItem(
		/** The setting's unique id in current module. */
		1: string id
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Get a list of setting data of the module. */
	list<CommonTypeSDKDataTypes.SettingItem> GetSettingItems(
		/** Category to filter the settings. Null indicates getting all settings of the module */
		1: string category, 
		
		/** Whecher to get the settings of children cagegories. */
		2: bool includeChildren
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Search a set of settings using a json format string.
According to the format of json string your write, searching can be separated to 3 types: simple search, lambda search and complicated search. And each of they can be combined with the other. */
	map<string, SettingSystemSDKDataTypes.SettingSearchResult> SearchSettingItems(
		/** Json string used to search. */
		1: string filterJson
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Get settings and categories in a tree */
	SettingSystemSDKDataTypes.SettingTree GetCategoryNode() throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Get child nodes of specified setting item or setting category */
	SettingSystemSDKDataTypes.NodeList GetChildNode(
		/** The parent node */
		1: string parent, 
		
		/** Specifies whether the child nodes containing setting item or setting category, or both */
		2: SettingSystemSDKDataTypes.NodeType nodeType, 
		
		/** The parameter passed to the function which will be called while getting the item value */
		3: string param
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Set the specified setting's "dataValue" with the new value */
	bool SetSettingItem(
		/** Identity of the setting */
		1: string key, 
		
		/** Value to be set */
		2: string val
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Set a set of settings' "dataValue" */
	i32 SetSettingItems(
		/** The key-values to be set.  */
		1: map<string, string> keyValues
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Restore a module setting to default */
	bool RestoreDefault(
		/** Module name specifies the module to be restored. */
		1: string moduleName, 
		
		/** The category of which to restored. Null indicates all settings. */
		2: string category
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	bool RestoreUserDefault(1: string userId, 2: string moduleName, 3: string category) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Update the module settings from an older version to the latest one */
	bool UpdateModuleVersion(
		/** Module of the setting */
		1: string moduleName
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	i32 SetUserAppData(1: string userId, 2: string category, 3: map<string, CommonTypeSDKDataTypes.SettingValue> settingItems) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	CommonTypeSDKDataTypes.AppData GetUserAppData(1: string userId, 2: string category, 3: list<string> settingKeys) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	i32 RemoveUserAppData(1: string userId, 2: string category, 3: list<string> settingKeys) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	/** Notify layer0 that a setting item has specific event */
	bool SettingItemNotify(
		/** The item's ID */
		1: string key, 
		
		/** Optional. The arguments of the notification. In json string format */
		2: SettingSystemSDKDataTypes.JSON contents
	) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	bool SetNetworkSettings(1: bool EnableDHCP, 2: string IpAddress, 3: string SubMask, 4: string Gateway, 5: string MainDNS, 6: string SubDNS),

	bool SetNetworkProxy(1: string ProxyServer, 2: string ProxyPort),

	bool ConnectToWifi(1: string profileName, 2: string key) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	SettingSystemSDKDataTypes.RuyiNetworkSettings GetNetworkSettings() throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	SettingSystemSDKDataTypes.RuyiNetworkStatus GetNetworkStatus() throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	SettingSystemSDKDataTypes.RuyiNetworkTestResult RuyiTestNetwork() throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	SettingSystemSDKDataTypes.RuyiNetworkSpeed RuyiStartNetworkSpeedTest(1: i32 userindex) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	bool RuyiStopNetworkSpeedTest(1: i32 userindex) throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	list<SettingSystemSDKDataTypes.WifiEntity> GetAvailableWifi() throws (1: CommonTypeSDKDataTypes.ErrorException error1),

	bool DisconnectWifi() throws (1: CommonTypeSDKDataTypes.ErrorException error1),
}

