#pragma once

#include <stdexcept>

namespace Ruyi { namespace SDK { namespace Online {

	class RuyiNetException : public std::runtime_error
	{
	public:
		RuyiNetException(const char * what)
			: std::runtime_error(what)
		{
		}
	};
}}}