using System;

namespace Sheleski.Testing
{
    public class TestRigWithFunc<T, TResult> : ITestRig<T>
    {
        public Func<T, TResult> Func { get; }

        public TestRigWithFunc(Func<T, TResult> func)
        {
            this.Func = func;
        }

        public virtual FuncTestResult<T, TResult> ExecuteUsing(T target)
        {
            DateTime start = DateTime.Now, end;

            var returnValue = Func(target);

            end = DateTime.Now;
            
            return new FuncTestResult<T, TResult>(Func, target, end - start, returnValue);
        }

        public TestRigWithFuncExpectingException<T, TResult, TException> Throws<TException>() where TException : Exception
        {
            return new TestRigWithFuncExpectingException<T, TResult, TException>(Func);
        }

        TestResult<T> ITestRig<T>.ExecuteUsing(T target)
        {
            return this.ExecuteUsing(target);
        }
    }
}
