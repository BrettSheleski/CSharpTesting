using System;

namespace Sheleski.Testing
{
    public class TestRigWithAction<T> : ITestRig<T>
    {
        public Action<T> Action { get; }

        public virtual TestResult<T> ExecuteUsing(T target)
        {
            DateTime start = DateTime.Now;
            this.Action(target);
            DateTime end = DateTime.Now;

            return new Testing.ActionTestResult<T>(Action, target, end - start);
        }

        public TestRigWithAction(Action<T> action)
        {
            this.Action = action;
        }

        public TestRigWithActionExpectingException<T, TException> Throws<TException>() where TException : Exception
        {
            return new TestRigWithActionExpectingException<T, TException>(Action);
        }
    }
}
