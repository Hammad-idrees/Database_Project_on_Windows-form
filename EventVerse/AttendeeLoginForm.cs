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
    public partial class AttendeeLoginForm : Form
    {
        public AttendeeLoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the AttendeeRegistrationForm
            AttendeeRegistrationForm attendeeRegistrationForm = new AttendeeRegistrationForm();

            // Show the AttendeeRegistrationForm
            attendeeRegistrationForm.Show();

            // Optionally hide the current form (if you don't want it open anymore)
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate the input
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            string email = textBox1.Text;
            string password = textBox2.Text;

            // Hash the entered password
            string hashedPassword = HashPassword(password);

            // Verify credentials from the database
            string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";  // Use your actual connection string
            string query = "SELECT PasswordHash FROM Attendees WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string storedPasswordHash = result.ToString();

                        // Compare hashed password with stored password hash
                        if (VerifyPassword(hashedPassword, storedPasswordHash))
                        {
                            // Login successful - Show the attendee dashboard
                            MessageBox.Show("Login successful!");

                            // Create and show the Attendee Dashboard form
                            AttendeeDashboardForm attendeeDashboard = new AttendeeDashboardForm();
                            attendeeDashboard.Show();

                            // Hide the current login form
                            this.Hide();

                            // Optionally, close the login form when the dashboard form is closed
                            attendeeDashboard.FormClosed += (s, args) => this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        // Method to hash the password (same as in registration)
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
        // Method to verify password hash
        private bool VerifyPassword(string enteredPasswordHash, string storedPasswordHash)
        {
            return enteredPasswordHash == storedPasswordHash;
        }

    }
}
