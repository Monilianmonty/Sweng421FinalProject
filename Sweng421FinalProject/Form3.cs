using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sweng421FinalProject
{
    public partial class Form3 : Form
    {

        private User currentUser;
        public Form3(User u)
        {
            InitializeComponent();
            this.currentUser = u;
            LoadUserData();


        }

        //where tasks will be viewed
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadUserData()
        {

            Console.WriteLine("Loading user data for: " + currentUser.Username); // This will output to your debug console.
            label6.Text = currentUser.Username;

        }

        //deadline edit task
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //deadline new task
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //username textbox
        private void Username_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //new task textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //create task button
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //taskpriority for new task
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //confirm editing a task
        private void button6_Click(object sender, EventArgs e)
        {

        }

        //notify button:wrapper
        private void Notify_Click(object sender, EventArgs e)
        {

        }

        //visitor : generate report button
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //delete task from User
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //Select Task to edit
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //username label
        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
