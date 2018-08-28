#pragma once

#include "Layer0Test.h"
#include "BaseUnitTest.h"
#include "json.h"

using namespace Ruyi;
using namespace Ruyi::SDK;
using namespace Ruyi::SDK::SettingSystem::Api;
using namespace boost::property_tree;
using namespace std;

#define MAX_PLAYER_AMOUNT 4

class SettingSystemTest : public BaseUnitTest
{
public:
	SettingSystemTest(RuyiSDKContext::Endpoint endpoint = RuyiSDKContext::Endpoint::Console, string remoteAddress = "localhost");
	~SettingSystemTest();

	void SettingSys_SimulateAppAInstalled(); //order(10)
	//void SettingSys_SimulateAppAStarted(); //order(20)
	void SettingSys_SimulateChangeAndRestoreSettings(); //order(40)
	//void SettingSys_SimulateAppAStopped(); //order(50)
	//void SettingSys_SimulateAppAUninstalled(); //order(60)
	void SettingSys_GetSettingTree(); //order(70)

private:
	string testDirectory;

	//ptree _playerInfos[MAX_PLAYER_AMOUNT];
	Json::Reader JsonReader;
	Json::Value _playerInfos[MAX_PLAYER_AMOUNT];

	SubscribeClient* sdkSubscriber;

	SubscribeClient* sdkInternalSubScriber;

	string moduleName;

	void LoginTestUser(Json::Value& ret, string user, string pass);

	void PrintTree(Ruyi::SDK::SettingSystem::Api::SettingTree tree);
	void PrintTreeNode(Ruyi::SDK::SettingSystem::Api::CategoryNode node, string prefix,
		std::map<std::string, Ruyi::SDK::CommonType::SettingCategory>& mapCates,
		std::map<std::string, Ruyi::SDK::CommonType::SettingItem>& mapItems);
};