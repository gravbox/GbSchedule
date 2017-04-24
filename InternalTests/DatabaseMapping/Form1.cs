using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DatabaseMapping
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private Gravitybox.Controls.Schedule schedule1;
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(296, 40);
			this.panel1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Appearance.FontSize = 10F;
			this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.ColumnHeader.Appearance.FontSize = 10F;
			this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.ColumnHeader.Size = 100;
			this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentAppearance.ShadowSize = 0;
			this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
			this.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
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
			this.schedule1.SelectedAppointmentAppearance.ShadowSize = 0;
			this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.schedule1.Selector.Appearance.FontSize = 10F;
			this.schedule1.Size = new System.Drawing.Size(296, 45);
			this.schedule1.StartTime = new System.DateTime(((long)(0)));
			this.schedule1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 85);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{

//			string connectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" +
//				@"ocking Mode=1;Data Source=""Schedule.mdb"";Jet OLEDB:Engine Type=5;Provider=""Micro" +
//				@"soft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist secur" +
//				@"ity info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Datab" +
//				@"ase=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on " +
//				@"Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet O" +
//				@"LEDB:Global Bulk Transactions=1";

			string connectionString = "data source=(local);database=gravitybox;uid=sa;pwd=;";

			//Command Text
			string cmdText = "select * from a_table;select * from c_table;select * from ac_table;select * from p_table;select * from ap_table;select * from r_table";

			//Connection
			System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
			System.Data.SqlClient.SqlCommand selectCommand = new System.Data.SqlClient.SqlCommand(cmdText);
			System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(selectCommand);

			//Select command
			DataSet ds = new DataSet();
			selectCommand.Connection = connection;
			adapter.Fill(ds);

			//**************************************************
			//Map fields
			//**************************************************

			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Clear();
			schedule1.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Clear();
			schedule1.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Clear();
			schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Clear();
			schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Clear();
			schedule1.DataBindings.RoomBinding.DataFieldBindingCollection.Clear();

			//Appointment
			ds.Tables[0].Columns["the_key"].AllowDBNull = false;
			ds.Tables[0].Columns["the_key"].Unique = true;
			ds.Tables[0].Columns["s_time"].AllowDBNull = false;
			ds.Tables[0].Columns["duration"].AllowDBNull = false;

			schedule1.DataBindings.AppointmentBinding.DataSource = ds.Tables[0];
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("appointment_guid", "the_key");
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("start_date", "s_time");
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("length", "duration");
			schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("subject", "mytext");

			//Category
			ds.Tables[1].Columns["the_key"].AllowDBNull = false;
			ds.Tables[1].Columns["the_key"].Unique = true;
			ds.Tables[1].Columns["mytext"].AllowDBNull = false;
			ds.Tables[1].Columns["mycolor"].AllowDBNull = false;

			schedule1.DataBindings.CategoryBinding.DataSource = ds.Tables[1];
			schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("category_guid", "the_key");
			schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("name", "mytext");
			schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("color", "mycolor");

			//Link table
			ds.Tables[2].Columns["key1"].AllowDBNull = false;
			ds.Tables[2].Columns["key2"].AllowDBNull = false;
			schedule1.DataBindings.AppointmentCategoryBinding.DataSource = ds.Tables[2];
			schedule1.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Add("appointment_guid", "key1");
			schedule1.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Add("category_guid", "key2");

			//Provider
			ds.Tables[3].Columns["the_key"].AllowDBNull = false;
			ds.Tables[3].Columns["the_key"].Unique = true;
			ds.Tables[3].Columns["mytext"].AllowDBNull = false;
			ds.Tables[3].Columns["mycolor"].AllowDBNull = false;

			schedule1.DataBindings.ProviderBinding.DataSource = ds.Tables[3];
			schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("provider_guid", "the_key");
			schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("name", "mytext");
			schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("color", "mycolor");

			//Link table
			ds.Tables[4].Columns["key1"].AllowDBNull = false;
			ds.Tables[4].Columns["key2"].AllowDBNull = false;
			schedule1.DataBindings.AppointmentProviderBinding.DataSource = ds.Tables[4];
			schedule1.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Add("appointment_guid", "key1");
			schedule1.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Add("provider_guid", "key2");

			//Room
			ds.Tables[5].Columns["the_key"].AllowDBNull = false;
			ds.Tables[5].Columns["the_key"].Unique = true;
			ds.Tables[5].Columns["mytext"].AllowDBNull = false;

			schedule1.DataBindings.RoomBinding.DataSource = ds.Tables[5];
			schedule1.DataBindings.RoomBinding.DataFieldBindingCollection.Add("room_guid", "the_key");
			schedule1.DataBindings.RoomBinding.DataFieldBindingCollection.Add("name", "mytext");

//			schedule1.DataBindings.SaveXML(@"c:\myxml.xml");
//			schedule1.DataBindings.LoadXML(@"c:\myxml.xml");

			schedule1.DataSource = ds;
			schedule1.Bind();

			MessageBox.Show("Loaded");
			schedule1.DataSourceUpdated+=new Gravitybox.Objects.RefreshDelegate(schedule1_DataSourceUpdated);

		}

		private void schedule1_DataSourceUpdated(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(DateTime.Now.ToLongTimeString());
		}

	}
}
