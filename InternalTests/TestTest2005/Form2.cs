using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Gravitybox.Objects;
using System.Data.OleDb;

namespace TestTest2005
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();

			schedule1.BeforeToolTip += new Gravitybox.Controls.Schedule.ToolTipAppointmentEventDelegate(schedule1_BeforeToolTip);

			//this.LoadStyleTheme(Gravitybox.Controls.Schedule.ThemeConstants.Office2007);
			this.LoadStyleTheme(Gravitybox.Controls.Schedule.ThemeConstants.Olive);
			//this.LoadStyleTheme(Gravitybox.Controls.Schedule.ThemeConstants.Energy);
			//this.LoadOffice2007();
			//this.LoadOffice2007_2();
			//this.LoadOffice2007_3();
			//this.LoadProviderTest();
			//this.LoadVactation();
      return;

      const int DAYRANGE = 500;

      DateTime startDate = new DateTime(2006, 1, 1, 8, 0, 0);
      schedule1.AutoRedraw = false;
      schedule1.SetMinMaxDate(startDate, startDate.AddDays(DAYRANGE));
      schedule1.StartTime = startDate;
      schedule1.DayLength = 10;
      schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;

      for(int ii = 1 ; ii <= 150 ; ii++)
      {
        schedule1.ProviderCollection.Add("", "Provider " + ii.ToString());
      }

      for(int ii = 0 ; ii < DAYRANGE ; ii++)
      {
        Appointment appt = schedule1.AppointmentCollection.Add("", startDate.AddDays(ii), startDate, 120);
        appt.Subject = "Appt " + ii.ToString();
        appt.ProviderList.Add(schedule1.ProviderCollection[ii % schedule1.ProviderCollection.Count]);
      }

      schedule1.AutoRedraw = true;

    }

		private void schedule1_BeforeToolTip(object sender, Gravitybox.Objects.EventArgs.ToolTipAppointmentEventArgs e)
		{
			e.HeaderText = "My Header";
		}

    #region LoadOffice2007
    private void LoadOffice2007()
    {
      this.panel1.Visible = false;
      this.Width = 300;

      DateTime dayStart = new DateTime(2006, 1, 1, 0, 0, 0);
      schedule1.SetMinMaxDate(dayStart, dayStart);
      schedule1.HeaderDateFormat = "dddd";
      schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
      schedule1.StartTime = dayStart;
      schedule1.DayLength = 24;
      schedule1.Visibility.ShowTime(dayStart.AddHours(8));

      schedule1.EventHeader.Appearance.BackColor = Color.FromArgb(0xA6, 0xC0, 0xE1);
      schedule1.EventHeader.Appearance.BorderColor = schedule1.EventHeader.Appearance.BackColor;
      schedule1.EventHeader.Appearance.BorderWidth = 0;

      //Main Grid
      schedule1.Appearance.BackColor = Color.White;
      schedule1.Appearance.BorderWidth = 0;

      //Column Header
      schedule1.ColumnHeader.Appearance.BackColor = Color.FromArgb(0xF8, 0xCF, 0x91);
      schedule1.ColumnHeader.Appearance.BackColor2 = Color.FromArgb(0xF5, 0xBB, 0x4E);
      schedule1.ColumnHeader.Appearance.BackGradientStyle = GradientStyleConstants.Vertical;
      schedule1.ColumnHeader.AutoFit = true;
      schedule1.ColumnHeader.Appearance.FontSize = 8;

      //Row Header
      schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(0xD6, 0xE2, 0xF1);
      schedule1.RowHeader.Appearance.BackColor2 = Color.FromArgb(0xF5, 0xBB, 0x4E);
      schedule1.RowHeader.Appearance.ForeColor = Color.FromArgb(0x68, 0x93, 0xCC);
      schedule1.RowHeader.Appearance.FontSize = 8;
      schedule1.ColumnHeader.Size = 200;

      //Create an Appointment appearance
      AppointmentAppearance appearance = new AppointmentAppearance();
      appearance.BackColor = Color.White;
      appearance.BackColor2 = Color.FromArgb(0xD6, 0xE2, 0xF1);
      appearance.BackGradientStyle = GradientStyleConstants.Vertical;
      appearance.BorderColor = Color.FromArgb(0x68, 0x93, 0xCC);
      appearance.FontBold = true;
      appearance.IsRound = true;
      appearance.FontSize = 8;
      appearance.ShadowSize = 5;

      Appointment appt = null;

      //Appointment 1
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(9), 30);
      appt.Subject = "Weekly Dept. Meeting";
      appt.Appearance = appearance;

      //Appointment 2
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(9), 60);
      appt.Subject = "Management Meeting";
      appt.IsEvent = true;
      appt.Appearance = appearance;

      //Appointment 3
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(10), 30);
      appt.Subject = "Meet w/ Joe";
      appt.Appearance = (AppointmentAppearance)appearance.Clone();
      appt.Appearance.BackColor2 = Color.LightGreen;

    }
    
    #endregion

    #region LoadOffice2007_2
    private void LoadOffice2007_2()
    {
      this.panel1.Visible = false;
      this.Width = 600;
      this.Height = 420;

      DateTime dayStart = new DateTime(2006, 1, 2, 0, 0, 0);
      schedule1.SetMinMaxDate(dayStart, dayStart.AddDays(2));
      schedule1.HeaderDateFormat = "ddd";
      schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
      schedule1.StartTime = dayStart;
      schedule1.DayLength = 24;
      schedule1.Visibility.ShowTime(dayStart.AddMinutes(570));

      schedule1.EventHeader.Appearance.BackColor = Color.FromArgb(0xA6, 0xC0, 0xE1);
      schedule1.EventHeader.Appearance.BorderColor = schedule1.EventHeader.Appearance.BackColor;
      schedule1.EventHeader.Appearance.BorderWidth = 0;

      //Colored Areas
      ScheduleArea area = schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xE7, 0xEF, 0xF7), dayStart, 480);
      area.Appearance.BorderWidth = 0;
      area = schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xE7, 0xEF, 0xF7), dayStart.AddHours(18), 360);
      area.Appearance.BorderWidth = 0;
      area = schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xFE, 0xD8, 0xB6), dayStart.AddDays(2));
      area.Appearance.BorderWidth = 0;

      //Main Grid
      schedule1.Appearance.BackColor = Color.White;
      schedule1.Appearance.BorderWidth = 0;
      schedule1.Appearance.ForeColor = Color.FromArgb(0xA5, 0xBD, 0xDE);
      

      //Column Header
      schedule1.ColumnHeader.Appearance.BackColor = Color.FromArgb(0xD6, 0xE2, 0xF1);
      schedule1.ColumnHeader.Appearance.ForeColor = Color.Black;
      schedule1.ColumnHeader.Appearance.FontSize = 8;
      schedule1.ColumnHeader.AutoFit = true;

      //Row Header
      schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(0xE9, 0xE7, 0xB8);
      schedule1.RowHeader.Appearance.FontSize = 8;
      schedule1.RowHeader.Size = 20;

      //Create an Appointment appearance
      AppointmentAppearance appearance = new AppointmentAppearance();
      appearance.BackColor = Color.White;
      appearance.BackColor2 = Color.FromArgb(0xD6, 0xE2, 0xF1);
      appearance.BackGradientStyle = GradientStyleConstants.Vertical;
      appearance.BorderColor = Color.FromArgb(0x68, 0x93, 0xCC);
      appearance.FontBold = true;
      appearance.IsRound = true;
      appearance.FontSize = 8;
      appearance.ShadowSize = 5;

      Appointment appt = null;

      //Appointment 1
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(10), 150);
      appt.Subject = "10 Years!";
      appt.Appearance = (AppointmentAppearance)appearance.Clone();
      appt.Appearance.BackColor = Color.FromArgb(0xCD, 0xE7, 0xDE);
      appt.Appearance.BackColor2 = Color.FromArgb(0x9A, 0xBD, 0xB8);
      appt.Appearance.BorderColor = Color.FromArgb(0x71, 0x84, 0x83);
      appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
      appt.Header.Appearance.BackColor = appt.Appearance.BackColor;
      appt.Header.Appearance.FontBold = true;
      appt.Header.Appearance.FontSize = 8;
      appt.Header.Appearance.AllowBreak = false;
      appt.Appearance.FontBold = false;
      appt.Header.Text = "Anniversary";

      //Appointment 2
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(13), 210);
      appt.Subject = "Pick up the pictures from the grand opening";
      appt.Appearance = (AppointmentAppearance)appearance.Clone();
      appt.Appearance.BackColor = Color.FromArgb(0xB9, 0xE7, 0xEE);
      appt.Appearance.BackColor2 = Color.FromArgb(0x7A, 0xCF, 0xD9);
      appt.Appearance.BorderColor = Color.FromArgb(0x55, 0x9B, 0x9E);
      appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
      appt.Header.Appearance.BackColor = appt.Appearance.BackColor;
      appt.Header.Appearance.FontBold = true;
      appt.Header.Appearance.FontSize = 8;
      appt.Header.Appearance.AllowBreak = false;
      appt.Appearance.FontBold = false;
      appt.Header.Text = "Pick up Pictures";

      //Appointment 3
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(2), dayStart.AddMinutes(570), 150);
      appt.Subject = "Company Meeting; I only need to be half engaged here";
      appt.Appearance = (AppointmentAppearance)appearance.Clone();
      appt.Appearance.BackColor2 = Color.FromArgb(0xEE, 0xAA, 0x6A);

      //Appointment 4
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(2), dayStart.AddMinutes(690), 120);
      appt.Subject = "Release Software";
      appt.Appearance = (AppointmentAppearance)appearance.Clone();
      appt.Appearance.BorderColor = Color.FromArgb(0x5B, 0x67, 0x96);
      appt.Appearance.BackColor = Color.FromArgb(0xC6, 0xCB, 0xE8);
      appt.Appearance.BackColor2 = Color.FromArgb(0x64, 0x8C, 0xC8);

      //Appointment 5
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(1), dayStart.AddMinutes(660), 180);
      appt.Subject = "I really need to talk to him today!";
      appt.Appearance = (AppointmentAppearance)appearance.Clone();
      appt.Appearance.BorderColor = Color.FromArgb(0xA4, 0x9A, 0x49);
      appt.Appearance.BackColor = Color.FromArgb(0xFB, 0xED, 0xB8);
      appt.Appearance.BackColor2 = Color.FromArgb(0xE3, 0xD3, 0x5F);
      appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
      appt.Header.Appearance.BackColor = appt.Appearance.BackColor;
      appt.Header.Appearance.FontBold = true;
      appt.Header.Appearance.FontSize = 8;
      appt.Header.Appearance.AllowBreak = false;
      appt.Appearance.FontBold = false;
      appt.Header.Text = "Call John";
     
      //Appointment 5
      appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(1), dayStart.AddMinutes(900), 90);
      appt.Subject = "Check Credit";
      appt.Appearance = (AppointmentAppearance)appearance.Clone();
      appt.Appearance.BorderColor = Color.FromArgb(0xA7, 0x70, 0x4F);
      appt.Appearance.BackColor = Color.FromArgb(0xFD, 0xC5, 0xBB);
      appt.Appearance.BackColor2 = Color.FromArgb(0xD8, 0x93, 0x6E);
      
    }
    
    #endregion

		#region LoadOffice2007_3
		private void LoadOffice2007_3()
		{			
			this.Width = 600;
			this.Height = 420;

			this.panel1.BackColor = Color.FromArgb(0xD4, 0xE4, 0xF3);
			//this.lblMessage.Appearance.BackColor = Color.FromArgb(0xFF, 0xEA, 0xA1);
			//this.lblMessage.Appearance.BorderColor = Color.FromArgb(0xF8, 0xBE, 0x50);
			//this.lblMessage.Appearance.BorderWidth = 2;
			//this.lblMessage.Appearance.ForeColor = Color.FromArgb(0x7F, 0x73, 0x8B);
			
			DateTime dayStart = new DateTime(2006, 1, 2, 0, 0, 0);
			schedule1.SetMinMaxDate(dayStart, dayStart.AddDays(2));
			schedule1.HeaderDateFormat = "ddd";
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
			schedule1.StartTime = dayStart;
			schedule1.DayLength = 24;
			schedule1.Visibility.ShowTime(dayStart.AddMinutes(570));

			schedule1.EventHeader.Appearance.BackColor = Color.FromArgb(0xA6, 0xC0, 0xE1);
			schedule1.EventHeader.Appearance.BorderColor = schedule1.EventHeader.Appearance.BackColor;
			schedule1.EventHeader.Appearance.BorderWidth = 0;

			//Colored Areas
			ScheduleArea area = schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xE7, 0xEF, 0xF7), dayStart, 480);
			area.Appearance.BorderWidth = 0;
			area = schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xE7, 0xEF, 0xF7), dayStart.AddHours(18), 360);
			area.Appearance.BorderWidth = 0;
			area = schedule1.ColoredAreaCollection.Add("", Color.FromArgb(0xFE, 0xD8, 0xB6), dayStart.AddDays(2));
			area.Appearance.BorderWidth = 0;

			//Main Grid
			schedule1.Appearance.BackColor = Color.FromArgb(0xE6, 0xED, 0xF7);
			schedule1.Appearance.BorderWidth = 0;
			schedule1.Appearance.ForeColor = Color.FromArgb(0xA5, 0xBD, 0xDE);

			//Column Header
			schedule1.ColumnHeader.Appearance.BackColor = Color.White;
			schedule1.ColumnHeader.Appearance.BackColor2 = Color.FromArgb(0xD6, 0xE2, 0xF1);
			schedule1.ColumnHeader.Appearance.BackGradientStyle = GradientStyleConstants.Vertical;
			schedule1.ColumnHeader.Appearance.ForeColor = Color.Black; 
			schedule1.ColumnHeader.Appearance.FontSize = 8;
			schedule1.ColumnHeader.Appearance.FontBold = true;
			schedule1.ColumnHeader.AutoFit = true;

			//Row Header
			schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(0xD6, 0xE2, 0xF1);
			schedule1.RowHeader.Appearance.ForeColor = Color.FromArgb(0x6C, 0x98, 0xD5);
			schedule1.RowHeader.Appearance.FontSize = 8;
			schedule1.RowHeader.Size = 20;

			//Create an Appointment appearance
			AppointmentAppearance appearance = new AppointmentAppearance();
			appearance.BackColor = Color.White;
			appearance.BackColor2 = Color.FromArgb(0xD6, 0xE2, 0xF1);
			appearance.BackGradientStyle = GradientStyleConstants.Vertical;
			appearance.BorderColor = Color.FromArgb(0x68, 0x93, 0xCC);
			appearance.FontBold = true;
			appearance.IsRound = true;
			appearance.FontSize = 8;
			appearance.ShadowSize = 5;

			Appointment appt = null;

			//Appointment 1
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(10), 150);
			appt.Subject = "10 Years!";
			appt.Appearance = (AppointmentAppearance)appearance.Clone();
			appt.Appearance.BackColor = Color.FromArgb(0xCD, 0xE7, 0xDE);
			appt.Appearance.BackColor2 = Color.FromArgb(0x9A, 0xBD, 0xB8);
			appt.Appearance.BorderColor = Color.FromArgb(0x71, 0x84, 0x83);
			appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appt.Header.Appearance.BackColor = appt.Appearance.BackColor;
			appt.Header.Appearance.FontBold = true;
			appt.Header.Appearance.FontSize = 8;
			appt.Header.Appearance.AllowBreak = false;
			appt.Appearance.FontBold = false;
			appt.Header.Text = "Anniversary";
			appt.ToolTipText = "Here is some text to see!";

			//Appointment 2
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(13), 210);
			appt.Subject = "Pick up the pictures from the grand opening";
			appt.Appearance = (AppointmentAppearance)appearance.Clone();
			appt.Appearance.BackColor = Color.FromArgb(0xB9, 0xE7, 0xEE);
			appt.Appearance.BackColor2 = Color.FromArgb(0x7A, 0xCF, 0xD9);
			appt.Appearance.BorderColor = Color.FromArgb(0x55, 0x9B, 0x9E);
			appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appt.Header.Appearance.BackColor = appt.Appearance.BackColor;
			appt.Header.Appearance.FontBold = true;
			appt.Header.Appearance.FontSize = 8;
			appt.Header.Appearance.AllowBreak = false;
			appt.Appearance.FontBold = false;
			appt.Header.Text = "Pick up Pictures";

			//Appointment 3
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(2), dayStart.AddMinutes(570), 150);
			appt.Subject = "Company Meeting; I only need to be half engaged here";
			appt.Appearance = (AppointmentAppearance)appearance.Clone();
			appt.Appearance.BackColor2 = Color.FromArgb(0xEE, 0xAA, 0x6A);

			//Appointment 4
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(2), dayStart.AddMinutes(690), 120);
			appt.Subject = "Release Software";
			appt.Appearance = (AppointmentAppearance)appearance.Clone();
			appt.Appearance.BorderColor = Color.FromArgb(0x5B, 0x67, 0x96);
			appt.Appearance.BackColor = Color.FromArgb(0xC6, 0xCB, 0xE8);
			appt.Appearance.BackColor2 = Color.FromArgb(0x64, 0x8C, 0xC8);

			//Appointment 5
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(1), dayStart.AddMinutes(660), 180);
			appt.Subject = "I really need to talk to him today!";
			appt.Appearance = (AppointmentAppearance)appearance.Clone();
			appt.Appearance.BorderColor = Color.FromArgb(0xA4, 0x9A, 0x49);
			appt.Appearance.BackColor = Color.FromArgb(0xFB, 0xED, 0xB8);
			appt.Appearance.BackColor2 = Color.FromArgb(0xE3, 0xD3, 0x5F);
			appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appt.Header.Appearance.BackColor = appt.Appearance.BackColor;
			appt.Header.Appearance.FontBold = true;
			appt.Header.Appearance.FontSize = 8;
			appt.Header.Appearance.AllowBreak = false;
			appt.Appearance.FontBold = false;
			appt.Header.Text = "Call John";

			//Appointment 5
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(1), dayStart.AddMinutes(900), 90);
			appt.Subject = "Check Credit";
			appt.Appearance = (AppointmentAppearance)appearance.Clone();
			appt.Appearance.BorderColor = Color.FromArgb(0xA7, 0x70, 0x4F);
			appt.Appearance.BackColor = Color.FromArgb(0xFD, 0xC5, 0xBB);
			appt.Appearance.BackColor2 = Color.FromArgb(0xD8, 0x93, 0x6E);

		}

		#endregion

		#region LoadProviderTest

		private void LoadProviderTest()
		{
			this.panel1.Visible = false;
			this.Width = 600;
			this.Height = 420;

			DateTime dayStart = new DateTime(2006, 1, 2, 0, 0, 0);
			schedule1.SetMinMaxDate(dayStart, dayStart.AddDays(2));
			schedule1.HeaderDateFormat = "ddd";
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft;
			schedule1.StartTime = dayStart;
			schedule1.DayLength = 24;
			schedule1.Visibility.ShowTime(dayStart.AddMinutes(570));
			schedule1.UseDefaultDrawnHeaders = true;

			//Add Providers
			schedule1.ProviderCollection.Clear();
			schedule1.ProviderCollection.Add("", "John", Color.LightBlue);
			schedule1.ProviderCollection.Add("", "Ralph", Color.LightCyan);
			schedule1.ProviderCollection.Add("", "Mike", Color.LightGreen);
			schedule1.ProviderCollection.Add("", "Sally", Color.LightYellow);

			//Make header gradients
			foreach (Provider provider in schedule1.ProviderCollection)
			{
				provider.Appearance.BackColor2 = Color.White;
				provider.Appearance.BackGradientStyle = GradientStyleConstants.Vertical;
			}

			//Add Rooms
			schedule1.RoomCollection.Clear();
			schedule1.RoomCollection.Add("", "Room 1");
			schedule1.RoomCollection.Add("", "Room 2");
			schedule1.RoomCollection.Add("", "Room 3");
			schedule1.RoomCollection.Add("", "Room 4");

			//Make header gradients
			foreach (Room room in schedule1.RoomCollection)
			{
				room.Appearance.BackColor2 = Color.White;
				room.Appearance.BackGradientStyle = GradientStyleConstants.Vertical;
			}

			schedule1.EventHeader.Appearance.BackColor = Color.FromArgb(0xA6, 0xC0, 0xE1);
			schedule1.EventHeader.Appearance.BorderColor = schedule1.EventHeader.Appearance.BackColor;
			schedule1.EventHeader.Appearance.BorderWidth = 0;

			//Colored Areas
			foreach (Provider provider in schedule1.ProviderCollection)
			{
				ScheduleArea area = schedule1.ColoredAreaCollection.Add("", provider.Appearance.BackColor, provider);
				area.Appearance.BorderWidth = 0;
			}

			//Main Grid
			schedule1.Appearance.BackColor = Color.White;
			schedule1.Appearance.BorderWidth = 0;
			schedule1.Appearance.ForeColor = Color.FromArgb(0xA5, 0xBD, 0xDE);

			//Column Header
			schedule1.ColumnHeader.Appearance.BackColor = Color.FromArgb(0xD6, 0xE2, 0xF1);
			schedule1.ColumnHeader.Appearance.ForeColor = Color.Black;
			schedule1.ColumnHeader.Appearance.FontSize = 8;
			schedule1.ColumnHeader.AutoFit = true;

			//Row Header
			schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(0xE9, 0xE7, 0xB8);
			schedule1.RowHeader.Appearance.FontSize = 8;
			schedule1.RowHeader.Size = 20;

		}

		#endregion

		#region LoadStyleTheme
		private void LoadStyleTheme(Gravitybox.Controls.Schedule.ThemeConstants theme)
		{
			this.panel1.Visible = false;
			this.Width = 600;
			this.Height = 420;

			DateTime dayStart = new DateTime(2006, 1, 2, 0, 0, 0);
			schedule1.SetMinMaxDate(dayStart, dayStart.AddDays(2));
			schedule1.HeaderDateFormat = "ddd";
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
			schedule1.StartTime = dayStart;
			schedule1.DayLength = 24;
			schedule1.Visibility.ShowTime(dayStart.AddMinutes(570));

			schedule1.ColumnHeader.AutoFit = true;
			schedule1.RowHeader.Size = 20;
			schedule1.ApplyTheme(theme);

			Appointment appt = null;

			//Appointment 1
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(10), 150);
			appt.Subject = "10 Years!";
			appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appt.Header.Text = "Anniversary";

			//Appointment 2
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate, dayStart.AddHours(13), 210);
			appt.Subject = "Pick up the pictures from the grand opening";
			appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appt.Header.Text = "Pick up Pictures";

			//Appointment 3
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(2), dayStart.AddMinutes(570), 150);
			appt.Subject = "Company Meeting; I only need to be half engaged here";

			//Appointment 4
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(2), dayStart.AddMinutes(690), 120);
			appt.Subject = "Release Software";

			//Appointment 5
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(1), dayStart.AddMinutes(660), 180);
			appt.Subject = "I really need to talk to him today!";
			appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appt.Header.Text = "Call John";

			//Appointment 5
			appt = schedule1.AppointmentCollection.Add("", schedule1.MinDate.AddDays(1), dayStart.AddMinutes(900), 90);
			appt.Subject = "Check Credit";

		}

		#endregion

		#region LoadVacation
		private void LoadVactation()
    {
      //Set The ViewMode Like You Instructed
      DateTime startDate = new DateTime(2006, 6, 1, 8, 0, 0);
      schedule1.AutoRedraw = false;
      schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft;
      schedule1.HeaderDateFormat = "MM/dd/yy";
      schedule1.SetMinMaxDate(startDate, startDate.AddDays(390));

      //Turn off all user interaction
      schedule1.AllowAdd = false;
      schedule1.AllowCopy = false;
      schedule1.AllowDrop = false;
      schedule1.AllowMove = false;
      schedule1.AllowRemove = false;
      schedule1.AllowSelector = false;

      //Setup database connection
      string sConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Temp\Chris.Ryhal\Project\VacationGravityBox\Vacation.mdb;";
      OleDbConnection myConn = new OleDbConnection(sConn);

      //Load all prople
      string sSQL = @"SELECT HR_EmployeeData.empid, HR_EmployeeData.CompleteName FROM HR_EmployeeData ORDER BY HR_EmployeeData.CompleteName";
      OleDbCommand myCommand = new OleDbCommand(sSQL, myConn);
      myCommand.CommandText = sSQL;
      OleDbDataReader dr;
      myConn.Open();
      dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
      while(dr.Read())
      {
        schedule1.ProviderCollection.Add(dr["empid"].ToString(), dr["CompleteName"].ToString());
      }
      dr.Close();

      //Load appointments
      sSQL = "SELECT * FROM HR_VacationDates";
      myCommand = new OleDbCommand(sSQL, myConn);
      myCommand.CommandText = sSQL;
      myConn.Open();
      dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
      while(dr.Read())
      {
        Appointment appt = schedule1.AppointmentCollection.Add("", (DateTime)dr["Date"], startDate, 60);
        Provider prov = schedule1.ProviderCollection[dr["EmpId"].ToString()];
        appt.ProviderList.Add(prov);
        appt.Subject = prov.Text;
        appt.Appearance.BackColor = Color.LightBlue;
        //Debug.WriteLine(appt.StartDate);
      }
      dr.Close();

      myCommand.Dispose();
      myConn.Close();
      schedule1.AutoRedraw = true;

    }
    
    #endregion

  }
}