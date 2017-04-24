using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace MultiTest
{
	public class SelectorForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblDescription;
		internal System.Windows.Forms.Button cmdSetSelector;
		internal System.Windows.Forms.Button cmdAllowSelector;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public SelectorForm()
		{
			InitializeComponent();
			this.cmdSetSelector.Click += new System.EventHandler(this.cmdSetSelector_Click);
			this.cmdSetSelector.MouseEnter += new System.EventHandler(this.cmdSetSelector_MouseEnter);
			this.cmdSetSelector.MouseLeave += new System.EventHandler(this.cmdSetSelector_MouseLeave);
			this.cmdAllowSelector.Click += new System.EventHandler(this.cmdAllowSelector_Click);
			this.cmdAllowSelector.MouseEnter += new System.EventHandler(this.cmdAllowSelector_MouseEnter);
			this.cmdAllowSelector.MouseLeave += new System.EventHandler(this.cmdAllowSelector_MouseLeave);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.lblDescription = new System.Windows.Forms.Label();
			this.cmdSetSelector = new System.Windows.Forms.Button();
			this.cmdAllowSelector = new System.Windows.Forms.Button();
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDescription.Location = new System.Drawing.Point(4, 426);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(384, 24);
			this.lblDescription.TabIndex = 8;
			// 
			// cmdSetSelector
			// 
			this.cmdSetSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSetSelector.Location = new System.Drawing.Point(500, 426);
			this.cmdSetSelector.Name = "cmdSetSelector";
			this.cmdSetSelector.Size = new System.Drawing.Size(96, 24);
			this.cmdSetSelector.TabIndex = 7;
			this.cmdSetSelector.Text = "Set Selector";
			// 
			// cmdAllowSelector
			// 
			this.cmdAllowSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAllowSelector.Location = new System.Drawing.Point(396, 426);
			this.cmdAllowSelector.Name = "cmdAllowSelector";
			this.cmdAllowSelector.Size = new System.Drawing.Size(96, 24);
			this.cmdAllowSelector.TabIndex = 6;
			this.cmdAllowSelector.Text = "Allow Selector";
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.schedule1.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.schedule1.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.ColumnHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.ColumnHeader.FrameIncrement = 0;
			this.schedule1.ColumnHeader.Size = 100;
			this.schedule1.DayLength = 16;
			this.schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Location = new System.Drawing.Point(4, 0);
			this.schedule1.MaxDate = new System.DateTime(2004, 1, 10, 0, 0, 0, 0);
			this.schedule1.MinDate = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
			this.schedule1.Name = "schedule1";
			this.schedule1.RowHeader.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.RowHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.RowHeader.FrameIncrement = 0;
			this.schedule1.RowHeader.Size = 30;
			this.schedule1.SelectedAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.SelectedAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.SelectedAppointmentAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.SelectedAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Selector.Appearance.Alignment = System.Drawing.StringAlignment.Near;
			this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.schedule1.Selector.Appearance.BackColor2 = System.Drawing.Color.Wheat;
			this.schedule1.Selector.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox;
			this.schedule1.Selector.Column = 0;
			this.schedule1.Selector.Length = 1;
			this.schedule1.Selector.Row = 0;
			this.schedule1.Size = new System.Drawing.Size(592, 416);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 9;
			// 
			// SelectorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(600, 453);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.cmdSetSelector);
			this.Controls.Add(this.cmdAllowSelector);
			this.Name = "SelectorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SelectorForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdAllowSelector_Click(object sender, System.EventArgs e)
		{
			//Toggle the selector block on/off
			schedule1.AllowSelector = !schedule1.AllowSelector;
		}

		private void cmdSetSelector_Click(object sender, System.EventArgs e)
		{

			//Turn off drawing then set the selector posistion 
			//and size and then turn on drawing
			schedule1.AutoRedraw = false;
			schedule1.Selector.Column = 1;
			schedule1.Selector.Row = 1;
			schedule1.Selector.Length = 3;
			schedule1.AutoRedraw = true;

		}

		private void cmdAllowSelector_MouseEnter(object sender, System.EventArgs e)
		{
			lblDescription.Text = "This button will toggle the selector on/off.";
		}

		private void cmdAllowSelector_MouseLeave(object sender, System.EventArgs e)
		{
			lblDescription.Text = "";
		}

		private void cmdSetSelector_MouseEnter(object sender, System.EventArgs e)
		{
			lblDescription.Text = "This button will set the seletor to a specific place on the schedule.";
		}

		private void cmdSetSelector_MouseLeave(object sender, System.EventArgs e)
		{
			lblDescription.Text = "";			

		}

	}
}
