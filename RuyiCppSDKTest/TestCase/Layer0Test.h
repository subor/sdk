#pragma once

#include <string>
#include <iostream>
#include <fstream>

#include <boost/property_tree/ptree.hpp>
#include <boost/property_tree/json_parser.hpp>
#include <boost/foreach.hpp>

//#include <boost/filesystem/operations.hpp>
//#include <boost/filesystem/path.hpp>
//#include <boost/filesystem/convenience.hpp>

#include <assert.h>
#include <direct.h>
#include <io.h>

#include "CppUnitTest.h"
//#include "BaseUnitTest.h"
#include "RuyiSDK.h"

#ifdef _DEBUG
#pragma comment(lib, "json_vc71_libmtd.lib")
#else
#pragma comment(lib, "json_vc71_libmt.lib")
#endif

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

class Layer0Test 
{
public:
	void Layer0StartStop();
	void Layer0Stop();

protected:
	std::string randomString();

private:
	//PROCESS_INFORMATION proc;
};

std::string& replace_all(std::string& str, const std::string& old_value, const std::string& new_value);

std::string GetLocalModuleFileName();

std::string GetLocalCurrentDirectory();

bool FileCopy(const char* src, const char* dst);

//temporay
//turn object instance into json string
//json example "{\"Jump\":[{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"C\"}],\"AutoTrigger\":false},{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"B\"}],\"AutoTrigger\":false}]}"
std::string doserializeActionTriggerInfo(std::vector<Ruyi::SDK::CommonType::ActionTriggerInfo*>& vec);

//turn json string into object instance
//json example:"[{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"C\"}],\"AutoTrigger\":false},{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"B\"}],\"AutoTrigger\":false}]"
void deserializeActionTriggerInfo(std::vector<Ruyi::SDK::CommonType::ActionTriggerInfo*>& vec, std::string json);

//turn one ActionTriggerInfo json string into object instance
//json example:"{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"B\"}],\"AutoTrigger\":false}"
void deserializeSingleActionTriggerInfo(Ruyi::SDK::CommonType::ActionTriggerInfo& ati, std::string json);

//TChar to std::string
std::string TCHAR2STRING(TCHAR *STR);

//if the directory is exited
//int GetFilePath(std::string &strFilePath); //no neccessary boost lib
//check if the fold of the path exit, if not, create
void CheckFilePath(std::string &filePath);