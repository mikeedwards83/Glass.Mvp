using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Glass.Mvp
{
    public class MvpAsyncResult : IAsyncResult

    {
        private readonly WaitHandle _asyncWaitHandle;

        public MvpAsyncResult(
            bool isCompleted, 
            object asyncState, 
            bool completedSynchronously,
            WaitHandle asyncWaitHandle)
        {
            _asyncWaitHandle = asyncWaitHandle;
            IsCompleted = isCompleted;
            AsyncState = asyncState;
            CompletedSynchronously = completedSynchronously;
        }

        public bool IsCompleted { get;  set; }
        public WaitHandle AsyncWaitHandle { get; private set; }
        public object AsyncState { get; private set; }
        public bool CompletedSynchronously { get; private set; }
    }
}
