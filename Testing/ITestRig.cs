using System;
using System.Collections.Generic;
using System.Text;

namespace Sheleski.Testing
{
    public interface ITestRig<T>
    {
        TestResult<T> ExecuteUsing(T target);
    }
}
