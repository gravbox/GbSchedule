using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace DataViews
{
	public class MainForm : System.Windows.Forms.Form
	{

		private  System.ComponentModel.Container components = null;

		public MainForm()
		{	

			#region Form Header

			InitializeComponent();
			this.Load += new EventHandler(MainForm_Load);
			this.cmdBlue.Click += new EventHandler(cmdBlue_Click);
			this.cmdColorCategory.Click += new EventHandler(cmdColorCategory_Click);
			this.cmdColorProvider.Click += new EventHandler(cmdColorProvider_Click);
			this.cmdColorRoom.Click += new EventHandler(cmdColorRoom_Click);
			this.cmdNextSlot.Click += new EventHandler(cmdNextSlot_Click);
			this.cmdToggleConflicts.Click += new EventHandler(cmdToggleConflicts_Click);
			this.cmdToggleHeader.Click += new EventHandler(cmdToggleHeader_Click);
			this.cmdToggleRound.Click += new EventHandler(cmdToggleRound_Click);
			this.cmdToggleTransparency.Click += new EventHandler(cmdToggleTransparency_Click);
			this.cmdViewmodeDay.Click += new EventHandler(cmdViewmodeDay_Click);
			this.cmdViewmodeDayRoom.Click += new EventHandler(cmdViewmodeDayRoom_Click);
			this.cmdViewmodeProvider.Click += new EventHandler(cmdViewmodeProvider_Click);
			this.cmdViewmodeRoom.Click += new EventHandler(cmdViewmodeRoom_Click);
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

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Panel1 = new System.Windows.Forms.Panel();
			this.cmdNextSlot = new System.Windows.Forms.Button();
			this.lblHeader4 = new System.Windows.Forms.Label();
			this.cmdToggleConflicts = new System.Windows.Forms.Button();
			this.cmdToggleTransparency = new System.Windows.Forms.Button();
			this.cmdToggleRound = new System.Windows.Forms.Button();
			this.cmdToggleHeader = new System.Windows.Forms.Button();
			this.lblHeader3 = new System.Windows.Forms.Label();
			this.cmdBlue = new System.Windows.Forms.Button();
			this.cmdColorRoom = new System.Windows.Forms.Button();
			this.cmdColorProvider = new System.Windows.Forms.Button();
			this.cmdColorCategory = new System.Windows.Forms.Button();
			this.cmdViewmodeProvider = new System.Windows.Forms.Button();
			this.cmdViewmodeRoom = new System.Windows.Forms.Button();
			this.cmdViewmodeDay = new System.Windows.Forms.Button();
			this.cmdViewmodeDayRoom = new System.Windows.Forms.Button();
			this.lblHeader2 = new System.Windows.Forms.Label();
			this.lblHeader1 = new System.Windows.Forms.Label();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel1
			// 
			this.Panel1.Controls.Add(this.cmdNextSlot);
			this.Panel1.Controls.Add(this.lblHeader4);
			this.Panel1.Controls.Add(this.cmdToggleConflicts);
			this.Panel1.Controls.Add(this.cmdToggleTransparency);
			this.Panel1.Controls.Add(this.cmdToggleRound);
			this.Panel1.Controls.Add(this.cmdToggleHeader);
			this.Panel1.Controls.Add(this.lblHeader3);
			this.Panel1.Controls.Add(this.cmdBlue);
			this.Panel1.Controls.Add(this.cmdColorRoom);
			this.Panel1.Controls.Add(this.cmdColorProvider);
			this.Panel1.Controls.Add(this.cmdColorCategory);
			this.Panel1.Controls.Add(this.cmdViewmodeProvider);
			this.Panel1.Controls.Add(this.cmdViewmodeRoom);
			this.Panel1.Controls.Add(this.cmdViewmodeDay);
			this.Panel1.Controls.Add(this.cmdViewmodeDayRoom);
			this.Panel1.Controls.Add(this.lblHeader2);
			this.Panel1.Controls.Add(this.lblHeader1);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(120, 531);
			this.Panel1.TabIndex = 5;
			// 
			// cmdNextSlot
			// 
			this.cmdNextSlot.Location = new System.Drawing.Point(8, 488);
			this.cmdNextSlot.Name = "cmdNextSlot";
			this.cmdNextSlot.Size = new System.Drawing.Size(104, 24);
			this.cmdNextSlot.TabIndex = 16;
			this.cmdNextSlot.Text = "Next Slot";
			// 
			// lblHeader4
			// 
			this.lblHeader4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHeader4.Location = new System.Drawing.Point(8, 464);
			this.lblHeader4.Name = "lblHeader4";
			this.lblHeader4.Size = new System.Drawing.Size(104, 16);
			this.lblHeader4.TabIndex = 15;
			this.lblHeader4.Text = "Effects (Toggle)";
			// 
			// cmdToggleConflicts
			// 
			this.cmdToggleConflicts.Location = new System.Drawing.Point(8, 432);
			this.cmdToggleConflicts.Name = "cmdToggleConflicts";
			this.cmdToggleConflicts.Size = new System.Drawing.Size(104, 24);
			this.cmdToggleConflicts.TabIndex = 14;
			this.cmdToggleConflicts.Text = "Conflicts";
			// 
			// cmdToggleTransparency
			// 
			this.cmdToggleTransparency.Location = new System.Drawing.Point(8, 400);
			this.cmdToggleTransparency.Name = "cmdToggleTransparency";
			this.cmdToggleTransparency.Size = new System.Drawing.Size(104, 24);
			this.cmdToggleTransparency.TabIndex = 13;
			this.cmdToggleTransparency.Text = "Transparency";
			// 
			// cmdToggleRound
			// 
			this.cmdToggleRound.Location = new System.Drawing.Point(8, 368);
			this.cmdToggleRound.Name = "cmdToggleRound";
			this.cmdToggleRound.Size = new System.Drawing.Size(104, 24);
			this.cmdToggleRound.TabIndex = 12;
			this.cmdToggleRound.Text = "Round";
			// 
			// cmdToggleHeader
			// 
			this.cmdToggleHeader.Location = new System.Drawing.Point(8, 336);
			this.cmdToggleHeader.Name = "cmdToggleHeader";
			this.cmdToggleHeader.Size = new System.Drawing.Size(104, 24);
			this.cmdToggleHeader.TabIndex = 11;
			this.cmdToggleHeader.Text = "Header";
			// 
			// lblHeader3
			// 
			this.lblHeader3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHeader3.Location = new System.Drawing.Point(8, 312);
			this.lblHeader3.Name = "lblHeader3";
			this.lblHeader3.Size = new System.Drawing.Size(104, 16);
			this.lblHeader3.TabIndex = 10;
			this.lblHeader3.Text = "Effects (Toggle)";
			// 
			// cmdBlue
			// 
			this.cmdBlue.Location = new System.Drawing.Point(8, 280);
			this.cmdBlue.Name = "cmdBlue";
			this.cmdBlue.Size = new System.Drawing.Size(104, 24);
			this.cmdBlue.TabIndex = 9;
			this.cmdBlue.Text = "Blue";
			// 
			// cmdColorRoom
			// 
			this.cmdColorRoom.Location = new System.Drawing.Point(8, 184);
			this.cmdColorRoom.Name = "cmdColorRoom";
			this.cmdColorRoom.Size = new System.Drawing.Size(104, 24);
			this.cmdColorRoom.TabIndex = 8;
			this.cmdColorRoom.Text = "by Room";
			// 
			// cmdColorProvider
			// 
			this.cmdColorProvider.Location = new System.Drawing.Point(8, 248);
			this.cmdColorProvider.Name = "cmdColorProvider";
			this.cmdColorProvider.Size = new System.Drawing.Size(104, 24);
			this.cmdColorProvider.TabIndex = 7;
			this.cmdColorProvider.Text = "by Provider";
			// 
			// cmdColorCategory
			// 
			this.cmdColorCategory.Location = new System.Drawing.Point(8, 216);
			this.cmdColorCategory.Name = "cmdColorCategory";
			this.cmdColorCategory.Size = new System.Drawing.Size(104, 24);
			this.cmdColorCategory.TabIndex = 6;
			this.cmdColorCategory.Text = "by Category";
			// 
			// cmdViewmodeProvider
			// 
			this.cmdViewmodeProvider.Location = new System.Drawing.Point(8, 128);
			this.cmdViewmodeProvider.Name = "cmdViewmodeProvider";
			this.cmdViewmodeProvider.Size = new System.Drawing.Size(104, 24);
			this.cmdViewmodeProvider.TabIndex = 5;
			this.cmdViewmodeProvider.Text = "by Provider";
			// 
			// cmdViewmodeRoom
			// 
			this.cmdViewmodeRoom.Location = new System.Drawing.Point(8, 96);
			this.cmdViewmodeRoom.Name = "cmdViewmodeRoom";
			this.cmdViewmodeRoom.Size = new System.Drawing.Size(104, 24);
			this.cmdViewmodeRoom.TabIndex = 4;
			this.cmdViewmodeRoom.Text = "by Room";
			// 
			// cmdViewmodeDay
			// 
			this.cmdViewmodeDay.Location = new System.Drawing.Point(8, 64);
			this.cmdViewmodeDay.Name = "cmdViewmodeDay";
			this.cmdViewmodeDay.Size = new System.Drawing.Size(104, 24);
			this.cmdViewmodeDay.TabIndex = 3;
			this.cmdViewmodeDay.Text = "by Date";
			// 
			// cmdViewmodeDayRoom
			// 
			this.cmdViewmodeDayRoom.Location = new System.Drawing.Point(8, 32);
			this.cmdViewmodeDayRoom.Name = "cmdViewmodeDayRoom";
			this.cmdViewmodeDayRoom.Size = new System.Drawing.Size(104, 24);
			this.cmdViewmodeDayRoom.TabIndex = 2;
			this.cmdViewmodeDayRoom.Text = "by Date/Room";
			// 
			// lblHeader2
			// 
			this.lblHeader2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHeader2.Location = new System.Drawing.Point(8, 160);
			this.lblHeader2.Name = "lblHeader2";
			this.lblHeader2.Size = new System.Drawing.Size(104, 16);
			this.lblHeader2.TabIndex = 1;
			this.lblHeader2.Text = "Color Appts";
			// 
			// lblHeader1
			// 
			this.lblHeader1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHeader1.Location = new System.Drawing.Point(8, 8);
			this.lblHeader1.Name = "lblHeader1";
			this.lblHeader1.Size = new System.Drawing.Size(104, 16);
			this.lblHeader1.TabIndex = 0;
			this.lblHeader1.Text = "ViewMode";
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.schedule1.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.schedule1.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.ColumnHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.ColumnHeader.FrameIncrement = 0;
			this.schedule1.ColumnHeader.Size = 100;
			this.schedule1.DayLength = 16;
			this.schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Location = new System.Drawing.Point(120, 1);
			this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
			this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.schedule1.Name = "schedule1";
			this.schedule1.RowHeader.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.RowHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.RowHeader.FrameIncrement = 0;
			this.schedule1.RowHeader.Size = 30;
			this.schedule1.SelectedAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.SelectedAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.SelectedAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Selector.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.schedule1.Selector.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.Selector.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Selector.Column = 0;
			this.schedule1.Selector.Length = 1;
			this.schedule1.Selector.Row = 0;
			this.schedule1.Size = new System.Drawing.Size(568, 528);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(686, 531);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.Panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET Dataviews";
			this.Panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		bool headerOn = false;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Button cmdNextSlot;
		internal System.Windows.Forms.Label lblHeader4;
		internal System.Windows.Forms.Button cmdToggleConflicts;
		internal System.Windows.Forms.Button cmdToggleTransparency;
		internal System.Windows.Forms.Button cmdToggleRound;
		internal System.Windows.Forms.Button cmdToggleHeader;
		internal System.Windows.Forms.Label lblHeader3;
		internal System.Windows.Forms.Button cmdBlue;
		internal System.Windows.Forms.Button cmdColorRoom;
		internal System.Windows.Forms.Button cmdColorProvider;
		internal System.Windows.Forms.Button cmdColorCategory;
		internal System.Windows.Forms.Button cmdViewmodeProvider;
		internal System.Windows.Forms.Button cmdViewmodeRoom;
		internal System.Windows.Forms.Button cmdViewmodeDay;
		internal System.Windows.Forms.Button cmdViewmodeDayRoom;
		internal System.Windows.Forms.Label lblHeader2;
		internal System.Windows.Forms.Label lblHeader1;
		internal Gravitybox.Controls.Schedule schedule1;
		bool TransparencyOn = true;

		private void MainForm_Load(object sender, System.EventArgs e)
		{

			//Setup Schedule
			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/5/2004"));
			schedule1.StartTime = DateTime.Parse("8:00:00 AM");
			schedule1.DayLength = 10;
			schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide;
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft;
			schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.None;
			schedule1.AllowSelector = false;

			//Add NoDropAreas
			schedule1.NoDropAreaCollection.Add("", Color.Red, DateTime.Parse("12:00:00 PM"), 90); //Lunch hour

			//Load Data
			Appointment appointment = null;
			Provider provider = null;
			Room room = null;
			Category category = null;

			//Load Providers
			provider = schedule1.ProviderCollection.Add("", "Sam", Color.LightGoldenrodYellow);
			provider = schedule1.ProviderCollection.Add("", "Julie", Color.LightGray);
			provider = schedule1.ProviderCollection.Add("", "Joe", Color.LightGreen);

			//Load Categories
			category = schedule1.CategoryCollection.Add("", "Major", Color.LightBlue);
			category = schedule1.CategoryCollection.Add("", "Cleaning", Color.LightCoral);
			category = schedule1.CategoryCollection.Add("", "Misc", Color.LightCyan);

			//Load Rooms
			room = schedule1.RoomCollection.Add("", "Exam I");
			room = schedule1.RoomCollection.Add("", "Exam II");

			//Load Appointments
			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), schedule1.RoomCollection[0], DateTime.Parse("8:00:00 AM"), 60);
			appointment.Subject = "Sue Collins";
			appointment.CategoryList.Add(schedule1.CategoryCollection[0]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[1]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), schedule1.RoomCollection[0], DateTime.Parse("9:30:00 AM"), 60);
			appointment.Subject = "Joe Jones";
			appointment.CategoryList.Add(schedule1.CategoryCollection[0]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[2]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), schedule1.RoomCollection[0], DateTime.Parse("10:30:00 AM"), 60);
			appointment.Subject = "Bill Sellers";
			appointment.CategoryList.Add(schedule1.CategoryCollection[1]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[1]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), schedule1.RoomCollection[1], DateTime.Parse("8:30:00 AM"), 60);
			appointment.Subject = "Jack Jones";
			appointment.CategoryList.Add(schedule1.CategoryCollection[1]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[0]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), schedule1.RoomCollection[1], DateTime.Parse("9:30:00 AM"), 60);
			appointment.Subject = "Mike Martin";
			appointment.CategoryList.Add(schedule1.CategoryCollection[0]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[1]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), schedule1.RoomCollection[1], DateTime.Parse("10:30:00 AM"), 90);
			appointment.Subject = "Ian Davis";
			appointment.CategoryList.Add(schedule1.CategoryCollection[2]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[0]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), schedule1.RoomCollection[0], DateTime.Parse("9:00:00 AM"), 90);
			appointment.Subject = "Rusty Grey";
			appointment.CategoryList.Add(schedule1.CategoryCollection[1]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[1]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), schedule1.RoomCollection[0], DateTime.Parse("10:00:00 AM"), 90);
			appointment.Subject = "John Smith";
			appointment.CategoryList.Add(schedule1.CategoryCollection[2]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[0]);

			//Format all appointments
			foreach (Appointment element in schedule1.AppointmentCollection)
			{
				element.Appearance.IsRound = true;
				element.Appearance.Transparency = 30;
				element.Appearance.BackColor = Color.LightBlue;
			}

			schedule1.Refresh();

		}

		private void cmdViewmodeDayRoom_Click(object sender, System.EventArgs e)
		{
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft;
		}

		private void cmdViewmodeDay_Click(object sender, System.EventArgs e)
		{
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
		}

		private void cmdViewmodeRoom_Click(object sender, System.EventArgs e)
		{
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft;
		}

		private void cmdViewmodeProvider_Click(object sender, System.EventArgs e)
		{
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft;
		}

		private void cmdColorRoom_Click(object sender, System.EventArgs e)
		{

			//There is no room color so just map the room to some color
			foreach (Appointment appointment in schedule1.AppointmentCollection)
			{
				switch (schedule1.RoomCollection.IndexOf(appointment.Room))
				{
					case 0:
						appointment.Appearance.BackColor = Color.LightPink;
						break;
					case 1:
						appointment.Appearance.BackColor = Color.LightSeaGreen;
						break;
				}
			}
			schedule1.Refresh();

		}

		private void cmdColorCategory_Click(object sender, System.EventArgs e)
		{

			//Set the color to its Category's color	
			foreach (Appointment appointment in schedule1.AppointmentCollection)
				appointment.Appearance.BackColor = ((Gravitybox.Objects.Category)appointment.CategoryList[0]).Appearance.BackColor;

			schedule1.Refresh();

		}

		private void cmdColorProvider_Click(object sender, System.EventArgs e)
		{

			//Set the color to its Provider's color	
			foreach (Appointment appointment in schedule1.AppointmentCollection)				
				appointment.Appearance.BackColor = ((Gravitybox.Objects.Provider)appointment.ProviderList[0]).Appearance.BackColor;
    
			schedule1.Refresh();

		}

		private void cmdBlue_Click(object sender, System.EventArgs e)
		{

			//Set the color to Blue    
			foreach (Appointment appointment in schedule1.AppointmentCollection)
				appointment.Appearance.BackColor = Color.LightBlue;
    
			schedule1.Refresh();

		}

		private void cmdToggleHeader_Click(object sender, System.EventArgs e)
		{

			//Toggle the appointment header on/off
			headerOn = !headerOn;    
			foreach (Appointment appointment in schedule1.AppointmentCollection)
			{
				if (headerOn)
				{
					appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
					appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor;
					appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;
					appointment.Header.Appearance.AllowBreak = true;
					appointment.Header.Icon = schedule1.DefaultIcons.IconInfo;
				}
				else
				{
					appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None;
				}
			}
			schedule1.Refresh();
		}

		private void cmdToggleRound_Click(object sender, System.EventArgs e)
		{

			//Set the color to Blue    
			foreach (Appointment appointment in schedule1.AppointmentCollection)
				appointment.Appearance.IsRound = !appointment.Appearance.IsRound;
    
			schedule1.Refresh();

		}

		private void cmdToggleTransparency_Click(object sender, System.EventArgs e)
		{

			//Set the color to Blue
			TransparencyOn = !TransparencyOn;    
			foreach (Appointment appointment in schedule1.AppointmentCollection)
			{
				if (TransparencyOn)
					appointment.Appearance.Transparency = 30;
				else
					appointment.Appearance.Transparency = 0;
			}
			schedule1.Refresh();

		}

		private void cmdToggleConflicts_Click(object sender, System.EventArgs e)
		{

			if (schedule1.ConflictDisplay == Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap)
				schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide;
			else if (schedule1.ConflictDisplay == Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide)
				schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger;
			else if (schedule1.ConflictDisplay == Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger)
				schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap;
		}

		private void cmdNextSlot_Click(object sender, System.EventArgs e)
		{
			NextSlotForm F = new NextSlotForm();
			F.ShowDialog();			
		}

		private DateTime CreateTime(int hour, int minute)
		{
			return new DateTime(1, 1, 1, hour, minute, 0, 0);
		}

	}
}
