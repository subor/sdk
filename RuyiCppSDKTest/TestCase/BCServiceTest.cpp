#include "BCServiceTest.h"
#include <windows.h>

bool _bFileUploadFinished;
void OnFileUploadSuccess(string topic, apache::thrift::TBase* item)
{
	_bFileUploadFinished = true;
}

void OnFileUploadFailed(string topic, apache::thrift::TBase* item)
{
	_bFileUploadFinished = true;
}

BCServiceTest::BCServiceTest(RuyiSDKContext::Endpoint endpoint, string remoteAddress)
	:BaseUnitTest(endpoint, remoteAddress)
	, _TestEventId("")
{
	const string* pChar = &Ruyi::SDK::Constants::g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri;
	string* modifier = const_cast<string*>(pChar);
	replace_all(*modifier, "{addr}", "localhost");

	auto pubout = Ruyi::SDK::Constants::g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri;
	sdkSubscriber = SubscribeClient::CreateInstance(pubout);
	sdkSubscriber->Subscribe("SER_BCSERVICE");

	MessageHandler<void, std::string, apache::thrift::TBase*>* mh1 = new MessageHandler<void, std::string, apache::thrift::TBase*>();
	mh1->AddHandler(OnFileUploadSuccess);
	MessageHandler<void, std::string, apache::thrift::TBase*>* mh2 = new MessageHandler<void, std::string, apache::thrift::TBase*>();
	mh2->AddHandler(OnFileUploadFailed);

	sdkSubscriber->AddMessageHandler(OnFileUploadSuccess);
	sdkSubscriber->AddMessageHandler(OnFileUploadFailed);

	//sdkSubscriber->AddMessageHandler(mh1);
	//sdkSubscriber->AddMessageHandler(mh2);
	/*
	Json::Reader reader;
	Json::Value root;
	string jsonString1 = "{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"C\"}],\"AutoTrigger\":{\"AAA\":1,\"BBB\":\"bbb\"}}";
	string jsonString2 = "[{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"C\"}],\"AutoTrigger\":false},{\"TriggerConditions\":[{\"Device\":\"PS4\",\"Value\":\"B\"}],\"AutoTrigger\":true}]";
	if (reader.parse(jsonString2, root))
	{
	//std::cout << "ssddd:" << root["AutoTrigger"]["AAA"] << std::endl;
	int rootSize = root.size();
	for (int i = 0; i < rootSize; ++i)
	{
	std::cout << root[i]["AutoTrigger"].asBool() << std::endl;
	std::cout << root[i]["TriggerConditions"][0]["Device"].asString() << std::endl;
	}
	}*/
}

#pragma region Authentication
//order(0)
void BCServiceTest::BCS_Authentication_AuthenticateAnonymous() 
{
	string anonymousID;
	ruyiSDK->BCService->Authentication_GenerateAnonymousId(anonymousID, 0);
	ruyiSDK->BCService->Authentication_Initialize("", anonymousID, 0);

	string ret;
	ruyiSDK->BCService->Authentication_AuthenticateAnonymous(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64(), L"authenticate anonymous failed.");
	}
}

//order(10)
void BCServiceTest::BCS_Authentication_ClearSavedProfiedId() 
{
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
}

//order(20)
void BCServiceTest::BCS_Authentication_AuthenticateEmail() 
{
	string ret;
	ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "ray.t001@163.com", "111", true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
}

//order(22)
void BCServiceTest::BCS_Authentication_ResetEmailPassword()
{
	string ret = "";
	ruyiSDK->BCService->Authentication_ResetEmailPassword(ret, "ray.t001@163.com", 0);

	Assert::AreNotEqual(ret.c_str(), "");
}

//order(30)
void BCServiceTest::BCS_Authentication_AuthenticateUniversal() 
{
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
	string ret;
	ruyiSDK->BCService->Authentication_AuthenticateUniversal(ret, "ray.t008", "111", true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
}
#pragma endregion

#pragma region AsyncMatch
//order(50)
void BCServiceTest::BCS_AsyncMatch_CreateMatch() 
{
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);

	string ret;
	ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "ray.t001@163.com", "111", true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt());
	}

	string playerId1 = root["data"]["id"].asString();
	_playerId1 = playerId1;

	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);

	ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "ray.t002@163.com", "111", true, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt());
	}
	_playerId2 = root["data"]["id"].asString();

	string playersJson = "[{ \"platform\": \"BC\", \"id\": \"" + playerId1 + "\" }]";
	ruyiSDK->BCService->AsyncMatch_CreateMatch(ret, playersJson, "You've been challenged!", 0);
	if (JsonReader.parse(ret, _tkMatchInfo)) 
	{
		Assert::IsTrue(200 == _tkMatchInfo["status"].asInt64());
	}
}

