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
        Serializetion serializetion;
        Tasks tasks;
        int index;
        public Form1()
        {
            InitializeComponent();
            serializetion = new Serializetion();
            tasks = new Tasks();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            serializetion.Serialize<List<ToDoTask>>(tasks.AllTask);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            tasks.RemoveTask(checkedListBox1.SelectedItem as ToDoTask);
            checkedListBox1.Items.RemoveAt(index);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                foreach (ToDoTask item in serializetion.Deserialize<List<ToDoTask>>())
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(EnumAddEdit.Add, null);
            form2.ShowDialog();
            if(form2.DialogResult == DialogResult.OK)
            {
                tasks.AddTask(form2.ToDoTask);
                FillToDoList();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                tasks.ChangeCheckState(e.Index, true);
            else if (e.NewValue == CheckState.Unchecked)
                tasks.ChangeCheckState(e.Index, false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(EnumAddEdit.Edit, checkedListBox1.SelectedItem as ToDoTask);
            index = checkedListBox1.SelectedIndex;
            form2.ShowDialog();
            if(form2.DialogResult == DialogResult.OK)
            {
                tasks.UpdateTodo(checkedListBox1.SelectedIndex, form2.ToDoTask);
                FillToDoList();
            }
            checkedListBox1.SelectedIndex = index;
        }
    }
}

