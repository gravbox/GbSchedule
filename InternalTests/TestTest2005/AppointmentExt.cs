using System;
using System.Collections.Generic;
using System.Text;

namespace TestTest2005
{
  public class AppointmentExt : Gravitybox.Objects.Appointment
  {
    internal AppointmentExt(Gravitybox.Controls.Schedule mainObject)
      : base(mainObject)
    {
    }

    protected int _personId = 0;
    public int PersonId
    {
      get { return _personId; }
      set { _personId = value; }
    }
  }
}
