using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventVerse
{
    public partial class AttendeeDashboardForm : Form
    {
        public AttendeeDashboardForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Return to the login form
            AttendeeLoginForm loginForm = new AttendeeLoginForm();
            loginForm.Show();
            this.Close(); // Close the dashboard
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            EventBookingForm EventForm = new EventBookingForm();
            EventForm.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            EventForm.FormClosed += (s, args) => this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            EventSearchForm searchForm = new EventSearchForm();
            searchForm.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            searchForm.FormClosed += (s, args) => this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            MyEventsForm myEvent = new MyEventsForm();
            myEvent.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            myEvent.FormClosed += (s, args) => this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            ProfileForm myprofile = new ProfileForm();
            myprofile.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            myprofile.FormClosed += (s, args) => this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            FeedbackForm myprofile = new FeedbackForm();
            myprofile.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            myprofile.FormClosed += (s, args) => this.Close();
        }
    }
}
