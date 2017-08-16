using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sheleski.Testing.Tests
{
    [TestClass]
    public class TestRigTests
    {
        [TestMethod]
        public void TestRig_ActionIsCalled()
        {
            // Setup
            Person thePerson = new Person();
            var rig = TestRig.Create<Person>()
                             .Test(p => p.DoNothing());
            
            // Act
            TestResult<Person> result = rig.ExecuteUsing(thePerson);
            
            // Verify
            Assert.AreSame(thePerson, result.Target);
            Assert.IsTrue(result.Duration < TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void TestRig_FuncIsCalled()
        {
            // Setup
            var expectedDate = new DateTime(2000, 1, 1);
            var rig = TestRig.Create<Person>()
                             .Test(p => p.GetJanuaryFirst2000())
                             ;

            // Act
            var result = rig.ExecuteUsing(new Person());

            // Verify
            Assert.IsTrue(result.ReturnValue == expectedDate);
        }

        [TestMethod]
        public void TestRig_ExpectException()
        {
            // Setup
            var rig = TestRig.Create<Person>()
                             .Test(p => p.RaisesException())
                             .Throws<NotImplementedException>();

            // Act
            var result = rig.ExecuteUsing(new Person());

            // Verify
            Assert.IsTrue(result.Exception is NotImplementedException);
        }

        [TestMethod]
        public void TestRig_FuncRaisesException()
        {
            // Setup
            var rig = TestRig.Create<Person>()
                             .Test(p => p.RaisesInvalidOperationExceptionFunc())
                             .Throws<InvalidOperationException>();

            // Act
            var result = rig.ExecuteUsing(new Person());

            // Verify
            Assert.IsTrue(result.Exception is InvalidOperationException);
        }

        [TestMethod]
        [ExpectedException(typeof(Testing.ExpectedExceptionNotThrownException))]
        public void TestRig_ExpectingExceptionNotThrownInFunc()
        {
            // Setup
            var rig = TestRig.Create<Person>()
                             .Test(p => p.GetJanuaryFirst2000())
                             .Throws<InvalidOperationException>();

            // Act
            var result = rig.ExecuteUsing(new Person());

            // Verify
            
        }


        [TestMethod]
        [ExpectedException(typeof(Testing.ExpectedExceptionNotThrownException))]
        public void TestRig_ExpectingExceptionNotThrownInAction()
        {
            // Setup
            var rig = TestRig.Create<Person>()
                             .Test(p => p.DoNothing())
                             .Throws<InvalidOperationException>();

            // Act
            var result = rig.ExecuteUsing(new Person());

            // Verify

        }

        class Person
        {
            public void DoNothing()
            {
                
            }

            public void RaisesException()
            {
                throw new NotImplementedException();
            }

            public DateTime GetJanuaryFirst2000()
            {
                return new DateTime(2000, 1, 1);
            }

            public DateTime RaisesInvalidOperationExceptionFunc()
            {
                throw new InvalidOperationException();
            }
        }

    }
}
