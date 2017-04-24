using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

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
			this.Schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Label1.Location = new System.Drawing.Point(8, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(448, 40);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "This form interfaces with an MS-Access database and saves appointments. It only p" +
				"ersists the appointment\'s key, start date, start time, length, and subject.";
			// 
			// OleDbSelectCommand1
			// 
      this.OleDbSelectCommand1.CommandText = "SELECT appointment_guid, length, start_date, start_time, subject, recurrence_guid FROM Appointment" +
				"";
			this.OleDbSelectCommand1.Connection = this.OleDbConnection1;
			// 
			// OleDbConnection1
			// 
			this.OleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=schedule.mdb";
			// 
			// OleDbInsertCommand1
			// 
      this.OleDbInsertCommand1.CommandText = "INSERT INTO Appointment(appointment_guid, length, start_date, start_time, subject, recurrence_guid" +
				") VALUES (?, ?, ?, ?, ?, ?)";
			this.OleDbInsertCommand1.Connection = this.OleDbConnection1;
			this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, "appointment_guid"));
			this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"));
			this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"));
			this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"));
			this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 100, "subject"));
      this.OleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("recurrence_guid", System.Data.OleDb.OleDbType.VarWChar, 50, "recurrence_guid"));
			// 
			// OleDbDeleteCommand1
			// 
			this.OleDbDeleteCommand1.CommandText = "DELETE FROM Appointment WHERE (appointment_guid = ?)";
			this.OleDbDeleteCommand1.Connection = this.OleDbConnection1;
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "appointment_guid", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "length", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_length1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "length", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_date", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_date", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_time", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_time", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_time1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_time", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_subject", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "subject", System.Data.DataRowVersion.Original, null));
			this.OleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_subject1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "subject", System.Data.DataRowVersion.Original, null));
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
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, "appointment_guid"));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 100, "subject"));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "appointment_guid", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "length", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_length1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "length", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_date", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_date", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_time", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_time", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_start_time1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "start_time", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_subject", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "subject", System.Data.DataRowVersion.Original, null));
			this.OleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_subject1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "subject", System.Data.DataRowVersion.Original, null));
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
			this.Schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.Schedule1.EventHeader.AllowExpand = false;
			this.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.Schedule1.EventHeader.Appearance.FontSize = 10F;
			this.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.Schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.Schedule1.Location = new System.Drawing.Point(0, 40);
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
			this.Schedule1.Size = new System.Drawing.Size(464, 221);
			this.Schedule1.StartTime = new System.DateTime(((long)(0)));
			this.Schedule1.TabIndex = 2;
			this.Schedule1.DataSourceUpdated += new Gravitybox.Objects.RefreshDelegate(this.Schedule1_DataSourceUpdated);
			this.Schedule1.AfterAppointmentAdd += new Gravitybox.Controls.Schedule.AfterAppointmentEventDelegate(this.Schedule1_AfterAppointmentAdd);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 261);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Schedule1);
			this.MinimumSize = new System.Drawing.Size(472, 288);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule.NET";
			this.Load += new System.EventHandler(this.Form1_Load);
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

	}
}
