using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace To_Do
{
    
    [Serializable]
    public class Tasks
    {
        private List<ToDoTask> toDoTasks;
        public List<ToDoTask> AllTask { get { return toDoTasks; } }

        public Tasks()
        {
            toDoTasks = new List<ToDoTask>();
        }

        public void AddTask(ToDoTask t)
        {
            toDoTasks.Add(t);  
        }
        public void RemoveTask(ToDoTask t)
        {
            toDoTasks.Remove(t);
        }
        public void ChangeCheckState(int index, bool newState)
        {
            toDoTasks[index].State = newState;
        }
        public void UpdateTodo (int index,ToDoTask t)
        {
            toDoTasks[index] = t;
        }
    }
    [Serializable]
    public class ToDoTask
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool State { get; set; }
        public ToDoTask()
        {
        }
        public ToDoTask( string Title,DateTime startDate, DateTime endDate, bool state)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            State = state;
        }
        public override string ToString()
        {
            return $"{title}";
        }
    }

}

