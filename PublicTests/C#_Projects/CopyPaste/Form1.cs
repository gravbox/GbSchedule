using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace CopyPaste
{
	public class Form1 : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MenuItem menuEditCopy;
		internal System.Windows.Forms.MenuItem menuEditCut;
		internal System.Windows.Forms.MenuItem menuEditPaste;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.MenuItem menuFileExit;
		internal System.Windows.Forms.MenuItem menuEdit;
		internal Gravitybox.Controls.Schedule Schedule1;
		internal System.Windows.Forms.MenuItem menuHelpAbout;
		internal System.Windows.Forms.MenuItem menuHelp;
		internal System.Windows.Forms.MainMenu MainMenu1;
		internal System.Windows.Forms.MenuItem menuFile;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.menuEditCopy = new System.Windows.Forms.MenuItem();
			this.menuEditCut = new System.Windows.Forms.MenuItem();
			this.menuEditPaste = new System.Windows.Forms.MenuItem();
			this.Label1 = new System.Windows.Forms.Label();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.Schedule1 = new Gravitybox.Controls.Schedule();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.MainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// menuEditCopy
			// 
			this.menuEditCopy.Index = 1;
			this.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.menuEditCopy.Text = "&Copy";
			this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
			// 
			// menuEditCut
			// 
			this.menuEditCut.Index = 0;
			this.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuEditCut.Text = "Cu&t";
			this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
			// 
			// menuEditPaste
			// 
			this.menuEditPaste.Index = 2;
			this.menuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
			this.menuEditPaste.Text = "&Paste";
			this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
			// 
			// Label1
			// 
			this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label1.Location = new System.Drawing.Point(0, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(688, 56);
			this.Label1.TabIndex = 2;
			// 
			// menuFileExit
			// 
			this.menuFileExit.Index = 0;
			this.menuFileExit.Text = "E&xit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 1;
			this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						 this.menuEditCut,
																																						 this.menuEditCopy,
																																						 this.menuEditPaste});
			this.menuEdit.Text = "&Edit";
			this.menuEdit.Popup += new System.EventHandler(this.menuEdit_Popup);
			// 
			// Schedule1
			// 
			this.Schedule1.AllowDrop = true;
			this.Schedule1.Appearance.FontSize = 10F;
			this.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.Schedule1.ColumnHeader.Appearance.FontSize = 10F;
			this.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Schedule1.ColumnHeader.Size = 100;
			this.Schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.Schedule1.DefaultAppointmentAppearance.ShadowSize = 0;
			this.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
			this.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
			this.Schedule1.EventHeader.AllowExpand = false;
			this.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.Schedule1.EventHeader.Appearance.FontSize = 10F;
			this.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.Schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.Schedule1.Location = new System.Drawing.Point(0, 56);
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
			this.Schedule1.SelectedAppointmentAppearance.ShadowSize = 0;
			this.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
			this.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.Schedule1.Selector.Appearance.FontSize = 10F;
			this.Schedule1.Size = new System.Drawing.Size(688, 341);
			this.Schedule1.StartTime = new System.DateTime(((long)(0)));
			this.Schedule1.TabIndex = 3;
			this.Schedule1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Schedule1_KeyPress);
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Index = 0;
			this.menuHelpAbout.Text = "&About";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 2;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						 this.menuHelpAbout});
			this.menuHelp.Text = "&Help";
			// 
			// MainMenu1
			// 
			this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuFile,
																																							this.menuEdit,
																																							this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																						 this.menuFileExit});
			this.menuFile.Text = "&File";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 397);
			this.Controls.Add(this.Schedule1);
			this.Controls.Add(this.Label1);
			this.Menu = this.MainMenu1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		#region Form Variables

		private ArrayList ClipboardAppointments = new ArrayList();

		#endregion

		#region Form Load

		private void Form1_Load(object sender, System.EventArgs e)
		{

			//Setup the Schedule
			Schedule1.Appearance.BackColor = Color.LightYellow;
			Schedule1.StartTime = new DateTime(2000, 1, 1, 8, 0, 0);
			Schedule1.DayLength = 10;
			Schedule1.SetMinMaxDate(DateTime.Now, DateTime.Now.AddDays(4));
			Schedule1.ColumnHeader.AutoFit = true;
			Schedule1.MultiSelect = true;

			Label1.Text = "Select one or more appointments. You can then use copy/cut/paste shortcuts or menus.  After you copy or cut, move the selector to the place you wish to place the appointments and paste. If you cut and paste, the appointment is moved. If you copy and paste, a new appointment is created (a copy).";

			//Add some appointments
			Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, new DateTime(2000, 1, 1, 8, 0, 0), 60);
			Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, new DateTime(2000, 1, 1, 9, 30, 0), 30);
			Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, new DateTime(2000, 1, 1, 11, 0, 0), 120);
			Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(1), new DateTime(2000, 1, 1, 8, 30, 0), 60);
			Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(1), new DateTime(2000, 1, 1, 10, 0, 0), 90);
			Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(1), new DateTime(2000, 1, 1, 11, 0, 0), 60);

			foreach (Appointment appointment in Schedule1.AppointmentCollection)
			{
				appointment.Appearance.BackColor = Color.LightBlue;
				appointment.Subject = "This is a test";
				appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
			}

		}

		#endregion

		#region Menus

		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuEdit_Popup(object sender, System.EventArgs e)
		{

			//Enable the menus
			menuEditCopy.Enabled = (Schedule1.SelectedItems.Count > 0);
			menuEditCut.Enabled = (Schedule1.SelectedItems.Count > 0);
			menuEditPaste.Enabled = (ClipboardAppointments.Count > 0) && (Schedule1.SelectedItem == null);

		}

		private void menuEditCut_Click(object sender, System.EventArgs e)
		{

			this.ClearGhosted();
			this.ClipboardAppointments.Clear();	
			foreach (Appointment appointment in Schedule1.SelectedItems)
			{
				appointment.Appearance.Ghosted = true;
				this.ClipboardAppointments.Add(appointment.Key);
			}
			this.Schedule1.SelectedItems.Clear();

		}

		private void menuEditCopy_Click(object sender, System.EventArgs e)
		{

			this.ClipboardAppointments.Clear();

			//When coping make all appointment blink 
			Schedule1.AutoRedraw = false;
			foreach (Appointment appointment in Schedule1.SelectedItems)
			{
				appointment.Appearance.Ghosted = true;
				this.ClipboardAppointments.Add(appointment.Key);
			}
			Schedule1.AutoRedraw = true;

			//Sleep for a time period
			System.Threading.Thread.Sleep(200);

			//Make them all visible again
			Schedule1.AutoRedraw = false;
			foreach (Appointment appointment in Schedule1.SelectedItems)
				appointment.Appearance.Ghosted = false;

			Schedule1.AutoRedraw = true;

		}

		private void menuEditPaste_Click(object sender, System.EventArgs e)
		{

			//When pasting calculate the earliest appointments date/time
			DateTime firstTime = DateTime.MaxValue;
			foreach (string key in this.ClipboardAppointments)
			{
				Appointment appointment = Schedule1.AppointmentCollection[key];
				if (firstTime > appointment.StartDateTime)
					firstTime = appointment.StartDateTime;
			}

			//There was some error, do nothing
			if (firstTime == DateTime.MaxValue)
				return;

			//Now that we have the first time...
			DateTime selectorDate = Schedule1.Visibility.GetDateFromRowCol(this.Schedule1.Selector.Column);
			DateTime selectorTime = Schedule1.Visibility.GetTimeFromRowCol(this.Schedule1.Selector.Row);
			DateTime selector = selectorDate.AddHours(selectorTime.Hour).AddMinutes(selectorTime.Minute);

			//Get the number of minutes between the first appointment's position and the selector
			int differenceMinutes = (int)selector.Subtract(firstTime).TotalMinutes;

			Schedule1.AutoRedraw = false;
			foreach (string key in this.ClipboardAppointments)
			{
				Appointment appointment = Schedule1.AppointmentCollection[key];
				DateTime apptDateTime = appointment.StartDateTime;
				apptDateTime = apptDateTime.AddMinutes(differenceMinutes);

				//If the appointment is ghosted then the user cut the appointment 
				//and pasted it somewhere else, otherwise it was copied
				if (appointment.Appearance.Ghosted)
				{
					//Move the appointment, so just reset their date/time
					appointment.StartDate = apptDateTime;
					appointment.StartTime = apptDateTime;
				}
				else
				{
					//Create a copy of the appointment and add them to the collection
					appointment = (Appointment)appointment.Clone();
					appointment.StartDate = apptDateTime;
					appointment.StartTime = apptDateTime;
					appointment.Recurrence = null;
					Schedule1.AppointmentCollection.Add(appointment);
				}

			}
			Schedule1.AutoRedraw = true;

			//Clear all ghosted appointments
			this.ClearGhosted();

		}

		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("About Gravitybox Schedule Copy/Paste Test\nVersion 1.0", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region Schedule Events

		private void Schedule1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//If pressed <ESC> then clear all ghosted items
			if (e.KeyChar == (char)27)
				this.ClearGhosted();

		}

		#endregion

		#region Methods

		private void ClearGhosted()
		{

			foreach (Appointment appointment in Schedule1.AppointmentCollection)
			{
				if (appointment.Appearance.Ghosted)
				{
					appointment.Appearance.Ghosted = false;
					if (this.ClipboardAppointments.Contains(appointment.Key))
						this.ClipboardAppointments.Remove(appointment.Key);	  
				}
			}

		}

		#endregion

	}
}