using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace WeekSummary
{
	public class MainForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MenuItem mnuFileFlip;
		internal System.Windows.Forms.MenuItem MenuItem3;
		internal System.Windows.Forms.MenuItem mnuFile;
		internal System.Windows.Forms.MenuItem mnuFileExit;
		internal System.Windows.Forms.MainMenu MainMenu1;
		private Gravitybox.Controls.Schedule Schedule1;
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			InitializeComponent();
			this.mnuFileFlip.Click += new System.EventHandler(this.mnuFileFlip_Click);
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			this.Load += new System.EventHandler(this.MainForm_Load);
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
			this.mnuFileFlip = new System.Windows.Forms.MenuItem();
			this.MenuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuFileExit = new System.Windows.Forms.MenuItem();
			this.MainMenu1 = new System.Windows.Forms.MainMenu();
			this.Schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// mnuFileFlip
			// 
			this.mnuFileFlip.Index = 0;
			this.mnuFileFlip.RadioCheck = true;
			this.mnuFileFlip.Text = "&Flip Mode";
			// 
			// MenuItem3
			// 
			this.MenuItem3.Index = 1;
			this.MenuItem3.Text = "-";
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						this.mnuFileFlip,
																																						this.MenuItem3,
																																						this.mnuFileExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Index = 2;
			this.mnuFileExit.Text = "E&xit";
			// 
			// MainMenu1
			// 
			this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.mnuFile});
			// 
			// Schedule1
			// 
			this.Schedule1.AllowDrop = true;
			this.Schedule1.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.Schedule1.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.Schedule1.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Schedule1.ColumnHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.ColumnHeader.FrameIncrement = 0;
			this.Schedule1.ColumnHeader.Size = 100;
			this.Schedule1.DayLength = 16;
			this.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.Schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.Schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Schedule1.Location = new System.Drawing.Point(0, 0);
			this.Schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
			this.Schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.Schedule1.Name = "Schedule1";
			this.Schedule1.RowHeader.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Schedule1.RowHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.RowHeader.FrameIncrement = 0;
			this.Schedule1.RowHeader.Size = 30;
			this.Schedule1.SelectedAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.Schedule1.SelectedAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
			this.Schedule1.SelectedAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.SelectedAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.Schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.Schedule1.SelectedAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.Selector.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.Schedule1.Selector.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.Schedule1.Selector.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.Schedule1.Selector.Column = 0;
			this.Schedule1.Selector.Length = 1;
			this.Schedule1.Selector.Row = 0;
			this.Schedule1.Size = new System.Drawing.Size(504, 349);
			this.Schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.Schedule1.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 349);
			this.Controls.Add(this.Schedule1);
			this.Menu = this.MainMenu1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET Blockout Example";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		#region Load

		private void MainForm_Load(object sender, System.EventArgs e)
		{

			this.SetBounds(0, 0, 800, 500);

			//Setup the Schedule properties
			Schedule1.HeaderDateFormat = "MM/dd";
			Schedule1.SetMinMaxDate(DateTime.Parse("1/12/2004"), DateTime.Parse("1/16/2004"));
			Schedule1.StartTime = DateTime.Parse("8:00:00 AM");
			Schedule1.DayLength = 10;
			Schedule1.BlockoutColor = Color.Blue;

			//Create the lunch hour
			Schedule1.ColoredAreaCollection.Add("", Color.LightGreen, DateTime.Parse("12:00:00 PM"), 60);
			Schedule1.ColumnHeader.AutoFit = true;
			Schedule1.RowHeader.AutoFit = true;

			//Load the Rooms
			Schedule1.RoomCollection.Add("", "Room1");
			Schedule1.RoomCollection.Add("", "Room2");

			//Load some appointments
			Appointment appointment;
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/12/2004"), Schedule1.RoomCollection[0], DateTime.Parse("9:00:00 AM"), 90);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/13/2004"), Schedule1.RoomCollection[1], DateTime.Parse("3:00:00 PM"), 120);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/13/2004"), Schedule1.RoomCollection[0], DateTime.Parse("10:00:00 AM"), 90);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/13/2004"), Schedule1.RoomCollection[1], DateTime.Parse("9:00:00 AM"), 120);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/13/2004"), Schedule1.RoomCollection[0], DateTime.Parse("11:00:00 AM"), 60);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/13/2004"), Schedule1.RoomCollection[1], DateTime.Parse("4:00:00 PM"), 120);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/14/2004"), Schedule1.RoomCollection[0], DateTime.Parse("8:00:00 AM"), 60);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/14/2004"), Schedule1.RoomCollection[1], DateTime.Parse("9:00:00 AM"), 60);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/14/2004"), Schedule1.RoomCollection[0], DateTime.Parse("9:30:00 AM"), 90);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/14/2004"), Schedule1.RoomCollection[1], DateTime.Parse("11:00:00 AM"), 30);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/15/2004"), Schedule1.RoomCollection[0], DateTime.Parse("8:30:00 AM"), 30);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/15/2004"), Schedule1.RoomCollection[1], DateTime.Parse("3:30:00 AM"), 90);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/15/2004"), Schedule1.RoomCollection[0], DateTime.Parse("1:30:00 AM"), 60);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/15/2004"), Schedule1.RoomCollection[1], DateTime.Parse("1:30:00 PM"), 120);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/15/2004"), Schedule1.RoomCollection[0], DateTime.Parse("3:00:00 PM"), 90);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/16/2004"), Schedule1.RoomCollection[1], DateTime.Parse("9:00:00 AM"), 120);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/16/2004"), Schedule1.RoomCollection[0], DateTime.Parse("10:30:00 AM"), 60);
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Parse("1/16/2004"), Schedule1.RoomCollection[1], DateTime.Parse("4:30:00 AM"), 30);

			foreach (Appointment element in Schedule1.AppointmentCollection)
				element.Subject = RandomString();
    
		}

		#endregion

		#region Random String

		public string RandomString()
		{
			return RandomString(10);
		}

		public string RandomString(int count)
		{

			string retval = "";
			if (count < 1)
				count++;

			System.Random rnd = new System.Random();
			for (int ii=1;ii<=count;ii++)
			{
				int c = (65 + (int)(25 * rnd.NextDouble()));
				retval += (char)c;
			}
	
			return retval;

		}

		#endregion

		#region Menus

		private void mnuFileExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuFileFlip_Click(object sender, System.EventArgs e)
		{

			Schedule1.AutoRedraw = false;

			//Now check to normal interactive day mode
			foreach (Appointment appointment in Schedule1.AppointmentCollection)
				appointment.Blockout = !mnuFileFlip.Checked;
    
			Schedule1.AllowSelector = mnuFileFlip.Checked;
			mnuFileFlip.Checked = !mnuFileFlip.Checked;

			Schedule1.AutoRedraw = true;

		}

		#endregion

	}
}
