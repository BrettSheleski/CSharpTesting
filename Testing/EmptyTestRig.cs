using System;
using System.Collections.Generic;
using System.Text;

namespace Sheleski.Testing
{
    public class EmptyTestRig<T> : TestRig<T>
    {
        public TestRigWithAction<T> Test(Action<T> action)
        {
            return new TestRigWithAction<T>(action);
        }

        public TestRigWithFunc<T, TResult> Test<TResult>(Func<T, TResult> action)
        {
            return new TestRigWithFunc<T, TResult>(action);
        }
    }
}
