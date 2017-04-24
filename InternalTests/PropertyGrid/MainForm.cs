using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace PropertyGrid
{
	public class MainForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button cmdScheduleRecurrence;
		internal System.Windows.Forms.Button cmdScheduleProperties;
		internal System.Windows.Forms.Button cmdHeader;
		internal System.Windows.Forms.Button cmdScheduleBar;
		internal System.Windows.Forms.Button cmdDialogConfiguration;
		internal System.Windows.Forms.Button cmdDialogProvider;
		internal System.Windows.Forms.Button cmdDialogPrint;
		internal System.Windows.Forms.Button cmdDialogCategoryMaster;
		internal System.Windows.Forms.Button cmdDialogCategory;
		internal System.Windows.Forms.Button cmdDialogAppointment;
		internal System.Windows.Forms.Button cmdPropertyItem;
		internal System.Windows.Forms.Button cmdSchedule;
		internal System.Windows.Forms.Button cmdAlarm;
		internal System.Windows.Forms.Button cmdRoom;
		internal System.Windows.Forms.Button cmdProvider;
		internal System.Windows.Forms.Button cmdCategory;
		internal System.Windows.Forms.Button cmdAppointment;
		internal System.Windows.Forms.PropertyGrid PropertyGrid1;
    internal Button cmdMisc;
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			InitializeComponent();
			this.cmdScheduleRecurrence.Click += new System.EventHandler(this.cmdScheduleRecurrence_Click);
			this.cmdScheduleProperties.Click += new System.EventHandler(this.cmdScheduleProperties_Click);
			this.cmdHeader.Click += new System.EventHandler(this.cmdHeader_Click);
			this.cmdScheduleBar.Click += new System.EventHandler(this.cmdScheduleBar_Click);
			this.cmdDialogConfiguration.Click += new System.EventHandler(this.cmdDialogConfiguration_Click);
			this.cmdDialogProvider.Click += new System.EventHandler(this.cmdDialogProvider_Click);
			this.cmdDialogPrint.Click += new System.EventHandler(this.cmdDialogPrint_Click);
			this.cmdDialogCategoryMaster.Click += new System.EventHandler(this.cmdDialogCategoryMaster_Click);
			this.cmdDialogCategory.Click += new System.EventHandler(this.cmdDialogCategory_Click);
			this.cmdDialogAppointment.Click += new System.EventHandler(this.cmdDialogAppointment_Click);
			this.cmdPropertyItem.Click += new System.EventHandler(this.cmdPropertyItem_Click);
			this.cmdSchedule.Click += new System.EventHandler(this.cmdSchedule_Click);
			this.cmdAlarm.Click += new System.EventHandler(this.cmdAlarm_Click);
			this.cmdRoom.Click += new System.EventHandler(this.cmdRoom_Click);
			this.cmdProvider.Click += new System.EventHandler(this.cmdProvider_Click);
			this.cmdCategory.Click += new System.EventHandler(this.cmdCategory_Click);
			this.cmdAppointment.Click += new System.EventHandler(this.cmdAppointment_Click);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.Label4 = new System.Windows.Forms.Label();
      this.Label3 = new System.Windows.Forms.Label();
      this.Label2 = new System.Windows.Forms.Label();
      this.Label1 = new System.Windows.Forms.Label();
      this.cmdScheduleRecurrence = new System.Windows.Forms.Button();
      this.cmdScheduleProperties = new System.Windows.Forms.Button();
      this.cmdHeader = new System.Windows.Forms.Button();
      this.cmdScheduleBar = new System.Windows.Forms.Button();
      this.cmdDialogConfiguration = new System.Windows.Forms.Button();
      this.cmdDialogProvider = new System.Windows.Forms.Button();
      this.cmdDialogPrint = new System.Windows.Forms.Button();
      this.cmdDialogCategoryMaster = new System.Windows.Forms.Button();
      this.cmdDialogCategory = new System.Windows.Forms.Button();
      this.cmdDialogAppointment = new System.Windows.Forms.Button();
      this.cmdPropertyItem = new System.Windows.Forms.Button();
      this.cmdSchedule = new System.Windows.Forms.Button();
      this.cmdAlarm = new System.Windows.Forms.Button();
      this.cmdRoom = new System.Windows.Forms.Button();
      this.cmdProvider = new System.Windows.Forms.Button();
      this.cmdCategory = new System.Windows.Forms.Button();
      this.cmdAppointment = new System.Windows.Forms.Button();
      this.PropertyGrid1 = new System.Windows.Forms.PropertyGrid();
      this.cmdMisc = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // Label4
      // 
      this.Label4.Location = new System.Drawing.Point(7, 9);
      this.Label4.Name = "Label4";
      this.Label4.Size = new System.Drawing.Size(488, 48);
      this.Label4.TabIndex = 46;
      this.Label4.Text = resources.GetString("Label4.Text");
      // 
      // Label3
      // 
      this.Label3.Location = new System.Drawing.Point(303, 377);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(160, 16);
      this.Label3.TabIndex = 45;
      this.Label3.Text = "Dialogs";
      // 
      // Label2
      // 
      this.Label2.Location = new System.Drawing.Point(391, 65);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(104, 16);
      this.Label2.TabIndex = 44;
      this.Label2.Text = "Objects";
      // 
      // Label1
      // 
      this.Label1.Location = new System.Drawing.Point(271, 65);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(104, 16);
      this.Label1.TabIndex = 43;
      this.Label1.Text = "Components";
      // 
      // cmdScheduleRecurrence
      // 
      this.cmdScheduleRecurrence.Location = new System.Drawing.Point(271, 193);
      this.cmdScheduleRecurrence.Name = "cmdScheduleRecurrence";
      this.cmdScheduleRecurrence.Size = new System.Drawing.Size(104, 24);
      this.cmdScheduleRecurrence.TabIndex = 28;
      this.cmdScheduleRecurrence.Text = "Sch Recur";
      // 
      // cmdScheduleProperties
      // 
      this.cmdScheduleProperties.Location = new System.Drawing.Point(271, 161);
      this.cmdScheduleProperties.Name = "cmdScheduleProperties";
      this.cmdScheduleProperties.Size = new System.Drawing.Size(104, 24);
      this.cmdScheduleProperties.TabIndex = 27;
      this.cmdScheduleProperties.Text = "Sch Properties";
      // 
      // cmdHeader
      // 
      this.cmdHeader.Location = new System.Drawing.Point(271, 129);
      this.cmdHeader.Name = "cmdHeader";
      this.cmdHeader.Size = new System.Drawing.Size(104, 24);
      this.cmdHeader.TabIndex = 26;
      this.cmdHeader.Text = "Header";
      // 
      // cmdScheduleBar
      // 
      this.cmdScheduleBar.Location = new System.Drawing.Point(392, 288);
      this.cmdScheduleBar.Name = "cmdScheduleBar";
      this.cmdScheduleBar.Size = new System.Drawing.Size(104, 24);
      this.cmdScheduleBar.TabIndex = 36;
      this.cmdScheduleBar.Text = "Schedule Bar";
      // 
      // cmdDialogConfiguration
      // 
      this.cmdDialogConfiguration.Location = new System.Drawing.Point(303, 569);
      this.cmdDialogConfiguration.Name = "cmdDialogConfiguration";
      this.cmdDialogConfiguration.Size = new System.Drawing.Size(160, 24);
      this.cmdDialogConfiguration.TabIndex = 42;
      this.cmdDialogConfiguration.Text = "Configuration Dialog";
      // 
      // cmdDialogProvider
      // 
      this.cmdDialogProvider.Location = new System.Drawing.Point(303, 537);
      this.cmdDialogProvider.Name = "cmdDialogProvider";
      this.cmdDialogProvider.Size = new System.Drawing.Size(160, 24);
      this.cmdDialogProvider.TabIndex = 41;
      this.cmdDialogProvider.Text = "Provider Dialog";
      // 
      // cmdDialogPrint
      // 
      this.cmdDialogPrint.Location = new System.Drawing.Point(303, 505);
      this.cmdDialogPrint.Name = "cmdDialogPrint";
      this.cmdDialogPrint.Size = new System.Drawing.Size(160, 24);
      this.cmdDialogPrint.TabIndex = 40;
      this.cmdDialogPrint.Text = "Print Dialog";
      // 
      // cmdDialogCategoryMaster
      // 
      this.cmdDialogCategoryMaster.Location = new System.Drawing.Point(303, 473);
      this.cmdDialogCategoryMaster.Name = "cmdDialogCategoryMaster";
      this.cmdDialogCategoryMaster.Size = new System.Drawing.Size(160, 24);
      this.cmdDialogCategoryMaster.TabIndex = 39;
      this.cmdDialogCategoryMaster.Text = "Category Master Dialog";
      // 
      // cmdDialogCategory
      // 
      this.cmdDialogCategory.Location = new System.Drawing.Point(303, 441);
      this.cmdDialogCategory.Name = "cmdDialogCategory";
      this.cmdDialogCategory.Size = new System.Drawing.Size(160, 24);
      this.cmdDialogCategory.TabIndex = 38;
      this.cmdDialogCategory.Text = "Category Dialog";
      // 
      // cmdDialogAppointment
      // 
      this.cmdDialogAppointment.Location = new System.Drawing.Point(303, 409);
      this.cmdDialogAppointment.Name = "cmdDialogAppointment";
      this.cmdDialogAppointment.Size = new System.Drawing.Size(160, 24);
      this.cmdDialogAppointment.TabIndex = 37;
      this.cmdDialogAppointment.Text = "Appointment  Dialog";
      // 
      // cmdPropertyItem
      // 
      this.cmdPropertyItem.Location = new System.Drawing.Point(392, 256);
      this.cmdPropertyItem.Name = "cmdPropertyItem";
      this.cmdPropertyItem.Size = new System.Drawing.Size(104, 24);
      this.cmdPropertyItem.TabIndex = 35;
      this.cmdPropertyItem.Text = "PropertyItem";
      // 
      // cmdSchedule
      // 
      this.cmdSchedule.Location = new System.Drawing.Point(271, 97);
      this.cmdSchedule.Name = "cmdSchedule";
      this.cmdSchedule.Size = new System.Drawing.Size(104, 24);
      this.cmdSchedule.TabIndex = 25;
      this.cmdSchedule.Text = "Schedule";
      // 
      // cmdAlarm
      // 
      this.cmdAlarm.Location = new System.Drawing.Point(391, 225);
      this.cmdAlarm.Name = "cmdAlarm";
      this.cmdAlarm.Size = new System.Drawing.Size(104, 24);
      this.cmdAlarm.TabIndex = 33;
      this.cmdAlarm.Text = "Alarm";
      // 
      // cmdRoom
      // 
      this.cmdRoom.Location = new System.Drawing.Point(391, 193);
      this.cmdRoom.Name = "cmdRoom";
      this.cmdRoom.Size = new System.Drawing.Size(104, 24);
      this.cmdRoom.TabIndex = 32;
      this.cmdRoom.Text = "Room";
      // 
      // cmdProvider
      // 
      this.cmdProvider.Location = new System.Drawing.Point(391, 161);
      this.cmdProvider.Name = "cmdProvider";
      this.cmdProvider.Size = new System.Drawing.Size(104, 24);
      this.cmdProvider.TabIndex = 31;
      this.cmdProvider.Text = "Provider";
      // 
      // cmdCategory
      // 
      this.cmdCategory.Location = new System.Drawing.Point(391, 129);
      this.cmdCategory.Name = "cmdCategory";
      this.cmdCategory.Size = new System.Drawing.Size(104, 24);
      this.cmdCategory.TabIndex = 30;
      this.cmdCategory.Text = "Category";
      // 
      // cmdAppointment
      // 
      this.cmdAppointment.Location = new System.Drawing.Point(391, 97);
      this.cmdAppointment.Name = "cmdAppointment";
      this.cmdAppointment.Size = new System.Drawing.Size(104, 24);
      this.cmdAppointment.TabIndex = 29;
      this.cmdAppointment.Text = "Appointment";
      // 
      // PropertyGrid1
      // 
      this.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
      this.PropertyGrid1.Location = new System.Drawing.Point(7, 65);
      this.PropertyGrid1.Name = "PropertyGrid1";
      this.PropertyGrid1.Size = new System.Drawing.Size(248, 536);
      this.PropertyGrid1.TabIndex = 24;
      // 
      // cmdMisc
      // 
      this.cmdMisc.Location = new System.Drawing.Point(328, 328);
      this.cmdMisc.Name = "cmdMisc";
      this.cmdMisc.Size = new System.Drawing.Size(104, 24);
      this.cmdMisc.TabIndex = 47;
      this.cmdMisc.Text = "Misc";
      this.cmdMisc.Click += new System.EventHandler(this.cmdMisc_Click);
      // 
      // MainForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(502, 611);
      this.Controls.Add(this.cmdMisc);
      this.Controls.Add(this.Label4);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.cmdScheduleRecurrence);
      this.Controls.Add(this.cmdScheduleProperties);
      this.Controls.Add(this.cmdHeader);
      this.Controls.Add(this.cmdScheduleBar);
      this.Controls.Add(this.cmdDialogConfiguration);
      this.Controls.Add(this.cmdDialogProvider);
      this.Controls.Add(this.cmdDialogPrint);
      this.Controls.Add(this.cmdDialogCategoryMaster);
      this.Controls.Add(this.cmdDialogCategory);
      this.Controls.Add(this.cmdDialogAppointment);
      this.Controls.Add(this.cmdPropertyItem);
      this.Controls.Add(this.cmdSchedule);
      this.Controls.Add(this.cmdAlarm);
      this.Controls.Add(this.cmdRoom);
      this.Controls.Add(this.cmdProvider);
      this.Controls.Add(this.cmdCategory);
      this.Controls.Add(this.cmdAppointment);
      this.Controls.Add(this.PropertyGrid1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Gravitybox Schedule.NET PropertyGrid example";
      this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private Gravitybox.Controls.Schedule schedule1 = new Gravitybox.Controls.Schedule();

		private void MainForm_Load(object sender, System.EventArgs e)
		{

			schedule1.CategoryCollection.Add("", "Category 1", Color.Yellow);
			schedule1.ProviderCollection.Add("", "Provider 1", Color.Orange);
			schedule1.RoomCollection.Add("", "Room 1");
			Appointment appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/1/2004"), schedule1.RoomCollection[0], "8:00:00 AM", 60);
			appointment.PropertyItemCollection.Add("", "MyKey", "MySetting");

		}


		private void cmdAppointment_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1.AppointmentCollection[0];
		}

		private void cmdCategory_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1.CategoryCollection[0];
		}

		private void cmdRoom_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1.RoomCollection[0];
		}

		private void cmdProvider_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1.ProviderCollection[0];
		}

		private void cmdAlarm_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1.AppointmentCollection[0].Alarm;
		}

		private void cmdSchedule_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1;
		}

		private void cmdAppointmentCollection_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1.AppointmentCollection;
		}

		private void cmdPropertyItem_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = schedule1.AppointmentCollection[0].PropertyItemCollection[0];
		}

		private void cmdDialogAppointment_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = new AppointmentDialogSettings();
		}

		private void cmdDialogCategory_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = new CategoryDialogSettings();
		}

		private void cmdDialogCategoryMaster_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = (new CategoryDialogSettings()).CategoryMasterDialog;
		}

		private void cmdDialogPrint_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = new PrintDialogSettings(DateTime.Parse("1/1/2004"), DateTime.Parse("8:00:00 AM"), DateTime.Parse("1/1/2004"), DateTime.Parse("12:00:00 PM"));
		}

		private void cmdDialogProvider_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = new ProviderDialogSettings();
		}

		private void cmdDialogConfiguration_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = new ConfigurationDialogSettings();
		}

		private void cmdScheduleBar_Click(object sender, System.EventArgs e) 
		{
			PropertyGrid1.SelectedObject = schedule1.AppointmentBar;
		}

		private void cmdHeader_Click(object sender, System.EventArgs e) 
		{
			PropertyGrid1.SelectedObject = new Gravitybox.Controls.Header();
		}

		private void cmdScheduleProperties_Click(object sender, System.EventArgs e) 
		{
			PropertyGrid1.SelectedObject = new Gravitybox.Controls.AppointmentProperties();
		}

		private void cmdScheduleRecurrence_Click(object sender, System.EventArgs e)
		{
			PropertyGrid1.SelectedObject = new Gravitybox.Controls.AppointmentRecurrence();

		}

    private void cmdMisc_Click(object sender, EventArgs e)
    {
      PropertyGrid1.SelectedObject = new Gravitybox.Objects.AlarmDialogSettings();
    }

	}
}
