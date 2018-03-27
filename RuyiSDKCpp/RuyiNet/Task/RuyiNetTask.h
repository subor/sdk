#pragma once

#include <iostream>

#include "boost/container/detail/json.hpp"
#include "RuyiNetTaskBase.h"

using json = nlohmann::json;

namespace Ruyi
{
	template<typename Data>
	class RuyiNetTask : public RuyiNetTaskBase
	{
	public:
		typedef std::function<void(Data)> CallbackType;

		RuyiNetTask(const ExecuteType & onExecute, const CallbackType & callback);
		virtual ~RuyiNetTask() {}

		void Clone(const RuyiNetTaskBase * other) override;
		virtual void Execute() override;
		void OnResponse() const override;
		bool IsCompleted() { return mCompleted; }

	protected:
		ExecuteType mOnExecute;

	private:
		CallbackType mCallback;
	};

	template<typename Data>
	RuyiNetTask<Data>::RuyiNetTask(const ExecuteType & onExecute, const CallbackType & callback)
		: mOnExecute(onExecute), mCallback(callback)
	{
	}

	template<typename Data>
	void RuyiNetTask<Data>::Clone(const RuyiNetTaskBase * other)
	{
		auto super = (RuyiNetTask<Data> *)(other);
		mOnExecute = super->mOnExecute;
		mCallback = super->mCallback;
	}

	template<typename Data>
	void RuyiNetTask<Data>::Execute()
	{
		mCompleted = false;
		mResponse = mOnExecute();
		mCompleted = true;
	}

	template<typename Data>
	void RuyiNetTask<Data>::OnResponse() const 
	{
		if (mCallback != nullptr)
		{
			std::cout << mResponse;
			Data response = json::parse(mResponse);
			mCallback(response);
		}
	}
}