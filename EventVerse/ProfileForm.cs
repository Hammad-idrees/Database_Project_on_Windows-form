using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventVerse
{
    public partial class ProfileForm : Form
    {
        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearFields()
        {
            // Clear all textboxes after saving
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            AttendeeDashboardForm AttendeeDashboard = new AttendeeDashboardForm();
            AttendeeDashboard.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            AttendeeDashboard.FormClosed += (s, args) => this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve values from the textboxes
            string firstName = textBox1.Text.Trim();
            string lastName = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();
            string phoneNumber = textBox5.Text.Trim();

            // Validate inputs (simple validation, you can expand this as needed)
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            // Insert data into the UserProfiles table
            string query = "INSERT INTO UpdatedUserProfiles (FirstName, LastName, Email, Password, PhoneNumber) " +
                           "VALUES (@FirstName, @LastName, @Email, @Password, @PhoneNumber)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to avoid SQL Injection
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // You should hash the password in real applications
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query to insert data
                        cmd.ExecuteNonQuery();

                        // Optionally, show a confirmation message
                        MessageBox.Show("Profile updated successfully!");

                        // Clear the fields or close the form as needed
                        ClearFields(); // Assuming ClearFields is a method to clear the input fields
                    }
                    catch (Exception ex)
                    {
                        // Show an error message if there is an issue
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
