using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using To_Do;

namespace ExamToday
{
    public partial class Form2 : Form
    {
        public ToDoTask ToDoTask { get; set; }
        public Form2(EnumAddEdit enumAddEdit,ToDoTask toDoTask)
        {
            InitializeComponent();
            if (enumAddEdit == EnumAddEdit.Edit)
            {
                ToDoTask = toDoTask;
                textBox1.Text = toDoTask.title;
                dateTimePicker1.Value = Convert.ToDateTime(toDoTask.StartDate);
                dateTimePicker2.Value = Convert.ToDateTime(toDoTask.EndDate);
            }
            else
                ToDoTask = new ToDoTask();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToDoTask = new ToDoTask(textBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value, ToDoTask.State);
            this.DialogResult = DialogResult.OK;
        }
    }
}
