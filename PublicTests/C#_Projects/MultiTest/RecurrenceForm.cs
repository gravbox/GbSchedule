using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MultiTest
{
	public class RecurrenceForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button cmdAdd;
		internal System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Panel panel1;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public RecurrenceForm()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RecurrenceForm));
			this.cmdAdd = new System.Windows.Forms.Button();
			this.lblDescription = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAdd.Location = new System.Drawing.Point(504, 8);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(128, 24);
			this.cmdAdd.TabIndex = 7;
			this.cmdAdd.Text = "Add Recurrence";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.Location = new System.Drawing.Point(0, 8);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(488, 24);
			this.lblDescription.TabIndex = 8;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblDescription);
			this.panel1.Controls.Add(this.cmdAdd);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 317);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(640, 40);
			this.panel1.TabIndex = 10;
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
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
			this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentAppearance.NoFill = false;
			this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentHeaderAppearance.NoFill = false;
			this.schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
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
			this.schedule1.Size = new System.Drawing.Size(640, 317);
			this.schedule1.StartTime = new System.DateTime(((long)(0)));
			this.schedule1.TabIndex = 0;
			// 
			// RecurrenceForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 357);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(472, 272);
			this.Name = "RecurrenceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recurrence";
			this.Load += new System.EventHandler(this.RecurrenceForm_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void RecurrenceForm_Load(object sender, System.EventArgs e)
		{
			lblDescription.Text = "By pressing the button you will add a recurrence pattern for this appointment every 2 days for 8 occurrences.";

			DateTime minDate = new DateTime(2006, 1, 1);
			schedule1.SetMinMaxDate(minDate, minDate .AddDays(20));
			schedule1.StartTime = new DateTime(2000, 1, 1, 8, 0, 0);
			schedule1.DayLength = 10;

			Gravitybox.Objects.Appointment appointment = schedule1.AppointmentCollection.Add("", minDate, schedule1.StartTime, 120);
			appointment.Subject = "This is a test";

		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			if (schedule1.AppointmentCollection.Count == 0)
				return;

			Gravitybox.Objects.Appointment appointment = schedule1.AppointmentCollection[0];
			Gravitybox.Objects.Recurrence recurrence = new Gravitybox.Objects.Recurrence();

			//Setup recurrence object for every other day (every 2 days) for 8 occurrences
			recurrence.StartDate = appointment.StartDate;
			recurrence.EndIterations = 8;
			recurrence.EndType = Gravitybox.Objects.RecurrenceEndConstants.EndByInterval;
			recurrence.RecurrenceInterval = Gravitybox.Objects.RecurrenceIntervalConstants.Daily;

			recurrence.RecurrenceDay.DayInterval = 2;
			recurrence.RecurrenceDay.RecurrenceMode = Gravitybox.Objects.RecurrenceDayConstants.DayInterval;

			schedule1.AppointmentCollection.AddRecurrence(appointment, recurrence);

		}

	}
}
