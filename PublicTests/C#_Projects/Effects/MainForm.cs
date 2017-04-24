using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace Effects
{
	public class MainForm : System.Windows.Forms.Form
	{

		#region Form Header

		internal System.Windows.Forms.Button cmdFile;
		internal System.Windows.Forms.ImageList ImageList1;
		internal System.Windows.Forms.Button cmdConflictDisplay;
		internal System.Windows.Forms.Button cmdRed;
		internal System.Windows.Forms.Button cmdGreen;
		internal System.Windows.Forms.Button cmdBlue;
		internal System.Windows.Forms.Button cmdConflicts;
		internal System.Windows.Forms.Button cmdAllowHeaders;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TrackBar TrackBar1;
		internal System.Windows.Forms.Button cmdRound;
		private Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			InitializeComponent();
			this.cmdConflictDisplay.Click += new System.EventHandler(this.cmdConflictDisplay_Click);
			this.cmdRed.Click += new System.EventHandler(this.cmdRed_Click);
			this.cmdGreen.Click += new System.EventHandler(this.cmdGreen_Click);
			this.cmdBlue.Click += new System.EventHandler(this.cmdBlue_Click);
			this.cmdFile.Click += new System.EventHandler(this.cmdFile_Click);
			this.cmdConflicts.Click += new System.EventHandler(this.cmdConflicts_Click);
			this.cmdAllowHeaders.Click += new System.EventHandler(this.cmdAllowHeaders_Click);
			this.TrackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
			this.cmdRound.Click += new System.EventHandler(this.cmdRound_Click);
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

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.cmdFile = new System.Windows.Forms.Button();
			this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
			this.cmdConflictDisplay = new System.Windows.Forms.Button();
			this.cmdRed = new System.Windows.Forms.Button();
			this.cmdGreen = new System.Windows.Forms.Button();
			this.cmdBlue = new System.Windows.Forms.Button();
			this.cmdConflicts = new System.Windows.Forms.Button();
			this.cmdAllowHeaders = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.TrackBar1 = new System.Windows.Forms.TrackBar();
			this.cmdRound = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			((System.ComponentModel.ISupportInitialize)(this.TrackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdFile
			// 
			this.cmdFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdFile.Location = new System.Drawing.Point(552, 392);
			this.cmdFile.Name = "cmdFile";
			this.cmdFile.Size = new System.Drawing.Size(96, 24);
			this.cmdFile.TabIndex = 18;
			this.cmdFile.Text = "File";
			// 
			// ImageList1
			// 
			this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// cmdConflictDisplay
			// 
			this.cmdConflictDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdConflictDisplay.Location = new System.Drawing.Point(344, 392);
			this.cmdConflictDisplay.Name = "cmdConflictDisplay";
			this.cmdConflictDisplay.Size = new System.Drawing.Size(96, 24);
			this.cmdConflictDisplay.TabIndex = 14;
			this.cmdConflictDisplay.Text = "Conflict Display";
			// 
			// cmdRed
			// 
			this.cmdRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdRed.Location = new System.Drawing.Point(448, 360);
			this.cmdRed.Name = "cmdRed";
			this.cmdRed.Size = new System.Drawing.Size(96, 24);
			this.cmdRed.TabIndex = 15;
			this.cmdRed.Text = "Red";
			// 
			// cmdGreen
			// 
			this.cmdGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdGreen.Location = new System.Drawing.Point(448, 392);
			this.cmdGreen.Name = "cmdGreen";
			this.cmdGreen.Size = new System.Drawing.Size(96, 24);
			this.cmdGreen.TabIndex = 16;
			this.cmdGreen.Text = "Green";
			// 
			// cmdBlue
			// 
			this.cmdBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdBlue.Location = new System.Drawing.Point(552, 360);
			this.cmdBlue.Name = "cmdBlue";
			this.cmdBlue.Size = new System.Drawing.Size(96, 24);
			this.cmdBlue.TabIndex = 17;
			this.cmdBlue.Text = "Blue";
			// 
			// cmdConflicts
			// 
			this.cmdConflicts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdConflicts.Location = new System.Drawing.Point(344, 360);
			this.cmdConflicts.Name = "cmdConflicts";
			this.cmdConflicts.Size = new System.Drawing.Size(96, 24);
			this.cmdConflicts.TabIndex = 12;
			this.cmdConflicts.Text = "Conflicts";
			// 
			// cmdAllowHeaders
			// 
			this.cmdAllowHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAllowHeaders.Location = new System.Drawing.Point(240, 360);
			this.cmdAllowHeaders.Name = "cmdAllowHeaders";
			this.cmdAllowHeaders.Size = new System.Drawing.Size(96, 24);
			this.cmdAllowHeaders.TabIndex = 10;
			this.cmdAllowHeaders.Text = "Allow Headers";
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.Location = new System.Drawing.Point(16, 368);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(208, 16);
			this.Label1.TabIndex = 13;
			this.Label1.Text = "Transparency";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TrackBar1
			// 
			this.TrackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.TrackBar1.LargeChange = 20;
			this.TrackBar1.Location = new System.Drawing.Point(8, 384);
			this.TrackBar1.Maximum = 100;
			this.TrackBar1.Name = "TrackBar1";
			this.TrackBar1.Size = new System.Drawing.Size(224, 42);
			this.TrackBar1.SmallChange = 5;
			this.TrackBar1.TabIndex = 19;
			this.TrackBar1.TickFrequency = 5;
			this.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
			// 
			// cmdRound
			// 
			this.cmdRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdRound.Location = new System.Drawing.Point(240, 392);
			this.cmdRound.Name = "cmdRound";
			this.cmdRound.Size = new System.Drawing.Size(96, 24);
			this.cmdRound.TabIndex = 11;
			this.cmdRound.Text = "Round";
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
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
			this.schedule1.Cursor = System.Windows.Forms.Cursors.Default;
			this.schedule1.DayLength = 16;
			this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentAppearance.NoFill = false;
			this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentHeaderAppearance.NoFill = false;
			this.schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
			this.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
			this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.schedule1.EventHeader.Appearance.FontSize = 10F;
			this.schedule1.EventHeader.Appearance.NoFill = false;
			this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.schedule1.EventHeader.ExpandAppearance.NoFill = false;
			this.schedule1.Location = new System.Drawing.Point(0, 0);
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
			this.schedule1.Size = new System.Drawing.Size(656, 352);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 20;
			this.schedule1.AppointmentHeaderInfoClick += new Gravitybox.Controls.Schedule.AppointmentMouseEventDelegate(this.schedule1_AppointmentHeaderInfoClick);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 429);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.cmdConflictDisplay);
			this.Controls.Add(this.cmdRed);
			this.Controls.Add(this.cmdGreen);
			this.Controls.Add(this.cmdBlue);
			this.Controls.Add(this.cmdConflicts);
			this.Controls.Add(this.cmdAllowHeaders);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TrackBar1);
			this.Controls.Add(this.cmdRound);
			this.Controls.Add(this.cmdFile);
			this.Name = "MainForm";
			this.Text = "Gravitybox Schedule.NET Effects Example";
			((System.ComponentModel.ISupportInitialize)(this.TrackBar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		bool AllowHeaders = true;
		bool Msg1Displayed= false;
		bool Msg2Displayed = false;

		private void MainForm_Load(object sender, System.EventArgs e)
		{

			schedule1.ColumnHeader.AutoFit = true;
			schedule1.MultiSelect = true;
			schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider;

			schedule1.ProviderCollection.Add("", "Provider I", Color.Yellow);
			schedule1.ProviderCollection.Add("", "Provider II", Color.Red);

			schedule1.CategoryCollection.Add("", "Category I", Color.Yellow);
			schedule1.CategoryCollection.Add("", "Category II", Color.Red);

			schedule1.RoomCollection.Add("", "Room I");
			schedule1.RoomCollection.Add("", "Room II");

			LoadSet5();

		}

		private void LoadSet1()
		{

			const int Transparency = 40;
			Appointment appointment;

			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/5/2004"));
			schedule1.AppointmentCollection.Clear();

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("8:00:00 AM"), 120);
			appointment.Subject = "Appointment 1";
			appointment.Appearance.IsRound = true;
			appointment.Appearance.BackColor = Color.LightBlue;
			appointment.Header.Appearance.AllowBreak = true;
			appointment.Header.Appearance.Transparency = Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("11:00:00 AM"), 120);
			appointment.Subject = "Appointment 2";
			appointment.Appearance.BackColor = Color.LightCoral;
			appointment.Appearance.Transparency = Transparency;
			appointment.Header.Appearance.AllowBreak = true;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("9:30:00 AM"), 60);
			appointment.Subject = "Appointment 3";
			appointment.Appearance.IsRound = true;
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightCyan;
			appointment.Header.Icon = schedule1.DefaultIcons.IconInfo;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("12:30:00 PM"), 60);
			appointment.Subject = "Appointment 4";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightGoldenrodYellow;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("10:00:00 AM"), 60);
			appointment.Subject = "Appointment 5";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.IsRound = true;
			appointment.Appearance.BackColor = Color.LightGray;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.DateHeader;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("1:30:00 PM"), 60);
			appointment.Subject = "Appointment 6";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightGreen;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appointment.Header.Text = "Custom";
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/4/2004"), DateTime.Parse("8:30:00 AM"), 90);
			appointment.Subject = "Appointment 7";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightPink;
			appointment.Header.Appearance.Transparency = 0;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/5/2004"), DateTime.Parse("11:30:00 AM"), 90);
			appointment.Subject = "Appointment 8";
			appointment.Appearance.IsRound = true;
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightSeaGreen;
			appointment.Header.Appearance.Transparency = 0;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None;

			schedule1.Refresh();

		}

		private void LoadSet2()
		{

			const int Transparency = 50;
			Appointment appointment;

			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/4/2004"));
			schedule1.AppointmentCollection.Clear();

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("11:00:00 AM"), 120);
			appointment.Subject = "Appointment 1";
			appointment.Appearance.BackColor = Color.LightCoral;
			appointment.Appearance.Transparency = Transparency;
			appointment.Header.Icon = schedule1.DefaultIcons.IconInfo;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;
			appointment.Header.Appearance.AllowBreak = true;
			appointment.ProviderList.Add(schedule1.ProviderCollection[0]);
			appointment.IconCollection.Add("", this.ImageList1.Images[0]);
			appointment.IconCollection.Add("", this.ImageList1.Images[1]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("10:00:00 AM"), 60);
			appointment.Subject = "Appointment 2";
			appointment.Appearance.BackColor = Color.LightGray;
			appointment.Appearance.Transparency = Transparency;
			appointment.Header.Icon = schedule1.DefaultIcons.IconQuestion;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;
			appointment.ProviderList.Add(schedule1.ProviderCollection[1]);

			TrackBar1.Value = Transparency;
			schedule1.Refresh();

		}

		private void LoadSet3()
		{

			const int Transparency = 50;
			Appointment appointment;

			//if (!Msg2Displayed)
			//{
			//  MessageBox.Show("This example will toggle the appointment headers on/off.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//  Msg2Displayed = true
			//}

			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/4/2004"));
			schedule1.AppointmentCollection.Clear();

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("12:00:00 PM"), 90);
			appointment.Subject = "Appointment 1";
			appointment.Appearance.BackColor = Color.LightBlue;
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.IsRound = true;
			appointment.Header.Icon = schedule1.DefaultIcons.IconInfo;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;
			appointment.Header.Appearance.AllowBreak = true;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("11:00:00 AM"), 150);
			appointment.Subject = "Appointment 2";
			appointment.Appearance.BackColor = Color.LightGreen;
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.IsRound = true;
			appointment.Header.Icon = schedule1.DefaultIcons.IconInfo;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;
			appointment.Header.Appearance.AllowBreak = true;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("11:30:00 AM"), 60);
			appointment.Subject = "Appointment 3";
			appointment.Appearance.BackColor = Color.LightGreen;
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.IsRound = true;
			appointment.Header.Icon = schedule1.DefaultIcons.IconInfo;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;
			appointment.Header.Appearance.AllowBreak = true;

			TrackBar1.Value = Transparency;
			schedule1.Refresh();

		}

		private void LoadSet5()
		{

			const int Transparency = 40;
			Appointment appointment;

			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/5/2004"));
			schedule1.AppointmentCollection.Clear();

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("8:00:00 AM"), 120);
			appointment.Subject = "Appointment 1";
			appointment.Appearance.IsRound = true;
			appointment.Appearance.BackColor = Color.LightBlue;
			appointment.Header.Appearance.AllowBreak = true;
			appointment.Header.Appearance.Transparency = Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("11:00:00 AM"), 120);
			appointment.Subject = "Appointment 2";
			appointment.Appearance.BackColor = Color.LightCoral;
			appointment.Appearance.Transparency = Transparency;
			appointment.Header.Appearance.AllowBreak = true;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/4/2004"), DateTime.Parse("9:30:00 AM"), 60);
			appointment.Subject = "Appointment 3";
			appointment.Appearance.IsRound = true;
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightCyan;
			appointment.Header.Icon = schedule1.DefaultIcons.IconInfo;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("12:30:00 PM"), 60);
			appointment.Subject = "Appointment 4";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightGoldenrodYellow;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/5/2004"), DateTime.Parse("10:00:00 AM"), 60);
			appointment.Subject = "Appointment 5";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.IsRound = true;
			appointment.Appearance.BackColor = Color.LightGray;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.DateHeader;
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("1:30:00 PM"), 60);
			appointment.Subject = "Appointment 6";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightGreen;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text;
			appointment.Header.Text = "Custom";
			appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("8:30:00 AM"), 90);
			appointment.Subject = "Appointment 7";
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightPink;
			appointment.Header.Appearance.Transparency = 0;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/4/2004"), DateTime.Parse("11:30:00 AM"), 90);
			appointment.Subject = "Appointment 8";
			appointment.Appearance.IsRound = true;
			appointment.Appearance.Transparency = Transparency;
			appointment.Appearance.BackColor = Color.LightSeaGreen;
			appointment.Header.Appearance.Transparency = 0;
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None;

			schedule1.Refresh();

		}

		private void cmdRound_Click(object sender, System.EventArgs e)
		{

			if (!Msg1Displayed)
			{
				MessageBox.Show("This example will toggle the corners of the appointment between round and square.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Msg1Displayed = true;
			}

	
			foreach (Appointment appointment in schedule1.AppointmentCollection)
			{
				appointment.Appearance.IsRound = !appointment.Appearance.IsRound;
			}
			schedule1.Refresh();

		}

		private void TrackBar1_ValueChanged(object sender, System.EventArgs e)
		{

			foreach (Appointment appointment in schedule1.AppointmentCollection)
			{
				appointment.Appearance.Transparency = TrackBar1.Value;
				appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency;
			}
			schedule1.Refresh();

		}

		private void cmdAllowHeaders_Click(object sender, System.EventArgs e)
		{

			AllowHeaders = !AllowHeaders;    
			foreach (Appointment appointment in schedule1.AppointmentCollection)
			{
				if (AllowHeaders)
					appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
				else
					appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None;      
			}
			schedule1.Refresh();

		}

		private void cmdConflicts_Click(object sender, System.EventArgs e)
		{

			MessageBox.Show("This example will turn off the side-by-side conflict view but you can still see the appointment because the top layer is 50% transparent.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

			LoadSet3();
			schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap;

		}

		private void schedule1_AppointmentHeaderInfoClick(object sender, Gravitybox.Objects.EventArgs.AppointmentMouseEventArgs e)
		{
			MessageBox.Show("You clicked the info box for appointment: " + e.Appointment.Subject, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#region Color Schemes

		private void cmdBlue_Click(object sender, System.EventArgs e)
		{
			AddScheme(Color.LightBlue, Color.Black, Color.Blue, Color.White);
		}

		private void cmdGreen_Click(object sender, System.EventArgs e)
		{
			AddScheme(Color.LightGreen, Color.Black, Color.Green, Color.White);
		}

		private void cmdRed_Click(object sender, System.EventArgs e)
		{
			AddScheme(Color.LightPink, Color.Black, Color.Red, Color.White);
		}

		private void AddScheme(Color apptBackColor, Color apptForeColor, Color headerBackColor, Color headerForeColor)
		{

			schedule1.AutoRedraw = false;
			try
			{
				Appointment appointment = null;
				schedule1.AppointmentCollection.Clear();

				appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("9:00:00 AM"), 90);
				appointment.Subject = "Appointment 1";

				appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("11:00:00 AM"), 120);
				appointment.Subject = "Appointment 2";

				appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("8:00:00 AM"), 90);
				appointment.Subject = "Appointment 3";

				appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("10:00:00 AM"), 90);
				appointment.Subject = "Appointment 4";

				appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("9:30:00 AM"), 150);
				appointment.Subject = "Appointment 5";

				//Background 40% transparent
				//Appointment color white
				//Appointment is round
				//Header NOT transparent
				//Header Font White
				//Header Info Icon
				//Header has line below (break)
				//Header shows time
				foreach (Appointment a in schedule1.AppointmentCollection)
				{
					a.Appearance.BackColor = apptBackColor;
					a.Appearance.ForeColor = apptForeColor;
					a.Appearance.Transparency = 40;
					a.Appearance.IsRound = true;
					a.Header.Icon = schedule1.DefaultIcons.IconInfo;
					a.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader;
					a.Header.Appearance.Transparency = 0;
					a.Header.Appearance.AllowBreak = true;
					a.Header.Appearance.BackColor = headerBackColor;
					a.Header.Appearance.ForeColor = headerForeColor;
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				schedule1.AutoRedraw = true;
			}

		}

		#endregion

		private void cmdConflictDisplay_Click(object sender, System.EventArgs e)
		{

			if (schedule1.ConflictDisplay == Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap)
				schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide;
			else if (schedule1.ConflictDisplay == Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide)
				schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger;
			else if (schedule1.ConflictDisplay == Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger)
				schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap;    

		}

		private void cmdFile_Click(object sender, System.EventArgs e)
		{

			MessageBox.Show("This example will save the entire appointment collection to the file 'C:\\Test.vcs' and then reload it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

			schedule1.AppointmentCollection.ToVCAL("C:\\Test.vcs", false);
			schedule1.AppointmentCollection.Clear();
			schedule1.AppointmentCollection.FromVCAL("C:\\Test.vcs", false);
			schedule1.Refresh();
		}

	}

}