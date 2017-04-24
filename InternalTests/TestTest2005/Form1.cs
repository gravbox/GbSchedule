using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gravitybox.Objects;
using Gravitybox.Controls;

namespace TestTest2005
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			schedule1.AfterAppointmentMove += new Gravitybox.Controls.Schedule.AfterAppointmentEventDelegate(schedule1_AfterAppointmentMove);
			schedule1.BeforeAppointmentReminder += new Schedule.BeforeAlarmEventDelegate(schedule1_BeforeAppointmentReminder);
			schedule1.BeforeAppointmentDue += new Schedule.BeforeAlarmEventDelegate(schedule1_BeforeAppointmentDue);			
		}

		private void schedule1_BeforeAppointmentDue(object sender, Gravitybox.Objects.EventArgs.BeforeAlarmEventArgs e)
		{
			e.Cancel = true;
		}

		private void schedule1_BeforeAppointmentReminder(object sender, Gravitybox.Objects.EventArgs.BeforeAlarmEventArgs e)
		{			
			e.Cancel = true;	
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			//Alarm Stuff
			//DateTime startDate = DateTime.Now.AddMinutes(1);
			//Appointment appointment = schedule1.AppointmentCollection.Add("", startDate, startDate, 60);
			//appointment.Alarm.IsArmed = true;
			//appointment.Alarm.Reminder = 0;
			//appointment.Alarm.AllowOpen = true;

			schedule1.AppointmentCollection.SaveXML(@"c:\q.xml");



			//CustomerProblem1();

		}

		private void CustomerProblem1()
		{			
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop;
			schedule1.ToolTipIsBalloon = false;

			schedule1.RoomCollection.Clear();
			for (int ii = 1; ii <= 2; ii++)
			{
				schedule1.RoomCollection.Add("", "Room " + ii);
			}

			DateTime startTime = new DateTime(2008, 1, 1, 0, 0, 0);
			schedule1.SetMinMaxDate(startTime, startTime.AddDays(30));

			foreach (Room room in schedule1.RoomCollection)
			{
				for (int jj = 1; jj < 4; jj++)
				{
					for (int ii = 1; ii <= 4; ii++)
					{
						Appointment appointment = schedule1.AppointmentCollection.Add("", startTime.AddDays(jj - 1), startTime.AddMinutes(30 * (ii - 1)), 30);
						appointment.Room = room;
						appointment.Subject = "Appointment " + schedule1.AppointmentCollection.Count;
						appointment.ToolTipText = "asdsadasd";
					}
				}
			}			
		}

		private void schedule1_ColoredAreaClick(object sender, Gravitybox.Objects.EventArgs.ScheduleAreaMouseEventArgs e)
		{
			int ii = 0;
		}

		private void Form1_LoadXXX(object sender, EventArgs e)
		{
			schedule1.ProviderCollection.Clear();
			schedule1.ProviderCollection.Add("", "Provider 1");
			schedule1.ProviderCollection.Add("", "Provider 2");
			schedule1.ProviderCollection.Add("", "Provider 3");

			schedule1.CategoryCollection.Clear();
			schedule1.CategoryCollection.Add("", "Category 1");
			schedule1.CategoryCollection.Add("", "Category 2");
			schedule1.CategoryCollection.Add("", "Category 3");

			schedule1.ResourceCollection.Clear();
			schedule1.ResourceCollection.Add("", "Resource 1");
			schedule1.ResourceCollection.Add("", "Resource 2");
			schedule1.ResourceCollection.Add("", "Resource 3");
			schedule1.ResourceCollection.Add("", "Resource 4");

			schedule1.RoomCollection.Clear();
			schedule1.RoomCollection.Add("", "Room 1");
			schedule1.RoomCollection.Add("", "Room 2");
			//schedule1.RoomCollection.Add("", "Room 3");

			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
			schedule1.StartTime = new DateTime(2000, 1, 1, 8, 0, 0);
			schedule1.DayLength = 10;
			schedule1.SetMinMaxDate(schedule1.MinDate, schedule1.MinDate.AddDays(100));

			//DateTime startDate = DateTime.Now;
			//schedule1.AutoRedraw = false;
			//schedule1.UseDefaultAppearances = false;

			//DateTime newTime = new DateTime(2000, 1, 1, 8, 0, 0);
			//for(int ii = 0 ; ii < 1000 ; ii++)
			//{
			//  schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(ii), newTime, 60);
			//}

			//schedule1.AutoRedraw = true;
			//DateTime endDate = DateTime.Now;
			//System.Diagnostics.Debug.WriteLine(endDate.Subtract(startDate).TotalMilliseconds);

			this.schedule1.NoDropAreaCollection.Add("X", Color.LightBlue, schedule1.MinDate.AddDays(1));
			this.schedule1.NoDropAreaCollection.Add("Y", Color.Salmon, schedule1.MinDate.AddDays(3));

			this.schedule1.NoDropAreaClick += new Gravitybox.Controls.Schedule.ScheduleAreaEventMouseDelegate(schedule1_NoDropAreaClick);
			this.schedule1.BeforePropertyDialog += new Gravitybox.Controls.Schedule.BeforePropertyDialogEventDelegate(schedule1_BeforePropertyDialog);
			this.schedule1.PropertyDialogSaveInvalidArea += new Gravitybox.Controls.Schedule.TextExtendedEventDelegate(this.schedule1_PropertyDialogSaveInvalidArea);
			this.schedule1.ColumnHeaderClick += new Gravitybox.Controls.Schedule.AfterHeaderEventDelegate(this.schedule1_ColumnHeaderClick);

			DateTime newDate = new DateTime(2000, 1, 1, 8, 0, 0);
			this.schedule1.ColoredAreaCollection.Add("", Color.Blue, newDate);
			this.schedule1.ColoredAreaCollection.Add("", Color.Blue, newDate, newDate, 60);
			ScheduleAreaList list = this.schedule1.ColoredAreaCollection.Find(newDate, newDate.AddHours(2), 30);


			//2006-07-18
			DateTime startTime = new DateTime(2000, 1, 1, 8, 0, 0, 0);
			this.schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop;
			this.schedule1.AppointmentCollection.Clear();
			this.schedule1.AppointmentCollection.Add("", this.schedule1.MinDate, this.schedule1.RoomCollection[0], startTime, 60);
			this.schedule1.AppointmentCollection.Add("", this.schedule1.MinDate.AddDays(1), this.schedule1.RoomCollection[0], startTime, 60);
			this.schedule1.AppointmentCollection.Add("", this.schedule1.MinDate, this.schedule1.RoomCollection[1], startTime, 60);

			//this.schedule1.AppointmentCollection.Add("", this.schedule1.MinDate.AddDays(1), this.schedule1.RoomCollection[0], startTime.AddHours(1), 60);

			Appointment appt = this.schedule1.AppointmentCollection.ToList().NextAreaAvailable(this.schedule1.MinDate, schedule1.RoomCollection[0], startTime, 1440, false);
			System.Diagnostics.Debug.WriteLine(appt.StartDateTime + " " + appt.Room.Text);

		}

		private void schedule1_NoDropAreaClick(object sender, Gravitybox.Objects.EventArgs.ScheduleAreaMouseEventArgs e)
		{
		}

		private void schedule1_BeforePropertyDialog(object sender, Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs e)
		{
			e.DialogSettings.AllowSubject = false;
			Appointment appointment = (Appointment)e.BaseObject;
			appointment.StartDateTime = new DateTime(2000, 1, 1, 8, 0, 0);
		}

		void schedule1_AfterUserAppointmentAdd(object sender, Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs e)
		{
			Appointment appointment = (Appointment)e.BaseObject;
			System.Diagnostics.Debug.WriteLine(appointment.StartDate);
			System.Diagnostics.Debug.WriteLine(appointment.StartTime);
			System.Diagnostics.Debug.WriteLine(appointment.StartDateTime);
		}

		void schedule1_AfterAppointmentMove(object sender, Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs e)
		{
			Appointment appointment = (Appointment)e.BaseObject;
			//AppointmentExt appt = (AppointmentExt)e.BaseObject;
			System.Diagnostics.Debug.WriteLine(appointment.StartDate);
			System.Diagnostics.Debug.WriteLine(appointment.StartTime);
			System.Diagnostics.Debug.WriteLine(appointment.StartDateTime);
		}

		private void RecurrenceYearTest()
		{
			schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute20;
			schedule1.AppointmentTimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute20;

			ScheduleDataset ds = new ScheduleDataset();
			schedule1.DataSource = ds;
			schedule1.Bind();

			Gravitybox.Objects.Recurrence r = new Recurrence();
			r.RecurrenceYear.DayInterval = 2;
			r.RecurrenceYear.DayOrdinal = RecurrenceOrdinalConstants.Last;
			r.RecurrenceYear.DayPosition = RecurrenceOrdinalDayConstants.Thursday;
			r.RecurrenceYear.MonthInterval = 5;
			r.RecurrenceYear.MonthOrdinal = 6;
			r.RecurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal;

			schedule1.RecurrenceCollection.Add(r);
			ds = (ScheduleDataset)schedule1.DataSource;


			//ds.RECURRENCE.

			string s = r.ToXML();

			r = new Recurrence();
			r.FromXML(s);
		}

		private void Test1()
		{
			ContextMenu contextMenu = new ContextMenu();
			ArrayList viewmodeList = new ArrayList(Enum.GetValues(typeof(Gravitybox.Controls.Schedule.ViewModeConstants)));
			foreach (object o in viewmodeList)
				contextMenu.MenuItems.Add(o.ToString(), new EventHandler(ViewModeMenuClick));
			schedule1.ContextMenu = contextMenu;

			for (int ii = 1; ii <= 5; ii++)
			{
				schedule1.ProviderCollection.Add("", "Provider " + ii.ToString());
				schedule1.CategoryCollection.Add("", "Category " + ii.ToString());
				schedule1.RoomCollection.Add("", "Room " + ii.ToString());
				//schedule1.PriorityCollection.Add("", "Priority " + ii.ToString());
				schedule1.ResourceCollection.Add("", "Resource " + ii.ToString());
			}

			//First day of week
			cboFDW.Items.Add(System.DayOfWeek.Sunday);
			cboFDW.Items.Add(System.DayOfWeek.Monday);
			cboFDW.Items.Add(System.DayOfWeek.Tuesday);
			cboFDW.Items.Add(System.DayOfWeek.Wednesday);
			cboFDW.Items.Add(System.DayOfWeek.Thursday);
			cboFDW.Items.Add(System.DayOfWeek.Friday);
			cboFDW.Items.Add(System.DayOfWeek.Saturday);
			cboFDW.SelectedIndexChanged += new EventHandler(cboFDW_SelectedIndexChanged);
			cboFDW.SelectedIndex = 0;
		}

		private void cboFDW_SelectedIndexChanged(object sender, EventArgs e)
		{
			schedule1.FirstDayOfWeek = (System.DayOfWeek)cboFDW.SelectedItem;
		}

		private void ViewModeMenuClick(object sender, EventArgs e)
		{
			Gravitybox.Controls.Schedule.ViewModeConstants viewmode = (Gravitybox.Controls.Schedule.ViewModeConstants)Enum.Parse(typeof(Gravitybox.Controls.Schedule.ViewModeConstants), ((MenuItem)sender).Text);
			schedule1.ViewMode = viewmode;
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.Q | Keys.Control))
			{
				ArrayList viewmodeList = new ArrayList(Enum.GetValues(typeof(Gravitybox.Controls.Schedule.ViewModeConstants)));
				Gravitybox.Controls.Schedule.ViewModeConstants viewmode = schedule1.ViewMode;
				if (viewmodeList.IndexOf(viewmode) == viewmodeList.Count - 1)
				{
					schedule1.ViewMode = (Gravitybox.Controls.Schedule.ViewModeConstants)viewmodeList[0];
				}
				else
				{
					schedule1.ViewMode = (Gravitybox.Controls.Schedule.ViewModeConstants)viewmodeList[viewmodeList.IndexOf(viewmode) + 1];
				}
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{

			PrintDialogSettings settings = new PrintDialogSettings(schedule1.MinDate, schedule1.StartTime, schedule1.MaxDate, schedule1.StartTime.AddHours(schedule1.DayLength));
			settings.PageSettings.Landscape = true;
			schedule1.GoPreview(settings);

		}

		private void schedule1_PropertyDialogSaveInvalidArea(object sender, Gravitybox.Objects.EventArgs.TextExtendedEventArgs e)
		{
			e.IsValid = true;
		}

		private void schedule1_ColumnHeaderClick(object sender, Gravitybox.Objects.EventArgs.AfterHeaderEventArgs e)
		{

			Provider provider = schedule1.ProviderCollection[0];
			int ii = this.schedule1.Visibility.GetCorFromProvider(provider);
			provider = schedule1.ProviderCollection[1];
			ii = this.schedule1.Visibility.GetCorFromProvider(provider);
			provider = schedule1.ProviderCollection[2];
			ii = this.schedule1.Visibility.GetCorFromProvider(provider);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			schedule1.Dialogs.ShowCategoryConfiguration();
		}

	}

}