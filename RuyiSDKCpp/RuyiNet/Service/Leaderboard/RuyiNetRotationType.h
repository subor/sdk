#pragma once

#include "../../Enum.h"

namespace Ruyi { namespace SDK { namespace Online {

	ENUM(RuyiNetRotationType, char,
		NEVER,
		DAILY,
		DAYS,
		WEEKLY,
		MONTHLY,
		YEARLY);
}}} 