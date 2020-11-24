using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using To_Do;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Tasks tasks;
        [TestInitialize]
        public void Initialize()
        {
            tasks = new Tasks();
        }
        [TestMethod]
        public void AddTest()
        {
            tasks.AddTask(new ToDoTask());
            Assert.AreEqual(1, tasks.AllTask.Count);
        }
        public void DeleteTest()
        {
            tasks.AddTask(new ToDoTask());
            tasks.RemoveTask( tasks.AllTask[0]);
            Assert.AreEqual(0, tasks.AllTask.Count);
        }
        public void CheckState()
        {
            tasks.AddTask(new ToDoTask());
            tasks.ChangeCheckState(0,true);
            Assert.AreEqual(true, tasks.AllTask[0].State);
        }
        public void UpdateTest()
        {
            tasks.AddTask(new ToDoTask());
            tasks.UpdateTodo(0, new ToDoTask("To-Do",DateTime.Now,DateTime.Now,true));
            Assert.AreEqual(1, tasks.AllTask.Count);
        }
    }
}
