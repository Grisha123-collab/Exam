using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using To_Do;

namespace ExamToday
{
    public partial class Form1 : Form
    {
        Serializer serializer;
        Tasks tasks;
        public Form1()
        {
            InitializeComponent();
            serializer = new Serializer();
            tasks = new Tasks();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            serializer.Serialize <List<ToDoTask>>(tasks.AllTask);
         
        }      
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try 
            {

                foreach (ToDoTask item in serializer.Deserialize<List<ToDoTask>>())
                    tasks.AddTask(item);

                if (tasks.AllTask.Count > 0)
                    FillToDoList();
            }
            catch { }
        }
        private void FillToDoList()
        {
            foreach (ToDoTask item in tasks.AllTask)
            {
                checkedListBox1.Items.Add(item);
                if (item.State == true)
                    checkedListBox1.Items[checkedListBox1.Items.Count - 1] = CheckState.Checked;
            }
        }


/*
        Serializer serializer;
        Missions missions;
        public Form1()
        {
            InitializeComponent();
            serializer = new Serializer();
            missions = new Missions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Mission item in serializer.Deserialize<List<Mission>>())
                    missions.AddMission(item);

                if (missions.AllMissions.Count > 0)
                    FillToDoList();
            }
            catch { }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serializer.Serialize<List<Mission>>(missions.AllMissions);
        }

        private void FillToDoList()
        {
            toDoList.Items.Clear();
            foreach (Mission item in missions.AllMissions)
            {
                toDoList.Items.Add(item);
                if (item.State == true)
                    toDoList.SetItemChecked(toDoList.Items.Count - 1, true);
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                missions.AddMission(form2.Mission);
            }
            *//*missions.AddMission(new Mission("test1", DateTime.Now, DateTime.Now, true));
            FillToDoList();*//*
        }

        private void toDoList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toDoList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                missions.ChangeCheckState(e.Index, true);
            else if (e.NewValue == CheckState.Unchecked)
                missions.ChangeCheckState(e.Index, false);
        }*/

    }
}
