#pragma once

#include "Layer0Test.h"

using namespace Ruyi;

class BaseUnitTest 
{
public:
	BaseUnitTest(RuyiSDKContext::Endpoint endpoint = RuyiSDKContext::Endpoint::Console, string remoteAddress = "localhost");
	virtual ~BaseUnitTest();

protected:
	RuyiSDK* ruyiSDK;
};