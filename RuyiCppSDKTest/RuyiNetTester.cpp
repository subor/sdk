#include "CppUnitTest.h"

#include "TestCase\RuyiNetTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace RuyiCppSDKTest
{
	TEST_CLASS(RuyiNetTester) 
	{
	public:
		static RuyiNetTest* pRuyiNetTest;

		TEST_CLASS_INITIALIZE(ClassInitialize)
		{
			pRuyiNetTest = new RuyiNetTest();
		}

		TEST_CLASS_CLEANUP(ClassCleanup)
		{
			delete pRuyiNetTest;
			pRuyiNetTest = NULL;
		}

		TEST_METHOD(RUYINET_Initialize)
		{
			pRuyiNetTest->Login();
			pRuyiNetTest->RuyiNet_Initialize();
		}

		TEST_METHOD(RUYINET_FriendService)
		{
			pRuyiNetTest->Login();
			pRuyiNetTest->RuyiNet_Initialize();
			pRuyiNetTest->FriendServiceTest();
		}
	};

	RuyiNetTest* RuyiNetTester::pRuyiNetTest;
}