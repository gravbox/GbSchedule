Option Strict On
Option Explicit On 

Module Globals

  Public Function GetDate(ByVal inputDate As Date) As Date
    'This function will ensure that the Date has no round-off error
    Return DateSerial(inputDate.Year, inputDate.Month, inputDate.Day)
  End Function

End Module
