using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace OutlookExample
{
	public class MainForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MenuItem mnuApptCategory;
		internal System.Windows.Forms.MonthCalendar MonthCalendar1;
		internal System.Windows.Forms.MenuItem mnuApptDelete;
		internal System.Windows.Forms.MenuItem mnuViewDay;
		internal System.Windows.Forms.MenuItem mnuApptProvider;
		internal System.Windows.Forms.MenuItem mnuExit;
		internal System.Windows.Forms.MainMenu MainMenu1;
		internal System.Windows.Forms.MenuItem mnuFile;
		internal System.Windows.Forms.MenuItem mnuNewAppointment;
		internal System.Windows.Forms.MenuItem MenuItem5;
		internal System.Windows.Forms.MenuItem mnuSetup;
		internal System.Windows.Forms.MenuItem mnuSetupProvider;
		internal System.Windows.Forms.MenuItem mnuSetupCategory;
		internal System.Windows.Forms.MenuItem mnuSetupRoom;
		internal System.Windows.Forms.MenuItem mnuView;
		internal System.Windows.Forms.MenuItem mnuViewWorkWeek;
		internal System.Windows.Forms.MenuItem mnuViewWeek;
		internal System.Windows.Forms.MenuItem mnuViewMonth;
		internal System.Windows.Forms.MenuItem mnuHelp;
		internal System.Windows.Forms.MenuItem MenuItem1;
		internal System.Windows.Forms.MenuItem MenuItem2;
		internal System.Windows.Forms.MenuItem MenuItem3;
		internal System.Windows.Forms.MenuItem mnuHelpAbout;
		internal System.Windows.Forms.MenuItem mnuApptOpen;
		internal System.Windows.Forms.ContextMenu AppointmentMenu;
		internal System.Windows.Forms.MenuItem MenuItem9;
		internal Gravitybox.Controls.Header Header1;
		private Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			InitializeComponent();
			this.MonthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateChanged);
			this.mnuViewDay.Click += new System.EventHandler(this.mnuViewDay_Click);
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			this.mnuNewAppointment.Click += new System.EventHandler(this.mnuNewAppointment_Click);
			this.mnuSetupProvider.Click += new System.EventHandler(this.mnuSetupProvider_Click);
			this.mnuSetupCategory.Click += new System.EventHandler(this.mnuSetupCategory_Click);
			this.mnuSetupRoom.Click += new System.EventHandler(this.mnuSetupRoom_Click);
			this.mnuViewWorkWeek.Click += new System.EventHandler(this.mnuViewWorkWeek_Click);
			this.mnuViewWeek.Click += new System.EventHandler(this.mnuViewWeek_Click);
			this.mnuViewMonth.Click += new System.EventHandler(this.mnuViewMonth_Click);
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.Click += new System.EventHandler(this.MainForm_Click);
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
			this.mnuApptCategory = new System.Windows.Forms.MenuItem();
			this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.mnuApptDelete = new System.Windows.Forms.MenuItem();
			this.mnuViewDay = new System.Windows.Forms.MenuItem();
			this.mnuApptProvider = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.MainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuNewAppointment = new System.Windows.Forms.MenuItem();
			this.MenuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuSetup = new System.Windows.Forms.MenuItem();
			this.mnuSetupProvider = new System.Windows.Forms.MenuItem();
			this.mnuSetupCategory = new System.Windows.Forms.MenuItem();
			this.mnuSetupRoom = new System.Windows.Forms.MenuItem();
			this.mnuView = new System.Windows.Forms.MenuItem();
			this.mnuViewWorkWeek = new System.Windows.Forms.MenuItem();
			this.mnuViewWeek = new System.Windows.Forms.MenuItem();
			this.mnuViewMonth = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.MenuItem1 = new System.Windows.Forms.MenuItem();
			this.MenuItem2 = new System.Windows.Forms.MenuItem();
			this.MenuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			this.mnuApptOpen = new System.Windows.Forms.MenuItem();
			this.AppointmentMenu = new System.Windows.Forms.ContextMenu();
			this.MenuItem9 = new System.Windows.Forms.MenuItem();
			this.Header1 = new Gravitybox.Controls.Header();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// mnuApptCategory
			// 
			this.mnuApptCategory.Index = 1;
			this.mnuApptCategory.Text = "&Categories";
			// 
			// MonthCalendar1
			// 
			this.MonthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MonthCalendar1.CalendarDimensions = new System.Drawing.Size(1, 2);
			this.MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
			this.MonthCalendar1.Location = new System.Drawing.Point(536, 40);
			this.MonthCalendar1.Name = "MonthCalendar1";
			this.MonthCalendar1.ShowToday = false;
			this.MonthCalendar1.ShowTodayCircle = false;
			this.MonthCalendar1.TabIndex = 3;
			// 
			// mnuApptDelete
			// 
			this.mnuApptDelete.Index = 4;
			this.mnuApptDelete.Text = "&Delete";
			// 
			// mnuViewDay
			// 
			this.mnuViewDay.Index = 0;
			this.mnuViewDay.Text = "&Day";
			// 
			// mnuApptProvider
			// 
			this.mnuApptProvider.Index = 2;
			this.mnuApptProvider.Text = "&Providers";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "E&xit";
			// 
			// MainMenu1
			// 
			this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.mnuFile,
																																							this.mnuSetup,
																																							this.mnuView,
																																							this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						this.mnuNewAppointment,
																																						this.MenuItem5,
																																						this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuNewAppointment
			// 
			this.mnuNewAppointment.Index = 0;
			this.mnuNewAppointment.Text = "&New Appointment";
			// 
			// MenuItem5
			// 
			this.MenuItem5.Index = 1;
			this.MenuItem5.Text = "-";
			// 
			// mnuSetup
			// 
			this.mnuSetup.Index = 1;
			this.mnuSetup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						 this.mnuSetupProvider,
																																						 this.mnuSetupCategory,
																																						 this.mnuSetupRoom});
			this.mnuSetup.Text = "&Setup";
			// 
			// mnuSetupProvider
			// 
			this.mnuSetupProvider.Index = 0;
			this.mnuSetupProvider.Text = "&Providers";
			// 
			// mnuSetupCategory
			// 
			this.mnuSetupCategory.Index = 1;
			this.mnuSetupCategory.Text = "&Categories";
			// 
			// mnuSetupRoom
			// 
			this.mnuSetupRoom.Index = 2;
			this.mnuSetupRoom.Text = "&Rooms";
			// 
			// mnuView
			// 
			this.mnuView.Index = 2;
			this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						this.mnuViewDay,
																																						this.mnuViewWorkWeek,
																																						this.mnuViewWeek,
																																						this.mnuViewMonth});
			this.mnuView.Text = "&View";
			// 
			// mnuViewWorkWeek
			// 
			this.mnuViewWorkWeek.Index = 1;
			this.mnuViewWorkWeek.Text = "Wo&rk Week";
			// 
			// mnuViewWeek
			// 
			this.mnuViewWeek.Index = 2;
			this.mnuViewWeek.Text = "&Week";
			// 
			// mnuViewMonth
			// 
			this.mnuViewMonth.Index = 3;
			this.mnuViewMonth.Text = "&Month";
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 3;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						this.MenuItem1,
																																						this.MenuItem2,
																																						this.MenuItem3,
																																						this.mnuHelpAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// MenuItem1
			// 
			this.MenuItem1.Index = 0;
			this.MenuItem1.Text = "&Contents";
			// 
			// MenuItem2
			// 
			this.MenuItem2.Index = 1;
			this.MenuItem2.Text = "&Search";
			// 
			// MenuItem3
			// 
			this.MenuItem3.Index = 2;
			this.MenuItem3.Text = "-";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 3;
			this.mnuHelpAbout.Text = "&About";
			// 
			// mnuApptOpen
			// 
			this.mnuApptOpen.Index = 0;
			this.mnuApptOpen.Text = "&Open";
			// 
			// AppointmentMenu
			// 
			this.AppointmentMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																										this.mnuApptOpen,
																																										this.mnuApptCategory,
																																										this.mnuApptProvider,
																																										this.MenuItem9,
																																										this.mnuApptDelete});
			// 
			// MenuItem9
			// 
			this.MenuItem9.Index = 3;
			this.MenuItem9.Text = "-";
			// 
			// Header1
			// 
			this.Header1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Header1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
			this.Header1.Location = new System.Drawing.Point(0, 0);
			this.Header1.Name = "Header1";
			this.Header1.Size = new System.Drawing.Size(728, 40);
			this.Header1.TabIndex = 4;
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
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
			this.schedule1.Cursor = System.Windows.Forms.Cursors.Default;
			this.schedule1.DayLength = 16;
			this.schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Location = new System.Drawing.Point(256, 120);
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
			this.schedule1.Size = new System.Drawing.Size(136, 120);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 465);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.Header1);
			this.Controls.Add(this.MonthCalendar1);
			this.Menu = this.MainMenu1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET Outlook Example";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		public enum DisplayModeConstants
		{
			Day = 1,
			WorkWeek = 2,
			Week = 3,
			Month = 4
		}

		private DisplayModeConstants m_DisplayMode;
		private bool isRefreshing = false;

		public DisplayModeConstants DisplayMode
		{
			get { return m_DisplayMode; }
			set 
			{
				m_DisplayMode = value;
				RefreshRange(MonthCalendar1.SelectionStart);
			}
		}

		private void RefreshRange(DateTime selectedDate)
		{

			try 
			{
				DateTime startDate = DateTime.Now;
				DateTime endDate = DateTime.Now;

				if (isRefreshing) 	
					return;

				isRefreshing = true;
				schedule1.AutoRedraw = false;

				//Uncheck all menu items
				mnuViewDay.Checked = false;
				mnuViewWorkWeek.Checked = false;
				mnuViewWeek.Checked = false;
				mnuViewMonth.Checked = false;	

				//Setup the display mode
				if (this.DisplayMode == DisplayModeConstants.Day)
				{
					schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
					mnuViewDay.Checked = true;
					schedule1.HeaderDateFormat = "dddd, MMMM dd";
					startDate = selectedDate;
					endDate = selectedDate;
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
					schedule1.RowHeader.Size = 25;
				}
				else if (this.DisplayMode == DisplayModeConstants.WorkWeek)
				{
					schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
					mnuViewWorkWeek.Checked = true;
					schedule1.HeaderDateFormat = "ddd, MMM dd";
					startDate = selectedDate.AddDays(-int.Parse(selectedDate.DayOfWeek.ToString("d")) + 1);
					endDate = startDate.AddDays(4);
					//startDate = DateAdd(DateInterval.Day, -int.Parse(selectedDate.DayOfWeek.ToString("d")) + 1, selectedDate);
					//endDate = DateAdd(DateInterval.Day, 4, startDate);
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
					schedule1.RowHeader.Size = 25;
				}
				else if (this.DisplayMode == DisplayModeConstants.Week)
				{
					schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
					mnuViewWeek.Checked = true;
					schedule1.HeaderDateFormat = "ddd, MMM dd";
					startDate = selectedDate.AddDays(-int.Parse(selectedDate.DayOfWeek.ToString("d")));
					endDate = startDate.AddDays(6);
					//startDate = DateAdd(DateInterval.Day, -int.Parse(selectedDate.DayOfWeek.ToString("d")), selectedDate);
					//endDate = DateAdd(DateInterval.Day, 6, startDate);
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
					schedule1.RowHeader.Size = 25;
				}
				else if (this.DisplayMode == DisplayModeConstants.Month)
				{
					schedule1.Appearance.ForeColor = System.Drawing.Color.Black;
					mnuViewMonth.Checked = true;
					startDate = selectedDate.AddDays(-selectedDate.Day + 1);
					//startDate = DateAdd(DateInterval.Day, -selectedDate.Day + 1, selectedDate);
					endDate = startDate.AddMonths(1).AddDays(-1);
					//endDate = DateAdd(DateInterval.Month, 1, startDate);
					//endDate = DateAdd(DateInterval.Day, -1, endDate);
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month;
				}

				if (this.DisplayMode == DisplayModeConstants.Month)
				{
					this.MonthCalendar1.SetSelectionRange(selectedDate, selectedDate);
					this.MonthCalendar1.SelectionRange.Start = selectedDate;
					this.MonthCalendar1.SelectionRange.End = selectedDate;
					schedule1.SetMinMaxDate(startDate, endDate);
				}
				else
				{
					this.MonthCalendar1.SetSelectionRange(startDate, endDate);
					this.MonthCalendar1.SelectionRange.Start = startDate;
					this.MonthCalendar1.SelectionRange.End = endDate;
					schedule1.SetMinMaxDate(MonthCalendar1.SelectionStart, MonthCalendar1.SelectionEnd);
				}

				schedule1.AutoRedraw = true;
				isRefreshing = false;

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{

			try 
			{
				this.Header1.Text = "Outlook Example";
				MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday;
				DisplayMode = DisplayModeConstants.Month;
				schedule1.ColumnHeader.AutoFit = true;
				ResizeForm();

				//Refresh the scehdule display
				RefreshRange(MonthCalendar1.SelectionStart);

				LoadTestAppointments();

			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void LoadTestAppointments()
		{

			Appointment appointment;
			schedule1.AppointmentCollection.Clear();

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Today, DateTime.Parse("10:00:00 AM"), 60);
			appointment.Subject = "This is a test!";
			appointment.ToolTipText = appointment.Subject;
			appointment.Appearance.BackColor = System.Drawing.Color.Yellow;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Today, DateTime.Parse("11:00:00 AM"), 60);
			appointment.Subject = "Just Another Test!";
			appointment.ToolTipText = appointment.Subject;
			appointment.IsFlagged = true;
			appointment.Appearance.BackColor = System.Drawing.Color.Aqua;

			schedule1.Refresh();

		}

		private void ResizeForm()
		{

			try 
			{
				schedule1.Location = new System.Drawing.Point(0, Header1.Height);
				schedule1.Size = new System.Drawing.Size(this.ClientSize.Width - this.MonthCalendar1.Width, this.ClientSize.Height - Header1.Height);
				MonthCalendar1.Location = new System.Drawing.Point(this.ClientSize.Width - MonthCalendar1.Width, Header1.Height);
				SetupDateFormat();
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void MonthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{

			try 
			{
				RefreshRange(e.Start);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#region View Menus

		private void mnuViewDay_Click(object sender, System.EventArgs e)
		{
			this.DisplayMode = DisplayModeConstants.Day;
		}

		private void mnuViewWorkWeek_Click(object sender, System.EventArgs e)
		{
			this.DisplayMode = DisplayModeConstants.WorkWeek;
		}

		private void mnuViewWeek_Click(object sender, System.EventArgs e)
		{
			this.DisplayMode = DisplayModeConstants.Week;
		}

		private void mnuViewMonth_Click(object sender, System.EventArgs e)
		{
			this.DisplayMode = DisplayModeConstants.Month;
		}

		#endregion

		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			ResizeForm();
		}

		#region Setup Menus

		private void mnuSetupProvider_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowProviderConfiguration();
		}

		private void mnuSetupCategory_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowCategoryConfiguration();
		}

		private void mnuSetupRoom_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowRoomConfiguration();
		}

		#endregion

		private void mnuHelpAbout_Click(object sender, System.EventArgs e)
		{

			try 
			{
				AboutForm F = new AboutForm();
				F.ShowDialog();
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void mnuNewAppointment_Click(object sender, System.EventArgs e)
		{

			try 
			{
				DateTime newDate = schedule1.MinDate.AddDays(schedule1.Selector.Column);
				//DateTime newDate = DateAdd(DateInterval.Day, schedule1.Selector.Column, schedule1.MinDate);
				if (newDate < schedule1.MinDate) newDate = schedule1.MinDate;
				if (newDate > schedule1.MaxDate) 
					newDate = schedule1.MaxDate;
				DateTime newTime = schedule1.StartTime.AddMinutes(schedule1.Selector.Row * int.Parse(schedule1.TimeIncrement.ToString("d")));
				//DateTime newTime = DateAdd(DateInterval.Minute, schedule1.Selector.Row * int.Parse(schedule1.TimeIncrement.ToString("d")), schedule1.StartTime);
				int newLength = schedule1.Selector.Length * int.Parse(schedule1.TimeIncrement.ToString("d"));

				Appointment appointment = schedule1.AppointmentCollection.Add("", newDate, newTime, newLength);
				schedule1.Dialogs.ShowPropertyDialog(appointment);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void mnuApptDelete_Click(object sender, System.EventArgs e)
		{

			try 
			{
				if (schedule1.SelectedItem == null) 
					return;
				if (MessageBox.Show("Do you wish to remove this appointment?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					return;
				schedule1.AppointmentCollection.Remove(schedule1.SelectedItem);
				schedule1.Refresh();
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void mnuApptProvider_Click(object sender, System.EventArgs e)
		{

			try 
			{
				if (schedule1.SelectedItem == null) 
					return;
				schedule1.Dialogs.ShowProviderDialog(schedule1.SelectedItem);
			}																																																																																		 
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void mnuApptCategory_Click(object sender, System.EventArgs e)
		{

			try 
			{
				if (schedule1.SelectedItem == null) 
					return;
			
				schedule1.Dialogs.ShowCategoryDialog(schedule1.SelectedItem);					
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void mnuApptOpen_Click(object sender, System.EventArgs e)
		{

			try 
			{
				if (schedule1.SelectedItem == null)
					return;
				schedule1.Dialogs.ShowPropertyDialog(schedule1.SelectedItem);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void schedule1_AppointmentClick(object sender, Gravitybox.Objects.EventArgs.AppointmentMouseEventArgs e)
		{

			try 
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Right)
					this.AppointmentMenu.Show(schedule1, new System.Drawing.Point(e.X, e.Y));
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		private void schedule1_Resize(object sender, System.EventArgs e)
		{
			SetupDateFormat();
		}

		private void SetupDateFormat()
		{

			//When not in month mode this will format the date headers to match the width of the columns
			if (schedule1.ViewMode != Gravitybox.Controls.Schedule.ViewModeConstants.Month)
			{
				if (schedule1.ColumnHeader.Size < 60)
				{
					schedule1.HeaderDateFormat = "M/d";
				}
				else if (schedule1.ColumnHeader.Size < 90)
				{
					schedule1.HeaderDateFormat = "ddd dd";
				}
				else
				{
					schedule1.HeaderDateFormat = "ddd, MMM dd";
				}
			}

		}

		private void MainForm_Click(object sender, System.EventArgs e)
		{
			//Click the form to reload the default appointments for testing
			LoadTestAppointments();
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Close();

		}

	}
}
