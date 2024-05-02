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
    public partial class Form2 : Form
    {

        private UserManager userManager = new UserManager();
        public Form2()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //ignore
        private void label3_Click(object sender, EventArgs e)
        {

        }

        //username
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //password
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //confirm password
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void InitializeDropdown()
        {
            comboBox1.Items.Add("User");
            comboBox1.Items.Add("Admin");
            comboBox1.SelectedIndex = 0;  // Default to 'User'
        }
        //drowpdown for priority
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //cancel
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Optionally close the form or clear the inputs
        }

        private void ClearForm()
        {
            // Clear all input fields and reset defaults
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = 0;
        }

        //create 
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            PersonBase newPerson;

            if (comboBox1.SelectedItem.ToString() == "Admin")
            {
                newPerson = new Admin(username, password);
            }
            else
            {
                newPerson = new User(username, password);
            }

            if (userManager.AddPerson(newPerson))
            {
                MessageBox.Show($"{newPerson.GetType().Name} registered successfully.");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Username already exists.");
            }
        }
    }
}
