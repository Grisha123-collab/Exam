using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace To_Do
{
    /*public class Missions
        {
            private List<Mission> missions;
            public List<Mission> AllMissions { get { return missions; } }

            public Missions()
            {
                missions = new List<Mission>();
            }

            public void AddMission(Mission mission)
            {
                missions.Add(mission);
            }

            public void RemoveMission(Mission mission)
            {
                missions.Remove(mission);
            }
        }*/
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

    public class Serializer
    {
        public T Deserialize<T>() where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (Stream stream = File.Open("todo.xml", FileMode.Open))
            {
                return (T)ser.Deserialize(stream);
            }
        }
        public void Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
            using (FileStream fs = new FileStream("todo.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, ObjectToSerialize);
            }
        }
    }

}
/*[Serializable]
    public class Mission
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool State { get; set; }

        public Mission(string title, DateTime startDate, DateTime endDate, bool state) 
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            State = state;
        }
        public Mission() { }

        public override string ToString()
        {
            return $"{Title}";
        }
    }

    [Serializable]
    public class Missions
    {
        private List<Mission> missions;
        public List<Mission> AllMissions { get { return missions; } }

        public Missions()
        {
            missions = new List<Mission>();
        }

        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }

        public void RemoveMission(Mission mission)
        {
            missions.Remove(mission);
        }

        public void ChangeCheckState(int index, bool newState)
        {
            missions[index].State = newState;
        }
    }

    public class Serializer
    {
        public T Deserialize<T>() where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (Stream stream = File.Open("missions.xml", FileMode.Open))
            {
                return (T)ser.Deserialize(stream);
            }
        }
        public void Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
            using (FileStream fs = new FileStream("missions.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, ObjectToSerialize);
            }
        }
    }*/
