/// GENERATED BY SDK TOOL.

/// DON'T MODIFY THIS FILE UNLESS YOU'RE FULLY UNDERSTANDING WHAT YOU ARE DOING!!!

#include "../PubSub/MessageCreator.h" 

using namespace Ruyi;

std::map<string, MessageCreatorFunc> MessageCreator::ccs;

void MessageCreator::Initialize()
{
	REGIST_CREATION_FUNCTION("Ruyi.SDK.InputManager.RuyiGamePadInput", Ruyi::SDK::InputManager::RuyiGamePadInput);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.InputManager.RuyiKeyboardInput", Ruyi::SDK::InputManager::RuyiKeyboardInput);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.InputManager.RuyiMouseInput", Ruyi::SDK::InputManager::RuyiMouseInput);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.InputManager.RuyiJoystickInput", Ruyi::SDK::InputManager::RuyiJoystickInput);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.InputManager.InputActionTriggered", Ruyi::SDK::InputManager::InputActionTriggered);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.InputManager.AxisActionTriggered", Ruyi::SDK::InputManager::AxisActionTriggered);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.InputManager.GamepadInfo", Ruyi::SDK::InputManager::GamepadInfo);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.StorageLayer.GetLocalPathResult", Ruyi::SDK::StorageLayer::GetLocalPathResult);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.RuyiNetworkSettingNameValue", Ruyi::SDK::SettingSystem::Api::RuyiNetworkSettingNameValue);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.RuyiNetworkTestItem", Ruyi::SDK::SettingSystem::Api::RuyiNetworkTestItem);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.RuyiNetworkSettings", Ruyi::SDK::SettingSystem::Api::RuyiNetworkSettings);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.RuyiNetworkStatus", Ruyi::SDK::SettingSystem::Api::RuyiNetworkStatus);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.RuyiNetworkTestResult", Ruyi::SDK::SettingSystem::Api::RuyiNetworkTestResult);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.RuyiNetworkSpeed", Ruyi::SDK::SettingSystem::Api::RuyiNetworkSpeed);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.ZPBluetoothDeviceInfo", Ruyi::SDK::SettingSystem::Api::ZPBluetoothDeviceInfo);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.ZPBluetoothDeviceList", Ruyi::SDK::SettingSystem::Api::ZPBluetoothDeviceList);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.ZPBluetoothDevicePinRequest", Ruyi::SDK::SettingSystem::Api::ZPBluetoothDevicePinRequest);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.CategoryNode", Ruyi::SDK::SettingSystem::Api::CategoryNode);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.SettingSearchResult", Ruyi::SDK::SettingSystem::Api::SettingSearchResult);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.SettingTree", Ruyi::SDK::SettingSystem::Api::SettingTree);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.NodeList", Ruyi::SDK::SettingSystem::Api::NodeList);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.SettingSystem.Api.WifiEntity", Ruyi::SDK::SettingSystem::Api::WifiEntity);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.BrainCloudApi.BCServiceStartedNotification", Ruyi::SDK::BrainCloudApi::BCServiceStartedNotification);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.BrainCloudApi.FileUploadSuccessResult", Ruyi::SDK::BrainCloudApi::FileUploadSuccessResult);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.BrainCloudApi.FileUploadFailedResult", Ruyi::SDK::BrainCloudApi::FileUploadFailedResult);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.LocalizationService.LanguageChangedMsg", Ruyi::SDK::LocalizationService::LanguageChangedMsg);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.UserServiceExternal.TriggerKeys", Ruyi::SDK::UserServiceExternal::TriggerKeys);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.UserServiceExternal.InputActionEvent", Ruyi::SDK::UserServiceExternal::InputActionEvent);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.UserServiceExternal.UserEvent", Ruyi::SDK::UserServiceExternal::UserEvent);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.UserServiceExternal.UserInfo_Public", Ruyi::SDK::UserServiceExternal::UserInfo_Public);
	REGIST_CREATION_FUNCTION("Ruyi.SDK.OverlayManagerExternal.NotifyTakeScreenShot", Ruyi::SDK::OverlayManagerExternal::NotifyTakeScreenShot);
}