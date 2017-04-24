using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace MultiTest
{
	public class AutoSizeForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblDescription;
		internal System.Windows.Forms.MonthCalendar MonthCalendar1;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public AutoSizeForm()
		{			
			InitializeComponent();
			this.MonthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateChanged);
			this.Load += new System.EventHandler(this.AutoSizeForm_Load);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.lblDescription = new System.Windows.Forms.Label();
			this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(0, 159);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(192, 208);
			this.lblDescription.TabIndex = 5;
			this.lblDescription.Text = "XXX";
			// 
			// MonthCalendar1
			// 
			this.MonthCalendar1.Location = new System.Drawing.Point(0, -1);
			this.MonthCalendar1.Name = "MonthCalendar1";
			this.MonthCalendar1.TabIndex = 4;
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
			this.schedule1.Location = new System.Drawing.Point(192, 0);
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
			this.schedule1.Size = new System.Drawing.Size(424, 422);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 6;
			// 
			// AutoSizeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 421);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.MonthCalendar1);
			this.Name = "AutoSizeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AutoSizeForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void AutoSizeForm_Load(object sender, System.EventArgs e)
		{

			//Setup the contorols
			schedule1.StartTime = DateTime.Parse("8:00:00 AM");
				schedule1.DayLength = 9;
			schedule1.HeaderDateFormat = "ddd M/d";
			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;

			//Reset the display date
			ReloadWeek(DateTime.Now);

		}

		private void MonthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{

			//Reset the display date
			ReloadWeek(e.Start);

		}

		private void ReloadWeek(DateTime newDate)
		{

			//This will display the work week that contains the specified date
			int dayIndex = int.Parse(newDate.DayOfWeek.ToString("d"));
			DateTime weekStart = newDate.AddDays(-dayIndex + 1);
			DateTime weekEnd = weekStart.AddDays(4);
			schedule1.SetMinMaxDate(weekStart, weekEnd);
			MonthCalendar1.SetSelectionRange(weekStart, weekEnd);

			//Add code to load appointments here
			//TODO
		}

	}
}
