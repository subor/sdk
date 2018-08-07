#pragma once

#include "Layer0Test.h"
#include "BaseUnitTest.h"

using namespace Ruyi;
using namespace Ruyi::SDK;
using namespace Ruyi::SDK::StorageLayer;
using namespace std;

class StorageLayerTest : public BaseUnitTest
{
public:
	StorageLayerTest(RuyiSDKContext::Endpoint endpoint = RuyiSDKContext::Endpoint::Console, string remoteAddress = "localhost");

	void TestGetPath(string mouted, string local, string layer0, string path, bool valid);

	std::string GetLayer0Path();

private:
	string MountedRoot(string mountedRoot, string path = "");
	string LocalRoot(string source, string local, string path);
};