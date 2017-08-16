namespace Sheleski.Testing
{
    public static class TestRig
    {
        public static EmptyTestRig<T> Create<T>()
        {
            return TestRig<T>.Create();
        }
    }

    public abstract class TestRig<T>
    {
        public static EmptyTestRig<T> Create()
        {
            return new EmptyTestRig<T>();
        }
    }
}
