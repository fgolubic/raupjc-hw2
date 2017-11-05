using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo;

namespace TodoTests
{
    [TestClass]
    public class TodoItemTests
    {
        

        [TestMethod]
        public void TestMethod1()
        {
            TodoItem item = new TodoItem("neki text");

            item.MarkAsCompleted();

            Assert.AreEqual(true,item.IsCompleted);

        }

        [TestMethod]
        public void TestMethod2()
        {
            TodoItem item = new TodoItem("equalstest");

            TodoItem item2= new TodoItem("equalstest");

            Assert.AreEqual(false,item.Equals(item2));

            item2.Id = item.Id;

            Assert.AreEqual(true,item.Equals(item2));


        }

        [TestMethod]
        public void TestMethod3()
        {
            TodoItem item = new TodoItem("hashcodetest");

            TodoItem item2 = new TodoItem("hashcodetest");

            Assert.IsFalse(item.GetHashCode() == item2.GetHashCode());

            item2.Id = item.Id;

            Assert.IsTrue(item.GetHashCode()==item2.GetHashCode());


        }
    }
}
