namespace Outlook2007
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
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
      this.schedule1.Appearance.FontSize = 10F;
      this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
      this.schedule1.Appearance.Key = "f578533a-a743-4320-9ed7-c003c197f620";
      this.schedule1.Appearance.NoFill = false;
      this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
      this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.schedule1.ColumnHeader.Appearance.FontSize = 10F;
      this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.schedule1.ColumnHeader.Appearance.Key = "ce50b1bf-611b-4303-9b0e-328ce5b63d25";
      this.schedule1.ColumnHeader.Appearance.NoFill = false;
      this.schedule1.ColumnHeader.Size = 100;
      this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
      this.schedule1.DefaultAppointmentAppearance.Key = "e0a032d4-30a0-45bd-90d2-3f2afb380b44";
      this.schedule1.DefaultAppointmentAppearance.NoFill = false;
      this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
      this.schedule1.DefaultAppointmentHeaderAppearance.Key = "da4b7711-69b3-46e3-8595-cf73235fddf5";
      this.schedule1.DefaultAppointmentHeaderAppearance.NoFill = false;
      this.schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
      this.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
      this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.schedule1.EventHeader.Appearance.FontSize = 10F;
      this.schedule1.EventHeader.Appearance.Key = "6fb94898-dc05-420c-a43c-e85f86e7caec";
      this.schedule1.EventHeader.Appearance.NoFill = false;
      this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
      this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
      this.schedule1.EventHeader.ExpandAppearance.Key = "f925c914-0504-4ed9-84b8-ece923efbc92";
      this.schedule1.EventHeader.ExpandAppearance.NoFill = false;
      this.schedule1.Location = new System.Drawing.Point(72, 88);
      this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
      this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
      this.schedule1.Name = "schedule1";
      this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.schedule1.RowHeader.Appearance.FontSize = 10F;
      this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.schedule1.RowHeader.Appearance.Key = "53a66d2e-26aa-4795-9c35-7b41b5bb8284";
      this.schedule1.RowHeader.Appearance.NoFill = false;
      this.schedule1.RowHeader.Size = 30;
      this.schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
      this.schedule1.SelectedAppointmentAppearance.FontSize = 10F;
      this.schedule1.SelectedAppointmentAppearance.Key = "dda11dbe-fdf4-4c2c-8ae2-75dd0864c3f2";
      this.schedule1.SelectedAppointmentAppearance.NoFill = false;
      this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
      this.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
      this.schedule1.SelectedAppointmentHeaderAppearance.Key = "f3c3be96-ff89-49a8-90ac-2bd773857012";
      this.schedule1.SelectedAppointmentHeaderAppearance.NoFill = false;
      this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
      this.schedule1.Selector.Appearance.FontSize = 10F;
      this.schedule1.Selector.Appearance.Key = "55302c7b-f477-422a-aa51-2a027dd55060";
      this.schedule1.Selector.Appearance.NoFill = false;
      this.schedule1.Size = new System.Drawing.Size(416, 232);
      this.schedule1.StartTime = new System.DateTime(((long)(0)));
      this.schedule1.TabIndex = 0;
      this.schedule1.TimeMarker.Appearance.FontSize = 10F;
      this.schedule1.TimeMarker.Appearance.Key = "2d89b724-2f8e-4d58-8f18-462dcdeea322";
      this.schedule1.TimeMarker.Appearance.NoFill = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(562, 368);
      this.Controls.Add(this.schedule1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private Gravitybox.Controls.Schedule schedule1;
  }
}

