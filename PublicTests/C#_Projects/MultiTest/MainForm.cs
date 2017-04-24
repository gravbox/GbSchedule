using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Gravitybox.Objects;

namespace MultiTest
{
	public class MainForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button cmdPrint;
		internal System.Windows.Forms.Button cmdXML;
		internal System.Windows.Forms.Button cmdUserDrawn;
		internal System.Windows.Forms.Button cmdIcons;
		internal System.Windows.Forms.Button cmdViewmode;
		internal System.Windows.Forms.Button cmdColors;
		internal System.Windows.Forms.Button cmdSelector;
		internal System.Windows.Forms.Button cmdAutoSizeRowCol;
		internal System.Windows.Forms.Button cmdAutoSizeCol;
		internal System.Windows.Forms.Button cmdAutoSizeRow;
		internal System.Windows.Forms.Button cmdRecurrence;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			InitializeComponent();
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			this.cmdXML.Click += new System.EventHandler(this.cmdXML_Click);
			this.cmdUserDrawn.Click += new System.EventHandler(this.cmdUserDrawn_Click);
			this.cmdIcons.Click += new System.EventHandler(this.cmdIcons_Click);
			this.cmdViewmode.Click += new System.EventHandler(this.cmdViewmode_Click);
			this.cmdColors.Click += new System.EventHandler(this.cmdColors_Click);
			this.cmdSelector.Click += new System.EventHandler(this.cmdSelector_Click);
			this.cmdAutoSizeRowCol.Click += new System.EventHandler(this.cmdAutoSizeRowCol_Click);
			this.cmdAutoSizeCol.Click += new System.EventHandler(this.cmdAutoSizeCol_Click);
			this.cmdAutoSizeRow.Click += new System.EventHandler(this.cmdAutoSizeRow_Click);
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
			this.cmdPrint = new System.Windows.Forms.Button();
			this.cmdXML = new System.Windows.Forms.Button();
			this.cmdUserDrawn = new System.Windows.Forms.Button();
			this.cmdIcons = new System.Windows.Forms.Button();
			this.cmdViewmode = new System.Windows.Forms.Button();
			this.cmdColors = new System.Windows.Forms.Button();
			this.cmdSelector = new System.Windows.Forms.Button();
			this.cmdAutoSizeRowCol = new System.Windows.Forms.Button();
			this.cmdAutoSizeCol = new System.Windows.Forms.Button();
			this.cmdAutoSizeRow = new System.Windows.Forms.Button();
			this.cmdRecurrence = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdPrint
			// 
			this.cmdPrint.Location = new System.Drawing.Point(9, 298);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Size = new System.Drawing.Size(128, 24);
			this.cmdPrint.TabIndex = 9;
			this.cmdPrint.Text = "Print";
			// 
			// cmdXML
			// 
			this.cmdXML.Location = new System.Drawing.Point(8, 266);
			this.cmdXML.Name = "cmdXML";
			this.cmdXML.Size = new System.Drawing.Size(128, 24);
			this.cmdXML.TabIndex = 8;
			this.cmdXML.Text = "XML";
			// 
			// cmdUserDrawn
			// 
			this.cmdUserDrawn.Location = new System.Drawing.Point(9, 234);
			this.cmdUserDrawn.Name = "cmdUserDrawn";
			this.cmdUserDrawn.Size = new System.Drawing.Size(128, 24);
			this.cmdUserDrawn.TabIndex = 7;
			this.cmdUserDrawn.Text = "User-Drawn";
			// 
			// cmdIcons
			// 
			this.cmdIcons.Location = new System.Drawing.Point(8, 202);
			this.cmdIcons.Name = "cmdIcons";
			this.cmdIcons.Size = new System.Drawing.Size(128, 24);
			this.cmdIcons.TabIndex = 6;
			this.cmdIcons.Text = "Appointment Icons";
			// 
			// cmdViewmode
			// 
			this.cmdViewmode.Location = new System.Drawing.Point(8, 170);
			this.cmdViewmode.Name = "cmdViewmode";
			this.cmdViewmode.Size = new System.Drawing.Size(128, 24);
			this.cmdViewmode.TabIndex = 5;
			this.cmdViewmode.Text = "Viewmode";
			// 
			// cmdColors
			// 
			this.cmdColors.Location = new System.Drawing.Point(8, 138);
			this.cmdColors.Name = "cmdColors";
			this.cmdColors.Size = new System.Drawing.Size(128, 24);
			this.cmdColors.TabIndex = 4;
			this.cmdColors.Text = "Colors";
			// 
			// cmdSelector
			// 
			this.cmdSelector.Location = new System.Drawing.Point(8, 106);
			this.cmdSelector.Name = "cmdSelector";
			this.cmdSelector.Size = new System.Drawing.Size(128, 24);
			this.cmdSelector.TabIndex = 3;
			this.cmdSelector.Text = "Selector";
			// 
			// cmdAutoSizeRowCol
			// 
			this.cmdAutoSizeRowCol.Location = new System.Drawing.Point(8, 74);
			this.cmdAutoSizeRowCol.Name = "cmdAutoSizeRowCol";
			this.cmdAutoSizeRowCol.Size = new System.Drawing.Size(128, 24);
			this.cmdAutoSizeRowCol.TabIndex = 2;
			this.cmdAutoSizeRowCol.Text = "AutoSize Row/Col";
			// 
			// cmdAutoSizeCol
			// 
			this.cmdAutoSizeCol.Location = new System.Drawing.Point(8, 42);
			this.cmdAutoSizeCol.Name = "cmdAutoSizeCol";
			this.cmdAutoSizeCol.Size = new System.Drawing.Size(128, 24);
			this.cmdAutoSizeCol.TabIndex = 1;
			this.cmdAutoSizeCol.Text = "AutoSize Column";
			// 
			// cmdAutoSizeRow
			// 
			this.cmdAutoSizeRow.Location = new System.Drawing.Point(8, 10);
			this.cmdAutoSizeRow.Name = "cmdAutoSizeRow";
			this.cmdAutoSizeRow.Size = new System.Drawing.Size(128, 24);
			this.cmdAutoSizeRow.TabIndex = 0;
			this.cmdAutoSizeRow.Text = "AutoSize Row";
			// 
			// cmdRecurrence
			// 
			this.cmdRecurrence.Location = new System.Drawing.Point(8, 330);
			this.cmdRecurrence.Name = "cmdRecurrence";
			this.cmdRecurrence.Size = new System.Drawing.Size(128, 24);
			this.cmdRecurrence.TabIndex = 10;
			this.cmdRecurrence.Text = "Recurrence";
			this.cmdRecurrence.Click += new System.EventHandler(this.cmdRecurrence_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(144, 359);
			this.Controls.Add(this.cmdRecurrence);
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.cmdXML);
			this.Controls.Add(this.cmdUserDrawn);
			this.Controls.Add(this.cmdIcons);
			this.Controls.Add(this.cmdViewmode);
			this.Controls.Add(this.cmdColors);
			this.Controls.Add(this.cmdSelector);
			this.Controls.Add(this.cmdAutoSizeRowCol);
			this.Controls.Add(this.cmdAutoSizeCol);
			this.Controls.Add(this.cmdAutoSizeRow);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Gravitybox.NET";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void cmdAutoSizeRow_Click(object sender, System.EventArgs e)
		{
			AutoSizeForm F = new AutoSizeForm();
			F.lblDescription.Text = "Resize this screen and notice that the rows stretch to fit the schedule height.";
			F.schedule1.RowHeader.AutoFit = true;
			F.ShowDialog();
		}

