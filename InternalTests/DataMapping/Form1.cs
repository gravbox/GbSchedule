using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DatabaseMapping
{
	public class Form1 : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label lblHeader;
    private Panel panel1;
    private Button button1;
    private Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.lblHeader = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.schedule1 = new Gravitybox.Controls.Schedule();
      this.button1 = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblHeader
      // 
      this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblHeader.Location = new System.Drawing.Point(0, 0);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Size = new System.Drawing.Size(615, 40);
      this.lblHeader.TabIndex = 1;
      this.lblHeader.Text = "[LABEL]";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 312);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(615, 37);
      this.panel1.TabIndex = 2;
      // 
      // schedule1
      // 
      this.schedule1.AllowDrop = true;
      this.schedule1.Appearance.FontSize = 10F;
      this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
      this.schedule1.Appearance.NoFill = false;
      this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
      this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.schedule1.ColumnHeader.Appearance.FontSize = 10F;
      this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.schedule1.ColumnHeader.Appearance.NoFill = false;
      this.schedule1.ColumnHeader.Size = 100;
      this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
      this.schedule1.DefaultAppointmentAppearance.NoFill = false;
      this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
      this.schedule1.DefaultAppointmentHeaderAppearance.NoFill = false;
      this.schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
      this.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
      this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.schedule1.EventHeader.Appearance.FontSize = 10F;
      this.schedule1.EventHeader.Appearance.NoFill = false;
      this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
      this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
      this.schedule1.EventHeader.ExpandAppearance.NoFill = false;
      this.schedule1.Location = new System.Drawing.Point(0, 40);
      this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
      this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
      this.schedule1.Name = "schedule1";
      this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.schedule1.RowHeader.Appearance.FontSize = 10F;
      this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.schedule1.RowHeader.Appearance.NoFill = false;
      this.schedule1.RowHeader.Size = 30;
      this.schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
      this.schedule1.SelectedAppointmentAppearance.FontSize = 10F;
      this.schedule1.SelectedAppointmentAppearance.NoFill = false;
      this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
      this.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
      this.schedule1.SelectedAppointmentHeaderAppearance.NoFill = false;
      this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
      this.schedule1.Selector.Appearance.FontSize = 10F;
      this.schedule1.Selector.Appearance.NoFill = false;
      this.schedule1.Size = new System.Drawing.Size(615, 272);
      this.schedule1.StartTime = new System.DateTime(((long)(0)));
      this.schedule1.TabIndex = 3;
      this.schedule1.TimeMarker.Appearance.FontSize = 10F;
      this.schedule1.TimeMarker.Appearance.NoFill = false;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(8, 8);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(615, 349);
      this.Controls.Add(this.schedule1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.lblHeader);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Gravitybox Schedule";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		#region PopulateSchedule

		private void PopulateSchedule(DataSet ds)
		{
			//Map fields

			//Clear all bindings
			schedule1.DataBindings.FromXML("");

			//Appointment
			schedule1.DataBindings.AppointmentBinding.DataSource = ds.Tables["A_Table"];
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("appointment_guid", "key");
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("start_date", "the_start");
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("length", "the_length");
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("subject", "the_text");

			//Category
			schedule1.DataBindings.CategoryBinding.DataSource = ds.Tables["C_Table"];
			schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("category_guid", "key");
			schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("name", "the_text");
			schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("color", "the_color");

			//Appointment-Category Link table
			schedule1.DataBindings.AppointmentCategoryBinding.DataSource = ds.Tables["AC_Table"];
			schedule1.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Add("appointment_guid", "key1");
			schedule1.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Add("category_guid", "key2");

			//Provider
			schedule1.DataBindings.ProviderBinding.DataSource = ds.Tables["P_Table"];
			schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("provider_guid", "key");
			schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("name", "the_text");
			schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("color", "the_color");

			//Appointment-Provider Link table
			schedule1.DataBindings.AppointmentProviderBinding.DataSource = ds.Tables["AP_Table"];
			schedule1.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Add("appointment_guid", "key1");
			schedule1.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Add("provider_guid", "key2");

			//Room
			schedule1.DataBindings.RoomBinding.DataSource = ds.Tables["R_Table"];
			schedule1.DataBindings.RoomBinding.DataFieldBindingCollection.Add("room_guid", "key");
			schedule1.DataBindings.RoomBinding.DataFieldBindingCollection.Add("name", "the_text");

			//Bind the dataset to the schedule
			schedule1.DataSource = ds;
			schedule1.Bind();

			MessageBox.Show("Load Success!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		#endregion

		#region Form Load

    DataSet ds = null;
		private void Form1_Load(object sender, System.EventArgs e)
		{
			lblHeader.Text = "The dataset would normally be created by querying a database but in this example we will just build it manually.";
			ds = CreateDataset();
			FillData(ds);
			PopulateSchedule(ds);

			//Setup the schedule
			schedule1.SetMinMaxDate(DateTime.Now, DateTime.Now.AddDays(5));
			schedule1.StartTime = new DateTime(2004, 1, 1, 8, 0, 0);
			schedule1.DayLength = 10;
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
		}

		#endregion

		#region CreateDataset

		private DataSet CreateDataset()
		{
			//**************************************
			//This method creates tables that will be 
			//mapped to the schedule control with data mapping
			//A_Table = Appointment
			//C_Table = Category
			//P_Table = Provider
			//R_Table = Room
			//AC_Table = AppointmentCategory
			//AP_Table = AppointmentProvider
			//**************************************

			//Create a new dataset
			DataSet ds = new DataSet();
			DataTable dt = null;

			//Create the table to map to the Appointment table
			dt = new DataTable("A_Table");
			dt.Columns.Add("key", typeof(string));
			dt.Columns.Add("the_start", typeof(DateTime));
			dt.Columns.Add("the_length", typeof(int));
			dt.Columns.Add("the_text", typeof(string));
      dt.Columns.Add("NewProperty", typeof(string));
			ds.Tables.Add(dt);

			//Create the table to map to the Category table
			dt = new DataTable("C_Table");
			dt.Columns.Add("key", typeof(string));
			dt.Columns.Add("the_text", typeof(string));
			dt.Columns.Add("the_color", typeof(int));
			ds.Tables.Add(dt);

			//Create the table to map to the Provider table
			dt = new DataTable("P_Table");
			dt.Columns.Add("key", typeof(string));
			dt.Columns.Add("the_text", typeof(string));
			dt.Columns.Add("the_color", typeof(int));
			ds.Tables.Add(dt);

			//Create the table to map to the Room table
			dt = new DataTable("R_Table");
			dt.Columns.Add("key", typeof(string));
			dt.Columns.Add("the_text", typeof(string));
			ds.Tables.Add(dt);

			//Create the table to map to the Appoitment_Category table
			dt = new DataTable("AC_Table");
			dt.Columns.Add("key1", typeof(string));
			dt.Columns.Add("key2", typeof(string));
			ds.Tables.Add(dt);

			//Create the table to map to the Appoitment_Provider table
			dt = new DataTable("AP_Table");
			dt.Columns.Add("key1", typeof(string));
			dt.Columns.Add("key2", typeof(string));
			ds.Tables.Add(dt);

			//Set fields to be unique if required
			ds.Tables["A_Table"].Columns["key"].Unique = true;
			ds.Tables["C_Table"].Columns["key"].Unique = true;
			ds.Tables["P_Table"].Columns["key"].Unique = true;
			ds.Tables["R_Table"].Columns["key"].Unique = true;

			//Set fields to disallow Null if required
			ds.Tables["A_Table"].Columns["key"].AllowDBNull = false;
			ds.Tables["A_Table"].Columns["the_start"].AllowDBNull = false;
			ds.Tables["A_Table"].Columns["the_length"].AllowDBNull = false;
			ds.Tables["C_Table"].Columns["key"].AllowDBNull = false;
			ds.Tables["C_Table"].Columns["the_text"].AllowDBNull = false;
			ds.Tables["C_Table"].Columns["the_color"].AllowDBNull = false;
			ds.Tables["P_Table"].Columns["key"].AllowDBNull = false;
			ds.Tables["P_Table"].Columns["the_text"].AllowDBNull = false;
			ds.Tables["P_Table"].Columns["the_color"].AllowDBNull = false;
			ds.Tables["R_Table"].Columns["key"].AllowDBNull = false;
			ds.Tables["R_Table"].Columns["the_text"].AllowDBNull = false;
			ds.Tables["AC_Table"].Columns["key1"].AllowDBNull = false;
			ds.Tables["AC_Table"].Columns["key2"].AllowDBNull = false;			
			ds.Tables["AP_Table"].Columns["key1"].AllowDBNull = false;
			ds.Tables["AP_Table"].Columns["key2"].AllowDBNull = false;

			//Return the newly create dataset
			return ds;
		}

		#endregion

		#region FillData

		private void FillData(DataSet ds)
		{
			//This simulates loading from a database. There will be data in the dataset when we bind it
			DataRow dr = null;

			//Create an appointment at 9:00 AM tommorrow
			dr = ds.Tables["A_Table"].NewRow();
			dr["key"] = "A111"; //Some key
			dr["the_start"] = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1, 9, 0, 0);
			dr["the_length"] = 120; //2 hours
			dr["the_text"] = "Test Appointment";
			ds.Tables["A_Table"].Rows.Add(dr);

			//Create a Category
			dr = ds.Tables["C_Table"].NewRow();
			dr["key"] = "C111"; //Some key
			dr["the_text"] = "Category 1";
			dr["the_Color"] = Color.Blue.ToArgb();
			ds.Tables["C_Table"].Rows.Add(dr);

			//Create a Provider
			dr = ds.Tables["P_Table"].NewRow();
			dr["key"] = "P111"; //Some key
			dr["the_text"] = "Provider 1";
			dr["the_Color"] = Color.Yellow.ToArgb();
			ds.Tables["P_Table"].Rows.Add(dr);

			//Connect the Appointment and Category
			dr = ds.Tables["AC_Table"].NewRow();
			dr["key1"] = "A111";
			dr["key2"] = "C111";
			ds.Tables["AC_Table"].Rows.Add(dr);

			//Connect the Appointment and Provider
			dr = ds.Tables["AP_Table"].NewRow();
			dr["key1"] = "A111";
			dr["key2"] = "P111";
			ds.Tables["AP_Table"].Rows.Add(dr);

		}

		#endregion

    private void button1_Click(object sender, System.EventArgs e)
    {
      DataRow dr = ds.Tables[0].Rows[0];
      MessageBox.Show("DATASET: start time: " + dr["the_start"].ToString() + " Length: " + dr["the_length"].ToString() + " Subject: " + dr["the_text"].ToString(), "Info", MessageBoxButtons.OK);
      MessageBox.Show("SCHTRIPS: PUTime: " + this.schedule1.SelectedItem.StartTime.ToShortTimeString() + " Length: " + this.schedule1.SelectedItem.Length.ToString() + " Subject: " + this.schedule1.SelectedItem.Subject.ToString(), "Info", MessageBoxButtons.OK);
    }

	}
}
