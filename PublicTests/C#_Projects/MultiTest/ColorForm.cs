using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace MultiTest
{

	public class ColorForm : System.Windows.Forms.Form
	{
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public ColorForm()
		{
			InitializeComponent();
			this.Load += new System.EventHandler(this.ColorForm_Load);
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
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
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
			this.schedule1.DayLength = 16;
			this.schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
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
			this.schedule1.Size = new System.Drawing.Size(624, 445);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 4;
			// 
			// ColorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 445);
			this.Controls.Add(this.schedule1);
			this.Name = "ColorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ColorForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void ColorForm_Load(object sender, System.EventArgs e)
		{

			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/5/2004"));
			schedule1.StartTime = DateTime.Parse("8:00:00 AM");
			schedule1.DayLength = 10;
			Appointment appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("9:00:00 AM"), 120);
			appointment.Subject = "This is a test";

			//Appointment Color
			appointment.Appearance.BackColor = Color.BlanchedAlmond;
			appointment.Appearance.ForeColor = Color.DarkGray;

			//Other Colors
			schedule1.Appearance.BackColor = Color.Yellow;
			schedule1.Appearance.ForeColor = Color.Blue;
			schedule1.BackColor = Color.Green;
			schedule1.EventHeader.Appearance.BackColor = Color.DarkKhaki;
			schedule1.Selector.Appearance.BackColor = Color.DarkRed;

			//RowHeader
			schedule1.RowHeader.Appearance.BackColor = Color.Blue; //Background
			schedule1.RowHeader.Appearance.ForeColor = Color.Yellow; //Text
			schedule1.RowHeader.Appearance.BorderColor = Color.LightGray; //Border

			//ColumnHeader
			schedule1.ColumnHeader.Appearance.BackColor = Color.Yellow; //Background
			schedule1.ColumnHeader.Appearance.ForeColor= Color.Blue; //Text
			schedule1.ColumnHeader.Appearance.BorderColor = Color.DarkGreen; //Border


		}

	}
}
