#include "Layer0Test.h"


void Layer0Test::Layer0StartStop()
{
	Assert::AreEqual(1, 1.001, 0.001);
}

void Layer0Test::Layer0Stop() {}

std::string Layer0Test::randomString()
{
	std::string ret;

	return ret;
}

std::string& replace_all(std::string& str, const std::string& old_value, const std::string& new_value)
{
	while (true)
	{
		std::string::size_type pos(0);
		if ((pos = str.find(old_value)) != std::string::npos)
		{
			str.replace(pos, old_value.length(), new_value);
		}
		else
		{
			break;
		}
	}
	return str;
}

std::string GetLocalModuleFileName()
{
	char szModuleFilePath[MAX_PATH];
	int n = GetModuleFileNameA(0, szModuleFilePath, MAX_PATH); //获得当前执行文件的路径  
	szModuleFilePath[strrchr(szModuleFilePath, '\\') - szModuleFilePath + 1] = 0;//将最后一个"\\"后的字符置为0  

	return std::string(szModuleFilePath);
}

std::string GetLocalCurrentDirectory()
{
	TCHAR szDir[MAX_PATH] = { 0 };
	GetCurrentDirectory(MAX_PATH, szDir);

	return TCHAR2STRING(szDir) + "\\";
}

bool FileCopy(const char* src, const char* dst)
{
	std::ifstream in(src, std::ios::binary);
	std::ofstream out(dst, std::ios::binary);

	char buf[2048];
	long long totalBytes = 0;
	while (in)
	{
		in.read(buf, 2048);
		out.write(buf, in.gcount());
		totalBytes += in.gcount();
	}
	in.close();
	out.close();

	return true;
}

////turn json string into object instance
////json example:"[{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"C\"}],\"AutoTrigger\":false},{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"B\"}],\"AutoTrigger\":false}]";
//std::string doserializeActionTriggerInfo(std::vector<Ruyi::SDK::CommonType::ActionTriggerInfo*>& vec)
//{
//	boost::property_tree::ptree pt;
//	boost::property_tree::ptree ptArray;
//
//	for (std::vector<Ruyi::SDK::CommonType::ActionTriggerInfo*>::iterator it = vec.begin(); it != vec.end(); ++it)
//	{
//		boost::property_tree::ptree ptChild;
//		boost::property_tree::ptree ptTC;
//		for (std::vector<Ruyi::SDK::CommonType::InputIdentifier>::iterator ii_it = (*it)->TriggerConditions.begin(); ii_it != (*it)->TriggerConditions.end(); ++ii_it)
//		{
//			boost::property_tree::ptree ptII;
//			ptII.put("Device", ii_it->Device);
//			ptII.put("Value", ii_it->Value);
//			ptTC.push_back(std::make_pair("", ptII));
//			ptTC.push_back(std::make_pair("", ptII));
//			ptTC.push_back(std::make_pair("", ptII));
//		}
//
//		ptChild.put_child("TriggerConditions", ptTC);
//		ptChild.put("AutoTrigger", (*it)->AutoTrigger);
//		ptArray.push_back(std::make_pair("", ptChild));
//	}
//
//	pt.put_child("Jump", ptArray);
//
//	std::stringstream ss;
//	write_json(ss, pt);
//	//std::cout << "ssss:" << ss.str() << std::endl;
//	return ss.str();
//}


//void deserializeActionTriggerInfo(std::vector<Ruyi::SDK::CommonType::ActionTriggerInfo*>& vec, std::string json)
//{
//	std::stringstream settingSS(json);
//
//	boost::property_tree::ptree ptListTriggers;
//	boost::property_tree::ptree subPT;
//
//	try { read_json(settingSS, ptListTriggers); }
//	catch (boost::property_tree::ptree_error& e) { std::cout << "deserializeActionTriggerInfo Parse Json Error" << std::endl; }
//
//	for (boost::property_tree::ptree::iterator it = ptListTriggers.begin(); it != ptListTriggers.end(); ++it)
//	{
//		Ruyi::SDK::CommonType::ActionTriggerInfo* atInfo = new Ruyi::SDK::CommonType::ActionTriggerInfo();
//		subPT = it->second.get_child("TriggerConditions");
//
//		for (boost::property_tree::ptree::iterator it_sub = subPT.begin(); it_sub != subPT.end(); ++it_sub)
//		{
//			Ruyi::SDK::CommonType::InputIdentifier ii;
//			string device = it_sub->second.get<string>("Device");
//			string value = it_sub->second.get<string>("Value");
//
//			ii.Device = device;
//			ii.Value = value;
//			std::cout << "device:" << device << std::endl;
//			std::cout << "value:" << value << std::endl;
//			atInfo->TriggerConditions.push_back(ii);
//		}
//
//		bool autoTrigger = it->second.get<bool>("AutoTrigger");
//		std::cout << "autoTrigger:" << autoTrigger << std::endl;
//		atInfo->AutoTrigger = autoTrigger;
//
//		vec.push_back(atInfo);
//	}
//}

////turn one ActionTriggerInfo json string into object instance
////json example:"{\"TriggerConditions\":[{\"Device\":\"XB360\",\"Value\":\"B\"}],\"AutoTrigger\":false}"
//void deserializeSingleActionTriggerInfo(Ruyi::SDK::CommonType::ActionTriggerInfo& ati, std::string json)
//{
//	std::stringstream settingSS(json);
//
//	boost::property_tree::ptree pt;
//	boost::property_tree::ptree ptTC;
//
//	try { read_json(settingSS, pt); }
//	catch (boost::property_tree::ptree_error& e) { std::cout << "deserializeSingleActionTriggerInfo Parse Json Error" << std::endl; }
//
//	ptTC = pt.get_child("TriggerConditions");
//
//	for (boost::property_tree::ptree::iterator it = ptTC.begin(); it != ptTC.end(); ++it)
//	{
//		Ruyi::SDK::CommonType::InputIdentifier ii;
//		ii.Device = it->second.get<string>("Device");
//		ii.Value = it->second.get<string>("Value");
//
//		ati.TriggerConditions.push_back(ii);
//	}
//
//	ati.AutoTrigger = pt.get<bool>("AutoTrigger");
//}

std::string TCHAR2STRING(TCHAR *STR)
{
	int iLen = WideCharToMultiByte(CP_ACP, 0, STR, -1, NULL, 0, NULL, NULL);
	char* chRtn = new char[iLen * sizeof(char)];
	WideCharToMultiByte(CP_ACP, 0, STR, -1, chRtn, iLen, NULL, NULL);
	std::string str(chRtn);
	return str;
}

/*
int GetFilePath(std::string &strFilePath)
{
	//string strPath;
	//int nRes = 0;
	//指定路径           
	//strPath = "C:\";

	boost::filesystem::path full_path(boost::filesystem::initial_path());
	full_path = boost::filesystem::system_complete(boost::filesystem::path(strFilePath, boost::filesystem::native));
	//判断各级子目录是否存在，不存在则需要创建
	if (!exists(full_path))
	{
		bool bRet = boost::filesystem::create_directories(full_path);
		if (false == bRet)
		{
			return -1;
		}
	}
	//strFilePath = full_path.native_directory_string();
	return 0;
}
*/

void CheckFilePath(std::string &filePath)
{
	if (-1 == access(filePath.c_str(), 0)) 
	{
		Logger::WriteMessage(("File fold not exit: " + filePath).c_str());
		int flag = mkdir(filePath.c_str());
	}
}
