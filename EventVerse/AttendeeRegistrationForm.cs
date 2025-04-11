using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventVerse
{
    public partial class AttendeeRegistrationForm : Form
    {
        public AttendeeRegistrationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validate the input
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Hash the password
            string hashedPassword = HashPassword(textBox4.Text);

            // Store attendee data into the database
            string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";  // Use your actual connection string
            string query = "INSERT INTO Attendees (FirstName, LastName, Email, PasswordHash, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PhoneNumber)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registration successful!");
                    this.Close();  // Close the registration form
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }
        }
        // Method to hash the password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte byteValue in bytes)
                {
                    builder.Append(byteValue.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Close the current registration form
            this.Hide();

            // Open the Login form
            AttendeeLoginForm loginForm = new AttendeeLoginForm();
            loginForm.Show();

            // Optionally, if you want to close the current form when the user exits the login form
            loginForm.FormClosed += (s, args) => this.Close();
        }
    }

}
