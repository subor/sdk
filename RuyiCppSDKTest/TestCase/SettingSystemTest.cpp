#include "SettingSystemTest.h"
#include <filesystem>

using namespace Ruyi::SDK::CommonType;

void SubscribeHandler(std::string topic, apache::thrift::TBase* msg)
{
	InputManager::RuyiGamePadInput* rgpi = dynamic_cast<InputManager::RuyiGamePadInput*>(msg);
	if (rgpi != NULL)
	{
		rgpi->printTo(std::cout);
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
	string appaConfig = testDirectory + "..\\..\\..\\..\\commons\\Resources\\Configs\\AppA.cfg";
	string targetFile;
	
	StorageLayer::GetLocalPathResult result;
	ruyiSDK->Storage->GetLocalPath(result, "/<HDD0>/");
	size_t idx = result.path.find("LocalRoot");

	if (idx != -1) 
	{
		string layer0Path = result.path.substr(0, idx);
	
		std::experimental::filesystem::path targetPath;
		targetPath.append(layer0Path).append("LocalRoot\\Resources\\Configs\\AppA.cfg");
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

//order(40)
void SettingSystemTest::SettingSys_SimulateChangeAndRestoreSettings()
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

	::Ruyi::SDK::CommonType::SettingItem setting;
	ruyiSDK->SettingSys->GetSettingItem(setting, "ShowBlood");
	Assert::IsTrue(setting.dataValue == "False");
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