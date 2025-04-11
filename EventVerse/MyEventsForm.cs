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
    public partial class MyEventsForm : Form
    {
        public MyEventsForm()
        {
            InitializeComponent();
        }

        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void MyEventsForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            AttendeeDashboardForm AttendeeDashboard = new AttendeeDashboardForm();
            AttendeeDashboard.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            AttendeeDashboard.FormClosed += (s, args) => this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Hide the booked events grid and show the upcoming events grid
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;

            // Load upcoming events from the 'Event' table
            LoadUpcomingEvents();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Hide the upcoming events grid and show the booked events grid
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;

            // Load booked events from the 'EventBookings' table
            LoadBookedEvents();
        }
        // Load upcoming events (from 'Events' table)
        private void LoadUpcomingEvents()
        {
            // Define the SQL query to get upcoming events from the 'Events' table
            string query = "SELECT EventName, EventDescription, EventType, EventCategory, EventDate, Location FROM Events WHERE EventDate > GETDATE()";

            // Initialize the DataTable to hold the data
            DataTable dt = new DataTable();

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the query
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Use a DataAdapter to fill the DataTable with the query result
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView2.DataSource = dt;

                    // Close the connection
                    connection.Close();
                }
            }
        }
        // Load booked events (from 'EventBookings' table)
        private void LoadBookedEvents()
        {
            // Define the SQL query to get booked events from the 'EventBookings' table
            string query = "SELECT EventName, EventDescription, EventType, EventCategory, EventDate, EventLocation, TicketQuantity FROM EventBookings";

            // Initialize the DataTable to hold the data
            DataTable dt = new DataTable();

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the query
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Use a DataAdapter to fill the DataTable with the query result
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dt;

                    // Close the connection
                    connection.Close();
                }
            }
        }

    }
}
