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
    public partial class FeedbackForm : Form
    {

        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";

        public FeedbackForm()
        {
            InitializeComponent();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            AttendeeDashboardForm AttendeeDashboard = new AttendeeDashboardForm();
            AttendeeDashboard.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            AttendeeDashboard.FormClosed += (s, args) => this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FeedbackForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eventVerseDataSet4.EventBookings' table. You can move, or remove it, as needed.
            this.eventBookingsTableAdapter.Fill(this.eventVerseDataSet4.EventBookings);
            // Add ratings to the checkedListBox
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.Add(5);
            checkedListBox1.Items.Add(4);
            checkedListBox1.Items.Add(3);
            checkedListBox1.Items.Add(2);
            checkedListBox1.Items.Add(1);
        }

    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve selected event name
            string eventName = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(eventName))
            {
                MessageBox.Show("Please select an event.");
                return;
            }

            // Retrieve selected rating (ensure only one item is checked)
            if (checkedListBox1.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please select one rating.");
                return;
            }

            // Convert the selected rating to an integer
            int rating = Convert.ToInt32(checkedListBox1.CheckedItems[0]);

            // Retrieve comment
            string comment = textBox1.Text.Trim();

            // Save the feedback in the Feedback table
            SaveFeedback(eventName, rating, comment);
        }
        private void SaveFeedback(string eventName, int rating, string comment)
        {
            // SQL query to insert feedback data into the Feedback table
            string query = "INSERT INTO Feedback (EventName, Rating, Comment) " +
                           "VALUES (@EventName, @Rating, @Comment)";

            // Create the connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@Rating", rating);
                    cmd.Parameters.AddWithValue("@Comment", comment);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Show success message
                        MessageBox.Show("Feedback submitted successfully!");

                        // Optionally, clear fields after submission
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
        private void ClearFields()
        {
            // Clear the form fields after feedback submission
            comboBox1.SelectedIndex = -1;  // Reset ComboBox selection
            checkedListBox1.ClearSelected();  // Reset CheckedListBox selection
            textBox1.Clear();  // Clear the comment text box
        }

    }
}
