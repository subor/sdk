#include "SettingSystemTest.h"
#include <filesystem>

using namespace Ruyi::SDK::CommonType;

void SubscribeHandler(std::string topic, apache::thrift::TBase* msg)
{
	InputManager::InputDeviceStateChanged* idsc = dynamic_cast<InputManager::InputDeviceStateChanged*>(msg);
	if (idsc != NULL)
	{
		idsc->printTo(std::cout);
	}
}

void OnSettingItemChanged(string topic, apache::thrift::TBase* item)
//void OnSettingItemChanged(string topic, Ruyi::SDK::CommonType::SettingItem item)
{
	std::cout << "OnSettingItemChanged" << std::endl;
}

void OnSettingSystemInitialized(string topic, apache::thrift::TBase* rootNode)
{
	std::cout << "OnSettingSystemInitialized" << std::endl;
}

SettingSystemTest::SettingSystemTest(RuyiSDKContext::Endpoint endpoint, string remoteAddress)
	:BaseUnitTest(endpoint, remoteAddress)
{
	const string* pChar = &Ruyi::SDK::Constants::g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri;
	string* modifier = const_cast<string*>(pChar);
	replace_all(*modifier, "{addr}", "localhost");

	auto pubout = Ruyi::SDK::Constants::g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri;

	sdkSubscriber = SubscribeClient::CreateInstance(pubout);
	sdkSubscriber->Subscribe("SER_L0SETTINGSYSTEM");

	//MessageHandler<void, std::string, apache::thrift::TBase*>* mh1 = new MessageHandler<void, std::string, apache::thrift::TBase*>();
	//mh1->AddHandler(OnSettingItemChanged);
	//MessageHandler<void, std::string, apache::thrift::TBase*>* mh2 = new MessageHandler<void, std::string, apache::thrift::TBase*>();
	//mh2->AddHandler(OnSettingSystemInitialized);

	sdkSubscriber->AddMessageHandler(OnSettingItemChanged);
	sdkSubscriber->AddMessageHandler(OnSettingSystemInitialized);

	testDirectory = GetLocalCurrentDirectory();

	Logger::WriteMessage(("SettingSystem testDirectory:" + testDirectory + "\n").c_str());

	sdkInternalSubScriber = SubscribeClient::CreateInstance(pubout);

	moduleName = "AppA";

	Sleep(5000); // temporary code: wait SettingSystem to finish the initialization work
	
	//SettingSys_SimulateAppAInstalled();
	//SettingSys_SimulateLoginAndChangeSettings();
}

SettingSystemTest::~SettingSystemTest() 
{
	try 
	{
		if (nullptr != sdkSubscriber) 
		{
			delete sdkSubscriber;
			sdkSubscriber = nullptr;
		}
	} catch(exception)
	{
	
	}
}

//order(10)
void SettingSystemTest::SettingSys_SimulateAppAInstalled() 
{
	string appaConfig = testDirectory + "..\\..\\..\\..\\Commons\\Resources\\Configs\\AppA.cfg";
	string targetFile;
	
	StorageLayer::GetLocalPathResult result;
	ruyiSDK->Storage->GetLocalPath(result, "/<HDD0>/");
	size_t idx = result.path.find("RuyiLocalRoot");

	if (idx != -1) 
	{
		string layer0Path = result.path.substr(0, idx);
	
		std::experimental::filesystem::path targetPath;
		targetPath.append(layer0Path).append("RuyiLocalRoot\\Resources\\Configs\\AppA.cfg");
		Logger::WriteMessage(("targetPath:" + targetPath.string() + "\n").c_str());

		targetFile = targetPath.string();
	}
	
	 
	struct stat buffer;
	if (stat(targetFile.c_str(), &buffer) == 0)
	{
		remove(targetFile.c_str());
	}

	struct stat buffer1;
	Assert::AreEqual(stat(appaConfig.c_str(), &buffer1), 0);

	Logger::WriteMessage(("appaConfig:" + appaConfig + "\n").c_str());
	Logger::WriteMessage(("targetFile:" + targetFile + "\n").c_str());

	try 
	{
		string filePath = testDirectory + "Resources\\Configs";

		CheckFilePath(filePath);
		Sleep(1000);
		FileCopy(appaConfig.c_str(), targetFile.c_str());
	}catch (exception e) 
	{
		Logger::WriteMessage("SettingSys_SimulateAppAInstalled FileCopy Error\n");
	}

	struct stat buffer2;
	Assert::AreEqual(stat(targetFile.c_str(), &buffer2), 0);
}

//order(20) internal so, No Test in cpp
/*
void SettingSystemTest::SettingSys_SimulateAppAStarted()
{
}
*/

