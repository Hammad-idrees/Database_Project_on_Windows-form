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
    public partial class AdminLoginForm : Form
    {
        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the AttendeeRegistrationForm
            AdminRegisterForm adminRegistrationForm = new AdminRegisterForm();

            // Show the AttendeeRegistrationForm
            adminRegistrationForm.Show();

            // Optionally hide the current form (if you don't want it open anymore)
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validate the input fields
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            string email = textBox1.Text.Trim();
            string userPassword = textBox2.Text.Trim(); // Renamed variable to avoid conflict with method parameter

            // Hash the entered password to compare with stored hashed password
            string hashedPassword = HashPassword(userPassword);

            // SQL query to check the email and retrieve the hashed password
            string query = "SELECT PasswordHash FROM Admins WHERE Email = @Email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                try
                {
                    // Open connection
                    conn.Open();

                    // Execute query and get the result
                    object result = cmd.ExecuteScalar();

                    // If result is null, email doesn't exist
                    if (result != null)
                    {
                        string storedPasswordHash = result.ToString();

                        // Verify the entered password against the stored hash
                        if (VerifyPassword(hashedPassword, storedPasswordHash))
                        {
                            // Login successful, show admin dashboard
                            MessageBox.Show("Login successful!");

                            // Create and show the Admin Dashboard form
                            AdminDashboardForm adminDashboard = new AdminDashboardForm();
                            adminDashboard.Show();

                            // Hide the login form
                            this.Hide();

                            // Close the login form when dashboard is closed
                            adminDashboard.FormClosed += (s, args) => this.Close();
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
                // Compute the hash of the password
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to hex string
                StringBuilder builder = new StringBuilder();
                foreach (byte byteValue in bytes)
                {
                    builder.Append(byteValue.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // Method to verify the entered password hash against the stored password hash
        private bool VerifyPassword(string enteredPasswordHash, string storedPasswordHash)
        {
            return enteredPasswordHash == storedPasswordHash;
        }


    }
  }

