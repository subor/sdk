#pragma once

#ifndef RUYI_STRING_INCLUDED
#define RUYI_STRING_INCLUDED

#include <codecvt>
#include <string>

#ifdef _UNICODE

typedef std::wstring RuyiString; 

inline std::string ToString(const RuyiString & str)
{
	std::wstring_convert<std::codecvt_utf8<wchar_t>> conv1;
	return conv1.to_bytes(str);
}

inline RuyiString ToRuyiString(const std::string & str)
{
	std::wstring_convert<std::codecvt_utf8<wchar_t>> conv1;
	return conv1.from_bytes(str);
}

#define RUYI_STR(x) L##x

#else
typedef std::string RuyiString;

#define ToString(x) x
#define ToRuyiString(x) x
#define RUYI_STR(x) x

#endif	//	_UNICODE

#endif	//	RUYI_STRING_INCLUDED