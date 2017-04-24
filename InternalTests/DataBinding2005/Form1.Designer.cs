namespace DataBinding2005
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
      this.components = new System.ComponentModel.Container();
      this.schedule1 = new Gravitybox.Controls.Schedule();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.qQQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileConnection = new System.Windows.Forms.ToolStripMenuItem();
      this.menuFileSynchronize = new System.Windows.Forms.ToolStripMenuItem();
      this.scheduleDomainController1 = new Gravitybox.Controls.ScheduleDomainController();
      this.contextMenuStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
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
      this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
      this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
      this.schedule1.Name = "schedule1";
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
      this.schedule1.Size = new System.Drawing.Size(546, 322);
      this.schedule1.StartTime = new System.DateTime(((long)(0)));
      this.schedule1.TabIndex = 0;
      this.schedule1.TimeMarker.Appearance.FontSize = 10F;
      this.schedule1.TimeMarker.Appearance.NoFill = false;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qQQToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(110, 26);
      // 
      // qQQToolStripMenuItem
      // 
      this.qQQToolStripMenuItem.Name = "qQQToolStripMenuItem";
      this.qQQToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
      this.qQQToolStripMenuItem.Text = "QQQ";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(546, 24);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // menuFile
      // 
      this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileConnection,
            this.menuFileSynchronize});
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new System.Drawing.Size(35, 20);
      this.menuFile.Text = "&File";
      // 
      // menuFileConnection
      // 
      this.menuFileConnection.Name = "menuFileConnection";
      this.menuFileConnection.Size = new System.Drawing.Size(152, 22);
      this.menuFileConnection.Text = "&Connect";
      this.menuFileConnection.Click += new System.EventHandler(this.menuFileConnection_Click);
      // 
      // menuFileSynchronize
      // 
      this.menuFileSynchronize.Name = "menuFileSynchronize";
      this.menuFileSynchronize.Size = new System.Drawing.Size(152, 22);
      this.menuFileSynchronize.Text = "&Synchronize";
      this.menuFileSynchronize.Click += new System.EventHandler(this.menuFileSynchronize_Click);
      // 
      // scheduleDomainController1
      // 
      this.scheduleDomainController1.ConnectionString = "";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(546, 322);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.schedule1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Form1";
      this.contextMenuStrip1.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Gravitybox.Controls.Schedule schedule1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem qQQToolStripMenuItem;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem menuFile;
    private System.Windows.Forms.ToolStripMenuItem menuFileConnection;
    private System.Windows.Forms.ToolStripMenuItem menuFileSynchronize;
    private Gravitybox.Controls.ScheduleDomainController scheduleDomainController1;

  }
}

