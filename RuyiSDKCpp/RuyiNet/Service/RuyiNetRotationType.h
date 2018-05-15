#pragma once

#include "../Enum.h"

namespace Ruyi
{
	ENUM(RuyiNetRotationType, char,
		NEVER,
		DAILY,
		DAYS,
		WEEKLY,
		MONTHLY,
		YEARLY);
}