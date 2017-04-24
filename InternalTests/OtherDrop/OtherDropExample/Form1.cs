using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OtherDropExample
{
	public class Form1 : System.Windows.Forms.Form
	{
		private Gravitybox.Controls.Schedule schedule1;
		private System.Windows.Forms.ListBox listBox1;
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
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
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
			this.schedule1.EndTime = new System.DateTime(1, 1, 2, 0, 0, 0, 0);
			this.schedule1.EventHeader.AllowExpand = false;
			this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.schedule1.EventHeader.Appearance.FontSize = 10F;
			this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.schedule1.Location = new System.Drawing.Point(144, 0);
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
			this.schedule1.Size = new System.Drawing.Size(272, 160);
			this.schedule1.StartTime = new System.DateTime(((long)(0)));
			this.schedule1.TabIndex = 0;
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(144, 160);
			this.listBox1.TabIndex = 1;
			this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 165);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.schedule1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			listBox1.DoDragDrop("Hello", DragDropEffects.Move);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			listBox1.Items.Add("Item 1");
			listBox1.Items.Add("Item 2");
			listBox1.Items.Add("Item 3");
			listBox1.Items.Add("Item 4");
			listBox1.Items.Add("Item 5");
			listBox1.Items.Add("Item 6");
		}

	}
}
