#include "stdafx.h"
#include "CppUnitTest.h"

#include "TestCase\Layer0Test.h"
#include "TestCase\StorageLayerTest.h"
#include "TestCase\SettingSystemTest.h"
#include "TestCase\BCServiceTest.h"
#include "TestCase\InputManagerTest.h"
#include "TestCase\L10NServiceTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

#define STORAGE_TEST(T_NAME, t_path, t_result) \
TEST_METHOD(##T_NAME##_hdd)	\
{	\
	Assert::AreNotEqual(layer0Root.c_str(), "");		\
	pStorageLayerTest->TestGetPath("/<HDD0>/", "hdd0", layer0Root, t_path, t_result);	\
}	\
TEST_METHOD(##T_NAME##_cache)	\
{	\
	Assert::AreNotEqual(layer0Root.c_str(), "");		\
	pStorageLayerTest->TestGetPath("/<HTTPHDDCACHE>/", "httphddcache", layer0Root, t_path, t_result);	\
}

namespace RuyiCppSDKTest
{
	TEST_CLASS(StorageLayerTester)
	{
	public:
		static StorageLayerTest* pStorageLayerTest;

		// to get the running root of layer0, if this failed, sure all test will fail.
		static std::string layer0Root;

		TEST_CLASS_INITIALIZE(ClassInitialize)
		{
			pStorageLayerTest = new StorageLayerTest();

			std::string lp = pStorageLayerTest->GetLayer0Path();
			Logger::WriteMessage("layer0 root: ");
			Logger::WriteMessage(lp.c_str());
			layer0Root = lp;
		}
		TEST_CLASS_CLEANUP(ClassCleanup)
		{
			delete pStorageLayerTest;
			pStorageLayerTest = NULL;
		}

		STORAGE_TEST(StorageLayerTest_1, "New.txt", true);
		STORAGE_TEST(StorageLayerTest_2, "New.txt", true);
		STORAGE_TEST(StorageLayerTest_3, "/New.txt", true);
		STORAGE_TEST(StorageLayerTest_4, "Newfolder/New.txt", true);
		STORAGE_TEST(StorageLayerTest_5, "/Newfolder/New.txt", true);
		STORAGE_TEST(StorageLayerTest_6, "Newfolder/New.txt", true);
		STORAGE_TEST(StorageLayerTest_7, "..", false);
		STORAGE_TEST(StorageLayerTest_8, "/..", false);
		STORAGE_TEST(StorageLayerTest_9, "../", false);
		STORAGE_TEST(StorageLayerTest_a, "../subdir", false);
		STORAGE_TEST(StorageLayerTest_b, "../../", false);
		STORAGE_TEST(StorageLayerTest_c, "../../subdir", false);
		STORAGE_TEST(StorageLayerTest_d, "../subdir/..", false);
	};

	StorageLayerTest* StorageLayerTester::pStorageLayerTest;
	std::string StorageLayerTester::layer0Root = "";
}