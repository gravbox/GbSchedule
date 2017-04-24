namespace Medical
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuView = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewDay = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewWeek = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewMonth = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuViewProvider = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewRoom = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdDay = new System.Windows.Forms.ToolStripButton();
			this.cmdWeek = new System.Windows.Forms.ToolStripButton();
			this.cmdMonth = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdProvider = new System.Windows.Forms.ToolStripButton();
			this.cmdRoom = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblHeader = new System.Windows.Forms.Label();
			this.cmdNext = new System.Windows.Forms.Button();
			this.cmdBack = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.contextMenuAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuSchedule = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuContextScheduleDay = new System.Windows.Forms.ToolStripMenuItem();
			this.menuContextScheduleWeek = new System.Windows.Forms.ToolStripMenuItem();
			this.menuContextScheduleMonth = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.menuContextScheduleProvider = new System.Windows.Forms.ToolStripMenuItem();
			this.menuContextScheduleRoom = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.contextMenuAppointment.SuspendLayout();
			this.contextMenuSchedule.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.menuHelp});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(668, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileExit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(35, 20);
			this.menuFile.Text = "&File";
			// 
			// menuFileExit
			// 
			this.menuFileExit.Name = "menuFileExit";
			this.menuFileExit.Size = new System.Drawing.Size(152, 22);
			this.menuFileExit.Text = "E&xit";
			// 
			// menuView
			// 
			this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewDay,
            this.menuViewWeek,
            this.menuViewMonth,
            this.toolStripMenuItem1,
            this.menuViewProvider,
            this.menuViewRoom});
			this.menuView.Name = "menuView";
			this.menuView.Size = new System.Drawing.Size(41, 20);
			this.menuView.Text = "&View";
			// 
			// menuViewDay
			// 
			this.menuViewDay.Image = ((System.Drawing.Image)(resources.GetObject("menuViewDay.Image")));
			this.menuViewDay.Name = "menuViewDay";
			this.menuViewDay.Size = new System.Drawing.Size(152, 22);
			this.menuViewDay.Text = "Day";
			this.menuViewDay.Click += new System.EventHandler(this.menuViewDay_Click);
			// 
			// menuViewWeek
			// 
			this.menuViewWeek.Image = ((System.Drawing.Image)(resources.GetObject("menuViewWeek.Image")));
			this.menuViewWeek.Name = "menuViewWeek";
			this.menuViewWeek.Size = new System.Drawing.Size(152, 22);
			this.menuViewWeek.Text = "Week";
			this.menuViewWeek.Click += new System.EventHandler(this.menuViewWeek_Click);
			// 
			// menuViewMonth
			// 
			this.menuViewMonth.Image = ((System.Drawing.Image)(resources.GetObject("menuViewMonth.Image")));
			this.menuViewMonth.Name = "menuViewMonth";
			this.menuViewMonth.Size = new System.Drawing.Size(152, 22);
			this.menuViewMonth.Text = "Month";
			this.menuViewMonth.Click += new System.EventHandler(this.menuViewMonth_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// menuViewProvider
			// 
			this.menuViewProvider.Image = ((System.Drawing.Image)(resources.GetObject("menuViewProvider.Image")));
			this.menuViewProvider.Name = "menuViewProvider";
			this.menuViewProvider.Size = new System.Drawing.Size(152, 22);
			this.menuViewProvider.Text = "Provider";
			this.menuViewProvider.Click += new System.EventHandler(this.menuViewProvider_Click);
			// 
			// menuViewRoom
			// 
			this.menuViewRoom.Name = "menuViewRoom";
			this.menuViewRoom.Size = new System.Drawing.Size(152, 22);
			this.menuViewRoom.Text = "Room";
			this.menuViewRoom.Click += new System.EventHandler(this.menuViewRoom_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
			this.menuHelp.Name = "menuHelp";
			this.menuHelp.Size = new System.Drawing.Size(40, 20);
			this.menuHelp.Text = "&Help";
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Name = "menuHelpAbout";
			this.menuHelpAbout.Size = new System.Drawing.Size(152, 22);
			this.menuHelpAbout.Text = "&About";
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Appearance.FontSize = 10F;
			this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.schedule1.Appearance.ItemLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(142)))), ((int)(((byte)(206)))));
			this.schedule1.Appearance.ItemLineWidth = 2;
			this.schedule1.Appearance.Key = "ad24a71f-1d15-485e-867d-4532c229a1be";
			this.schedule1.Appearance.MajorLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
			this.schedule1.Appearance.MajorLineWidth = 1;
			this.schedule1.Appearance.MinorLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(231)))), ((int)(((byte)(247)))));
			this.schedule1.Appearance.MinorLineWidth = 1;
			this.schedule1.Appearance.NoFill = false;
			this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(246)))));
			this.schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(222)))), ((int)(((byte)(239)))));
			this.schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical;
			this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
			this.schedule1.ColumnHeader.Appearance.FontSize = 8F;
			this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.ColumnHeader.Appearance.Key = "c4e3ea6f-bd03-4838-a1c0-0bf066cb8567";
			this.schedule1.ColumnHeader.Appearance.NoFill = false;
			this.schedule1.ColumnHeader.Size = 100;
			this.schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(211)))), ((int)(((byte)(234)))));
			this.schedule1.DefaultAppointmentAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical;
			this.schedule1.DefaultAppointmentAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(140)))), ((int)(((byte)(201)))));
			this.schedule1.DefaultAppointmentAppearance.FontSize = 8F;
			this.schedule1.DefaultAppointmentAppearance.IsRound = true;
			this.schedule1.DefaultAppointmentAppearance.Key = "64500759-b879-435e-8ced-8de0e0313914";
			this.schedule1.DefaultAppointmentAppearance.NoFill = false;
			this.schedule1.DefaultAppointmentAppearance.ShadowSize = 5;
			this.schedule1.DefaultAppointmentHeaderAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(140)))), ((int)(((byte)(201)))));
			this.schedule1.DefaultAppointmentHeaderAppearance.FontBold = true;
			this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentHeaderAppearance.Key = "e9d0372a-cbcd-45ab-a145-722aa96b13ff";
			this.schedule1.DefaultAppointmentHeaderAppearance.NoFill = false;
			this.schedule1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
			this.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced;
			this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.schedule1.EventHeader.Appearance.FontSize = 10F;
			this.schedule1.EventHeader.Appearance.Key = "68ae98ae-53c0-4eec-8191-fbfdce9dd093";
			this.schedule1.EventHeader.Appearance.NoFill = false;
			this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.schedule1.EventHeader.ExpandAppearance.Key = "8ca36909-5230-4cc3-ab72-2445f0fa76fd";
			this.schedule1.EventHeader.ExpandAppearance.NoFill = false;
			this.schedule1.Location = new System.Drawing.Point(0, 96);
			this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
			this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.schedule1.Name = "schedule1";
			this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
			this.schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(187)))), ((int)(((byte)(78)))));
			this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(147)))), ((int)(((byte)(204)))));
			this.schedule1.RowHeader.Appearance.FontSize = 8F;
			this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(147)))), ((int)(((byte)(204)))));
			this.schedule1.RowHeader.Appearance.Key = "4fe16205-44aa-4442-a619-55c0e9815c8c";
			this.schedule1.RowHeader.Appearance.NoFill = false;
			this.schedule1.RowHeader.Size = 30;
			this.schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentAppearance.FontSize = 10F;
			this.schedule1.SelectedAppointmentAppearance.Key = "57e32629-7799-4187-90dc-70a34b938e55";
			this.schedule1.SelectedAppointmentAppearance.NoFill = false;
			this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.SelectedAppointmentHeaderAppearance.Key = "77e8fdd9-80c5-4f96-843c-461228ab1848";
			this.schedule1.SelectedAppointmentHeaderAppearance.NoFill = false;
			this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.schedule1.Selector.Appearance.FontSize = 10F;
			this.schedule1.Selector.Appearance.Key = "147ef456-ad96-4de8-8eb7-3457cad38925";
			this.schedule1.Selector.Appearance.NoFill = false;
			this.schedule1.Size = new System.Drawing.Size(668, 330);
			this.schedule1.StartTime = new System.DateTime(((long)(0)));
			this.schedule1.TabIndex = 2;
			this.schedule1.TimeMarker.Appearance.FontSize = 10F;
			this.schedule1.TimeMarker.Appearance.Key = "04b469fe-b683-43d5-a04f-c2ca9c1fbba8";
			this.schedule1.TimeMarker.Appearance.NoFill = false;
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdDay,
            this.cmdWeek,
            this.cmdMonth,
            this.toolStripSeparator1,
            this.cmdProvider,
            this.cmdRoom});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(668, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// cmdDay
			// 
			this.cmdDay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.cmdDay.Image = ((System.Drawing.Image)(resources.GetObject("cmdDay.Image")));
			this.cmdDay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdDay.Name = "cmdDay";
			this.cmdDay.Size = new System.Drawing.Size(30, 22);
			this.cmdDay.Text = "Day";
			this.cmdDay.Click += new System.EventHandler(this.cmdDay_Click);
			// 
			// cmdWeek
			// 
			this.cmdWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.cmdWeek.Image = ((System.Drawing.Image)(resources.GetObject("cmdWeek.Image")));
			this.cmdWeek.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdWeek.Name = "cmdWeek";
			this.cmdWeek.Size = new System.Drawing.Size(38, 22);
			this.cmdWeek.Text = "Week";
			this.cmdWeek.Click += new System.EventHandler(this.cmdWeek_Click);
			// 
			// cmdMonth
			// 
			this.cmdMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.cmdMonth.Image = ((System.Drawing.Image)(resources.GetObject("cmdMonth.Image")));
			this.cmdMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdMonth.Name = "cmdMonth";
			this.cmdMonth.Size = new System.Drawing.Size(41, 22);
			this.cmdMonth.Text = "Month";
			this.cmdMonth.Click += new System.EventHandler(this.cmdMonth_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// cmdProvider
			// 
			this.cmdProvider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.cmdProvider.Image = ((System.Drawing.Image)(resources.GetObject("cmdProvider.Image")));
			this.cmdProvider.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdProvider.Name = "cmdProvider";
			this.cmdProvider.Size = new System.Drawing.Size(51, 22);
			this.cmdProvider.Text = "Provider";
			this.cmdProvider.Click += new System.EventHandler(this.cmdProvider_Click);
			// 
			// cmdRoom
			// 
			this.cmdRoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.cmdRoom.Image = ((System.Drawing.Image)(resources.GetObject("cmdRoom.Image")));
			this.cmdRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdRoom.Name = "cmdRoom";
			this.cmdRoom.Size = new System.Drawing.Size(38, 22);
			this.cmdRoom.Text = "Room";
			this.cmdRoom.Click += new System.EventHandler(this.cmdRoom_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(226)))), ((int)(((byte)(241)))));
			this.panel2.Controls.Add(this.lblHeader);
			this.panel2.Controls.Add(this.cmdNext);
			this.panel2.Controls.Add(this.cmdBack);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 49);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(668, 47);
			this.panel2.TabIndex = 4;
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHeader.Location = new System.Drawing.Point(64, 8);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(168, 25);
			this.lblHeader.TabIndex = 5;
			this.lblHeader.Text = "05 - 11. January";
			// 
			// cmdNext
			// 
			this.cmdNext.FlatAppearance.BorderSize = 0;
			this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdNext.Image = ((System.Drawing.Image)(resources.GetObject("cmdNext.Image")));
			this.cmdNext.Location = new System.Drawing.Point(36, 8);
			this.cmdNext.Name = "cmdNext";
			this.cmdNext.Size = new System.Drawing.Size(22, 22);
			this.cmdNext.TabIndex = 4;
			this.cmdNext.UseVisualStyleBackColor = true;
			this.cmdNext.Click += new System.EventHandler(this.button3_Click);
			// 
			// cmdBack
			// 
			this.cmdBack.FlatAppearance.BorderSize = 0;
			this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmdBack.Image = ((System.Drawing.Image)(resources.GetObject("cmdBack.Image")));
			this.cmdBack.Location = new System.Drawing.Point(8, 8);
			this.cmdBack.Name = "cmdBack";
			this.cmdBack.Size = new System.Drawing.Size(22, 22);
			this.cmdBack.TabIndex = 3;
			this.cmdBack.UseVisualStyleBackColor = true;
			this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(64, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 25);
			this.label1.TabIndex = 5;
			this.label1.Text = "05 - 11. January";
			// 
			// button3
			// 
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.Location = new System.Drawing.Point(36, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(22, 22);
			this.button3.TabIndex = 4;
			this.button3.UseVisualStyleBackColor = true;
			// 
			// contextMenuAppointment
			// 
			this.contextMenuAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem,
            this.propertiesToolStripMenuItem});
			this.contextMenuAppointment.Name = "contextMenuStrip1";
			this.contextMenuAppointment.Size = new System.Drawing.Size(135, 120);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("propertiesToolStripMenuItem.Image")));
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.propertiesToolStripMenuItem.Text = "Properties";
			// 
			// contextMenuSchedule
			// 
			this.contextMenuSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuContextScheduleDay,
            this.menuContextScheduleWeek,
            this.menuContextScheduleMonth,
            this.toolStripMenuItem6,
            this.menuContextScheduleProvider,
            this.menuContextScheduleRoom});
			this.contextMenuSchedule.Name = "contextMenuSchedule";
			this.contextMenuSchedule.Size = new System.Drawing.Size(153, 142);
			// 
			// menuContextScheduleDay
			// 
			this.menuContextScheduleDay.Image = ((System.Drawing.Image)(resources.GetObject("menuContextScheduleDay.Image")));
			this.menuContextScheduleDay.Name = "menuContextScheduleDay";
			this.menuContextScheduleDay.Size = new System.Drawing.Size(152, 22);
			this.menuContextScheduleDay.Text = "Day";
			this.menuContextScheduleDay.Click += new System.EventHandler(this.menuContextScheduleDay_Click);
			// 
			// menuContextScheduleWeek
			// 
			this.menuContextScheduleWeek.Image = ((System.Drawing.Image)(resources.GetObject("menuContextScheduleWeek.Image")));
			this.menuContextScheduleWeek.Name = "menuContextScheduleWeek";
			this.menuContextScheduleWeek.Size = new System.Drawing.Size(152, 22);
			this.menuContextScheduleWeek.Text = "Week";
			this.menuContextScheduleWeek.Click += new System.EventHandler(this.menuContextScheduleWeek_Click);
			// 
			// menuContextScheduleMonth
			// 
			this.menuContextScheduleMonth.Image = ((System.Drawing.Image)(resources.GetObject("menuContextScheduleMonth.Image")));
			this.menuContextScheduleMonth.Name = "menuContextScheduleMonth";
			this.menuContextScheduleMonth.Size = new System.Drawing.Size(152, 22);
			this.menuContextScheduleMonth.Text = "Month";
			this.menuContextScheduleMonth.Click += new System.EventHandler(this.menuContextScheduleMonth_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(122, 6);
			// 
			// menuContextScheduleProvider
			// 
			this.menuContextScheduleProvider.Image = ((System.Drawing.Image)(resources.GetObject("menuContextScheduleProvider.Image")));
			this.menuContextScheduleProvider.Name = "menuContextScheduleProvider";
			this.menuContextScheduleProvider.Size = new System.Drawing.Size(152, 22);
			this.menuContextScheduleProvider.Text = "Provider";
			this.menuContextScheduleProvider.Click += new System.EventHandler(this.menuContextScheduleProvider_Click);
			// 
			// menuContextScheduleRoom
			// 
			this.menuContextScheduleRoom.Name = "menuContextScheduleRoom";
			this.menuContextScheduleRoom.Size = new System.Drawing.Size(152, 22);
			this.menuContextScheduleRoom.Text = "Room";
			this.menuContextScheduleRoom.Click += new System.EventHandler(this.menuContextScheduleRoom_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 426);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Gravitybox Software";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.contextMenuAppointment.ResumeLayout(false);
			this.contextMenuSchedule.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuFileExit;
		private System.Windows.Forms.ToolStripMenuItem menuView;
		private System.Windows.Forms.ToolStripMenuItem menuViewDay;
		private System.Windows.Forms.ToolStripMenuItem menuViewWeek;
		private System.Windows.Forms.ToolStripMenuItem menuViewMonth;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuViewProvider;
		private System.Windows.Forms.ToolStripMenuItem menuHelp;
		private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
		private Gravitybox.Controls.Schedule schedule1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdDay;
		private System.Windows.Forms.ToolStripButton cmdWeek;
		private System.Windows.Forms.ToolStripButton cmdMonth;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton cmdProvider;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.Button cmdNext;
		private System.Windows.Forms.Button cmdBack;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ToolStripButton cmdRoom;
		private System.Windows.Forms.ContextMenuStrip contextMenuAppointment;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuSchedule;
		private System.Windows.Forms.ToolStripMenuItem menuViewRoom;
		private System.Windows.Forms.ToolStripMenuItem menuContextScheduleDay;
		private System.Windows.Forms.ToolStripMenuItem menuContextScheduleWeek;
		private System.Windows.Forms.ToolStripMenuItem menuContextScheduleMonth;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem menuContextScheduleProvider;
		private System.Windows.Forms.ToolStripMenuItem menuContextScheduleRoom;
	}
}

