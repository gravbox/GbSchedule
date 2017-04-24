using System;
using System.Collections.Generic;
using System.Text;

namespace TestTest2005
{
  public class AppointmentAppearanceExt : Gravitybox.Objects.AppointmentAppearance
  {
    protected int _linkId = 0;

    public int LinkId
    {
      get { return _linkId; }
      set { _linkId = value; }
    }

  }
}
