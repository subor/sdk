#include "RuyiNetTaskQueue.h"

namespace Ruyi
{
	RuyiNetTaskQueue::~RuyiNetTaskQueue()
	{
		while (mTaskQueue.size() > 0)
		{
			delete mTaskQueue.front();
			mTaskQueue.pop();
		}

		if (mCurrentTask != nullptr)
		{
			delete mCurrentTask;
			mCurrentTask = nullptr;
		}
	}

	void RuyiNetTaskQueue::Enqueue(RuyiNetTaskBase * task)
	{
		mTaskQueue.push(task);
	}

	void RuyiNetTaskQueue::Update()
	{
		if (mCurrentTask != nullptr)
		{
			if (mCurrentTask->GetCompleted())
			{
				mCurrentTask->OnResponse();
				mTaskThread = nullptr;

				delete mCurrentTask;
				mCurrentTask = nullptr;
			}
		}
		else if (mTaskQueue.size() > 0)
		{
			mCurrentTask = std::move(mTaskQueue.front());
			mTaskQueue.pop();
			mTaskThread = std::make_unique<std::thread>(std::bind(&RuyiNetTaskBase::Execute, mCurrentTask));
		}
	}
}