#include "L10NServiceTest.h"

void OnLanguageChanged(string topic, apache::thrift::TBase* item)
{
	Logger::WriteMessage("OnLanguageChanged !!!");
}


L10NServiceTest::L10NServiceTest(RuyiSDKContext::Endpoint endpoint, string remoteAddress)
	:BaseUnitTest(endpoint, remoteAddress)
{
	const string* pChar = &Ruyi::SDK::Constants::g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri;
	string* modifier = const_cast<string*>(pChar);
	replace_all(*modifier, "{addr}", "localhost");

	auto pubout = Ruyi::SDK::Constants::g_ConstantsSDKDataTypes_constants.layer0_publisher_out_uri;

	sdkSubscriber = SubscribeClient::CreateInstance(pubout);
	sdkSubscriber->Subscribe("SER_L10NSERVICE");
	
	//MessageHandler<void, std::string, apache::thrift::TBase*>* mh = new MessageHandler<void, std::string, apache::thrift::TBase*>();
	//mh->AddHandler(OnLanguageChanged);

	//sdkSubscriber->AddMessageHandler(mh);
	sdkSubscriber->AddMessageHandler(OnLanguageChanged);
}


#pragma region Text Searching

//order(10)
void L10NServiceTest::L10NServ_SwitchLanguageToCN()
{
	bool result = ruyiSDK->L10NService->SwitchLanguage("zh-CN", true, false);
	Assert::IsTrue(result);
}

//order(11)
void L10NServiceTest::L10NServ_SwitchLanguageToEN()
{
	bool result = ruyiSDK->L10NService->SwitchLanguage("en-US", true, false);
	Assert::IsTrue(result);
}

//order(20)
void L10NServiceTest::L10NServ_SwitchContext()
{
	ruyiSDK->L10NService->SwitchLanguage("en-US", true, false);

	bool result = ruyiSDK->L10NService->SwitchContext("com.playruyi.strings.platformStarting", "");
	Assert::IsTrue(result);
}

//order(30)
void L10NServiceTest::L10NServ_HintContext()
{
	ruyiSDK->L10NService->SwitchContext("com.playruyi.strings.platformStarting", "");

	string result = "";
	ruyiSDK->L10NService->HintContext(result);
	Assert::AreNotEqual(result.c_str(), "");
}

//order(40)
void L10NServiceTest::L10NServ_GetString()
{
	Assert::IsTrue(ruyiSDK->L10NService->SwitchLanguage("en-US", true, false));
	Assert::IsTrue(ruyiSDK->L10NService->SwitchContext("com.playruyi.strings.platformStarting", ""));

	string result = "";
	ruyiSDK->L10NService->GetString(result, "Start_Loading", "", "");
	Assert::AreNotEqual(result.c_str(), "");
}

//order(41)
void L10NServiceTest::L10NServ_GetStrings_language()
{
	ruyiSDK->L10NService->SwitchLanguage("en-US", true, false);

	std::map<string, string> result;
	ruyiSDK->L10NService->GetStrings(result, "\\w*Language\\w*", "", "");
	Assert::IsTrue(result.size() > 0);
}

//order(42)
void L10NServiceTest::L10NServ_GetStrings_context()
{
	ruyiSDK->L10NService->SwitchLanguage("en-US", true, false);

	std::map<string, string> result;
	ruyiSDK->L10NService->GetStrings(result, "", "com.playruyi.strings.platformRunning", "");
	Assert::IsTrue(result.size() > 0);
}

//order(43)
void L10NServiceTest::L10NServ_GetStrings_all()
{
	ruyiSDK->L10NService->SwitchLanguage("en-US", true, false);

	std::map<string, string> result;
	ruyiSDK->L10NService->GetStrings(result, "", "", "");
	Assert::IsTrue(result.size() > 0);
}
#pragma endregion

#pragma region File Mapping
//order(50)
void L10NServiceTest::L10NServ_GetFileNameVirtual()
{
	string result = "";
	ruyiSDK->L10NService->GetFileName(result, "Images/logo.jpg", true, "");
	Assert::AreNotEqual(result.c_str(), "");
}

//order(60)
void L10NServiceTest::L10NServ_GetFileNameActual()
{
	string result = "";
	ruyiSDK->L10NService->GetFileName(result, "Images/logo.jpg", false, "com.playruyi.image.starting");
	Assert::AreNotEqual(result.c_str(), "");
}

//order(61)
void L10NServiceTest::L10NServ_GetFileNameActualInSubContext()
{
	string result = "";
	ruyiSDK->L10NService->GetFileName(result, "Images/logo.jpg", false, "com.playruyi.image");
	Assert::AreNotEqual(result.c_str(), "");
}

#pragma endregion