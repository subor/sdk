#include "StorageLayerTest.h"
#include <windows.h>

#include <filesystem>

void StringToWstring(std::wstring& szDst, std::string str)
{
	std::string temp = str;
	int len = MultiByteToWideChar(CP_ACP, 0, (LPCSTR)temp.c_str(), -1, NULL, 0);
	wchar_t * wszUtf8 = new wchar_t[len + 1];
	memset(wszUtf8, 0, len * 2 + 2);
	MultiByteToWideChar(CP_ACP, 0, (LPCSTR)temp.c_str(), -1, (LPWSTR)wszUtf8, len);
	szDst = wszUtf8;
	std::wstring r = wszUtf8;
	delete[] wszUtf8;
}

StorageLayerTest::StorageLayerTest(RuyiSDKContext::Endpoint endpoint, string remoteAddress)
	:BaseUnitTest(endpoint, remoteAddress)
{
}

struct StorageLayerTestPath
{
	string input;
	string output;
	bool result;
	StorageLayerTestPath(string _input, string _output, bool _result) : input(_input), output(_output), result(_result)
	{}
};

std::string StorageLayerTest::GetLayer0Path()
{
	StorageLayer::GetLocalPathResult result;
	ruyiSDK->Storage->GetLocalPath(result, "/<HDD0>/n.txt");
	size_t idx = result.path.find("RuyiLocalRoot");
	
	Assert::AreNotEqual((int)idx, -1);
	return result.path.substr(0, idx);
}

void StorageLayerTest::TestGetPath(string mouted, string local, string layer0, string path, bool valid)
{
	string mountRoot = MountedRoot(mouted, path);

	StorageLayer::GetLocalPathResult result;
	ruyiSDK->Storage->GetLocalPath(result, mountRoot);

	string cwd = GetLocalCurrentDirectory();
	string localPath = LocalRoot(layer0, local, path);

	std::string tt = "";
	tt.append("local: ").append(localPath);
	Logger::WriteMessage(tt.c_str());

	tt = "";
	tt.append("remote: ").append(result.path);
	Logger::WriteMessage(tt.c_str());
	Logger::WriteMessage("\n");
	valid ? Assert::AreEqual(localPath, result.path) : Assert::AreNotEqual(localPath, result.path);
}

string StorageLayerTest::MountedRoot(string mountedRoot, string path) 
{
	return mountedRoot + path;
}

string StorageLayerTest::LocalRoot(string source, string local, string path) 
{
	std::experimental::filesystem::path p;
	p.append(source).append("RuyiLocalRoot").append(local).append(path);
	return p.string();
}