//order(30)
void SettingSystemTest::SettingSys_SimulateLoginAndChangeSettings() 
{
	std::vector<SettingItem> vecSetting;
	ruyiSDK->SettingSys->GetSettingItems(vecSetting, "ActionMapping", true);

	std::map<string, string> settings;
	for (std::vector<SettingItem>::iterator it = vecSetting.begin(); it != vecSetting.end(); ++it) 
	{
		if (0 == it->dataType.compare("dataList")) 
		{
			string jsonData = "[";
			for (std::vector<string>::iterator sub_it = it->dataList.values.begin(); sub_it != it->dataList.values.end(); ++sub_it) 
			{
				//std::cout << "eess:" << *sub_it  << std::endl;
				jsonData.append(*sub_it);
				if ( sub_it != (it->dataList.values.end() - 1) )
				{ jsonData.append(","); }
			}
			jsonData.append("]");
			Logger::WriteMessage(("SettingSys_SimulateLoginAndChangeSettings jsonData:" + jsonData).c_str());
			settings.insert(make_pair(it->id, jsonData));
		}
	}

	PlayerLoginAndChangeSettings_0(settings);
	//PlayerLoginAndChangeSettings_1(settings);
	//PlayerLoginAndChangeSettings_2(settings);
}

//order(40)
void SettingSystemTest::SettingSys_SimulateRestoreSettings()
{
	LoginTestUser(_playerInfos[0], "ray.t001@163.com", "111");

	bool bRet = false;

	std::map<string, string> kvs;
	kvs["Mute"] = "true";
	kvs["AudioVolume"] = "35";
	int count = ruyiSDK->SettingSys->SetSettingItems(kvs);
	Assert::IsTrue(2 == count);

	bRet = ruyiSDK->SettingSys->RestoreDefault("systemsetting", "AudioSettings");
	Assert::IsTrue(bRet);

	bRet = ruyiSDK->SettingSys->SetSettingItem("ShowBlood", "true");
	Assert::IsTrue(bRet);

	bRet = ruyiSDK->SettingSys->RestoreDefault("AppA", "GameSettings");
	Assert::IsTrue(bRet);
}

//order(50) internal so, No Test in cpp
/*
void SettingSystemTest::SettingSys_SimulateAppAStopped() 
{
}
*/

//order(60) internal so, No Test in cpp
/*
void SettingSystemTest::SettingSys_SimulateAppAUninstalled() 
{
}
*/

//order(70)
void SettingSystemTest::SettingSys_GetSettingTree() 
{
	Ruyi::SDK::SettingSystem::Api::SettingTree settingTree ;
	ruyiSDK->SettingSys->GetCategoryNode(settingTree);
	Assert::IsTrue(settingTree.__isset.CateNode);

	PrintTree(settingTree);
}


void SettingSystemTest::LoginTestUser(Json::Value& ret, string user, string pass)
{
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);

	string jsonStr;
	ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(jsonStr, user, pass, true, 0);
	
	if (JsonReader.parse(jsonStr, ret))
	{
		Assert::IsTrue(200 == ret["status"].asInt64());
	}
}

void SettingSystemTest::PlayerLoginAndChangeSettings_0(std::map<string, string>& settings) 
{
	string username = "ray.t001@163.com";
	LoginTestUser(_playerInfos[0], username, "111");

	string userId = _playerInfos[0]["data"]["profileId"].asString();

	std::map<string, string> updateSettings;

	std::map<string, string>::iterator settingsIt = settings.find("Jump");
	if (settingsIt != settings.end()) 
	{
		string strSetting = settingsIt->second;

		vector<ActionTriggerInfo*> vecATI;
		deserializeActionTriggerInfo(vecATI, strSetting);
		
		ActionTriggerInfo* atInfo = new ActionTriggerInfo();
		if (nullptr != atInfo) 
		{
			InputIdentifier ii;
			ii.Device = "XB360"; //Ruyi::SDK::GlobalInputDefine::RuyiInputDeviceType::XB360
			ii.Value = "B"; //Ruyi::SDK::GlobalInputDefine::GamepadButtonFlags::B;
			atInfo->TriggerConditions.push_back(ii);
			atInfo->AutoTrigger = false;
		}

		delete vecATI[1];
		vecATI[1] = atInfo;
		
		string strSettingModified = doserializeActionTriggerInfo(vecATI);

		ptree pt;
		std::stringstream ss(strSettingModified);
		try { read_json(ss, pt); }
		catch (ptree_error& e) { Logger::WriteMessage("PlayerLoginAndChangeSettings_0 Parse Json Error"); }
		updateSettings["Jump"] = pt.get<string>("Jump");
	}

	int count = 0;
	try 
	{
		count = ruyiSDK->SettingSys->SetUserAppData(userId, "ActionMapping", updateSettings);
	} catch (exception e) 
	{ 
		Logger::WriteMessage("PlayerLoginAndChangeSettings_0 SetUserSetting Error !!!"); 
	}
	Assert::IsTrue(1 == count);

	std::vector<string> settingsToGet{ "Jump" };
	AppData* appData = nullptr;
	ruyiSDK->SettingSys->GetUserAppData(*appData, userId, "ActionMapping", settingsToGet);
	Assert::IsTrue(appData != nullptr);
}

