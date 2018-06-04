using System.Collections.Generic;
using System.Threading;

namespace Ruyi.SDK.Online
{
    internal class RuyiNetTaskQueue
    {
        public RuyiNetTaskQueue()
        {
            mTaskQueue = new Queue<RuyiNetTaskBase>();
        }

        public void Enqueue(RuyiNetTaskBase task)
        {
            mTaskQueue.Enqueue(task);
        }

        public void Update()
        {
            if (mCurrentTask != null)
            {
                if (mCurrentTask.Completed)
                {
                    mCurrentTask.OnResponse();

                    mTaskThread = null;
                    mCurrentTask = null;
                }
            }
            else if (mTaskQueue.Count > 0)
            {
                mCurrentTask = mTaskQueue.Dequeue();
                mTaskThread = new Thread(new ThreadStart(() => { mCurrentTask.Execute(); }));
                mTaskThread.Start();
            }
        }

        public int Work
        {
            get
            {
                if (mCurrentTask != null)
                {
                    return mTaskQueue.Count + 1;
                }

                return mTaskQueue.Count;
            }
        }

        private Thread mTaskThread;
        private Queue<RuyiNetTaskBase> mTaskQueue;
        private RuyiNetTaskBase mCurrentTask;
    }
}
