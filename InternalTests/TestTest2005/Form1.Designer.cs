namespace TestTest2005
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
      if (disposing && (components != null))
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cboFDW = new System.Windows.Forms.ComboBox();
      this.schedule1 = new Gravitybox.Controls.Schedule();
      this.button2 = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button2);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.cboFDW);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 280);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(642, 56);
      this.panel1.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(144, 24);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "First day of week";
      // 
      // cboFDW
      // 
      this.cboFDW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboFDW.FormattingEnabled = true;
      this.cboFDW.Location = new System.Drawing.Point(8, 24);
      this.cboFDW.Name = "cboFDW";
      this.cboFDW.Size = new System.Drawing.Size(120, 21);
      this.cboFDW.TabIndex = 0;
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
      this.schedule1.Size = new System.Drawing.Size(642, 280);
      this.schedule1.StartTime = new System.DateTime(((long)(0)));
      this.schedule1.TabIndex = 1;
      this.schedule1.TimeMarker.Appearance.FontSize = 10F;
      this.schedule1.TimeMarker.Appearance.NoFill = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(400, 24);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(642, 336);
      this.Controls.Add(this.schedule1);
      this.Controls.Add(this.panel1);
      this.KeyPreview = true;
      this.Name = "Form1";
      this.Text = "Form1";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cboFDW;
    private Gravitybox.Controls.Schedule schedule1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;


  }
}

