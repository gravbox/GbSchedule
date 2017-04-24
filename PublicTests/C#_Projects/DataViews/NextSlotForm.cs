using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace DataViews
{
	public class NextSlotForm : System.Windows.Forms.Form
	{

		#region Form Header

		internal System.Windows.Forms.Timer Timer1;
		internal System.Windows.Forms.Button cmdClose;
		internal System.Windows.Forms.Label lblDescription;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public NextSlotForm()
		{
			InitializeComponent();
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
			this.Load += new System.EventHandler(this.NextSlotForm_Load);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.cmdClose = new System.Windows.Forms.Button();
			this.lblDescription = new System.Windows.Forms.Label();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// Timer1
			// 
			this.Timer1.Interval = 2000;
			// 
			// cmdClose
			// 
			this.cmdClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.cmdClose.Location = new System.Drawing.Point(544, 416);
			this.cmdClose.Name = "cmdClose";
			this.cmdClose.Size = new System.Drawing.Size(80, 24);
			this.cmdClose.TabIndex = 5;
			this.cmdClose.Text = "&Close";
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblDescription.Location = new System.Drawing.Point(0, 408);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(536, 40);
			this.lblDescription.TabIndex = 4;
			this.lblDescription.Text = "[XXX]";
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
			this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.schedule1.Name = "schedule1";
			this.schedule1.SelectedItem = null;
			this.schedule1.Size = new System.Drawing.Size(632, 400);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 3;
			// 
			// NextSlotForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 445);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.lblDescription,
																																	this.schedule1,
																																	this.cmdClose});
			this.Name = "NextSlotForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NextSlotForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void NextSlotForm_Load(object sender, System.EventArgs e)
		{

			this.WindowState = FormWindowState.Maximized;
			this.Timer1.Interval = 800;

			lblDescription.Text = "This screen has a number of predefined appointments. An appointment will display in the top, left hand corner of the schedule and then move to the next free slot every 2 seconds. This functionality allows you query the schedule for available appointment space. Press 'Close' to close the screen.";

			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/5/2004"));
			schedule1.DayLength = 9;
			schedule1.RowHeader.Size = 25;
			schedule1.ColumnHeader.AutoFit = true;
			schedule1.AllowSelector = false;

			//Load some appointments
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("10:00:00 AM"), 60);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("12:00:00 PM"), 90);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("2:00:00 PM"), 60);

			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("8:30:00 AM"), 30);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("10:00:00 AM"), 30);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("11:00:00 AM"), 60);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("3:00:00 PM"), 60);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("4:30:00 PM"), 30);

			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("8:00:00 AM"), 30);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("10:30:00 AM"), 120);
			schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("3:30:00 PM"), 45);

			//Setup some appointment properties    
			int ii = 1;
			foreach (Appointment element in schedule1.AppointmentCollection)
			{
				element.Subject = "This is appointment " + ii.ToString();
				ii += 1;
			}

			//*******************************************
			//Add the appointment for which we will search for slots
			//Its key is "xyz", this can be any unique string 
			Appointment appointment;
			appointment = schedule1.AppointmentCollection.Add("xyz", DateTime.Parse("1/1/2004"), DateTime.Parse("8:00:00 AM"), 60);
			appointment.Subject = "Test Appt";
			appointment.Appearance.BackColor = Color.LightBlue;
			Timer1.Enabled = true;

			//Refresh the schedule
			schedule1.Refresh();

		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{

			//Get a refernece to the appointment "xyz"
			Appointment appointment = schedule1.AppointmentCollection["xyz"];

			//Create a skip collection to skip the test appointment itself
			//otherwise it will find itself as a conflict
			AppointmentList skipAppts = new AppointmentList(schedule1);
			skipAppts.Add(appointment);

			//Start the search at the appointment's current time + the schedule time increment (30 minutes)
			DateTime startTime = appointment.StartDateTime.Add(new TimeSpan(0, int.Parse(schedule1.TimeIncrement.ToString("d")), 0));

			//Find the next time slot
			Appointment testSlot = schedule1.AppointmentCollection.ToList().NextAreaAvailable(appointment.StartDate, startTime, appointment.Length, true, skipAppts);

			//Set the appointment's properties to reflect the new time slot
			if (testSlot == null)
			{
        appointment.StartDate = new DateTime(2004, 1, 1);
        appointment.StartTime = new DateTime(2004, 1, 1, 8, 0, 0);
			}
			else
			{
				appointment.StartDate = testSlot.StartDate;
				appointment.StartTime = testSlot.StartTime;
			}

			//Refresh the schedule
			schedule1.Refresh();
		}

		private void cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
