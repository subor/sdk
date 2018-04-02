#pragma once

#include "../../RuyiString.h"

namespace Ruyi
{
	class RuyiNetTaskBase
	{
	public:
		typedef std::function<std::string()> ExecuteType;

		RuyiNetTaskBase() : mCompleted(false) {}
		RuyiNetTaskBase(const RuyiNetTaskBase & other)
		{
			mCompleted = other.mCompleted;
			mResponse = other.mResponse;
			Clone(&other);
		}

		virtual ~RuyiNetTaskBase() {}

		virtual void Clone(const RuyiNetTaskBase * other) = 0;
		virtual void Execute() = 0;
		virtual void OnResponse() const = 0;

		bool GetCompleted() { return mCompleted; }

	protected:
		bool mCompleted;
		std::string mResponse;
	};
}