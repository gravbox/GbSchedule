using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace Medical
{
	public partial class Form1 : Form
	{
		#region Class Members

		public enum ViewTypeConstants
		{
			Day = 0,
			Week = 1,
			Month = 2,
			Provider = 3,
			Room = 4,
		}

		private ViewTypeConstants _viewType = ViewTypeConstants.Day;
		private DateTime _currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

		#endregion

		#region Constructor

		public Form1()
		{
			InitializeComponent();

			this.schedule1.AppointmentClick += new Gravitybox.Controls.Schedule.AppointmentMouseEventDelegate(schedule1_AppointmentClick);
			this.schedule1.BackgroundClick += new Gravitybox.Controls.Schedule.MouseEventDelegate(schedule1_BackgroundClick);
			this.schedule1.BeforePropertyDialog += new Gravitybox.Controls.Schedule.BeforePropertyDialogEventDelegate(schedule1_BeforePropertyDialog);

			//Initialize Schedule
			DateTime midnight = new DateTime(2000, 1, 1);
			ScheduleArea area = this.schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xE6, 0xED, 0xF7), midnight, 480);
			area.Appearance.BorderWidth = 0;
			area = this.schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xE6, 0xED, 0xF7), midnight.AddHours(17), 420);
			area.Appearance.BorderWidth = 0;

			//Add Providers
			this.schedule1.ProviderCollection.Add("", "John");
			this.schedule1.ProviderCollection.Add("", "Sally");
			this.schedule1.ProviderCollection.Add("", "Harry");
			this.schedule1.ProviderCollection.Add("", "Fred");

			//Add Rooms
			this.schedule1.RoomCollection.Add("", "Exam 1");
			this.schedule1.RoomCollection.Add("", "Prep 1");
			this.schedule1.RoomCollection.Add("", "Operatory 1");
			this.schedule1.RoomCollection.Add("", "Operatory 2");

			this.schedule1.Font = new Font("Arial", 10);
			this.schedule1.RowHeader.Size = 20;
			this.schedule1.ColumnHeader.Appearance.FontBold = true;
			this.schedule1.HeaderDateFormat = "dddd dd";

			this.AddAppointments();

			this.LoadSchedule(CurrentDate);
			this.schedule1.Visibility.ShowTime(midnight.AddHours(8));
		}

		#endregion

		#region Property Imeplementations

		public DateTime CurrentDate
		{
			get { return _currentDate; }
			set
			{
				_currentDate = value;
				this.LoadSchedule(_currentDate);
			}
		}

		public ViewTypeConstants ViewType
		{
			get { return _viewType; }
			set
			{
				_viewType = value;
				this.LoadSchedule(CurrentDate);
			}
		}

		#endregion

		#region Methods

		private void AddAppointments()
		{
			DateTime pivotDate = DateTime.Now.AddDays(-15);
			DateTime pivotTime = new DateTime(2000, 1, 1, 8, 0,0);
			const int dayRange = 30;
			int timeInc = (int)this.schedule1.TimeIncrement;
			int incPerDay = 8 * (60 / timeInc); //8 hours * incs per hour

			//Add 50 appointments randomly from 15 days ago to 15 day forth from 8am - 4pm, 60 min - 150 min			
			Random rnd = new Random();
			this.schedule1.AutoRedraw = false;
			for (int ii = 0; ii < 50; ii++)
			{
				DateTime startDate = pivotDate.AddDays(rnd.Next() % dayRange);
				DateTime startTime = pivotTime.AddMinutes(timeInc * (rnd.Next() % incPerDay));
				int length = (timeInc * 2) + ((rnd.Next() % 3) * timeInc);

				//Create the appointment
				Appointment appt = this.schedule1.AppointmentCollection.Add("", startDate, startTime, length);
				appt.Subject = "Appointment " + (ii + 1).ToString();
				appt.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

				//Associate a Provider
				appt.ProviderList.Add(this.schedule1.ProviderCollection[rnd.Next() % this.schedule1.ProviderCollection.Count]);

				//Associate a Room
				appt.Room = this.schedule1.RoomCollection[rnd.Next() % this.schedule1.RoomCollection.Count];

				//Make all day appointment
				if ((rnd.Next() % 10) == 0)
					appt.IsEvent = true;

			}

			this.schedule1.AutoRedraw = true;

		}

		private void LoadSchedule(DateTime date)
		{
			schedule1.AutoRedraw = false;
			DateTime startDate = DateTime.Now;
			DateTime endDate = DateTime.Now;

			cmdDay.Checked = (this.ViewType == ViewTypeConstants.Day);
			cmdWeek.Checked = (this.ViewType == ViewTypeConstants.Week);
			cmdMonth.Checked = (this.ViewType == ViewTypeConstants.Month);
			cmdProvider.Checked = (this.ViewType == ViewTypeConstants.Provider);
			cmdRoom.Checked = (this.ViewType == ViewTypeConstants.Room);
			menuContextScheduleDay.Checked = (this.ViewType == ViewTypeConstants.Day);
			menuContextScheduleWeek.Checked = (this.ViewType == ViewTypeConstants.Week);
			menuContextScheduleMonth.Checked = (this.ViewType == ViewTypeConstants.Month);
			menuContextScheduleProvider.Checked = (this.ViewType == ViewTypeConstants.Provider);
			menuContextScheduleRoom.Checked = (this.ViewType == ViewTypeConstants.Room);
			menuViewDay.Checked = (this.ViewType == ViewTypeConstants.Day);
			menuViewWeek.Checked = (this.ViewType == ViewTypeConstants.Week);
			menuViewMonth.Checked = (this.ViewType == ViewTypeConstants.Month);
			menuViewProvider.Checked = (this.ViewType == ViewTypeConstants.Provider);
			menuViewRoom.Checked = (this.ViewType == ViewTypeConstants.Room);

			foreach (Appointment a in this.schedule1.AppointmentCollection)
				a.Visible = true;

			switch (this.ViewType)
			{
				case ViewTypeConstants.Day:
					startDate = date;
					endDate = date;
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
					this.schedule1.RowHeader.Size = 20;
					break;
				case ViewTypeConstants.Week:
					startDate = date.AddDays(-(int)date.DayOfWeek);
					endDate = startDate.AddDays(6);
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
					this.schedule1.RowHeader.Size = 20;
					break;
				case ViewTypeConstants.Month:
					startDate = new DateTime(date.Year, date.Month, 1);
					endDate = startDate.AddMonths(1).AddDays(-1);
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month;
					break;
				case ViewTypeConstants.Provider:
					startDate = date;
					endDate = startDate;
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft;
					this.schedule1.RowHeader.Size = 20;
					foreach(Appointment a in this.schedule1.AppointmentCollection)
						a.Visible = (a.StartDate == date);
					break;
				case ViewTypeConstants.Room:
					startDate = date;
					endDate = date;
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft;
					this.schedule1.RowHeader.Size = 20;
					break;
			}

			schedule1.SetMinMaxDate(startDate, endDate);
			schedule1.ColumnHeader.AutoFit = true;

			//Setup the header
			if (this.ViewType == ViewTypeConstants.Month)
			{
				lblHeader.Text = startDate.ToString("MMMM yyyy");
			}
			else if (startDate == endDate)
			{
				lblHeader.Text = startDate.ToString("MMMM dd, yyyy");
			}
			else if ((startDate.Month == endDate.Month) && (startDate.Year == endDate.Year))
			{
				lblHeader.Text = startDate.ToString("MMMM dd") + " - " + endDate.ToString("dd, yyyy");
			}
			else
			{
				lblHeader.Text = startDate.ToString("MMMM, dd, yyyy") + " - " + endDate.ToString("MMMM, dd, yyyy");
			}

			schedule1.AutoRedraw = true;
		}

		#endregion

		#region Event Handlers

		private void cmdDay_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Day;
		}

		private void cmdWeek_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Week;
		}

		private void cmdMonth_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Month;
		}

		private void cmdProvider_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Provider;
		}

		private void cmdRoom_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Room;
		}

		private void menuViewDay_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Day;
		}

		private void menuViewWeek_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Week;
		}

		private void menuViewMonth_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Month;
		}

		private void menuViewProvider_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Provider;
		}

		private void menuViewRoom_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Room;
		}

		private void menuContextScheduleDay_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Day;
		}

		private void menuContextScheduleWeek_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Week;
		}

		private void menuContextScheduleMonth_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Month;
		}

		private void menuContextScheduleProvider_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Provider;
		}

		private void menuContextScheduleRoom_Click(object sender, EventArgs e)
		{
			this.ViewType = ViewTypeConstants.Room;
		}

		private void cmdBack_Click(object sender, EventArgs e)
		{
			switch (this.ViewType)
			{
				case ViewTypeConstants.Day:
					this.CurrentDate = this.CurrentDate.AddDays(-1);
					break;
				case ViewTypeConstants.Week:
					this.CurrentDate = this.CurrentDate.AddDays(-7);
					break;
				case ViewTypeConstants.Month:
					this.CurrentDate = this.CurrentDate.AddMonths(-1);
					break;
				case ViewTypeConstants.Provider:
					this.CurrentDate = this.CurrentDate.AddDays(-1);
					break;
				case ViewTypeConstants.Room:
					this.CurrentDate = this.CurrentDate.AddDays(-1);
					break;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			switch (this.ViewType)
			{
				case ViewTypeConstants.Day:
					this.CurrentDate = this.CurrentDate.AddDays(1);
					break;
				case ViewTypeConstants.Week:
					this.CurrentDate = this.CurrentDate.AddDays(7);
					break;
				case ViewTypeConstants.Month:
					this.CurrentDate = this.CurrentDate.AddMonths(1);
					break;
				case ViewTypeConstants.Provider:
					this.CurrentDate = this.CurrentDate.AddDays(1);
					break;
				case ViewTypeConstants.Room:
					this.CurrentDate = this.CurrentDate.AddDays(1);
					break;
			}
		}

		private void schedule1_BackgroundClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.contextMenuSchedule.Show(this.schedule1, e.X, e.Y);
			}
		}

		private void schedule1_AppointmentClick(object sender, Gravitybox.Objects.EventArgs.AppointmentMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.contextMenuAppointment.Show(this.schedule1, e.X, e.Y);
			}
		}

		private void schedule1_BeforePropertyDialog(object sender, Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs e)
		{
			//e.DialogSettings.Appearance.BackColor = Color.FromArgb(0xFF, 0xF5, 0xA8);
		}

		#endregion

	}
}