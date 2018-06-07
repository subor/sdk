#include "BaseUnitTest.h"

BaseUnitTest::BaseUnitTest(RuyiSDKContext::Endpoint endpoint, string remoteAddress)
{
	ruyiSDK = RuyiSDK::CreateSDKInstance(RuyiSDKContext(endpoint, remoteAddress));

	Assert::IsNotNull(ruyiSDK, L"create SDK instance failed!");
}

BaseUnitTest::~BaseUnitTest() 
{
	if (nullptr != ruyiSDK) 
	{
		delete ruyiSDK;
		ruyiSDK = nullptr;
	} 
}

