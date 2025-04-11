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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EventVerse
{
    public partial class AdminRegisterForm : Form
    {
        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";

        public AdminRegisterForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve the data from the textboxes
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();
            string phoneNumber = textBox5.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            // Validate email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            // Hash the password before saving it
            string hashedPassword = HashPassword(password);

            // Save the admin data to the database
            SaveAdmin(firstName, lastName, email, hashedPassword, phoneNumber);
        }

        private void SaveAdmin(string firstName, string lastName, string email, string passwordHash, string phoneNumber)
        {
            // SQL query to insert new admin into the Admin table
            string query = "INSERT INTO Admins (FirstName, LastName, Email, PasswordHash, PhoneNumber) " +
                           "VALUES (@FirstName, @LastName, @Email, @PasswordHash, @PhoneNumber)";

            // Create the connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash); // Hash the password before saving
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Show success message
                        MessageBox.Show("Admin registered successfully!");

                        // Optionally, clear fields after registration
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        // Show error message if there is an issue
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        // Optional: Function to clear the input fields after successful registration
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        // Email Validation Function
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        // Method to hash the password before storing it
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

        private void button1_Click(object sender, EventArgs e)
        {

            // Close the current registration form
            this.Hide();

            // Open the Login form
            AdminLoginForm loginForm = new AdminLoginForm();
            loginForm.Show();

            // Optionally, if you want to close the current form when the user exits the login form
            loginForm.FormClosed += (s, args) => this.Close();
        }
    }
 }

