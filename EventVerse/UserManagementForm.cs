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
    public partial class UserManagementForm : Form
    {
        // Connection string to connect to the database
        private string connectionString = "Data Source=LAPTOP-FN7Q3GFD;Initial Catalog=EventVerse;Integrated Security=True";

        public UserManagementForm()
        {
            InitializeComponent();
            LoadAttendeeData();
        }

        // Load the Attendee data into the DataGridView
        private void LoadAttendeeData()
        {
            string query = "SELECT AttendeeID, FirstName, LastName, Email, PhoneNumber FROM Attendees";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get AttendeeID of the selected row
                int attendeeID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AttendeeID"].Value);

                // SQL query to delete attendee
                string query = "DELETE FROM Attendees WHERE AttendeeID = @AttendeeID";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttendeeID", attendeeID);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Attendee deleted successfully!");
                            // Reload data to reflect changes
                            LoadAttendeeData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an attendee to delete.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the attendee ID from the selected row in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int attendeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AttendeeID"].Value);

                // Get the values from the input fields
                string firstName = textBox1.Text.Trim();
                string lastName = textBox2.Text.Trim();
                string email = textBox3.Text.Trim();
                string phoneNumber = textBox5.Text.Trim();

                // Validate inputs
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show("All fields are required!");
                    return;
                }

                // Ensure phone number is in the correct format (example: only digits)
                if (!long.TryParse(phoneNumber, out long parsedPhoneNumber))
                {
                    MessageBox.Show("Phone number is not in the correct format.");
                    return;
                }

                // Get the current timestamp for the UpdatedAt field
                DateTime updatedAt = DateTime.Now;

                // SQL query to insert data into NewAttendee
                string query = "INSERT INTO NewAttendee (AttendeeID, FirstName, LastName, Email, PhoneNumber, UpdatedAt) " +
                               "VALUES (@AttendeeID, @FirstName, @LastName, @Email, @PhoneNumber, @UpdatedAt)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters to avoid SQL injection
                    cmd.Parameters.AddWithValue("@AttendeeID", attendeeId);  // Use the attendeeId here
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@UpdatedAt", updatedAt);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Attendee details updated successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an attendee to edit.");
            }
        }
    }
               
                
  }
 
    

