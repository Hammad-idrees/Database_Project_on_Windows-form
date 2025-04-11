namespace EventVerse
{
    partial class EventSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventSearchForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.txtMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAvailableTickets = new System.Windows.Forms.CheckBox();
            this.cmbEventCategory = new System.Windows.Forms.ComboBox();
            this.dgvEventDetails = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.eventVerseDataSet = new EventVerse.EventVerseDataSet();
            this.eventVerseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventVerseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventVerseDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(504, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 53);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search Events";
            // 
            // txtEventName
            // 
            this.txtEventName.BackColor = System.Drawing.SystemColors.Info;
            this.txtEventName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEventName.Location = new System.Drawing.Point(404, 80);
            this.txtEventName.Multiline = true;
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(506, 46);
            this.txtEventName.TabIndex = 6;
            this.txtEventName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(932, 80);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(128, 46);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(404, 224);
            this.dtpStartDate.MaximumSize = new System.Drawing.Size(300, 40);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(300, 40);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(300, 40);
            this.dtpStartDate.TabIndex = 8;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Location = new System.Drawing.Point(407, 142);
            this.label2.MaximumSize = new System.Drawing.Size(500, 40);
            this.label2.MinimumSize = new System.Drawing.Size(500, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filters";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Date Range:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(408, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Event Categories:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(408, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Location:\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Items.AddRange(new object[] {
            "San Francisco",
            "Los Angeles",
            "New York",
            "Austin",
            "London",
            "",
            "Dubai",
            "Chicago",
            "Berlin",
            "San ",
            "Francisco",
            "Paris"});
            this.cmbLocation.Location = new System.Drawing.Point(404, 389);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(300, 24);
            this.cmbLocation.TabIndex = 14;
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.Location = new System.Drawing.Point(404, 453);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(300, 22);
            this.txtMaxPrice.TabIndex = 15;
            this.txtMaxPrice.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(408, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Price Range:\r\n";
            // 
            // chkAvailableTickets
            // 
            this.chkAvailableTickets.AutoSize = true;
            this.chkAvailableTickets.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkAvailableTickets.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAvailableTickets.Location = new System.Drawing.Point(913, 142);
            this.chkAvailableTickets.Name = "chkAvailableTickets";
            this.chkAvailableTickets.Size = new System.Drawing.Size(192, 30);
            this.chkAvailableTickets.TabIndex = 17;
            this.chkAvailableTickets.Text = "Available Tickets";
            this.chkAvailableTickets.UseVisualStyleBackColor = false;
            // 
            // cmbEventCategory
            // 
            this.cmbEventCategory.FormattingEnabled = true;
            this.cmbEventCategory.Items.AddRange(new object[] {
            "Technology",
            "",
            "Music",
            "",
            "Business",
            "",
            "Technology",
            "",
            "Music",
            "",
            "Business",
            "Technology",
            "",
            "Healthcare",
            "Culture"});
            this.cmbEventCategory.Location = new System.Drawing.Point(404, 321);
            this.cmbEventCategory.Name = "cmbEventCategory";
            this.cmbEventCategory.Size = new System.Drawing.Size(300, 24);
            this.cmbEventCategory.TabIndex = 19;
            this.cmbEventCategory.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // dgvEventDetails
            // 
            this.dgvEventDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEventDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventDetails.Location = new System.Drawing.Point(725, 196);
            this.dgvEventDetails.Name = "dgvEventDetails";
            this.dgvEventDetails.RowHeadersWidth = 51;
            this.dgvEventDetails.RowTemplate.Height = 24;
            this.dgvEventDetails.Size = new System.Drawing.Size(537, 279);
            this.dgvEventDetails.TabIndex = 20;
            this.dgvEventDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-8, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1308, 541);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(12, 438);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 52);
            this.button4.TabIndex = 25;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // eventVerseDataSet
            // 
            this.eventVerseDataSet.DataSetName = "EventVerseDataSet";
            this.eventVerseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eventVerseDataSetBindingSource
            // 
            this.eventVerseDataSetBindingSource.DataSource = this.eventVerseDataSet;
            this.eventVerseDataSetBindingSource.Position = 0;
            // 
            // EventSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 514);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgvEventDetails);
            this.Controls.Add(this.cmbEventCategory);
            this.Controls.Add(this.chkAvailableTickets);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaxPrice);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EventSearchForm";
            this.Text = "EventSearchForm";
            this.Load += new System.EventHandler(this.EventSearchForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventVerseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventVerseDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.NumericUpDown txtMaxPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAvailableTickets;
        private System.Windows.Forms.ComboBox cmbEventCategory;
        private System.Windows.Forms.DataGridView dgvEventDetails;
        private System.Windows.Forms.Button button4;
        private EventVerseDataSet eventVerseDataSet;
        private System.Windows.Forms.BindingSource eventVerseDataSetBindingSource;
    }
}