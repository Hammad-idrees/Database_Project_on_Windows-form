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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EventVerse
{
    public partial class EventSearchForm : Form
    {

        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";
        public EventSearchForm()
        {
            InitializeComponent();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve values from filters
            string eventName = txtEventName.Text.Trim();
            DateTime? startDate = dtpStartDate.Value > DateTime.Now ? dtpStartDate.Value : (DateTime?)null;
            string eventCategory = cmbEventCategory.SelectedItem?.ToString();
            string location = cmbLocation.SelectedItem?.ToString();
            decimal? maxPrice = string.IsNullOrEmpty(txtMaxPrice.Text) ? (decimal?)null : Convert.ToDecimal(txtMaxPrice.Text);
            bool checkAvailableTickets = chkAvailableTickets.Checked;

            // Build the base SQL query
            string query = "SELECT EventID, EventName, EventDescription, EventType, EventCategory, EventDate, Location, AvailableTickets, TicketPrice " +
                           "FROM Events WHERE 1 = 1";

            // Add conditions based on the filters
            if (!string.IsNullOrEmpty(eventName))
            {
                query += " AND EventName LIKE @EventName";
            }
            if (startDate.HasValue)
            {
                query += " AND EventDate > @StartDate";
            }
            if (!string.IsNullOrEmpty(eventCategory))
            {
                query += " AND EventCategory = @EventCategory";
            }
            if (!string.IsNullOrEmpty(location))
            {
                query += " AND Location = @Location";
            }
            if (maxPrice.HasValue)
            {
                query += " AND TicketPrice <= @MaxPrice";
            }
            if (checkAvailableTickets)
            {
                query += " AND AvailableTickets > 0";
            }

            // Initialize the DataTable to hold the data
            DataTable dt = new DataTable();

            // Create the connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Add parameters to avoid SQL injection
                    if (!string.IsNullOrEmpty(eventName))
                        cmd.Parameters.AddWithValue("@EventName", "%" + eventName + "%");
                    if (startDate.HasValue)
                        cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                    if (!string.IsNullOrEmpty(eventCategory))
                        cmd.Parameters.AddWithValue("@EventCategory", eventCategory);
                    if (!string.IsNullOrEmpty(location))
                        cmd.Parameters.AddWithValue("@Location", location);
                    if (maxPrice.HasValue)
                        cmd.Parameters.AddWithValue("@MaxPrice", maxPrice.Value);

                    // Execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            // Bind the DataTable to the DataGridView
            dgvEventDetails.DataSource = dt;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // When form loads, show all events first
            LoadAllEvents();
            LoadComboBoxData();
        }

        // This function loads all events without any filter
        // This function loads all events without any filter
        private void LoadAllEvents()
        {
            // Base SQL query to get all events
            string query = "SELECT EventID, EventName, EventDescription, EventType, EventCategory, EventDate, Location, AvailableTickets, TicketPrice " +
                           "FROM Events";

            // Initialize the DataTable to hold the data
            DataTable dt = new DataTable();

            // Create the connection and command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            // Bind the DataTable to the DataGridView
            dgvEventDetails.DataSource = dt;
        }

        private void LoadComboBoxData()
        {
            // Populate event categories (you can also retrieve them from the database)
            cmbEventCategory.Items.Add("Technology");
            cmbEventCategory.Items.Add("Music");
            cmbEventCategory.Items.Add("Business");
            // Add other categories here...

            // Populate locations (retrieve them from the database or hard-code)
            cmbLocation.Items.Add("New York");
            cmbLocation.Items.Add("Los Angeles");
            cmbLocation.Items.Add("London");
            // Add other locations here...
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EventSearchForm_Load_1(object sender, EventArgs e)
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
    }
}
