#pragma once

#include <queue>
#include <thread>

#include "RuyiNetTask.h"

namespace Ruyi
{
	class RuyiNetTaskQueue
	{
	public:
		~RuyiNetTaskQueue();

		void Enqueue(RuyiNetTaskBase * task);

		void Update();

	private:
		std::shared_ptr<std::thread> mTaskThread;
		std::queue<RuyiNetTaskBase *> mTaskQueue;
		RuyiNetTaskBase * mCurrentTask;
	};
}