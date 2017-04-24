using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataBinding2005
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      this.Load += new EventHandler(Form1_Load);
    }

    private string _connectionString = "data source=localhost;database=Gravitybox;uid=sa;pwd=;";
    private string AccountId = "00000000-0000-0000-0000-000000000000";
    //private ScheduleDataSet As DataSet = Nothing
    private bool _changed = false;

    public string ConnectionString
    {
      get { return _connectionString; }
      set
      {
        _connectionString = value;
        this.DatabaseConnect();
      }
    }

    public bool Changed
    {
      get { return _changed; }
      set
      {
        _changed = value;
        this.Text = "Gravitybox Software";
        if(this.Changed)
          this.Text += "*";
      }
    }

    public void DatabaseConnect()
    {
      this.scheduleDomainController1.ConnectionString = ConnectionString;
      if(schedule1.DataSource != null)
        this.scheduleDomainController1.UpdateData(AccountId, (DataSet)schedule1.DataSource);

      DataSet ds = this.scheduleDomainController1.GetScheduleDataSet(AccountId);
      schedule1.DataSource = ds;
      schedule1.Bind();

      if(schedule1.AppointmentCollection.Count > 0)
        System.Diagnostics.Debug.WriteLine(schedule1.AppointmentCollection[0].PropertyItemCollection.Count);

      if(schedule1.ResourceCollection.Count > 0)
      {
        System.Diagnostics.Debug.WriteLine(schedule1.ResourceCollection[0].PropertyItemCollection.Count);
      }
      else
      {
        schedule1.ResourceCollection.Add("", "Resource 1");
        schedule1.ResourceCollection.Add("", "Resource 2");
      }

      Changed = false;

    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
      schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Normal;
      schedule1.Dock = DockStyle.Fill;
      schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft;
      schedule1.StartTime = new DateTime(2000, 1, 1, 8, 0, 0);
      schedule1.DayLength = 10;
      schedule1.SetMinMaxDate(new DateTime(2005, 1, 1), new DateTime(2005, 1, 31));

      schedule1.DefaultAppointmentAppearance.BackColor = Color.LightBlue;

      //Create a lunch area
      //Gravitybox.Objects.ScheduleArea area = schedule1.ColoredAreaCollection.Add("", Color.LightSalmon, #12:00:00 PM#, 60);
      //area.Appearance.BorderWidth = 0;
      //area.Text = "Lunch";

      this.DatabaseConnect();

    }

    private void menuFileConnection_Click(object sender, System.EventArgs e)
    {
      //Reset connection string 
      //string s = InputBox("Enter the database connection string.", "Connection String", ConnectionString);
      //if(s != "")
      //  this.ConnectionString = s;
    }

    private void menuFileSynchronize_Click(object sender, System.EventArgs e)
    {
      //Synchronize with the database
      this.DatabaseConnect();
    }

    private void menuFileExit_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }

    private void schedule1_DataSourceUpdated(object sender, System.EventArgs e)
    {
      //The schedule has changed so we must remember to synchronize
      Changed = true;
    }

    private void Form2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      //Prompt to save if necessary
      if(this.Changed)
        if(MessageBox.Show("Do you wish to synchronize with the database.", "Synchronize", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          this.DatabaseConnect();
    }

    private void Button1_Click(object sender, System.EventArgs e)
    {
      //MsgBox(schedule1.AppointmentCollection.Count)
      //MsgBox(CType(schedule1.DataSource, Data.DataSet).Tables("Appointment").Rows.Count())
    }

    private void schedule1_AfterAppointmentAdd(object sender, Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs e)
    {
      Gravitybox.Objects.Appointment appt = (Gravitybox.Objects.Appointment)e.BaseObject;
      if(appt.PropertyItemCollection.Count == 0)
        appt.PropertyItemCollection.Add("chris", "", "XXX");

    }

  }
}