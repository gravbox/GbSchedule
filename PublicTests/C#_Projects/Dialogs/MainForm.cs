using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace Dialogs
{
	public class MainForm : System.Windows.Forms.Form
	{

		private System.ComponentModel.Container components = null;

		public MainForm()
		{

			#region Form Header

			InitializeComponent();
			this.cmdDialogProperties.Click += new System.EventHandler(this.cmdDialogProperties_Click);
			this.cmdDialogAlarm.Click += new System.EventHandler(this.cmdDialogAlarm_Click);
			this.cmdDialogProvider.Click += new System.EventHandler(this.cmdDialogProvider_Click);
			this.cmdDialogCategory.Click += new System.EventHandler(this.cmdDialogCategory_Click);
			this.cmdPropertyItemConfig.Click += new System.EventHandler(this.cmdPropertyItemConfig_Click);
			this.cmdConfigRoom.Click += new System.EventHandler(this.cmdConfigRoom_Click);
			this.cmdConfigProvider.Click += new System.EventHandler(this.cmdConfigProvider_Click);
			this.cmdConfigCateogry.Click += new System.EventHandler(this.cmdConfigCateogry_Click);
			this.cmdAbout.Click += new System.EventHandler(this.cmdAbout_Click);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.schedule1.BeforeAppointmentRemove += new Gravitybox.Controls.Schedule.BeforeAppointmentEventDelegate(this.schedule1_BeforeAppointmentRemove);			
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
			this.fraBack2 = new System.Windows.Forms.GroupBox();
			this.cmdDialogProperties = new System.Windows.Forms.Button();
			this.cmdDialogAlarm = new System.Windows.Forms.Button();
			this.cmdDialogProvider = new System.Windows.Forms.Button();
			this.cmdDialogCategory = new System.Windows.Forms.Button();
			this.fraBack1 = new System.Windows.Forms.GroupBox();
			this.cmdPropertyItemConfig = new System.Windows.Forms.Button();
			this.cmdConfigRoom = new System.Windows.Forms.Button();
			this.cmdConfigProvider = new System.Windows.Forms.Button();
			this.cmdConfigCateogry = new System.Windows.Forms.Button();
			this.fraBack3 = new System.Windows.Forms.GroupBox();
			this.cmdAbout = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.fraBack2.SuspendLayout();
			this.fraBack1.SuspendLayout();
			this.fraBack3.SuspendLayout();
			this.SuspendLayout();
			// 
			// fraBack2
			// 
			this.fraBack2.Controls.Add(this.cmdDialogProperties);
			this.fraBack2.Controls.Add(this.cmdDialogAlarm);
			this.fraBack2.Controls.Add(this.cmdDialogProvider);
			this.fraBack2.Controls.Add(this.cmdDialogCategory);
			this.fraBack2.Location = new System.Drawing.Point(8, 168);
			this.fraBack2.Name = "fraBack2";
			this.fraBack2.Size = new System.Drawing.Size(136, 160);
			this.fraBack2.TabIndex = 5;
			this.fraBack2.TabStop = false;
			this.fraBack2.Text = "Dialogs";
			// 
			// cmdDialogProperties
			// 
			this.cmdDialogProperties.Location = new System.Drawing.Point(24, 88);
			this.cmdDialogProperties.Name = "cmdDialogProperties";
			this.cmdDialogProperties.Size = new System.Drawing.Size(96, 24);
			this.cmdDialogProperties.TabIndex = 5;
			this.cmdDialogProperties.Text = "Properties";
			// 
			// cmdDialogAlarm
			// 
			this.cmdDialogAlarm.Location = new System.Drawing.Point(24, 24);
			this.cmdDialogAlarm.Name = "cmdDialogAlarm";
			this.cmdDialogAlarm.Size = new System.Drawing.Size(96, 24);
			this.cmdDialogAlarm.TabIndex = 3;
			this.cmdDialogAlarm.Text = "Alarm";
			// 
			// cmdDialogProvider
			// 
			this.cmdDialogProvider.Location = new System.Drawing.Point(24, 120);
			this.cmdDialogProvider.Name = "cmdDialogProvider";
			this.cmdDialogProvider.Size = new System.Drawing.Size(96, 24);
			this.cmdDialogProvider.TabIndex = 6;
			this.cmdDialogProvider.Text = "Provider";
			// 
			// cmdDialogCategory
			// 
			this.cmdDialogCategory.Location = new System.Drawing.Point(24, 56);
			this.cmdDialogCategory.Name = "cmdDialogCategory";
			this.cmdDialogCategory.Size = new System.Drawing.Size(96, 24);
			this.cmdDialogCategory.TabIndex = 4;
			this.cmdDialogCategory.Text = "Category";
			// 
			// fraBack1
			// 
			this.fraBack1.Controls.Add(this.cmdPropertyItemConfig);
			this.fraBack1.Controls.Add(this.cmdConfigRoom);
			this.fraBack1.Controls.Add(this.cmdConfigProvider);
			this.fraBack1.Controls.Add(this.cmdConfigCateogry);
			this.fraBack1.Location = new System.Drawing.Point(8, 8);
			this.fraBack1.Name = "fraBack1";
			this.fraBack1.Size = new System.Drawing.Size(136, 152);
			this.fraBack1.TabIndex = 4;
			this.fraBack1.TabStop = false;
			this.fraBack1.Text = "Configuration";
			// 
			// cmdPropertyItemConfig
			// 
			this.cmdPropertyItemConfig.Location = new System.Drawing.Point(24, 120);
			this.cmdPropertyItemConfig.Name = "cmdPropertyItemConfig";
			this.cmdPropertyItemConfig.Size = new System.Drawing.Size(96, 24);
			this.cmdPropertyItemConfig.TabIndex = 3;
			this.cmdPropertyItemConfig.Text = "PropertyItems";
			// 
			// cmdConfigRoom
			// 
			this.cmdConfigRoom.Location = new System.Drawing.Point(24, 88);
			this.cmdConfigRoom.Name = "cmdConfigRoom";
			this.cmdConfigRoom.Size = new System.Drawing.Size(96, 24);
			this.cmdConfigRoom.TabIndex = 2;
			this.cmdConfigRoom.Text = "Rooms";
			// 
			// cmdConfigProvider
			// 
			this.cmdConfigProvider.Location = new System.Drawing.Point(24, 56);
			this.cmdConfigProvider.Name = "cmdConfigProvider";
			this.cmdConfigProvider.Size = new System.Drawing.Size(96, 24);
			this.cmdConfigProvider.TabIndex = 1;
			this.cmdConfigProvider.Text = "Providers";
			// 
			// cmdConfigCateogry
			// 
			this.cmdConfigCateogry.Location = new System.Drawing.Point(24, 24);
			this.cmdConfigCateogry.Name = "cmdConfigCateogry";
			this.cmdConfigCateogry.Size = new System.Drawing.Size(96, 24);
			this.cmdConfigCateogry.TabIndex = 0;
			this.cmdConfigCateogry.Text = "Categories";
			// 
			// fraBack3
			// 
			this.fraBack3.Controls.Add(this.cmdAbout);
			this.fraBack3.Location = new System.Drawing.Point(8, 344);
			this.fraBack3.Name = "fraBack3";
			this.fraBack3.Size = new System.Drawing.Size(136, 56);
			this.fraBack3.TabIndex = 6;
			this.fraBack3.TabStop = false;
			this.fraBack3.Text = "Misc";
			// 
			// cmdAbout
			// 
			this.cmdAbout.Location = new System.Drawing.Point(20, 24);
			this.cmdAbout.Name = "cmdAbout";
			this.cmdAbout.Size = new System.Drawing.Size(96, 24);
			this.cmdAbout.TabIndex = 4;
			this.cmdAbout.Text = "About";
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
			this.schedule1.Location = new System.Drawing.Point(152, 0);
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
			this.schedule1.Size = new System.Drawing.Size(536, 402);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 407);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.fraBack2);
			this.Controls.Add(this.fraBack1);
			this.Controls.Add(this.fraBack3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET Dialogs Example";
			this.fraBack2.ResumeLayout(false);
			this.fraBack1.ResumeLayout(false);
			this.fraBack3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		internal System.Windows.Forms.GroupBox fraBack2;
		internal System.Windows.Forms.Button cmdDialogProperties;
		internal System.Windows.Forms.Button cmdDialogAlarm;
		internal System.Windows.Forms.Button cmdDialogProvider;
		internal System.Windows.Forms.Button cmdDialogCategory;
		internal System.Windows.Forms.GroupBox fraBack1;
		internal System.Windows.Forms.Button cmdConfigRoom;
		internal System.Windows.Forms.Button cmdConfigProvider;
		internal System.Windows.Forms.Button cmdConfigCateogry;
		internal System.Windows.Forms.GroupBox fraBack3;
		internal System.Windows.Forms.Button cmdAbout;
		internal Gravitybox.Controls.Schedule schedule1;
		internal System.Windows.Forms.Button cmdPropertyItemConfig;

		private void cmdConfigCateogry_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowCategoryConfiguration();
		}

		private void cmdConfigProvider_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowProviderConfiguration();
		}

		private void cmdConfigRoom_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowRoomConfiguration();
		}

		private void cmdDialogCategory_Click(object sender, System.EventArgs e)
		{
			if (schedule1.SelectedItem != null)
				schedule1.Dialogs.ShowCategoryDialog(schedule1.SelectedItem);
		
		}

		private void cmdDialogProvider_Click(object sender, System.EventArgs e)
		{
			if (schedule1.SelectedItem != null)
				schedule1.Dialogs.ShowProviderDialog(schedule1.SelectedItem);		
		}

		private void cmdDialogAlarm_Click(object sender, System.EventArgs e)
		{
			if (schedule1.SelectedItem != null)
				schedule1.Dialogs.ShowAlarmDialog(schedule1.SelectedItem);
		
		}

		private void cmdDialogProperties_Click(object sender, System.EventArgs e)
		{
			if (schedule1.SelectedItem != null)
			{
				AppointmentDialogSettings dialogSettings = new AppointmentDialogSettings();
				dialogSettings.AllowRoom = false;
				//dialogSettings.WarningText = "This is a warning!"
				schedule1.Dialogs.ShowPropertyDialog(schedule1.SelectedItem, dialogSettings);
			}
		}

		private void cmdAbout_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowAboutDialog();
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{

			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2003"), DateTime.Parse("1/1/2003"));
			schedule1.ColumnHeader.AutoFit = true;
			schedule1.AllowRemove = false;

			//Add an appointments so that all of the dialogs will work!
			Appointment appointment = schedule1.AppointmentCollection.Add("", schedule1.MinDate, DateTime.Parse("9:00:00 AM"), 120);
			appointment.Subject = "This is my subject!";
			schedule1.SelectedItem = appointment;

		}

		private void cmdPropertyItemConfig_Click(object sender, System.EventArgs e)
		{
			schedule1.Dialogs.ShowPropertyItemConfiguration(schedule1.AppointmentCollection[0].PropertyItemCollection);
		}

		private void schedule1_BeforeAppointmentRemove(object sender, Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs e)
		{
			e.Cancel = true;
		}

	}

}