void SettingSystemTest::PlayerLoginAndChangeSettings_1(std::map<string, string>& settings) 
{
	string username = "ray.t002@163.com";
	LoginTestUser(_playerInfos[1], username, "111");

	string userId = _playerInfos[1]["data"]["profileId"].asString();

	std::map<string, string> updateSettings;
	std::map<string, string>::iterator settingsIt = settings.find("Shot");
	if (settingsIt != settings.end()) 
	{
		string strSetting = settingsIt->second;

		std::vector<ActionTriggerInfo*> vecATI;
		deserializeActionTriggerInfo(vecATI, strSetting);

		ActionTriggerInfo* atiModify = new ActionTriggerInfo();
		deserializeSingleActionTriggerInfo(*atiModify, "{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"RightTrigger\"}],\"AutoTrigger\":false}");
		delete vecATI[1];
		vecATI[1] = atiModify;

		string shotJsonModified = doserializeActionTriggerInfo(vecATI);
		updateSettings["Shot"] = shotJsonModified;
	}

	int count = 0;
	try 
	{
		count = ruyiSDK->SettingSys->SetUserAppData(userId, "ActionMapping", updateSettings);
	} catch(exception e)
	{
		Logger::WriteMessage("PlayerLoginAndChangeSettings_1 SetUserSettings exception !!!");
	}
	Assert::IsTrue(count == 1);
}

void SettingSystemTest::PlayerLoginAndChangeSettings_2(std::map<string, string>& settings) 
{
	string username = "ray.t003@163.com";
	LoginTestUser(_playerInfos[2], username, "111");

	string key = "AudioVolume";
	Ruyi::SDK::CommonType::SettingItem setting;
	ruyiSDK->SettingSys->GetSettingItem(setting, key);
	float value = atof(setting.dataValue.c_str());
	value += 10;
	if (value >= 10)
	{
		value = 0;
	}
	bool bRet = ruyiSDK->SettingSys->SetSettingItem(key, to_string(value));
	Assert::IsTrue(bRet);
}

void SettingSystemTest::PrintTree(Ruyi::SDK::SettingSystem::Api::SettingTree tree)
{
	Logger::WriteMessage(("-" + tree.CateNode.id).c_str());
	
	for (auto child : tree.CateNode.children) 
	{
	//tree.SettingCategories
		PrintTreeNode(child, "  ", tree.SettingCategories, tree.SettingItems);
	}
}

struct CmpByValue
{
	bool operator()(const std::pair<std::string, int>& lhs, const std::pair<std::string, int>& rhs)
	{
		return lhs.second < rhs.second;
	}
};

void SettingSystemTest::PrintTreeNode(Ruyi::SDK::SettingSystem::Api::CategoryNode node, string prefix,
	std::map<std::string, Ruyi::SDK::CommonType::SettingCategory>& mapCates,
	std::map<std::string, Ruyi::SDK::CommonType::SettingItem>& mapItems) 
{
	Logger::WriteMessage((prefix + "-" + node.id).c_str());

	if (0 != node.categoryId.compare("")) 
	{
		std::map<std::string, Ruyi::SDK::CommonType::SettingCategory>::iterator mapCatesIt = mapCates.find(node.categoryId);
		if (mapCatesIt != mapCates.end()) 
		{
			Ruyi::SDK::CommonType::SettingCategory mapCate = mapCates[node.categoryId];
		
			std::vector<pair<std::string, int>> vecSortedItems(mapCate.items.begin(), mapCate.items.end());
			std::sort(vecSortedItems.begin(), vecSortedItems.end(), CmpByValue());

			std::map<std::string, Ruyi::SDK::CommonType::SettingItem>::iterator mapItemsIt;
			for (auto pair : vecSortedItems) 
			{
				mapItemsIt = mapItems.find(pair.first);

				if (mapItemsIt != mapItems.end()) 
				{
					Logger::WriteMessage((prefix + "  " + mapItems[pair.first].display + "(" + mapItems[pair.first].id + ")").c_str());
				}
			}
		}
	}

	if (node.children.size() > 0) 
	{
		for (auto child : node.children) 
		{
			PrintTreeNode(child, prefix + " ", mapCates, mapItems);
		}
	}
}