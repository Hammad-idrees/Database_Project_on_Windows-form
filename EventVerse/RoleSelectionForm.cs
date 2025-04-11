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
    public partial class RoleSelectionForm : Form
    {
        public RoleSelectionForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Open Attendee Registration/Login Form
            AdminLoginForm adminForm = new AdminLoginForm();
            adminForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open Attendee Registration/Login Form
            AttendeeLoginForm attendeeForm = new AttendeeLoginForm();
            attendeeForm.Show();
            this.Hide();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightBlue; // Change background color on hover
            button1.ForeColor = Color.Black;     // Change text color on hover
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightBlue; // Change background color on hover
            button2.ForeColor = Color.Black;     // Change text color on hover
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightBlue; // Change background color on hover
            button3.ForeColor = Color.Black;     // Change text color on hover
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightBlue; // Change background color on hover
            button4.ForeColor = Color.Black;     // Change text color on hover
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control; // Revert background color
            button1.ForeColor = SystemColors.ControlText; // Revert text color
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.Control; // Revert background color
            button2.ForeColor = SystemColors.ControlText; // Revert text color
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = SystemColors.Control; // Revert background color
            button3.ForeColor = SystemColors.ControlText; // Revert text color
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.Control; // Revert background color
            button4.ForeColor = SystemColors.ControlText; // Revert text color
        }

       

    }
}
