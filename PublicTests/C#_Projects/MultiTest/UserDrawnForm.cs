using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace MultiTest
{
	public class UserDrawnForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblDescription;
		internal System.Windows.Forms.Button cmdAdd;
		private Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public UserDrawnForm()
		{
			InitializeComponent();
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.schedule1.UserDrawnAppointmentBar += new Gravitybox.Controls.Schedule.AppointmentUserDrawEventDelegate(this.schedule1_UserDrawnAppointmentBar);
			this.Load += new System.EventHandler(this.UserDrawnForm_Load);
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
			this.cmdAdd = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.Location = new System.Drawing.Point(8, 416);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(512, 24);
			this.lblDescription.TabIndex = 6;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAdd.Location = new System.Drawing.Point(528, 416);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(128, 24);
			this.cmdAdd.TabIndex = 5;
			this.cmdAdd.Text = "Add Appointment";
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
			this.schedule1.Size = new System.Drawing.Size(656, 400);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 8;
			// 
			// UserDrawnForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 445);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.cmdAdd);
			this.Name = "UserDrawnForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UserDrawnForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{

			//Add an appointment
			Appointment appointment;
			schedule1.AppointmentCollection.Clear();
			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("9:00:00 AM"), 90);
			appointment.Subject = "This is a test";

			//Add providers to the appointment
			appointment.ProviderList.Add(schedule1.ProviderCollection[0]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[1]);
			appointment.ProviderList.Add(schedule1.ProviderCollection[2]);

			//Redraw the schedule
			schedule1.Refresh();

		}

		private void UserDrawnForm_Load(object sender, System.EventArgs e)
		{

			//Setup the screen
			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/10/2004"));
			schedule1.StartTime = DateTime.Parse("8:00:00 AM");
			schedule1.DayLength = 10;
			schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30;
			schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn;
			schedule1.AppointmentBar.Size = 10;
			lblDescription.Text = "Press the 'Add' button to add an appointment with a user-drawn provider bar.";

			//Add some Providers to the schedule
			//The appointment is 90 minutes and the scehdule increment is 30 minutes
			//This divides equally to 3 providers one foreach (30 minute period
			schedule1.ProviderCollection.Add("", "Provider1", Color.Blue);
			schedule1.ProviderCollection.Add("", "Provider2", Color.Yellow);
			schedule1.ProviderCollection.Add("", "Provider3", Color.Green);

		}

		private void schedule1_UserDrawnAppointmentBar(object sender, Gravitybox.Objects.EventArgs.AppointmentUserDrawEventArgs e)
		{

			int top = e.rectangle.Top; //start at the rectangle's top

			//*** NOTE **********************************************
			//The rectangle defined in this event's "e" parameter object
			//is the bounding rectangle of the bar that is to be user drawn.
			//You mayof course draw outside of this region but you WILL 
			//overwrite other graphics and this maynot look good.
			//It is best practice to draw inside of the bounding rectangle.
			//*******************************************************

			//Loop through all of the providers for the appointment
			//Assume that each provider serves one TimeIncrement (30 minutes)
			//so draw the provider color bar for an entire row
			foreach (Provider provider in e.Appointment.ProviderList)
			{

				int left = e.rectangle.Left; //the left side of the rectange
				int width = e.rectangle.Width; //the width of the rectangle
				int height = schedule1.RowHeader.Size; //the height of an entire row

				//Fill a rectangle for this provider at this TimeIncrement
				e.graphics.FillRectangle(new SolidBrush(provider.Color), new System.Drawing.Rectangle(left, top, width, height));

				//Move down one row foreach (provider
				top += schedule1.RowHeader.Size;

			}
			
		}

	}
}
