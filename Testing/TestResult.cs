using System;
using System.Collections.Generic;
using System.Text;

namespace Sheleski.Testing
{
    public interface ITestResult
    {
        object Target { get; }
        TimeSpan Duration { get; }
        Exception Exception { get; }
    }

    public interface ITestResult<T> : ITestResult
    {
        new T Target { get; }
    }

    public abstract class TestResult<T> : ITestResult<T>
    {
        public TestResult(T target, TimeSpan duration) : this(target, duration, null)
        {
        }

        public TestResult(T target, TimeSpan duration, Exception exception)
        {
            this.Target = target;
            this.Duration = duration;
            this.Exception = exception;
        }

        public T Target { get; }
        public TimeSpan Duration { get; }
        public Exception Exception { get; }

        object ITestResult.Target => this.Target;
    }

    public class ActionTestResult<T> : TestResult<T>
    {
        public ActionTestResult(Action<T> action, T target, TimeSpan duration) : this(action, target, duration, null)
        {
        }

        public ActionTestResult(Action<T> action, T target, TimeSpan duration, Exception exception) : base(target, duration, exception)
        {
            this.Action = action;
        }

        public Action<T> Action { get; }
    }

    public class FuncTestResult<T, TResult> : TestResult<T>
    {
        public FuncTestResult(Func<T, TResult> func, T target, TimeSpan duration, TResult returnValue) : this(func, target, duration, returnValue, null)
        {

        }

        public FuncTestResult(Func<T, TResult> func, T target, TimeSpan duration, TResult returnValue, Exception exception) : base(target, duration, exception)
        {
            this.Func = func;
            this.ReturnValue = returnValue;
        }

        public Func<T, TResult> Func { get; }
        public TResult ReturnValue { get; }
    }
}
