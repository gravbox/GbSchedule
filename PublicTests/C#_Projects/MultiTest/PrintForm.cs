using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace MultiTest
{
	public class PrintForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button cmdPreview;
		internal System.Windows.Forms.Button cmdPrint;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public PrintForm()
		{
			InitializeComponent();
			this.cmdPreview.Click += new System.EventHandler(this.cmdPreview_Click);
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.Load += new System.EventHandler(this.PrintForm_Load);
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
			this.cmdPreview = new System.Windows.Forms.Button();
			this.cmdPrint = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// cmdPreview
			// 
			this.cmdPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdPreview.Location = new System.Drawing.Point(416, 386);
			this.cmdPreview.Name = "cmdPreview";
			this.cmdPreview.Size = new System.Drawing.Size(80, 24);
			this.cmdPreview.TabIndex = 5;
			this.cmdPreview.Text = "Preview";
			// 
			// cmdPrint
			// 
			this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdPrint.Location = new System.Drawing.Point(504, 386);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Size = new System.Drawing.Size(80, 24);
			this.cmdPrint.TabIndex = 4;
			this.cmdPrint.Text = "Print";
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.schedule1.Appearance.FontSize = 10F;
			this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.schedule1.ColumnHeader.AllowResize = false;
			this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.ColumnHeader.Appearance.FontSize = 10F;
			this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.Cursor = System.Windows.Forms.Cursors.Default;
			this.schedule1.DataSource = null;
			this.schedule1.DayLength = 16;
			this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.EventHeader.AllowExpand = false;
			this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.schedule1.EventHeader.Appearance.FontSize = 10F;
			this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.schedule1.Location = new System.Drawing.Point(0, 0);
			this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
			this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.schedule1.Name = "schedule1";
			this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.RowHeader.Appearance.FontSize = 10F;
			this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.RowHeader.Size = 30;
			this.schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentAppearance.FontSize = 10F;
			this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.schedule1.Selector.Appearance.FontSize = 10F;
			this.schedule1.Size = new System.Drawing.Size(584, 376);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 6;
			// 
			// PrintForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 413);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.cmdPreview);
			this.Name = "PrintForm";
			this.Text = "PrintForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void PrintForm_Load(object sender, System.EventArgs e)
		{

			//Setup schedule
			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/5/2004"));
			schedule1.StartTime = DateTime.Parse("8:00:00 AM");
				schedule1.DayLength = 10;
			schedule1.EventHeader.AllowHeader = false;
			schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category;

			//Add Categories
			schedule1.CategoryCollection.Add("", "Category 1", Color.Blue);
			schedule1.CategoryCollection.Add("", "Category 2", Color.Yellow);
			schedule1.CategoryCollection.Add("", "Category 3", Color.LightGreen);

			//Add appointments
			Appointment appointment = null;

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), DateTime.Parse("9:00:00 AM"), 60);
			appointment.Subject = "Suzy Smith";
			appointment.CategoryList.Add(schedule1.CategoryCollection[2]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), DateTime.Parse("11:00:00 AM"), 60);
			appointment.Subject = "Walter Cline";
			appointment.CategoryList.Add(schedule1.CategoryCollection[1]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/3/2004"), DateTime.Parse("9:30:00 AM"), 60);
			appointment.Subject = "Jeff Newton";
			appointment.CategoryList.Add(schedule1.CategoryCollection[2]);

			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/5/2004"), DateTime.Parse("1:30:00 PM"), 60);
			appointment.Subject = "Tom Jones";
			appointment.CategoryList.Add(schedule1.CategoryCollection[0]);

		}

		private void cmdPreview_Click(object sender, System.EventArgs e)
		{

			//Preview the defined schedule area
			PrintDialogSettings dialogSettings = new PrintDialogSettings(DateTime.Parse("1/2/2004"), DateTime.Parse("9:00:00 AM"), DateTime.Parse("1/4/2004"), DateTime.Parse("4:00:00 PM"));
			schedule1.GoPreview(dialogSettings);

		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{

			//Print a portion of the schedule
			PrintDialogSettings dialogSettings = new PrintDialogSettings(DateTime.Parse("1/2/2004"), DateTime.Parse("9:00:00 AM"), DateTime.Parse("1/4/2004"), DateTime.Parse("4:00:00 PM"));
			schedule1.GoPrint();
		}

	}
}
