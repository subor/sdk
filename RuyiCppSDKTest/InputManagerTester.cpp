#include "stdafx.h"
#include "CppUnitTest.h"

#include "TestCase\Layer0Test.h"
#include "TestCase\StorageLayerTest.h"
#include "TestCase\SettingSystemTest.h"
#include "TestCase\BCServiceTest.h"
#include "TestCase\InputManagerTest.h"
#include "TestCase\L10NServiceTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace RuyiCppSDKTest
{
	TEST_CLASS(InputManagerTester)
	{
	public:
		static InputManagerTest* pInputManagerTest;

		TEST_CLASS_INITIALIZE(ClassInitialize)
		{
			pInputManagerTest = new InputManagerTest();
		}

		TEST_CLASS_CLEANUP(ClassCleanup)
		{
			delete pInputManagerTest;
			pInputManagerTest = NULL;
		}

		TEST_METHOD(InputManagerReceive)
		{
			pInputManagerTest->InputManagerReceiveInputMessage();
		}

		TEST_METHOD(InputManagerVibration)
		{
			pInputManagerTest->InputManagerVibration();
		}
	};

	InputManagerTest* InputManagerTester::pInputManagerTest;
}
