namespace TestTest2005
{
  partial class ViewmodeForm
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
      this.cmdViewmode = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblText = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // schedule1
      // 
      this.schedule1.AllowDrop = true;
      this.schedule1.Appearance.FontSize = 10F;
      this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
      this.schedule1.Appearance.Key = "cf961cc4-3180-430c-84fe-4c34be6e4568";
      this.schedule1.Appearance.NoFill = false;
      this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
      this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.schedule1.ColumnHeader.Appearance.FontSize = 10F;
      this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.schedule1.ColumnHeader.Appearance.Key = "6885c78c-eefa-41f2-aeff-af4f590fe0f3";
      this.schedule1.ColumnHeader.Appearance.NoFill = false;
      this.schedule1.ColumnHeader.Size = 100;
      this.schedule1.DefaultAppointmentAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical;
      this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
      this.schedule1.DefaultAppointmentAppearance.HatchStyle = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal;
      this.schedule1.DefaultAppointmentAppearance.IsRound = true;
      this.schedule1.DefaultAppointmentAppearance.Key = "a1601adf-34a1-4ee8-8540-b5b83d17a6a9";
      this.schedule1.DefaultAppointmentAppearance.NoFill = false;
      this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
      this.schedule1.DefaultAppointmentHeaderAppearance.Key = "a60316dd-4454-4282-979a-30ac3b62c18a";
      this.schedule1.DefaultAppointmentHeaderAppearance.NoFill = false;
      this.schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
      this.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
      this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.schedule1.EventHeader.Appearance.FontSize = 10F;
      this.schedule1.EventHeader.Appearance.Key = "abd9a79c-14a7-4719-a06a-b9a041416fa7";
      this.schedule1.EventHeader.Appearance.NoFill = false;
      this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
      this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
      this.schedule1.EventHeader.ExpandAppearance.Key = "cf45339b-1c90-4883-9725-d02db075e974";
      this.schedule1.EventHeader.ExpandAppearance.NoFill = false;
      this.schedule1.Location = new System.Drawing.Point(0, 0);
      this.schedule1.MaxDate = new System.DateTime(2006, 1, 31, 0, 0, 0, 0);
      this.schedule1.MinDate = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
      this.schedule1.MultiSelect = true;
      this.schedule1.Name = "schedule1";
      this.schedule1.RoomCollection.Add(new Gravitybox.Objects.Room("641a81ab-cb52-49b2-a685-140f6f287bba", "Room1", ""));
      this.schedule1.RoomCollection.Add(new Gravitybox.Objects.Room("55b77b4a-b03c-4343-a02c-36367b0d015f", "Room2", ""));
      this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
      this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
      this.schedule1.RowHeader.Appearance.FontSize = 10F;
      this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
      this.schedule1.RowHeader.Appearance.Key = "39f52ccf-ebba-4370-92b2-ba1e41debea5";
      this.schedule1.RowHeader.Appearance.NoFill = false;
      this.schedule1.RowHeader.Size = 30;
      this.schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
      this.schedule1.SelectedAppointmentAppearance.FontSize = 10F;
      this.schedule1.SelectedAppointmentAppearance.Key = "34af8169-aa58-4d88-9b24-8db4cbbfc162";
      this.schedule1.SelectedAppointmentAppearance.NoFill = false;
      this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
      this.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
      this.schedule1.SelectedAppointmentHeaderAppearance.Key = "dd8e4336-256b-4c80-aa56-03dbb7af9f59";
      this.schedule1.SelectedAppointmentHeaderAppearance.NoFill = false;
      this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
      this.schedule1.Selector.Appearance.FontSize = 10F;
      this.schedule1.Selector.Appearance.Key = "f6fc7ec2-bbdb-42d2-9ed5-eea98b6e7440";
      this.schedule1.Selector.Appearance.NoFill = false;
      this.schedule1.Size = new System.Drawing.Size(600, 338);
      this.schedule1.StartTime = new System.DateTime(((long)(0)));
      this.schedule1.TabIndex = 5;
      this.schedule1.TimeMarker.Appearance.FontSize = 10F;
      this.schedule1.TimeMarker.Appearance.Key = "b870d00f-eba2-48ed-95fb-ca49ebfa977c";
      this.schedule1.TimeMarker.Appearance.NoFill = false;
      // 
      // cmdViewmode
      // 
      this.cmdViewmode.Location = new System.Drawing.Point(8, 8);
      this.cmdViewmode.Name = "cmdViewmode";
      this.cmdViewmode.Size = new System.Drawing.Size(75, 23);
      this.cmdViewmode.TabIndex = 0;
      this.cmdViewmode.Text = "Viewmode";
      this.cmdViewmode.UseVisualStyleBackColor = true;
      this.cmdViewmode.Click += new System.EventHandler(this.cmdViewmode_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblText);
      this.panel1.Controls.Add(this.cmdViewmode);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 338);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(600, 42);
      this.panel1.TabIndex = 4;
      // 
      // lblText
      // 
      this.lblText.AutoSize = true;
      this.lblText.Location = new System.Drawing.Point(88, 16);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(41, 13);
      this.lblText.TabIndex = 1;
      this.lblText.Text = "[TEXT]";
      // 
      // ViewmodeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(600, 380);
      this.Controls.Add(this.schedule1);
      this.Controls.Add(this.panel1);
      this.Name = "ViewmodeForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Gravitybox Scehdule";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Gravitybox.Controls.Schedule schedule1;
    private System.Windows.Forms.Button cmdViewmode;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblText;
  }
}