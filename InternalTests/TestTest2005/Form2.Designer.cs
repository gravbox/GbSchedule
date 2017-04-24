namespace TestTest2005
{
  partial class Form2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(639, 47);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(68, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "05 - 11. January";
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(40, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(22, 22);
			this.button2.TabIndex = 1;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(22, 22);
			this.button1.TabIndex = 0;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Appearance.BorderWidth = 0;
			this.schedule1.Appearance.FontSize = 10F;
			this.schedule1.Appearance.ItemLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(140)))), ((int)(((byte)(201)))));
			this.schedule1.Appearance.ItemLineWidth = 2;
			this.schedule1.Appearance.Key = "ff4d24af-e865-4898-ad2d-2662671476fa";
			this.schedule1.Appearance.MajorLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(225)))));
			this.schedule1.Appearance.MajorLineWidth = 1;
			this.schedule1.Appearance.MinorLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(247)))));
			this.schedule1.Appearance.MinorLineWidth = 1;
			this.schedule1.Appearance.NoFill = false;
			this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(246)))));
			this.schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(222)))), ((int)(((byte)(239)))));
			this.schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical;
			this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
			this.schedule1.ColumnHeader.Appearance.FontSize = 8F;
			this.schedule1.ColumnHeader.Appearance.Key = "476d0355-08fb-41ec-8f29-e61c75405b85";
			this.schedule1.ColumnHeader.Appearance.NoFill = false;
			this.schedule1.ColumnHeader.Size = 100;
			this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
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
			this.schedule1.Location = new System.Drawing.Point(0, 47);
			this.schedule1.MaxDate = new System.DateTime(2006, 1, 31, 0, 0, 0, 0);
			this.schedule1.MinDate = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.schedule1.MultiSelect = true;
			this.schedule1.Name = "schedule1";
			this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
			this.schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(187)))), ((int)(((byte)(78)))));
			this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(147)))), ((int)(((byte)(204)))));
			this.schedule1.RowHeader.Appearance.FontSize = 8F;
			this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(147)))), ((int)(((byte)(204)))));
			this.schedule1.RowHeader.Appearance.Key = "2435803b-f690-4385-93a1-b4f129c0087f";
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
			this.schedule1.Size = new System.Drawing.Size(639, 379);
			this.schedule1.StartTime = new System.DateTime(((long)(0)));
			this.schedule1.TabIndex = 3;
			this.schedule1.TimeMarker.Appearance.FontSize = 10F;
			this.schedule1.TimeMarker.Appearance.Key = "b870d00f-eba2-48ed-95fb-ca49ebfa977c";
			this.schedule1.TimeMarker.Appearance.NoFill = false;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 426);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.panel1);
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Schedule";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

    }

    #endregion

		private Gravitybox.Controls.Schedule schedule1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;

  }
}