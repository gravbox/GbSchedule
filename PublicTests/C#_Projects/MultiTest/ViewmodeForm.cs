using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace MultiTest
{
	public class ViewmodeForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button cmdChange;
		internal System.Windows.Forms.Label lblDescription;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public ViewmodeForm()
		{
			InitializeComponent();
			this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
			this.Load += new System.EventHandler(this.ViewmodeForm_Load);
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
			this.cmdChange = new System.Windows.Forms.Button();
			this.lblDescription = new System.Windows.Forms.Label();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// cmdChange
			// 
			this.cmdChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdChange.Location = new System.Drawing.Point(488, 322);
			this.cmdChange.Name = "cmdChange";
			this.cmdChange.Size = new System.Drawing.Size(96, 24);
			this.cmdChange.TabIndex = 5;
			this.cmdChange.Text = "Change";
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.Location = new System.Drawing.Point(0, 330);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(480, 16);
			this.lblDescription.TabIndex = 4;
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
			this.schedule1.Location = new System.Drawing.Point(0, 0);
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
			this.schedule1.Size = new System.Drawing.Size(592, 312);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 6;
			// 
			// ViewmodeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 349);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.cmdChange);
			this.Controls.Add(this.lblDescription);
			this.Name = "ViewmodeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ViewmodeForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void ViewmodeForm_Load(object sender, System.EventArgs e)
		{

			//Add Providers
			schedule1.ProviderCollection.Add("", "Provider 1");
			schedule1.ProviderCollection.Add("", "Provider 2");

			//Add Rooms
			schedule1.RoomCollection.Add("", "Room 1");
			schedule1.RoomCollection.Add("", "Room 2");

			schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider;
			Appointment a;
			a = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("10:00:00 AM"), 60);
			a.ProviderList.Add(schedule1.ProviderCollection[0]);
			a.Subject = "qweqwe";
			a = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("11:00:00 AM"), 60);
			a.ProviderList.Add(schedule1.ProviderCollection[0]);
			a.Subject = "asdasd";
			a = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("9:00:00 AM"), 60);
			a.ProviderList.Add(schedule1.ProviderCollection[0]);
			a.Subject = "zxczxc";

			schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft;
			ChangeViewmode();

		}

		private void cmdChange_Click(object sender, System.EventArgs e) 
		{
			ChangeViewmode();
		}

		private void ChangeViewmode()
		{

			switch (schedule1.ViewMode)
			{
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft;
					lblDescription.Text = "DayTop/RoomLeft";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft;
					lblDescription.Text = "DayTop/ProviderLeft";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop;
					lblDescription.Text = "DayLeft/TimeTop";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop;
					lblDescription.Text = "DayLeft/RoomTop";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop;
					lblDescription.Text = "DayLeft/ProviderTop";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft;
					lblDescription.Text = "DayRoomTop/TimeLeft";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop;
					lblDescription.Text = "DayRoomLeft/TimeTop";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft;
					lblDescription.Text = "RoomTop/TimeLeft";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft;
					lblDescription.Text = "RoomTop/ProviderLeft";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop;
					lblDescription.Text = "RoomLeft/TimeTop";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop;
					lblDescription.Text = "RoomLeft/ProviderTop";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop;
					lblDescription.Text = "ProviderLeft/TimeTop";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft;
					lblDescription.Text = "ProviderTop/TimeLeft";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month;
					lblDescription.Text = "Month";
					break;
				case Gravitybox.Controls.Schedule.ViewModeConstants.Month:
					schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
					lblDescription.Text = "DayTop/TimeLeft";
					break;
			}

			
		}

	}
}
