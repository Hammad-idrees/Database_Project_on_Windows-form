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
    public partial class EventBookingForm : Form
    {
        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";

        public EventBookingForm()
        {
            InitializeComponent();
        }

        // Load event data when the form loads
        private void EventBookingForm_Load(object sender, EventArgs e)
        {
            // The ComboBoxes are now populated manually in the form designer.
        }

       

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        
        // Button click to proceed with booking
        private void button2_Click(object sender, EventArgs e)
        {
            {
                // Check if ComboBoxes are populated and an item is selected
                if (comboBox1.SelectedItem == null ||
                    comboBox2.SelectedItem == null ||
                    comboBox3.SelectedItem == null ||
                    comboBox4.SelectedItem == null)
                {
                    MessageBox.Show("Please select all required fields.");
                    return;
                }

                // Get the values from the form controls
                string eventName = comboBox1.SelectedItem.ToString();
                string eventDescription = textBox2.Text;
                string eventType = comboBox2.SelectedItem.ToString();
                string eventCategory = comboBox3.SelectedItem.ToString();
                DateTime eventDate = dateTimePicker1.Value;
                string eventLocation = comboBox4.SelectedItem.ToString();
                int ticketQuantity = (int)numericUpDown1.Value;

                // Save the booking details in the EventBookings table
                SaveBooking(eventName, eventDescription, eventType, eventCategory, eventDate, eventLocation, ticketQuantity);
            }
        }

        private void SaveBooking(string eventName, string eventDescription, string eventType, string eventCategory, DateTime eventDate, string eventLocation, int ticketQuantity)
        {
            // SQL query to insert booking details into the EventBookings table
            string query = "INSERT INTO EventBookings (EventName, EventDescription, EventType, EventCategory, EventDate, EventLocation, TicketQuantity) " +
                           "VALUES (@EventName, @EventDescription, @EventType, @EventCategory, @EventDate, @EventLocation, @TicketQuantity)";

            // Initialize SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create SqlCommand object
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to the command to avoid SQL Injection
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@EventDescription", eventDescription);
                    cmd.Parameters.AddWithValue("@EventType", eventType);
                    cmd.Parameters.AddWithValue("@EventCategory", eventCategory);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@EventLocation", eventLocation);
                    cmd.Parameters.AddWithValue("@TicketQuantity", ticketQuantity);

                    try
                    {
                        // Open the database connection and execute the query
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        // Optionally, show a confirmation message to the user
                        MessageBox.Show("Event booked successfully!");
                    }
                    catch (Exception ex)
                    {
                        // Show error message in case of failure
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }



        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
       
      
    }
}
