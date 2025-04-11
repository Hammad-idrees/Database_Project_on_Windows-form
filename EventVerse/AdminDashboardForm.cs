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
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Close the current Event booking form
            this.Hide();

            // Open the Event booking form
            UserManagementForm searchForm = new UserManagementForm();
            searchForm.Show();

            // Optionally, if you want to close the current form when the user exits the event booking form
            searchForm.FormClosed += (s, args) => this.Close();
        }
    }
}
