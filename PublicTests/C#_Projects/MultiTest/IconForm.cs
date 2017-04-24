using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Gravitybox.Objects;

namespace MultiTest
{
	public class IconForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblDescription;
		internal System.Windows.Forms.Button cmdAdd;
		internal System.Windows.Forms.ImageList ImageList1;
		internal Gravitybox.Controls.Schedule schedule1;
		private System.ComponentModel.IContainer components;

		public IconForm()
		{
			InitializeComponent();
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			this.Load += new System.EventHandler(this.IconForm_Load);
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(IconForm));
			this.lblDescription = new System.Windows.Forms.Label();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
			this.schedule1 = new Gravitybox.Controls.Schedule();
			this.SuspendLayout();
			// 
			// lblDescription
			// 
			this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription.Location = new System.Drawing.Point(8, 386);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(440, 24);
			this.lblDescription.TabIndex = 5;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAdd.Location = new System.Drawing.Point(456, 386);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(128, 24);
			this.cmdAdd.TabIndex = 4;
			this.cmdAdd.Text = "Add Appointment";
			// 
			// ImageList1
			// 
			this.ImageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
			this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// schedule1
			// 
			this.schedule1.AllowDrop = true;
			this.schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.schedule1.Appearance.FontSize = 10F;
			this.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray;
			this.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center;
			this.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control;
			this.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark;
			this.schedule1.ColumnHeader.Appearance.FontSize = 10F;
			this.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
			this.schedule1.ColumnHeader.Size = 100;
			this.schedule1.Cursor = System.Windows.Forms.Cursors.Default;
			this.schedule1.DataSource = null;
			this.schedule1.DayLength = 16;
			this.schedule1.DefaultAppointmentAppearance.FontSize = 10F;
			this.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.EventHeader.AllowExpand = false;
			this.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.schedule1.EventHeader.Appearance.FontSize = 10F;
			this.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow;
			this.schedule1.EventHeader.ExpandAppearance.FontSize = 10F;
			this.schedule1.Location = new System.Drawing.Point(0, 0);
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
			this.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3;
			this.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10F;
			this.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight;
			this.schedule1.Selector.Appearance.FontSize = 10F;
			this.schedule1.Size = new System.Drawing.Size(584, 376);
			this.schedule1.StartTime = new System.DateTime(1, 1, 1, 8, 0, 0, 0);
			this.schedule1.TabIndex = 6;
			// 
			// IconForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(584, 413);
			this.Controls.Add(this.schedule1);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.lblDescription);
			this.Name = "IconForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IconForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{

			//Add an appointment
			Appointment appointment;
			schedule1.AppointmentCollection.Clear();
			appointment = schedule1.AppointmentCollection.Add("", DateTime.Parse("1/2/2004"), "9:00:00 AM", 120);
			appointment.Subject = "This is a test";

			//Add images from the ImageList to the appointment
			appointment.IconCollection.Add("", ImageList1.Images[0]);
			appointment.IconCollection.Add("", ImageList1.Images[1]);

			schedule1.Refresh();

		}

		private void IconForm_Load(object sender, System.EventArgs e)
		{
			schedule1.SetMinMaxDate(DateTime.Parse("1/1/2004"), DateTime.Parse("1/10/2004"));
			schedule1.StartTime = DateTime.Parse("8:00:00 AM");
			schedule1.DayLength = 10;
			lblDescription.Text = "Press the 'Add' button to add an appointment with 2 icons.";

		}

	}
}
