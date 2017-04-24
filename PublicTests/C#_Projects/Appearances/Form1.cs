using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Appearances
{
	public class Form1 : System.Windows.Forms.Form
	{
		#region Form Header

		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button cmdSelectedAppointment;
		internal System.Windows.Forms.Button cmdArea;
		internal System.Windows.Forms.ToolTip ToolTip1;
		internal System.Windows.Forms.Button cmdSelector;
		internal System.Windows.Forms.Button cmdAppointment;
		internal System.Windows.Forms.Button cmdSchedule;
		internal System.Windows.Forms.Button cmdRowHeader;
		internal System.Windows.Forms.Button cmdColumnHeader;
		internal Gravitybox.Controls.Schedule Schedule1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			this.Label1 = new System.Windows.Forms.Label();
			this.cmdSelectedAppointment = new System.Windows.Forms.Button();
			this.cmdArea = new System.Windows.Forms.Button();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cmdSelector = new System.Windows.Forms.Button();
			this.cmdAppointment = new System.Windows.Forms.Button();
			this.cmdSchedule = new System.Windows.Forms.Button();
			this.cmdRowHeader = new System.Windows.Forms.Button();
			this.cmdColumnHeader = new System.Windows.Forms.Button();
			this.Schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.Location = new System.Drawing.Point(7, 385);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(376, 16);
			this.Label1.TabIndex = 17;
			this.Label1.Text = "Press each button to apply a custom appearance to each object.";
			// 
			// cmdSelectedAppointment
			// 
			this.cmdSelectedAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdSelectedAppointment.Location = new System.Drawing.Point(343, 409);
			this.cmdSelectedAppointment.Name = "cmdSelectedAppointment";
			this.cmdSelectedAppointment.Size = new System.Drawing.Size(104, 24);
			this.cmdSelectedAppointment.TabIndex = 16;
			this.cmdSelectedAppointment.Text = "Selected";
			this.ToolTip1.SetToolTip(this.cmdSelectedAppointment, "Create a custom appearance for selected appointments. Click on appointments to hi" +
				"ghlight them.");
			// 
			// cmdArea
			// 
			this.cmdArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdArea.Location = new System.Drawing.Point(231, 443);
			this.cmdArea.Name = "cmdArea";
			this.cmdArea.Size = new System.Drawing.Size(104, 24);
			this.cmdArea.TabIndex = 15;
			this.cmdArea.Text = "Area";
			this.ToolTip1.SetToolTip(this.cmdArea, "Create a highlighted area on the schedule with a custom appearance.");
			// 
			// cmdSelector
			// 
			this.cmdSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdSelector.Location = new System.Drawing.Point(231, 409);
			this.cmdSelector.Name = "cmdSelector";
			this.cmdSelector.Size = new System.Drawing.Size(104, 24);
			this.cmdSelector.TabIndex = 14;
			this.cmdSelector.Text = "Selector";
			this.ToolTip1.SetToolTip(this.cmdSelector, "Apply a colorful look to the area selector. Click the mouse on the schedule to mo" +
				"ve the selector.");
			// 
			// cmdAppointment
			// 
			this.cmdAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdAppointment.Location = new System.Drawing.Point(119, 441);
			this.cmdAppointment.Name = "cmdAppointment";
			this.cmdAppointment.Size = new System.Drawing.Size(104, 24);
			this.cmdAppointment.TabIndex = 13;
			this.cmdAppointment.Text = "Appointment";
			this.ToolTip1.SetToolTip(this.cmdAppointment, "Apply a custom look to all appointments.");
			// 
			// cmdSchedule
			// 
			this.cmdSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdSchedule.Location = new System.Drawing.Point(119, 409);
			this.cmdSchedule.Name = "cmdSchedule";
			this.cmdSchedule.Size = new System.Drawing.Size(104, 24);
			this.cmdSchedule.TabIndex = 12;
			this.cmdSchedule.Text = "Schedule";
			this.ToolTip1.SetToolTip(this.cmdSchedule, "Apply a gradient look to the schedule background.");
			// 
			// cmdRowHeader
			// 
			this.cmdRowHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdRowHeader.Location = new System.Drawing.Point(7, 441);
			this.cmdRowHeader.Name = "cmdRowHeader";
			this.cmdRowHeader.Size = new System.Drawing.Size(104, 24);
			this.cmdRowHeader.TabIndex = 11;
			this.cmdRowHeader.Text = "Row Header";
			this.ToolTip1.SetToolTip(this.cmdRowHeader, "Apply a gradient look to the row header.");
			// 
			// cmdColumnHeader
			// 
			this.cmdColumnHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdColumnHeader.Location = new System.Drawing.Point(7, 409);
			this.cmdColumnHeader.Name = "cmdColumnHeader";
			this.cmdColumnHeader.Size = new System.Drawing.Size(104, 24);
			this.cmdColumnHeader.TabIndex = 10;
			this.cmdColumnHeader.Text = "Column Header";
			this.ToolTip1.SetToolTip(this.cmdColumnHeader, "Apply a gradient look to the column header.");
			// 
			// Schedule1
			// 
			this.Schedule1.AllowDrop = true;
			this.Schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Schedule1.Appearance.FontSize = 10F;
			this.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.Schedule1.ColumnHeader.Appearance.FontSize = 10F;
			this.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Schedule1.ColumnHeader.Size = 100;
			this.Schedule1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.Schedule1.EventHeader.AllowExpand = false;
			this.Schedule1.EventHeader.Appearance.FontSize = 10F;
			this.Schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.Schedule1.Location = new System.Drawing.Point(-1, 1);
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
			this.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
			this.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.Schedule1.Selector.Appearance.FontSize = 10F;
			this.Schedule1.Size = new System.Drawing.Size(778, 376);
			this.Schedule1.StartTime = new System.DateTime(((long)(0)));
			this.Schedule1.TabIndex = 9;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 469);
			this.Controls.Add(this.cmdSelectedAppointment);
			this.Controls.Add(this.cmdArea);
			this.Controls.Add(this.cmdSelector);
			this.Controls.Add(this.cmdAppointment);
			this.Controls.Add(this.cmdSchedule);
			this.Controls.Add(this.cmdRowHeader);
			this.Controls.Add(this.cmdColumnHeader);
			this.Controls.Add(this.Schedule1);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			//Hook Events
			cmdAppointment.Click +=new EventHandler(cmdAppointment_Click);
			cmdArea.Click+=new EventHandler(cmdArea_Click);
			cmdColumnHeader.Click+=new EventHandler(cmdColumnHeader_Click);
			cmdRowHeader.Click+=new EventHandler(cmdRowHeader_Click);
			cmdSchedule.Click+=new EventHandler(cmdSchedule_Click);
			cmdSelector.Click+=new EventHandler(cmdSelector_Click);
			cmdSelectedAppointment.Click+=new EventHandler(cmdSelectedAppointment_Click);

			//Setup schedule
			Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
			Schedule1.SetMinMaxDate(DateTime.Now, DateTime.Now.AddDays(3));
			Schedule1.ColumnHeader.AutoFit = true;
			Schedule1.StartTime = new DateTime(2004, 1, 1, 8, 0, 0);
			Schedule1.DayLength = 10;

			//Add appointment
			Gravitybox.Objects.Appointment appointment;
			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Now.AddDays(1), new DateTime(2004, 1, 1, 9, 0, 0), 150);
			appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Subject = "This is a test for you to see. I also have a tooltip.";
			appointment.ToolTipText = "Just tooltip text.";

			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Now.AddDays(2), new DateTime(2004, 1, 1, 9, 30, 0), 150);
			appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Subject = "Some more text";
			appointment.ToolTipText = "Tooltip 2.";

			appointment = Schedule1.AppointmentCollection.Add("", DateTime.Now.AddDays(3), new DateTime(2004, 1, 1, 10, 0, 0), 150);
			appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader;
			appointment.Subject = "Yet again more text!";
			appointment.ToolTipText = "Tooltip 3.";

		}

		private void cmdAppointment_Click(object sender, EventArgs e)
		{

			if (Schedule1.AppointmentCollection.Count == 0)
				return;

			Schedule1.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.None;
			foreach (Gravitybox.Objects.Appointment appointment in Schedule1.AppointmentCollection)
			{
				appointment.Appearance.IsRound = true;
				appointment.Appearance.BackColor = Color.White;
				appointment.Appearance.BackColor2 = Color.LightSkyBlue;
				appointment.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal;
				appointment.Appearance.Transparency = 35;
				appointment.Appearance.TextVAlign = StringAlignment.Center;

				appointment.Header.Appearance.BackColor = Color.White;
				appointment.Header.Appearance.BackColor2 = Color.Aqua;
				appointment.Header.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal;
				appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.Text;
				appointment.Header.Text = "This is a very long header text!";
				appointment.Header.Appearance.TextTrimming = StringTrimming.EllipsisCharacter;
				appointment.Header.Appearance.TextVAlign = StringAlignment.Center;
			}

			Schedule1.Refresh();

		}

		private void cmdArea_Click(object sender, EventArgs e)
		{

			Schedule1.ColoredAreaCollection.Clear();
			Gravitybox.Objects.ScheduleArea area = Schedule1.ColoredAreaCollection.Add("", Color.LightPink, DateTime.Now, new DateTime(2004, 1, 1, 9, 0, 0), 90);
			area.Appearance.BorderWidth = 0;
			area.Appearance.BackColor2 = Color.Red;
			area.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal;

			Schedule1.Refresh();

		}

		private void cmdColumnHeader_Click(object sender, EventArgs e)
		{

			Schedule1.ColumnHeader.Appearance.BackColor = Color.Aqua;
			Schedule1.ColumnHeader.Appearance.BackColor2 = Color.White;
			Schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical;

		}

		private void cmdRowHeader_Click(object sender, EventArgs e)
		{

			Schedule1.RowHeader.Appearance.BackColor = Color.Aqua;
			Schedule1.RowHeader.Appearance.BackColor2 = Color.White;
			Schedule1.RowHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal;

		}

		private void cmdSchedule_Click(object sender, EventArgs e)
		{

			Schedule1.Appearance.BackColor = Color.White;
			Schedule1.Appearance.BackColor2 = Color.Aqua;
			Schedule1.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal;

		}

		private void cmdSelectedAppointment_Click(object sender, EventArgs e)
		{

			Schedule1.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance;

			Schedule1.SelectedAppointmentAppearance.BackColor = Color.White;
			Schedule1.SelectedAppointmentAppearance.BackColor2 = Color.LightGreen;
			Schedule1.SelectedAppointmentAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal;
			Schedule1.SelectedAppointmentAppearance.IsRound = true;

			Schedule1.SelectedAppointmentHeaderAppearance.BackColor = Color.White;
			Schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = Color.LightGreen;
			Schedule1.SelectedAppointmentHeaderAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal;

		}

		private void cmdSelector_Click(object sender, EventArgs e)
		{

			Schedule1.Selector.Appearance.BackColor = Color.Blue;
			Schedule1.Selector.Appearance.BackColor2 = Color.Yellow;
			Schedule1.Selector.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical;

		}

	}

}