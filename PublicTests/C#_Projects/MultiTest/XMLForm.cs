using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Gravitybox.Objects;

namespace MultiTest
{
	public class XMLForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button cmdAddMore;
		internal System.Windows.Forms.Button cmdSave;
		internal System.Windows.Forms.Label lblDescription;
		internal System.Windows.Forms.Button cmdLoad;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public XMLForm()
		{
			InitializeComponent();
			this.cmdAddMore.Click += new System.EventHandler(this.cmdAddMore_Click);
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
			this.Load += new System.EventHandler(this.XMLForm_Load);
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
			this.cmdAddMore = new System.Windows.Forms.Button();
			this.cmdSave = new System.Windows.Forms.Button();
			this.lblDescription = new System.Windows.Forms.Label();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// cmdAddMore
			// 
			this.cmdAddMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAddMore.Location = new System.Drawing.Point(392, 408);
			this.cmdAddMore.Name = "cmdAddMore";
			this.cmdAddMore.Size = new System.Drawing.Size(80, 24);
			this.cmdAddMore.TabIndex = 8;
			this.cmdAddMore.Text = "Add More";
			// 
			// cmdSave
			// 
			this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSave.Location = new System.Drawing.Point(480, 408);
			this.cmdSave.Name = "cmdSave";
			this.cmdSave.Size = new System.Drawing.Size(80, 24);
			this.cmdSave.TabIndex = 9;
			this.cmdSave.Text = "Save XML";
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.Location = new System.Drawing.Point(4, 411);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(388, 24);
			this.lblDescription.TabIndex = 12;
			// 
			// cmdLoad
			// 
			this.cmdLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdLoad.Location = new System.Drawing.Point(568, 408);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.Size = new System.Drawing.Size(80, 24);
			this.cmdLoad.TabIndex = 10;
			this.cmdLoad.Text = "Load XML";
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
			this.schedule1.Location = new System.Drawing.Point(-4, 0);
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
			this.schedule1.Size = new System.Drawing.Size(664, 394);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 13;
			// 
			// XMLForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 437);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.cmdAddMore);
			this.Controls.Add(this.cmdSave);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.cmdLoad);
			this.Name = "XMLForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XMLForm";
			this.ResumeLayout(false);

		}
		#endregion

		private const string FILENAME = @"C:\appointments.xml";
		private const int DAYCOUNT = 5;
		private DateTime MINDATE = new DateTime(2004, 1, 1, 0, 0, 0, 0);
		private System.Random rnd = new System.Random();

		private void XMLForm_Load(object sender, System.EventArgs e)
		{

			//Setup the screen
			schedule1.SetMinMaxDate(MINDATE, MINDATE.AddDays(DAYCOUNT - 1));
			schedule1.StartTime = DateTime.Parse("8:00:00 AM");
			schedule1.DayLength = 10;
			schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30;
			schedule1.AppointmentBar.Size = 10;
			lblDescription.Text = "Press the buttons to save and load the appointments to/from an XML file.";

			Recurrence X = new Recurrence();
			string S = X.ToXML();
			X.FromXML(S);
			System.Diagnostics.Debug.WriteLine(S);

			RandomAppointments();

		}

		private void RandomAppointments()
		{

			for (int ii=1;ii<=10;ii++)
			{
				DateTime newDate = schedule1.MinDate.AddDays(RandomInt(DAYCOUNT));
				DateTime newTime = schedule1.StartTime.AddMinutes(RandomInt(480));
				int length = 1 + RandomInt(119);
				schedule1.AppointmentCollection.Add("", newDate, newTime, length);
			}
			schedule1.Refresh();

		}

		private int RandomInt(int max)
		{
			return rnd.Next(max);
		}

		private void cmdLoad_Click(object sender, System.EventArgs e)
		{

			if (System.IO.File.Exists(FILENAME))
			{
				schedule1.AppointmentCollection.Clear();
				schedule1.AppointmentCollection.LoadXML(FILENAME);
				schedule1.Refresh();
			} 
			else 
			{
				MessageBox.Show("There is no appointment file!");
			}

		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{

			if (System.IO.File.Exists(FILENAME))
				System.IO.File.Delete(FILENAME);

			schedule1.AppointmentCollection.SaveXML(FILENAME);	

		}

		private void cmdAddMore_Click(object sender, System.EventArgs e)
		{
			this.RandomAppointments();
		}

	}
}
