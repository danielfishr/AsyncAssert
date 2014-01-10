namespace AsyncAssert
{
    using System;

    public class TimedAssertRunner
    {
        private readonly WaitTime _waitTime;

        public WaitTime WaitTime
        {
            get { return _waitTime; }
        }
        public TimedAssertRunner(TimeSpan ts)
        {
            _waitTime = new WaitTime(ts);
        }

        public TimedAssertRunner(WaitTime waitTime)
        {
            _waitTime = waitTime;
        }

        public void TrueBeforeTimeout(Func<bool> test, Func<string> failMsg = null, Func<bool> inconclusiveTest = null, Func<string> inconclusiveMessage = null)
        {
            var interval = TimeSpan.FromMilliseconds(100);
            AsyncAssert.TrueWithin(test, _waitTime.Remainder(),interval , failMsg, inconclusiveTest, inconclusiveMessage);
        }

        public void TrueBeforeTimeout(Func<bool> test, Func<bool> inconclusiveTest, Func<string> inconclusiveMessage)
        {
            AsyncAssert.TrueWithin(test, _waitTime.Remainder(), inconclusiveTest, inconclusiveMessage);
        }
    }
}