//order(52)
void BCServiceTest::BCS_AsyncMatch_FindMatchs() 
{
	string ret;
	ruyiSDK->BCService->AsyncMatch_FindMatches(ret, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(55)
void BCServiceTest::BCS_AsyncMatch_UpdateMatchSummaryData() 
{
	if (!_tkMatchInfo["status"].isNull() || 200 != _tkMatchInfo["status"].asInt()) 
	{ 
		return; 
	}

	auto dataJson = _tkMatchInfo["data"];
	auto tkVer = dataJson["version"];
	auto nVer = tkVer.asInt64();

	auto ownerId = dataJson["ownerId"].asString();
	auto matchId = dataJson["matchId"].asString();

	string ret;
	ruyiSDK->BCService->AsyncMatch_UpdateMatchSummaryData(ret, ownerId, matchId, nVer, "{\"Name\": \"Number Game\"}", 0);
	
	dataJson["version"] = nVer + 1;

	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(60)
void BCServiceTest::BCS_AsyncMatch_ReadMatch() 
{
	if (_tkMatchInfo.isNull() || 200 != _tkMatchInfo["status"].asInt()) 
	{
		return;
	}

	auto dataJson = _tkMatchInfo["data"];

	auto ownerId = dataJson["ownerId"].asString();
	auto matchId = dataJson["matchId"].asString();

	string ret;
	ruyiSDK->BCService->AsyncMatch_ReadMatch(ret, ownerId, matchId, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(70)
void BCServiceTest::BCS_AsyncMatch_SubmitTurn() 
{
	if (_tkMatchInfo.isNull() || 200 != _tkMatchInfo["status"].asInt()) 
	{
		return;
	}

	auto dataJson = _tkMatchInfo["data"];
	auto tkVer = dataJson["version"];
	auto nVer = tkVer.asInt64();

	auto ownerId = dataJson["ownerId"].asString();
	auto matchId = dataJson["matchId"].asString();

	string ret;
	ruyiSDK->BCService->AsyncMatch_SubmitTurn(ret, ownerId, matchId, nVer, "{\"num\": 22}", "", "", "", "", 0);

	dataJson["version"] = nVer + 1;
	++nVer;

	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->AsyncMatch_SubmitTurn(ret, ownerId, matchId, nVer, "{\"num\": 33}", "", "", "", "", 0);

	dataJson["version"] = nVer + 1;

	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(80)
void BCServiceTest::BCS_AsyncMatch_ReadMatchHistory() 
{
	if (_tkMatchInfo.isNull() || 200 != _tkMatchInfo["status"].asInt())
	{
		return;
	}

	auto dataJson = _tkMatchInfo["data"];

	auto ownerId = dataJson["ownerId"].asString();
	auto matchId = dataJson["matchId"].asString();

	string ret;
	ruyiSDK->BCService->AsyncMatch_ReadMatchHistory(ret, ownerId, matchId, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(90)
void BCServiceTest::BCS_AsyncMatch_CompleteMatch() 
{
	if (_tkMatchInfo.isNull() || 200 != _tkMatchInfo["status"].asInt())
	{
		return;
	}

	auto dataJson = _tkMatchInfo["data"];

	auto ownerId = dataJson["ownerId"].asString();
	auto matchId = dataJson["matchId"].asString();

	string ret;
	ruyiSDK->BCService->AsyncMatch_CompleteMatch(ret, ownerId, matchId, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(100)
void BCServiceTest::BCS_AsyncMatch_FindCompleteMatches() 
{
	string ret;
	ruyiSDK->BCService->AsyncMatch_FindCompleteMatches(ret, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	BCS_AsyncMatch_DeleteMatch();
}

//order(110)
void BCServiceTest::BCS_AsyncMatch_CreateMatchWithInitialTurn() 
{
	string playersJson = "[{ \"platform\": \"BC\", \"id\": \"" + _playerId1 + "\" }]";
	string matchStateJson = "{\"level\": 4}";
	string matchSummaryJson = "{\"teamPoints\": 32}";

	string ret;
	ruyiSDK->BCService->AsyncMatch_CreateMatchWithInitialTurn(ret, playersJson, matchStateJson, "You've been challenged again!", _playerId2, matchSummaryJson, 0);

	if (JsonReader.parse(ret, _tkMatchInfo)) 
	{
		Assert::IsTrue(200 == _tkMatchInfo["status"].asInt64());
	}
}

//order(120)
void BCServiceTest::BCS_AsyncMatch_AbandonMatch() 
{
	if (_tkMatchInfo.isNull() || 200 != _tkMatchInfo["status"].asInt()) 
	{
		return;
	}

	auto dataJson = _tkMatchInfo["data"];

	auto ownerId = dataJson["ownerId"].asString();
	auto matchId = dataJson["matchId"].asString();

	string ret;
	ruyiSDK->BCService->AsyncMatch_AbandonMatch(ret, ownerId, matchId, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(130)
void BCServiceTest::BCS_AsyncMatch_DeleteMatch() 
{
	if (_tkMatchInfo.isNull() || 200 != _tkMatchInfo["status"].asInt())
	{
		return;
	}

	auto dataJson = _tkMatchInfo["data"];

	auto ownerId = dataJson["ownerId"].asString();
	auto matchId = dataJson["matchId"].asString();

	string ret;
	ruyiSDK->BCService->AsyncMatch_DeleteMatch(ret, ownerId, matchId, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	_tkMatchInfo.clear();
}
#pragma endregion

#pragma region DataStream
//order(140)
void BCServiceTest::BCS_DataStream_CustomPageEvent()
{
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);

	string ret;
	ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "ray.t001@163.com", "111", true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string jsonEventData = "{\"test\": 1332}";
	ruyiSDK->BCService->DataStream_CustomPageEvent(ret, "testPageEvent", jsonEventData, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(400 == root["status"].asInt64());
	}
}

//order(150)
void BCServiceTest::BCS_DataStream_CustomScreenEvent() 
{
	string jsonEventData = "{\"test\": 1332}";
	string ret;
	ruyiSDK->BCService->DataStream_CustomScreenEvent(ret, "testScreenEvent", jsonEventData, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(400 == root["status"].asInt64());
	}
}

//order(160)
void BCServiceTest::BCS_DataStream_CustomTrackEvent() 
{
	string jsonEventData = "{\"test\": 1332}";
	string ret;
	ruyiSDK->BCService->DataStream_CustomTrackEvent(ret, "testTrackEvent", jsonEventData, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(400 == root["status"].asInt64());
	}
}
#pragma endregion DataStream

#pragma region Entity
//order(170)
void BCServiceTest::BCS_Entity_CreateEntity() 
{
	LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1000 Carling\"}";
	string acl = "{\"other\": 0}";

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(190)
void BCServiceTest::BCS_Entity_GetList() 
{
	LoginTestUser();

	string whereJson = "{\"entityType\": \"address\"}";
	string orderByJson = "{\"data.street\": 1}";

	string ret;
	ruyiSDK->BCService->Entity_GetList(ret, whereJson, orderByJson, 5, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(200)
void BCServiceTest::BCS_Entity_GetListCount() 
{
	LoginTestUser();

	string whereJson = "{\"entityType\": \"address\"}";

	string ret;
	ruyiSDK->BCService->Entity_GetListCount(ret, whereJson, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(210)
void BCServiceTest::BCS_Entity_GetEntity() 
{
	LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1002 Carling\"}";
	string acl = "{\"other\": 2}";

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string entityId = root["data"]["entityId"].asString();

	ruyiSDK->BCService->Entity_GetEntity(ret, entityId, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(220)
void BCServiceTest::BCS_Entity_GetEntitiesByType() 
{
	LoginTestUser();

	string entityType = "address";

	string ret;
	ruyiSDK->BCService->Entity_GetEntitiesByType(ret, entityType, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(230)
void BCServiceTest::BCS_Entity_GetPage() 
{
	LoginTestUser();

	string jsonContext = "{\"pagination\": {\"rowsPerPage\": 2,\"pageNumber\": 1},\"searchCriteria\": {\"entityType\": \"address\"},\"sortCriteria\": {\"createdAt\": 1,\"updatedAt\": -1}}";

	string ret;
	ruyiSDK->BCService->Entity_GetPage(ret, jsonContext, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	_entityPageContext = root["data"]["context"].asString();
}

//order(240)
void BCServiceTest::BCS_Entity_GetPageOffset() 
{
	LoginTestUser();

	if (0 == _entityPageContext.compare("")) 
	{
		BCS_Entity_GetPage();
	}

	string ret;
	ruyiSDK->BCService->Entity_GetPageOffset(ret, _entityPageContext, 1, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(250)
void BCServiceTest::BCS_Entity_GetSharedEntityForProfileId() 
{
	LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1003 Carling\"}";
	string acl = "{\"other\": 1}";

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string profileId = _TestUserInfoRoot["data"]["profileId"].asString();
	string entityId = root["data"]["entityId"].asString();

	ruyiSDK->BCService->Entity_GetSharedEntityForProfileId(ret, profileId, entityId, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(260)
void BCServiceTest::BCS_Entity_GetSharedEntitiesForProfileId() 
{
	LoginTestUser();

	string profileId = _TestUserInfoRoot["data"]["profileId"].asString();

	string ret;
	ruyiSDK->BCService->Entity_GetSharedEntitiesForProfileId(ret, profileId, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(270)
void BCServiceTest::BCS_Entity_GetSharedEntitiesListForProfileId() 
{
	LoginTestUser();

	string profileId = _TestUserInfoRoot["data"]["profileId"].asString();
	string whereJson = "{\"entityType\": \"address\"}";
	string orderByJson = "{\"data.street\": 1 }";

	string ret;
	ruyiSDK->BCService->Entity_GetSharedEntitiesListForProfileId(ret, profileId, whereJson, orderByJson, 10, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(280)
void BCServiceTest::BCS_Entity_IncrementUserEntityData() 
{
	LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1004 Carling\"}";
	string acl = "{\"other\": 1}";

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string entityId = root["data"]["entityId"].asString();
	string jsonData = "{\"test\" : 123 }";

	ruyiSDK->BCService->Entity_IncrementUserEntityData(ret, entityId, jsonData, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(290)
void BCServiceTest::BCS_Entity_IncrementSharedUserEntityData() 
{
	auto profileId = LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1005 Carling\"}";
	string acl = "{\"other\": 1}";
	
	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	//string profileId = _TestUserInfoRoot["data"]["profileId"].asString();
	string entityId = root["data"]["entityId"].asString();
	string jsonData = "{\"test\" : 3 }";

	ruyiSDK->BCService->Entity_IncrementSharedUserEntityData(ret, entityId, profileId, jsonData, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(300)
void BCServiceTest::BCS_Entity_UpdateEntity() 
{
	LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1006 Carling\"}";
	string acl = "{\"other\": 0}";

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string entityId = root["data"]["entityId"].asString();
	int version = root["data"]["version"].asInt();
	string entityNewDataJson = "{\"street\": \"1007 Carling Avenue, Ottawa, ON\"}";

	ruyiSDK->BCService->Entity_UpdateEntity(ret, entityId, entityType, entityNewDataJson, acl, version, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(320)
void BCServiceTest::BCS_Entity_UpdateSharedEntity()
{
	LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1009 Carling\"}";
	string acl = "{\"other\": 2}";

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string profileId = _TestUserInfoRoot["data"]["profileId"].asString();
	string entityId = root["data"]["entityId"].asString();
	int version = root["data"]["version"].asInt();

	LoginTestUser("ray.t002@163.com", "111");

	string entityNewDataJson = "{\"street\": \"1009 Shanghai Pudong\"}";

	ruyiSDK->BCService->Entity_UpdateSharedEntity(ret, entityId, profileId, entityType, entityNewDataJson, version, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(330)
void BCServiceTest::BCS_Entity_DeleteEntity() 
{
	LoginTestUser();

	string entityType = "address";
	string entityDataJson = "{\"street\": \"1009 Carling\"}";
	string acl = "{\"other\": 2}";

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, entityType, entityDataJson, acl, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string entityId = root["data"]["entityId"].asString();
	int version = root["data"]["version"].asInt();

	ruyiSDK->BCService->Entity_DeleteEntity(ret, entityId, version, 0);

	ruyiSDK->BCService->Entity_GetEntity(ret, entityId, 0);
	Assert::IsTrue(0 == ret.compare(""));
}

//order(340)
void BCServiceTest::BCS_Entity_UpdateSingleton() 
{
	LoginTestUser();

	string entityType = "settings";
	string entityDataJson = "{\"volume\": 63}";
	string acl = "{\"acl\": {\"other\": 2} }";
	int version = -1;

	string ret;
	ruyiSDK->BCService->Entity_UpdateSingleton(ret, entityType, entityDataJson, acl, version, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(350)
void BCServiceTest::BCS_Entity_GetSingleton() 
{
	LoginTestUser();

	string entityType = "settings";
	string ret;
	ruyiSDK->BCService->Entity_GetSingleton(ret, entityType, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(360)
void BCServiceTest::BCS_Entity_DeleteSingleton() 
{
	LoginTestUser();

	string entityType = "settings";

	string ret;
	ruyiSDK->BCService->Entity_DeleteSingleton(ret, entityType, -1, 0);
	ruyiSDK->BCService->Entity_GetSingleton(ret, entityType, 0);
	Assert::AreEqual(ret.c_str(), "");
}
#pragma endregion Entity

#pragma region Event
//order(400)
void BCServiceTest::BCS_Event_SendEvent() 
{
	LoginTestUser("", "", true);
	string profileId = _TestUserInfoRoot["data"]["profileId"].asString();
	string eventType = "testType1";
	string jsonEventData = "{\"msg\": \"Nice to meet you!\"}";

	LoginTestUser("ray.t002@163.com", "111", true);
	string ret;
	ruyiSDK->BCService->Event_SendEvent(ret, profileId, eventType, jsonEventData, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(410)
void BCServiceTest::BCS_Event_GetEvents() 
{
	LoginTestUser("", "", true);

	string ret;
	ruyiSDK->BCService->Event_GetEvents(ret, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	Json::Value events = root["data"]["incoming_events"];
	if (!events.isNull() && events.size() > 0) 
	{
		_TestEventId = events[0]["evId"].asString();
		char tmp[128];
		sprintf(tmp, "Test Event ID is: %d", _TestEventId);
		Logger::WriteMessage(tmp);
	}
}

//order(420)
void BCServiceTest::BCS_Event_UpdateIncomingEventData() 
{
	if (_TestEventId.empty()) 
	{
		BCS_Event_GetEvents();
	} else 
	{
		LoginTestUser();
	}

	string jsonEventData = "{\"msg\": \"Nice to meet you too!\"}";

	string ret;
	ruyiSDK->BCService->Event_UpdateIncomingEventData(ret, _TestEventId, jsonEventData, 0);

	ruyiSDK->BCService->Event_GetEvents(ret, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	Json::Value events = root["data"]["incoming_events"];
	for (int i = 0; i < events.size(); ++i) 
	{
		if (0 == _TestEventId.compare(events[i]["evId"].asString())) 
		{
			string evtData = events[i]["eventData"]["msg"].asString();
			Assert::IsTrue(0 == evtData.compare("Nice to meet you too!"));
		}
	}
}

//order(430)
void BCServiceTest::BCS_Event_DeleteIncomingEvent() 
{
	char tmp[128];
	sprintf(tmp, "In BCS_Event_DeleteIncomingEvent, Test Event ID is: %d", _TestEventId);
	Logger::WriteMessage(tmp);

	if (_TestEventId.empty()) 
	{
		BCS_Event_GetEvents();
	} else 
	{
		LoginTestUser();
	}

	string ret;
	ruyiSDK->BCService->Event_DeleteIncomingEvent(ret, _TestEventId, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
		Assert::IsTrue(root["data"]["deleted"].asBool());
	}
}
#pragma endregion

#pragma region File
//order(440)
void BCServiceTest::BCS_File_UploadFile() 
{
	LoginTestUser();

	string cloudPath = "test/files";

	// get the layer0
	string currentFolder = GetLocalCurrentDirectory();
	string localPath = currentFolder + "..\\..\\..\\..\\Commons\\Resources\\Configs\\SystemSetting\\SystemSetting.cfg";
	struct stat buffer;
	Assert::AreEqual(stat(localPath.c_str(), &buffer), 0);

	string ret;
	ruyiSDK->BCService->File_UploadFile(ret, cloudPath, "testCloudFile_shared.cfg", true, true, localPath, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->File_UploadFile(ret, cloudPath, "testCloudFile_private.cfg", false, true, localPath, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(445)
void BCServiceTest::BCS_File_GetCDNUrl() 
{
	LoginTestUser();

	string cloudPath = "test/files";
	string cloudFileName = "testCloudFile_shared.cfg";

	string ret;
	ruyiSDK->BCService->File_GetCDNUrl(ret, cloudPath, cloudFileName, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	std::cout << "The CDNUrl of " << cloudFileName << " is " << root["data"]["cdnUrl"].asString() << std::endl;
}

struct fileUploadData 
{
	RuyiSDK* ruyiSDK;
	string uploadId;
	long totalBytes;
};
unsigned int __stdcall fileUpload(void *pPM)
{
	fileUploadData* pData = (fileUploadData*)pPM;
	double progress = 0;
	long transferredBytes = 0;
	while (!_bFileUploadFinished)
	{
		progress = pData->ruyiSDK->BCService->File_GetUploadProgress(pData->uploadId, 0);
		transferredBytes = pData->ruyiSDK->BCService->File_GetUploadBytesTransferred(pData->uploadId, 0);

		Logger::WriteMessage(("FileUpload progress: " + to_string(progress) + ", transferred/total: " + to_string(transferredBytes) + "/" + to_string(pData->totalBytes)).c_str());

		Sleep(300);
	}

	return 0;
}

//order(450)
void BCServiceTest::BCS_File_GetUploadProgressAndBytes() 
{
	LoginTestUser();

	string cloudPath = "test/files";

	string currentFolder = GetLocalModuleFileName();
	string localPath = currentFolder + "\\libzmq.dll";

	_bFileUploadFinished = false;

	string ret;
	ruyiSDK->BCService->File_UploadFile(ret, cloudPath, "testdll_1906kb.dll", true, true, localPath, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string uploadId = root["data"]["fileDetails"]["uploadId"].asString();

	int64_t totalBytes = ruyiSDK->BCService->File_GetUploadTotalBytesToTransfer(uploadId, 0);

	fileUploadData data;
	data.ruyiSDK = ruyiSDK;
	data.uploadId = uploadId;
	data.totalBytes = totalBytes;
	HANDLE h =  (HANDLE)_beginthreadex(NULL, 0, fileUpload, &data, 0, NULL);

	WaitForSingleObject(h, 60000);
	Assert::IsTrue(_bFileUploadFinished);
}

//order(470)
void BCServiceTest::BCS_File_CancelUpload() 
{
	LoginTestUser();

	string cloudPath = "test/files";

	//string currentFolder = System.IO.Path.GetDirectoryName(sdk.GetType().Assembly.Location);
	string currentFolder = GetLocalCurrentDirectory(); //??? I don't know how to achieve this in cpp
	string localPath = currentFolder + "//ServiceGenerated.dll";

	//fstream file;
	//file.open(localPath);
	FILE* file = fopen(localPath.c_str(), "r");
	Assert::IsNotNull(file);

	_bFileUploadFinished = false;

	string ret;
	ruyiSDK->BCService->File_UploadFile(ret, cloudPath, "WillBeCancelled_1906kb.dll", true, true, localPath, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string uploadId = root["data"]["fileDetails"]["uploadId"].asString();
	ruyiSDK->BCService->File_CancelUpload(uploadId, 0);

	Sleep(1000);

	auto progress = ruyiSDK->BCService->File_GetUploadProgress(uploadId, 0);
	Assert::IsTrue(progress <= 0);
}

//order(480)
void BCServiceTest::BCS_File_ListUserFiles() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->File_ListUserFiles_SFO(ret, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->File_ListUserFiles_SNSFO(ret, "folderNotExist", false, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->File_ListUserFiles_SNSFO(ret, "test", false, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->File_ListUserFiles_SNSFO(ret, "test", true, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(490)
void BCServiceTest::BCS_File_DeleteFiles() 
{
	LoginTestUser();

	string cloudPath = "test/files";
	string cloudFileName = "testdll_1906kb.dll";

	string ret;
	ruyiSDK->BCService->File_DeleteUserFile(ret, cloudPath, cloudFileName, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue( 200 == root["status"].asInt64() || 400 == root["status"].asInt64() || 40432 == root["reason_code"].asInt64());
	}

	ruyiSDK->BCService->File_GetCDNUrl(ret, cloudPath, cloudFileName, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(400 == root["status"].asInt64() || 40432 == root["reason_code"].asInt64());
	}

	ruyiSDK->BCService->File_DeleteUserFiles(ret, "folderNotExist", true, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64() && 0 == root["data"]["fileList"].size());
	}

	ruyiSDK->BCService->File_DeleteUserFiles(ret, cloudPath, true, 0);
	Assert::IsTrue(200 == root["status"].asInt64());

	ruyiSDK->BCService->File_ListUserFiles_SFO(ret, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64() && 0 == root["data"]["fileList"].size());
	}
}
#pragma endregion

#pragma region Friend
//order(500)
void BCServiceTest::BCS_Friend_AddFriends() 
{
	string profileId1 = LoginTestUser("ray.t002@163.com", "111", true);
	string profileId2 = LoginTestUser("ray.t003@163.com", "111", true);

	LoginTestUser("", "", true);

	std::vector<string> vecFriendId{ profileId1, profileId2 };

	string ret;
	ruyiSDK->BCService->Friend_AddFriends(ret, vecFriendId, 0);

	ruyiSDK->BCService->Friend_ListFriends(ret, Ruyi::SDK::BrainCloudApi::FriendPlatform::brainCloud, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	Json::Value friends = root["data"]["friends"];
	Assert::IsTrue(!(friends.isNull()));

	bool bFindProfile1 = false;
	bool bFindProfile2 = false;

	for (int i = 0; i < friends.size(); ++i) 
	{
		string friId = friends[i]["playerId"].asString();
		if (0 == friId.compare(profileId1)) 
		{
			bFindProfile1 = true;
		}

		if (0 == friId.compare(profileId2)) 
		{
			bFindProfile2 = true;
		}
	}

	Assert::IsTrue(bFindProfile1 && bFindProfile2);
}

//order(510)
void BCServiceTest::BCS_Friend_ListFirends() 
{
	LoginTestUser();
	
	string ret;
	ruyiSDK->BCService->Friend_ListFriends(ret, Ruyi::SDK::BrainCloudApi::FriendPlatform::brainCloud, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(520)
void BCServiceTest::BCS_Friend_ReadFriendEntity() 
{
	string profileId1 = LoginTestUser("ray.t002@163.com", "111", true);

	string ret;
	ruyiSDK->BCService->Entity_CreateEntity(ret, "FirentTestType", "{\"age\": 18}", "{\"other\": 0}", 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string entityId = root["data"]["entityId"].asString();

	LoginTestUser("", "", true);

	ruyiSDK->BCService->Friend_ReadFriendEntity(ret, entityId, profileId1, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(530)
void BCServiceTest::BCS_Friend_ReadFriendsEntities() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Friend_ReadFriendsEntities(ret, "address", 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(540)
void BCServiceTest::BCS_Friend_ReadFriendUserState() 
{
	string profileId = LoginTestUser("ray.t002@163.com", "111", true);

	LoginTestUser("", "", true);

	string ret;
	ruyiSDK->BCService->Friend_ReadFriendUserState(ret, profileId, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(550)
void BCServiceTest::BCS_Friend_FindUserByUniversalId()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Friend_FindUserByUniversalId(ret, "ray", 10, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(560)
void BCServiceTest::BCS_Friend_FindUserByExactName()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Friend_FindUsersByExactName(ret, "ray.t001", 10, 0);

	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(570)
void BCServiceTest::BCS_Friend_FindUsersBySubstrName() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Friend_FindUsersBySubstrName(ret, "ray", 10, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(580)
void BCServiceTest::BCS_Friend_GetExternalIdForProfileId() 
{
	auto profileId = LoginTestUser();

	string ret;
	ruyiSDK->BCService->Friend_GetExternalIdForProfileId(ret, profileId, "Email", 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(590)
void BCServiceTest::BCS_Friend_GetProfileInfoForCredential() 
{
	auto profileId = LoginTestUser();

	string ret;
	ruyiSDK->BCService->Friend_GetExternalIdForProfileId(ret, profileId, "Email", 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	auto externalId = root["data"]["externalId"].asString();

	ruyiSDK->BCService->Friend_GetProfileInfoForCredential(ret, externalId, "Email", 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(600)
void BCServiceTest::BCS_Friend_GetSummaryDataForProfileId()
{
	auto profileId = LoginTestUser();

	string ret;
	ruyiSDK->BCService->Friend_GetSummaryDataForProfileId(ret, profileId, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(610)
void BCServiceTest::BCS_Friend_GetUsersOnlineStatus() 
{
	auto profileId1 = LoginTestUser();
	auto profileId2 = LoginTestUser("ray.t002@163.com", "111", true);

	std::vector<string> vecIds;

	string ret;
	ruyiSDK->BCService->Friend_GetUsersOnlineStatus(ret, vecIds, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}
#pragma endregion

#pragma region Gamification
//order(620)
void BCServiceTest::BCS_Gamification_ReadAllGamification()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadAllGamification(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(630)
void BCServiceTest::BCS_Gamification_ReadXpLevelsMetaData()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadXpLevelsMetaData(ret, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(640)
void BCServiceTest::BCS_Gamification_AwardAchievements()
{
	LoginTestUser();

	std::vector<string> vecIds;

	string ret;
	ruyiSDK->BCService->Gamification_AwardAchievements(ret, vecIds, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(650)
void BCServiceTest::BCS_Gamification_ReadAchievements()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadAchievements(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(660)
void BCServiceTest::BCS_Gamification_ReadAchievedAchievements()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadAchievedAchievements(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(670)
void BCServiceTest::BCS_Gamification_ReadMilestones() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadMilestones(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(680)
void BCServiceTest::BCS_Gamification_ReadMilestonesByCategory()
{
	LoginTestUser();
	
	string ret;
	ruyiSDK->BCService->Gamification_ReadMilestonesByCategory(ret, "", true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(690)
void BCServiceTest::BCS_Gamification_ReadInProgressMilestones() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadInProgressMilestones(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(700)
void BCServiceTest::BCS_Gamification_ReadCompletedMilestones() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadCompletedMilestones(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(710)
void BCServiceTest::BCS_Gamification_ResetMilestones()
{
	LoginTestUser();

	std::vector<string> vecIds;

	string ret;
	ruyiSDK->BCService->Gamification_ResetMilestones(ret, vecIds, 0);
}

//order(720)
void BCServiceTest::BCS_Gamification_ReadQuests()
{
	LoginTestUser();

	//std::vector<string> vecIds;

	string ret;
	ruyiSDK->BCService->Gamification_ReadQuests(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(730)
void BCServiceTest::BCS_Gamification_ReadQuestsByCategory()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadQuestsByCategory(ret, "", true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(740)
void BCServiceTest::BCS_Gamification_ReadQuestsWithStatus()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadQuestsWithStatus(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(750)
void BCServiceTest::BCS_Gamification_ReadQuestsWithBasicPercentage()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadQuestsWithBasicPercentage(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(760)
void BCServiceTest::BCS_Gamification_ReadQuestsWithComplexPercentage() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadQuestsWithComplexPercentage(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(770)
void BCServiceTest::BCS_Gamification_ReadNotStartedQuests()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadNotStartedQuests(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(780)
void BCServiceTest::BCS_Gamification_ReadInProgressQuests()
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadInProgressQuests(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(790)
void BCServiceTest::BCS_Gamification_ReadCompletedQuests() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->Gamification_ReadCompletedQuests(ret, true, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}
#pragma endregion

#pragma region GlobalApp
//order(800)
void BCServiceTest::BCS_GlobalApp_ReadProperties() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->GlobalApp_ReadProperties(ret, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}
#pragma endregion

#pragma region GlobalEntity
//order(810)
void BCServiceTest::BCS_GlobalEntity_CreateEntity() 
{
	LoginTestUser();

	string entityType = "G_Address";
	string entityDataJson = "{\"street\": \"1000 Carling\"}";
	string acl = "{\"other\": 2}";

	string ret;
	ruyiSDK->BCService->GlobalEntity_CreateEntity(ret, entityType, 600000, acl, entityDataJson, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(820)
void BCServiceTest::BCS_GlobalEntity_CreateEntityWithIndexedId() 
{
	LoginTestUser();

	string entityType = "G_Address";
	string indexedId = "testIndex";
	string entityDataJson = "{\"street\": \"1000 Carling\"}";
	string acl = "{\"other\": 2}";

	string ret;
	ruyiSDK->BCService->GlobalEntity_CreateEntityWithIndexedId(ret, entityType, indexedId, 600000, acl, entityDataJson, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(830)
void BCServiceTest::BCS_GlobalEntity_DoEntityUpdates() 
{
	auto profileId1 = LoginTestUser("ray.t002@163.com", "111", true);
	auto profileId2 = LoginTestUser("ray.t001@163.com", "111", true);

	string entityType = "G_Address";
	string indexedId = "testIndex2";
	string entityDataJson = "{\"street\": \"1001 SiChuan\"}";
	string acl = "{\"other\": 1}";

	string ret;
	ruyiSDK->BCService->GlobalEntity_CreateEntityWithIndexedId(ret, entityType, indexedId, 600000, acl, entityDataJson, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	auto entityId = root["data"]["entityId"].asString();
	auto version = root["data"]["version"].asInt();
	string entityNewDataJson = "{\"street\": \"1002 ChongQing\"}";

	ruyiSDK->BCService->GlobalEntity_UpdateEntity(ret, entityId, version, entityNewDataJson, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
	version = root["data"]["version"].asInt();
	acl = "{\"other\": 2}";

	ruyiSDK->BCService->GlobalEntity_UpdateEntityAcl(ret, entityId, version, acl, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
	version = root["data"]["version"].asInt();

	ruyiSDK->BCService->GlobalEntity_UpdateEntityTimeToLive(ret, entityId, version, 100000, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
	version = root["data"]["version"].asInt();
	acl = "{\"other\": 2}";

	ruyiSDK->BCService->GlobalEntity_UpdateEntityOwnerAndAcl(ret, entityId, version, profileId1, acl, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	auto increaseJson = "{\"testAdd\": 3542}";

	ruyiSDK->BCService->GlobalEntity_IncrementGlobalEntityData(ret, entityId, increaseJson, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(835)
void BCServiceTest::BCS_GlobalEntity_Retrieval() 
{
	LoginTestUser();

	string entityType = "G_Address";
	string entityDataJson = "{\"street\": \"34134 BeiJing\"}";
	string acl = "{\"other\": 2}";

	string ret;
	ruyiSDK->BCService->GlobalEntity_CreateEntity(ret, entityType, 600000, acl, entityDataJson, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
	auto entityId = root["data"]["entityId"].asString();

	auto whereJson = "{\"entityType\": \"G_Address\"}";
	auto orderByJson = "{\"data.street\" : 1}";

	ruyiSDK->BCService->GlobalEntity_GetList(ret, whereJson, orderByJson, 10, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string indexedId = "testIndex";
	ruyiSDK->BCService->GlobalEntity_GetListByIndexedId(ret, indexedId, 10, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->GlobalEntity_GetListCount(ret, whereJson, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	ruyiSDK->BCService->GlobalEntity_ReadEntity(ret, entityId, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	string jsonContext = "{\"pagination\": {\"rowsPerPage\": 2,\"pageNumber\": 1},\"searchCriteria\": {\"entityType\": \"G_Address\"},\"sortCriteria\": {\"createdAt\": 1,\"updatedAt\": -1}}";

	ruyiSDK->BCService->GlobalEntity_GetPage(ret, jsonContext, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	auto context = root["data"]["context"].asString();

	ruyiSDK->BCService->GlobalEntity_GetPageOffset(ret, context, 1, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(840)
void BCServiceTest::BCS_GlobalEntity_SystemEntities() 
{
	LoginTestUser();

	string entityType = "G_Address";
	string entityDataJson = "{\"street\": \"11991 NanJing\"}";
	string acl = "{\"other\": 1}";

	string ret;
	ruyiSDK->BCService->GlobalEntity_CreateEntity(ret, entityType, 600000, acl, entityDataJson, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
	auto entityId = root["data"]["entityId"].asString();
	auto version = root["data"]["version"].asInt();
	acl = "{\"other\": 2}";
	
	ruyiSDK->BCService->GlobalEntity_MakeSystemEntity(ret, entityId, version, acl, 0);
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(850)
void BCServiceTest::BCS_GlobalEntity_DeleteEntities()
{
	LoginTestUser();

	auto whereJson = "{\"entityType\": \"G_Address\"}";
	auto orderByJson = "{\"data.street\" : 1}";

	string ret;
	ruyiSDK->BCService->GlobalEntity_GetList(ret, whereJson, orderByJson, 30, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	auto entityList = root["data"]["entityList"];
	for (int i = 0; i < entityList.size(); ++i) 
	{
		auto entId = entityList[i]["entityId"].asString();
		int ver = entityList[i]["version"].asInt();
		string delRet;
		ruyiSDK->BCService->GlobalEntity_DeleteEntity(delRet, entId, ver, 0);
		Assert::IsTrue(0 == delRet.compare(""));
	}

	ruyiSDK->BCService->GlobalEntity_GetListCount(ret, whereJson, 0);
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}

	auto count = root["data"]["entityListCount"].asInt();
	Assert::IsTrue(0 == count);
}
#pragma endregion


#pragma region GlobalStatistics
//order(860)
void BCServiceTest::BCS_GlobalStatistics_IncrementGlobalStats() 
{
	LoginTestUser();

	string statJson = "{\"TestStat\": \"RESET\" }";
	string ret;
	ruyiSDK->BCService->GlobalStatistics_IncrementGlobalStats(ret, statJson, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(870)
void BCServiceTest::BCS_GlobalStatistics_ProcessStatistics() 
{
	LoginTestUser();

	std::map<string, string> statsData;
	statsData.insert(std::make_pair("INNING", "INC#1"));
	statsData.insert(std::make_pair("INNINGSREM", "DEC#1"));
	statsData.insert(std::make_pair("OUTS", "RESET"));
	statsData.insert(std::make_pair("POINTS", "INC_TO_LIMIT#5#30"));
	statsData.insert(std::make_pair("PLAYERS", "SET#8"));

	string ret;
	ruyiSDK->BCService->GlobalStatistics_ProcessStatistics(ret, statsData, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root)) 
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(880)
void BCServiceTest::BCS_GlobalStatistics_ReadAllGlobalStats() 
{
	LoginTestUser();
	string ret;
	ruyiSDK->BCService->GlobalStatistics_ReadAllGlobalStats(ret, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(890)
void BCServiceTest::BCS_GlobalStatistics_ReadGlobalStatsForCategory() 
{
	LoginTestUser();

	string ret;
	ruyiSDK->BCService->GlobalStatistics_ReadGlobalStatsForCategory(ret, "Test", 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

//order(900)
void BCServiceTest::BCS_GlobalStatistics_ReadGlobalStatsSubset() 
{
	LoginTestUser();

	std::vector<string> globalStats{ "TestStat" };
	string ret;
	ruyiSDK->BCService->GlobalStatistics_ReadGlobalStatsSubset(ret, globalStats, 0);
	Json::Value root;
	if (JsonReader.parse(ret, root))
	{
		Assert::IsTrue(200 == root["status"].asInt64());
	}
}

#pragma endregion


string BCServiceTest::LoginTestUser(string user, string pass, bool bRelogin) 
{
	if (!bRelogin) 
	{
		string proid = _TestUserInfoRoot["data"]["profileId"].asString();
		if (!proid.empty())
			return proid;
	}
	
	ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
	if (user.empty() || pass.empty()) 
	{
		user = "ray.t001@163.com";
		pass = "111";
	}

	string ret;
	ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, user, pass, true, 0);
	if (JsonReader.parse(ret, _TestUserInfoRoot))
	{
		Assert::IsTrue(_TestUserInfoRoot["status"].asInt64() == 200);
	}
	return _TestUserInfoRoot["data"]["profileId"].asString();
}