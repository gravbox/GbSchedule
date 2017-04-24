using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestTest2005
{
  public partial class ViewmodeForm : Form
  {
    public ViewmodeForm()
    {
      InitializeComponent();

      schedule1.ProviderCollection.Add("", "Provider 1");
      schedule1.ProviderCollection.Add("", "Provider 2");
      schedule1.ProviderCollection.Add("", "Provider 3");

      schedule1.RoomCollection.Add("", "Room 1");
      schedule1.RoomCollection.Add("", "Room 2");
      schedule1.RoomCollection.Add("", "Room 3");

      schedule1.ResourceCollection.Add("", "Resource 1");
      schedule1.ResourceCollection.Add("", "Resource 2");
      schedule1.ResourceCollection.Add("", "Resource 3");

    }

    private void cmdViewmode_Click(object sender, EventArgs e)
    {
      List<string> valueList = new List<string>(Enum.GetNames(typeof(Gravitybox.Controls.Schedule.ViewModeConstants)));
      int index = valueList.IndexOf(schedule1.ViewMode.ToString());
      if(index < valueList.Count - 1)
        index++;
      else
        index = 0;
      Gravitybox.Controls.Schedule.ViewModeConstants value = (Gravitybox.Controls.Schedule.ViewModeConstants)Enum.Parse(typeof(Gravitybox.Controls.Schedule.ViewModeConstants), valueList[index]);
      schedule1.ViewMode = value;

      lblText.Text = index.ToString() + ") " + schedule1.ViewMode.ToString();

    }

  }
}