		private void cmdAutoSizeCol_Click(object sender, System.EventArgs e)
		{
			AutoSizeForm F = new AutoSizeForm();
			F.lblDescription.Text = "Resize this screen and notice that the columns stretch to fit the schedule width.";
			F.schedule1.ColumnHeader.AutoFit = true;
			F.ShowDialog();
		}

		private void cmdAutoSizeRowCol_Click(object sender, System.EventArgs e)
		{
			AutoSizeForm F = new AutoSizeForm();
			F.lblDescription.Text = "Resize this screen and notice that the rows and columns stretch to fill the schedule.";
			F.schedule1.RowHeader.AutoFit = true;
			F.schedule1.ColumnHeader.AutoFit = true;
			F.ShowDialog();
		}

		private void cmdSelector_Click(object sender, System.EventArgs e)
		{
			SelectorForm F = new SelectorForm();
			F.ShowDialog();
		}

		private void cmdColors_Click(object sender, System.EventArgs e)
		{
			ColorForm F = new ColorForm();
			F.ShowDialog();
		}

		private void cmdViewmode_Click(object sender, System.EventArgs e)
		{
			ViewmodeForm F = new ViewmodeForm();
			F.ShowDialog();
		}

		private void cmdIcons_Click(object sender, System.EventArgs e)
		{
			IconForm F = new IconForm();
			F.ShowDialog();
		}

		private void cmdUserDrawn_Click(object sender, System.EventArgs e)
		{
			UserDrawnForm F = new UserDrawnForm();
			F.ShowDialog();
		}

		private void cmdXML_Click(object sender, System.EventArgs e)
		{
			XMLForm F = new XMLForm();
			F.ShowDialog();
		}

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			PrintForm F = new PrintForm();
			F.ShowDialog();

		}

		private void cmdRecurrence_Click(object sender, System.EventArgs e)
		{
			RecurrenceForm F = new RecurrenceForm();
			F.ShowDialog();
		}

	}
}
