#include "RuyiNetRotationType.h"
namespace Ruyi {
	namespace SDK {
		namespace Online {

RuyiNetRotationType ConvertStringToRuyiNetRotationType(std::string str)
{
	RuyiNetRotationType ret = RuyiNetRotationType::NEVER;

	if (0 == str.compare("NEVER"))
	{
		ret = RuyiNetRotationType::NEVER;
	}
	else if (0 == str.compare("DAILY"))
	{
		ret = RuyiNetRotationType::DAILY;
	}
	else if (0 == str.compare("WEEKLY"))
	{
		ret = RuyiNetRotationType::WEEKLY;
	}
	else if (0 == str.compare("MONTHLY"))
	{
		ret = RuyiNetRotationType::MONTHLY;
	}
	else if (0 == str.compare("YEARLY"))
	{
		ret = RuyiNetRotationType::YEARLY;
	}
	else if (0 == str.compare("DAYS"))
	{
		ret = RuyiNetRotationType::DAYS;
	}
	else {}

	return ret;
}
}}}