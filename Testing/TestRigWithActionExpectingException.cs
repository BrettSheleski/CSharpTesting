using System;

namespace Sheleski.Testing
{
    public class TestRigWithActionExpectingException<T, TException> : TestRigWithAction<T>
        where TException : Exception
    {
        public TestRigWithActionExpectingException(Action<T> action) : base(action)
        {
        }
        
        public override TestResult<T> ExecuteUsing(T target)
        {
            DateTime start = DateTime.Now;
            DateTime end;
            TException exception = null;
            try
            {
                this.Action(target);
                end = DateTime.Now;
            }
            catch (TException ex)
            {
                end = DateTime.Now;
                exception = ex;
            }

            if (exception == null)
            {
                throw new ExpectedExceptionNotThrownException($"Exception of type ${typeof(TException).FullName} was not thrown.");
            }

            return new Testing.ActionTestResult<T>(Action, target, end - start, exception);
        }
    }
}