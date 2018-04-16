#pragma once

#include "Layer0Test.h"

#include "BaseUnitTest.h"
#include "RuyiNet/RuyiNetClient.h"

using namespace Ruyi;
using namespace Ruyi::SDK;
using namespace std;

class RuyiNetTest : public BaseUnitTest
{
public:
	RuyiNetTest(RuyiSDKContext::Endpoint endpoint = RuyiSDKContext::Endpoint::Console, std::string remoteAddress = "localhost");

	//temporary for test, RuyiNet should not provide Login function, use should always login in main client
	void Login();
	void RuyiNet_Initialize();
	void FriendServiceTest();

private:

};