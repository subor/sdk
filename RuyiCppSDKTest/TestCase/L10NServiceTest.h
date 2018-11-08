#pragma once

#include "Layer0Test.h"
#include "BaseUnitTest.h"

using namespace Ruyi;
using namespace Ruyi::SDK;
using namespace std;

class L10NServiceTest : public BaseUnitTest 
{
public:
	L10NServiceTest(RuyiSDKContext::Endpoint endpoint = RuyiSDKContext::Endpoint::Console, string remoteAddress = "localhost");

	void L10NServ_SwitchLanguageToCN(); //order(10)
	void L10NServ_SwitchLanguageToEN(); //order(11)
	void L10NServ_SwitchContext(); //order(20)
	void L10NServ_HintContext(); //order(30)
	void L10NServ_GetString(); //order(40)
	void L10NServ_GetStrings_language(); //order(41)
	void L10NServ_GetStrings_context(); //order(42)
	void L10NServ_GetStrings_all(); //order(43)

	void L10NServ_GetFileNameVirtual(); //order(50)
	void L10NServ_GetFileNameActual(); //order(60)
	void L10NServ_GetFileNameActualInSubContext(); //order(61)

private:
	SubscribeClient* sdkSubscriber;
};