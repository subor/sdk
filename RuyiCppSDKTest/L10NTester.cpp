#include "CppUnitTest.h"

#include "TestCase\L10NServiceTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace RuyiCppSDKTest
{
	TEST_CLASS(L10NTester)
	{
	public:
		static L10NServiceTest* pL10NServiceTest;

		TEST_CLASS_INITIALIZE(ClassInitialize)
		{
			pL10NServiceTest = new L10NServiceTest();
		}
		TEST_CLASS_CLEANUP(ClassCleanup)
		{
			delete pL10NServiceTest;
			pL10NServiceTest = NULL;
		}

		//order(10)
		TEST_METHOD(L10NServ_SwitchLanguageToCN)
		{
			pL10NServiceTest->L10NServ_SwitchLanguageToCN();
		}

		//order(11)
		TEST_METHOD(L10NServ_SwitchLanguageToEN)
		{
			pL10NServiceTest->L10NServ_SwitchLanguageToEN();
		}

		//order(20)
		TEST_METHOD(L10NServ_SwitchContext)
		{
			pL10NServiceTest->L10NServ_SwitchContext();
		}

		//order(30)
		TEST_METHOD(L10NServ_HintContext)
		{
			pL10NServiceTest->L10NServ_HintContext();
		}

		//order(40)
		TEST_METHOD(L10NServ_GetString)
		{
			pL10NServiceTest->L10NServ_GetString();
		}

		//order(41)
		TEST_METHOD(L10NServ_GetStrings_language)
		{
			pL10NServiceTest->L10NServ_GetStrings_language();
		}

		//order(42)
		TEST_METHOD(L10NServ_GetStrings_context)
		{
			pL10NServiceTest->L10NServ_GetStrings_context();
		}

		//order(43)
		TEST_METHOD(L10NServ_GetStrings_all)
		{
			pL10NServiceTest->L10NServ_GetStrings_all();
		}

		//order(50)
		TEST_METHOD(L10NServ_GetFileNameVirtual)
		{
			pL10NServiceTest->L10NServ_GetFileNameVirtual();
		}

		//order(60)
		TEST_METHOD(L10NServ_GetFileNameActual)
		{
			pL10NServiceTest->L10NServ_GetFileNameActual();
		}

		//order(61)
		TEST_METHOD(L10NServ_GetFileNameActualInSubContext)
		{
			pL10NServiceTest->L10NServ_GetFileNameActualInSubContext();
		}
	};

	L10NServiceTest* L10NTester::pL10NServiceTest;
}