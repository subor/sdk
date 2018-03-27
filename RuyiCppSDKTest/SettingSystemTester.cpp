#include "CppUnitTest.h"
#include "TestCase\SettingSystemTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace RuyiCppSDKTest
{
	TEST_CLASS(SettingSystemTester)
	{
	public:
		static SettingSystemTest* pSettingSystemTest;

		TEST_CLASS_INITIALIZE(ClassInitialize)
		{
			pSettingSystemTest = new SettingSystemTest();
		}
		TEST_CLASS_CLEANUP(ClassCleanup)
		{
			delete pSettingSystemTest;
			pSettingSystemTest = NULL;
		}

		/*
		* need to rewrite there tests, they're assuming the test case are running
		* in the same folder with layer0, which are not always true, they can even
		* running on different machine.*/
		TEST_METHOD(SettingSys_TestAll)
		{
			pSettingSystemTest->SettingSys_SimulateAppAInstalled();

			// we can't silulate login and change setting for apps because we don't have 
			// sdk internal for settings, 
			// TODO, implement this when Layer0 finished the function of apply setting after app launch.
//			pSettingSystemTest->SettingSys_SimulateLoginAndChangeSettings();

//			pSettingSystemTest->SettingSys_SimulateRestoreSettings();

			pSettingSystemTest->SettingSys_GetSettingTree();
		}
	};

	SettingSystemTest* SettingSystemTester::pSettingSystemTest;
}
