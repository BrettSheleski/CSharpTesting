using System;

namespace Sheleski.Testing
{
    public class TestRigWithFuncExpectingException<T, TResult, TException> : TestRigWithFunc<T, TResult>
        where TException : Exception
    {
        public TestRigWithFuncExpectingException(Func<T, TResult> func) : base(func)
        {
        }

        public override FuncTestResult<T, TResult> ExecuteUsing(T target)
        {

            DateTime start = DateTime.Now;
            DateTime end;
            TException exception = null;
            TResult result = default(TResult);

            try
            {
                result = this.Func(target);
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

            return new Testing.FuncTestResult<T, TResult>(Func, target, end - start, result, exception);
        }
    }
}