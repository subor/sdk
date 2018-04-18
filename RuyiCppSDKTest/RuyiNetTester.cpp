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

		TEST_METHOD(RUYINET_LeaderboardService)
		{
			pRuyiNetTest->Login();
			pRuyiNetTest->RuyiNet_Initialize();
			pRuyiNetTest->LeaderboardServiceTest();
		}

		TEST_METHOD(RUYINET_CloudService)
		{
			pRuyiNetTest->Login();
			pRuyiNetTest->RuyiNet_Initialize();
			pRuyiNetTest->CloudServiceTest();
		}

		TEST_METHOD(RUYINET_LobbyService)
		{
			pRuyiNetTest->Login();
			pRuyiNetTest->RuyiNet_Initialize();
			pRuyiNetTest->LobbyServiceTest();
		}

		TEST_METHOD(RUYINET_PartyService)
		{
			pRuyiNetTest->Login();
			pRuyiNetTest->RuyiNet_Initialize();
			pRuyiNetTest->PartyServiceTest();
		}

		TEST_METHOD(RUYINET_TelemetryService)
		{
			pRuyiNetTest->Login();
			pRuyiNetTest->RuyiNet_Initialize();
			pRuyiNetTest->TelemetryServiceTest();
		}
	};

	RuyiNetTest* RuyiNetTester::pRuyiNetTest;
}