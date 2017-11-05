using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo;



namespace TodoTests
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ITodoRepository test = new TodoRepository();

            TodoItem entry1 = new TodoItem("test1");

            Assert.AreEqual(entry1,test.Add(entry1));

            Assert.AreEqual(entry1,test.Get(entry1.Id));

            Assert.IsTrue(test.MarkAsCompleted(entry1.Id));

            TodoItem entry2 = new TodoItem("test2");

            entry1.Text = "updated";

            Assert.AreEqual(entry1, test.Update(entry1));

            Assert.AreEqual(entry1.Text,test.Get(entry1.Id).Text);

            Assert.IsTrue(test.Remove(entry1.Id));

            test.Add(new TodoItem("entry3"));
            test.Add(entry2);

            Assert.AreEqual(2, test.GetAll().Count);

            test.MarkAsCompleted(entry2.Id);

            Assert.AreEqual(1,test.GetActive().Count);

            Assert.AreEqual(1, test.GetCompleted().Count);

            Assert.AreEqual(1, test.GetFiltered(i=>i.Id==entry2.Id).Count);

        }
    }
}
