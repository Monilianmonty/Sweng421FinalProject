namespace Sweng421FinalProject
{
    public partial class Form1 : Form
    {

        private UserManager userManager;

        //Login interface
        public Form1()
        {
            InitializeComponent();
            userManager = new UserManager(); 
        }

        //username textbox

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //ignore this method below
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //password textbox

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        // Login button click event handler
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim(); // Assuming textBox1 is for the username
            string password = textBox2.Text;        // Assuming textBox2 is for the password

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Authenticate user
            PersonBase loggedInUser = userManager.AuthenticateUser(username, password);
            if (loggedInUser != null)
            {
                MessageBox.Show("Login successful!");
                this.Hide(); // Optional: hide the login form
                
                Form3 mainForm = new Form3((User)loggedInUser); // Pass the authenticated user to Form3
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}