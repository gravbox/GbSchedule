using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace MSAccess
{
	public class Form1 : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label Label1;
		internal System.Data.OleDb.OleDbCommand OleDbSelectCommand1;
		internal System.Data.OleDb.OleDbConnection OleDbConnection1;
		internal System.Data.OleDb.OleDbCommand OleDbInsertCommand1;
		internal System.Data.OleDb.OleDbCommand OleDbDeleteCommand1;
		internal System.Data.OleDb.OleDbDataAdapter OleDbDataAdapter1;
    internal System.Data.OleDb.OleDbCommand OleDbUpdateCommand1;
    private Panel panel1;
    private Button button1;
    internal Gravitybox.Controls.Schedule Schedule1;
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
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
      this.Label1 = new System.Windows.Forms.Label();
      this.OleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
      this.OleDbConnection1 = new System.Data.OleDb.OleDbConnection();
      this.OleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
      this.OleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
      this.OleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
      this.OleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
      this.panel1 = new System.Windows.Forms.Panel();
      this.Schedule1 = new Gravitybox.Controls.Schedule();
      this.button1 = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // Label1
      // 
      this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.Label1.Location = new System.Drawing.Point(0, 0);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(600, 40);
      this.Label1.TabIndex = 3;
      this.Label1.Text = "This form interfaces with an MS-Access database and saves appointments. It only p" +
          "ersists the appointment\'s key, start date, start time, length, and subject.";
      // 
      // OleDbSelectCommand1
      // 
      this.OleDbSelectCommand1.CommandText = "SELECT appointment_guid, length, start_date, start_time, subject, recurrence_guid" +
          " FROM Appointment";
      this.OleDbSelectCommand1.Connection = this.OleDbConnection1;
      // 
      // OleDbConnection1
      // 
      this.OleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=schedule.mdb";
      // 
      // OleDbInsertCommand1
      // 
      this.OleDbInsertCommand1.CommandText = "INSERT INTO Appointment(appointment_guid, length, start_date, start_time, subject" +
          ", recurrence_guid) VALUES (?, ?, ?, ?, ?, ?)";
      this.OleDbInsertCommand1.Connection = this.OleDbConnection1;
      this.OleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, "appointment_guid"),
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"),
            new System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"),
            new System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 100, "subject"),
            new System.Data.OleDb.OleDbParameter("recurrence_guid", System.Data.OleDb.OleDbType.VarWChar, 50, "recurrence_guid")});
      // 
      // OleDbDeleteCommand1
      // 
      this.OleDbDeleteCommand1.CommandText = "DELETE FROM Appointment WHERE (appointment_guid = ?)";
      this.OleDbDeleteCommand1.Connection = this.OleDbConnection1;
      this.OleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "appointment_guid", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_length1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_date", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_date", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_time", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_time", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_time1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_time", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_subject", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "subject", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_subject1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "subject", System.Data.DataRowVersion.Original, null)});
      // 
      // OleDbDataAdapter1
      // 
      this.OleDbDataAdapter1.DeleteCommand = this.OleDbDeleteCommand1;
      this.OleDbDataAdapter1.InsertCommand = this.OleDbInsertCommand1;
      this.OleDbDataAdapter1.SelectCommand = this.OleDbSelectCommand1;
      this.OleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Appointment", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("appointment_guid", "appointment_guid"),
                        new System.Data.Common.DataColumnMapping("length", "length"),
                        new System.Data.Common.DataColumnMapping("start_date", "start_date"),
                        new System.Data.Common.DataColumnMapping("start_time", "start_time"),
                        new System.Data.Common.DataColumnMapping("subject", "subject")})});
      this.OleDbDataAdapter1.UpdateCommand = this.OleDbUpdateCommand1;
      // 
      // OleDbUpdateCommand1
      // 
      this.OleDbUpdateCommand1.CommandText = "UPDATE Appointment SET appointment_guid = ?, length = ?, start_date = ?, start_ti" +
          "me = ?, subject = ? WHERE (appointment_guid = ?)";
      this.OleDbUpdateCommand1.Connection = this.OleDbConnection1;
      this.OleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, "appointment_guid"),
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"),
            new System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"),
            new System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 100, "subject"),
            new System.Data.OleDb.OleDbParameter("Original_appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "appointment_guid", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_length1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_date", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_date", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_time", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_time", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_start_time1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start_time", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_subject", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "subject", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_subject1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "subject", System.Data.DataRowVersion.Original, null)});
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 338);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(600, 37);
      this.panel1.TabIndex = 4;
      // 
      // Schedule1
      // 
      this.Schedule1.AllowDrop = true;
      this.Schedule1.Appearance.FontSize = 10F;
      this.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
      this.Schedule1.Appearance.NoFill = false;
      this.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
      this.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.Schedule1.ColumnHeader.Appearance.FontSize = 10F;
      this.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.Schedule1.ColumnHeader.Appearance.NoFill = false;
      this.Schedule1.ColumnHeader.Size = 100;
      this.Schedule1.DefaultAppointmentAppearance.FontSize = 10F;
      this.Schedule1.DefaultAppointmentAppearance.NoFill = false;
      this.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
      this.Schedule1.DefaultAppointmentHeaderAppearance.NoFill = false;
      this.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
      this.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
      this.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.Schedule1.EventHeader.Appearance.FontSize = 10F;
      this.Schedule1.EventHeader.Appearance.NoFill = false;
      this.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
      this.Schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
      this.Schedule1.EventHeader.ExpandAppearance.NoFill = false;
      this.Schedule1.Location = new System.Drawing.Point(0, 40);
      this.Schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
      this.Schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
      this.Schedule1.Name = "Schedule1";
      this.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.Schedule1.RowHeader.Appearance.FontSize = 10F;
      this.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.Schedule1.RowHeader.Appearance.NoFill = false;
      this.Schedule1.RowHeader.Size = 30;
      this.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
      this.Schedule1.SelectedAppointmentAppearance.FontSize = 10F;
      this.Schedule1.SelectedAppointmentAppearance.NoFill = false;
      this.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
      this.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
      this.Schedule1.SelectedAppointmentHeaderAppearance.NoFill = false;
      this.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
      this.Schedule1.Selector.Appearance.FontSize = 10F;
      this.Schedule1.Selector.Appearance.NoFill = false;
      this.Schedule1.Size = new System.Drawing.Size(600, 298);
      this.Schedule1.StartTime = new System.DateTime(((long)(0)));
      this.Schedule1.TabIndex = 5;
      this.Schedule1.TimeMarker.Appearance.FontSize = 10F;
      this.Schedule1.TimeMarker.Appearance.NoFill = false;
      this.Schedule1.DataSourceUpdated += new Gravitybox.Objects.RefreshDelegate(this.Schedule1_DataSourceUpdated);
      this.Schedule1.AfterAppointmentAdd += new Gravitybox.Controls.Schedule.AfterAppointmentEventDelegate(this.Schedule1_AfterAppointmentAdd);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(16, 8);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(600, 375);
      this.Controls.Add(this.Schedule1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.Label1);
      this.MinimumSize = new System.Drawing.Size(472, 288);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Gravitybox Schedule.NET";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		GravityboxDataset MyDataset = null;

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
			//Setup the schedule
			Schedule1.SetMinMaxDate(new DateTime(2004, 1, 1), new DateTime(2004, 1, 5));
			Schedule1.StartTime = new DateTime(2004, 1, 1, 8, 0, 0);
			Schedule1.DayLength = 10;
			Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30;
			Schedule1.ColumnHeader.AutoFit = true;
			Schedule1.EventHeader.AllowHeader = false;
			Schedule1.HeaderDateFormat = "MMM dd";

			//Setup the dataset
			MyDataset = new GravityboxDataset();
			this.OleDbDataAdapter1.Fill(MyDataset, "Appointment");

			Schedule1.DataSource = MyDataset;
			Schedule1.Bind();

		}

		private void Schedule1_AfterAppointmentAdd(object sender, Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs e)
		{
			Gravitybox.Objects.Appointment appointment = (Gravitybox.Objects.Appointment)e.BaseObject;
			appointment.Appearance.IsRound = true;
			appointment.Appearance.BackColor = Color.LightBlue;
			appointment.Appearance.BackColor2 = Color.White;
			appointment.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical;
			appointment.Appearance.Transparency = 40;
		}

		private void Schedule1_DataSourceUpdated(object sender, System.EventArgs e)
		{
			this.OleDbDataAdapter1.Update(MyDataset);
		}

    private void button1_Click(object sender, EventArgs e)
    {
      foreach(Appointment appointment in Schedule1.AppointmentCollection)
      {
        System.Diagnostics.Debug.WriteLine(appointment.StartDate.ToShortDateString());
      }
      System.Diagnostics.Debug.WriteLine("");
      System.Diagnostics.Debug.WriteLine("");
    }

	}
}
