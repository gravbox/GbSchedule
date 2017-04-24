using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Datasets
{
	public class Form1 : System.Windows.Forms.Form
	{

		internal Gravitybox.Controls.Schedule Schedule1;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button Button1;
		private System.Windows.Forms.Label lblHeader;
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
			this.Schedule1 = new Gravitybox.Controls.Schedule();
			this.Button3 = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button1 = new System.Windows.Forms.Button();
			this.lblHeader = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Schedule1
			// 
			this.Schedule1.AllowDrop = true;
			this.Schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Schedule1.Appearance.FontSize = 10F;
			this.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.Schedule1.ColumnHeader.Appearance.FontSize = 10F;
			this.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Schedule1.ColumnHeader.Size = 100;
			this.Schedule1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Schedule1.DataSource = null;
			this.Schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.Schedule1.EventHeader.AllowExpand = false;
			this.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.Schedule1.EventHeader.Appearance.FontSize = 10F;
			this.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.Schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.Schedule1.Location = new System.Drawing.Point(0, 64);
			this.Schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
			this.Schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.Schedule1.Name = "Schedule1";
			this.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.Schedule1.RowHeader.Appearance.FontSize = 10F;
			this.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Schedule1.RowHeader.Size = 30;
			this.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
			this.Schedule1.SelectedAppointmentAppearance.FontSize = 10F;
			this.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
			this.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.Schedule1.Selector.Appearance.FontSize = 10F;
			this.Schedule1.Size = new System.Drawing.Size(600, 296);
			this.Schedule1.StartTime = new System.DateTime(((long)(0)));
			this.Schedule1.TabIndex = 4;
			this.Schedule1.DataSourceUpdated += new Gravitybox.Objects.RefreshDelegate(this.Schedule1_DataSourceUpdated);
			this.Schedule1.AfterAppointmentAdd += new Gravitybox.Controls.Schedule.AfterAppointmentEventDelegate(this.Schedule1_AfterAppointmentAdd);
			// 
			// Button3
			// 
			this.Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Button3.Enabled = false;
			this.Button3.Location = new System.Drawing.Point(328, 370);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(152, 24);
			this.Button3.TabIndex = 7;
			this.Button3.Text = "Remove Appointment";
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			// 
			// Button2
			// 
			this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Button2.Enabled = false;
			this.Button2.Location = new System.Drawing.Point(168, 370);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(152, 24);
			this.Button2.TabIndex = 6;
			this.Button2.Text = "Add Appointments";
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// Button1
			// 
			this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Button1.Location = new System.Drawing.Point(8, 370);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(152, 24);
			this.Button1.TabIndex = 5;
			this.Button1.Text = "Create Dataset";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// lblHeader
			// 
			this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblHeader.Location = new System.Drawing.Point(0, 0);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(600, 56);
			this.lblHeader.TabIndex = 8;
			this.lblHeader.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 397);
			this.Controls.Add(this.lblHeader);
			this.Controls.Add(this.Schedule1);
			this.Controls.Add(this.Button3);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Button1_Click(System.Object sender, System.EventArgs e)
		{

			//Setup the schedule
			Schedule1.SetMinMaxDate(new DateTime(2004, 1, 1), new DateTime(2004, 1, 4));
			Schedule1.StartTime = new DateTime(2004, 1, 1, 8, 0, 0);
			Schedule1.DayLength = 10;
			Schedule1.ColumnHeader.AutoFit = true;
			Schedule1.AllowRemove = true;

			//Create a dataset with an "Appointment" table
			System.Data.DataSet ds = new System.Data.DataSet();
			System.Data.DataTable dt = ds.Tables.Add("appointment");

			//Create the necessary columns
			dt.Columns.Add("appointment_guid", typeof(string));
			dt.Columns.Add("start_date", typeof(DateTime));
			dt.Columns.Add("start_time", typeof(DateTime));
			dt.Columns.Add("length", typeof(int));

			//Mark to disallow DBNull
			dt.Columns["appointment_guid"].AllowDBNull = false;
			dt.Columns["start_date"].AllowDBNull = false;
			dt.Columns["start_time"].AllowDBNull = false;
			dt.Columns["length"].AllowDBNull = false;

			//Mark the 'appointment_guid' column as a unique appointment_guid
			dt.Columns["appointment_guid"].Unique = true;

			//Optional Columns
			dt.Columns.Add("subject", typeof(string));
			dt.Columns.Add("ToolTipText", typeof(string));

			//Add datarows. This will be displayed by the schedule when it is databound
			System.Data.DataRow dr;
			dr = CreateDataRow(dt, Guid.NewGuid().ToString(), new DateTime(2004, 1, 1), new DateTime(2004, 1, 1, 8, 0, 0), 60, "Appointment 1");
			dr["ToolTipText"] = "This is a tip!";
			dr = CreateDataRow(dt, Guid.NewGuid().ToString(), new DateTime(2004, 1, 2), new DateTime(2004, 1, 2, 9, 0, 0), 60, "Appointment 2");
			dr = CreateDataRow(dt, Guid.NewGuid().ToString(), new DateTime(2004, 1, 3), new DateTime(2004, 1, 3, 10, 0, 0), 60, "Appointment 3");

			//Bind the dataset to the schedule
			Schedule1.DataSource = ds;
			Schedule1.Bind();

			DisplayAppointmentCount();

			this.Button2.Enabled = true;
			this.Button3.Enabled = true;

		}

		private System.Data.DataRow CreateDataRow(System.Data.DataTable dataTable, string key, DateTime startDate, DateTime startTime, int length, string subject)
		{

			//Create and populate a new row
			System.Data.DataRow dr = dataTable.NewRow();
			dr["appointment_guid"] = key;
			dr["start_date"] = startDate;
			dr["start_time"] = startTime;
			dr["length"] = length;
			dr["subject"] = subject;
			dataTable.Rows.Add(dr);
			return dr;

		}

		private void Button2_Click(System.Object sender, System.EventArgs e)
		{

			//Add 4 appointments to the schedule
			Schedule1.AutoRedraw = false;
			for (int ii=0;ii<=3;ii++)
			{
				Gravitybox.Objects.Appointment appointment;
				appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(ii), new DateTime(2004, 1, 1, 11, 0, 0), 60);
				appointment.Subject = "Appointment " + Schedule1.AppointmentCollection.Count.ToString();
			}
			Schedule1.AutoRedraw = true;
			DisplayAppointmentCount();

		}

		private void Button3_Click(System.Object sender, System.EventArgs e)
		{

			//Remove an appointment if possible
			if (Schedule1.AppointmentCollection.Count > 0)
			{
				Schedule1.AppointmentCollection.RemoveAt(0);
				DisplayAppointmentCount();
			}

		}

		private void DisplayAppointmentCount()
		{

			//Display the current number of appointments in the dataset.
			//This shows that the dataset is being updated by the schedule
			int count = ((System.Data.DataSet)Schedule1.DataSource).Tables[0].Rows.Count;
			MessageBox.Show("The current number of appointments is " + count.ToString(), "Appointment Count", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		private void Schedule1_DataSourceUpdated(object sender, System.EventArgs e)
		{
			//Notify that the dataset has been updated
			System.Diagnostics.Debug.WriteLine("DataSourceUpdated");
		}

		private void Schedule1_AfterAppointmentAdd(object sender, Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs e)
		{

			//Setup the appointment to look nice
			Gravitybox.Objects.Appointment appointment = (Gravitybox.Objects.Appointment)e.BaseObject;
			appointment.Appearance.BackColor = Color.White;
			appointment.Appearance.BackColor2 = Color.LightBlue;
			appointment.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal;
			appointment.Appearance.IsRound = true;
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			lblHeader.Text = "The first button below will create a dataset object and assign it to the schedule's Datasource property. The second button will add appointments to the schedule's AppointmentCollection and also update the underlying dataset. The third button will remove an appointment thereby updating the underlying dataset.";
		}

	}

}
