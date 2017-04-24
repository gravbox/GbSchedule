#Region "Copyright (c) 1998-2007 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2007 All Rights reserved              *
'                                                                      *
'                                                                      *
'This file and its contents are protected by United States and         *
'International copyright laws.  Unauthorized reproduction and/or       *
'distribution of all or any portion of the code contained herein       *
'is strictly prohibited and will result in severe civil and criminal   *
'penalties.  Any violations of this copyright will be prosecuted       *
'to the fullest extent possible under law.                             *
'                                                                      *
'THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF Gravitybox LLC    *
'                                                                      *
'UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY GRAVITYBOX PRODUCT.      *
'                                                                      *
'THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF GRAVITYBOX,        *
'INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
'INSURE ITS CONFIDENTIALITY.                                           *
'                                                                      *
'THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'SOURCE CODE CONTAINED HEREIN.                                         *
'                                                                      *
'THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'--------------------------------------------------------------------- *
#End Region

Option Strict On
Option Explicit On 

Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap
Imports Gravitybox.Objects

Module ScheduleGlobals

#Region "Class Members"

  Friend Enum DateCompareConstants As Integer
    dcdDefault = 0
    dcdFirstDateGreater = 1
    dcdFirstDateGreaterOrEqual = 2
  End Enum

  Public Const DefaultDateFormat As String = "ddd MMM, dd"
  Public Const DefaultClockSetting12Hour As String = "h:mm tt"
  Public Const DefaultClockSetting24Hour As String = "HH:mm"
  Public Const DefaultNoDate As DateTime = #1/3/0001#
  Public Const DefaultNoTime As DateTime = #1/4/0001#
  Public Const PivotDate As DateTime = #1/1/1980#
  Public Const PivotTime As DateTime = #12:00:00 AM#
  Public Const TextMargin As Integer = 2
  Public Const MinutesPerHour As Integer = 60
  Public Const HourPerDay As Integer = 24
  Public Const MinutesPerDay As Integer = MinutesPerHour * HourPerDay
  Public Const DaysPerWeek As Integer = 7
  Public Const MonthLargeRowCount As Integer = 6
  Public Const MonthSmallRowCount As Integer = 5
  Public Const MessageNeverGet As String = "There was an error with viewmode selection!"
  Public Const cAbsZero As Double = 0.00000000001
  Public Const ErrorConvertStartTime As String = "There was an error converting the start time."
  Public Const GhostedAlpha As Integer = 200
  Public ReadOnly GhostedBrushColor As Color = System.Drawing.Color.FromArgb(GhostedAlpha, 224, 224, 224)
  Public ReadOnly GhostedPenColor As Color = System.Drawing.Color.FromArgb(GhostedAlpha, Color.Silver)

  'Private constants needed for this object
  Public Const ErrorStringNoKey As String = "The specified key may not empty!"
  Public Const ErrorStringDuplicateKeyCollection As String = "The specified key already exists in this collection!"
  Public Const ErrorStringDuplicateKeyObject As String = "An object exists in the parent collection with the specified key!"
  Public Const ErrorStringObjectHasParent As String = "This object is already a member of a collection!"
  Public Const ErrorStringNoParentIndex As String = "This object does not have a parent collection and as such has no index value!"
  Public Const ErrorStringObjectHasNoParent As String = "This specified object must have a parent!"
  Public Const ErrorStringAutoNoSize As String = "You may not set this value when resizing is in an automatic mode!"
  Public Const ErrorStringMonthModeNoSize As String = "You may not set this value when in month mode!"

#End Region

#Region "Date/Time Functions"

  Public Function GetDate(ByVal inputDate As DateTime) As DateTime
    'This function will ensure that the Date has no round-off error
    Return DateSerial(inputDate.Year, inputDate.Month, inputDate.Day)
  End Function

  Public Function GetTime(ByVal inputTime As DateTime) As DateTime
    Return GetTime(inputTime, False)
  End Function

  Public Function GetTime(ByVal inputTime As DateTime, ByVal hourOnly As Boolean) As DateTime
    'This function will ensure that the Date has no round-off error
    If hourOnly Then
      Return TimeSerial(inputTime.Hour, 0, 0)
    Else
      Return TimeSerial(inputTime.Hour, inputTime.Minute, inputTime.Second)
    End If
  End Function

  Public Function DateToLong(ByVal value As DateTime) As Long

    Try
      Return DateDiff(DateInterval.Minute, PivotDate, value)
    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try

  End Function

  Public Function LongToDate(ByVal value As Long) As DateTime

    Try
      Return DateAdd(DateInterval.Minute, value, PivotDate)
    Catch ex As Exception
      Return PivotDate
    End Try

  End Function

  Public Function LongToDate(ByVal value As String) As DateTime

    Try
      Return LongToDate(CLng(value))
    Catch ex As Exception
      Return PivotDate
    End Try

  End Function

  Public Function TimeToLong(ByVal value As DateTime) As Long

    Try
      Return DateDiff(DateInterval.Minute, PivotTime, value)
    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try

  End Function

  Public Function LongToTime(ByVal value As Long) As DateTime

    Try
      Return DateAdd(DateInterval.Minute, value, PivotTime)
    Catch ex As Exception
      Return PivotTime
    End Try

  End Function

  Public Function LongToTime(ByVal value As String) As DateTime

    Try
      Return LongToTime(CLng(value))
    Catch ex As Exception
      Return PivotTime
    End Try

  End Function

  Public Function DateMatch(ByVal date1 As DateTime, ByVal date2 As DateTime) As Boolean

    Try
      Return date1.Equals(date2)
    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try

  End Function

  Public Function ConvertToDatePickerFormat(ByVal formatText As String, _
                                          ByVal isDate As Boolean, _
                                          ByVal ensure4DigitYear As Boolean) As String

    Try

      If isDate Then
        'Month must be CAPITAL "M"
        formatText = Replace(formatText, "m", "M")

        If ensure4DigitYear Then
          'If InStr(1, formatText, "yyyy", vbTextCompare) <> 0 Then
          If System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(formatText, "yyyy", Globalization.CompareOptions.IgnoreCase) <> 0 Then
            'There are already 4 digits so nothing to do
            'ElseIf InStr(1, formatText, "yy", vbTextCompare) <> 0 Then
          ElseIf System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(formatText, "yy", Globalization.CompareOptions.IgnoreCase) <> 0 Then
            'If there are 2 digits then format to 4
            formatText = Replace(formatText, "yy", "yyyy")
          End If
        End If

      Else
        'AM/PM is "tt"
        formatText = Replace(formatText, "AM/PM", "tt", , , vbTextCompare)
        formatText = Replace(formatText, "ap", "t")
        formatText = Replace(formatText, ":ss", "")
        formatText = Replace(formatText, "hh", "hh", , , vbTextCompare)

      End If
      Return formatText

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try
    Return Nothing

  End Function

  Public Function IsTimeOverlap(ByVal startTime1 As DateTime, ByVal length1 As Integer, ByVal startTime2 As DateTime, ByVal length2 As Integer) As Boolean

    Dim endTime1 As DateTime = Now
    Dim endTime2 As DateTime = Now

    Try
      endTime1 = DateAdd(DateInterval.Minute, length1, startTime1)
    Catch ex As Exception
			Call ErrorModule.SetErr("Block1:" & length1.ToString() & ":" & startTime1.ToString() & ControlChars.CrLf & ex.ToString)
			Return False
		End Try

		Try
			endTime2 = DateAdd(DateInterval.Minute, length2, startTime2)
		Catch ex As Exception
			Call ErrorModule.SetErr("Block2:" & length2.ToString() & ":" & startTime2.ToString() & ControlChars.CrLf & ex.ToString)
			Return False
		End Try

		Try
			If (length1 = 0) OrElse (length2 = 0) Then
				Return False
			ElseIf (startTime1 = startTime2) AndAlso _
				 (endTime1 = endTime2) Then
				'Times are exactly the same
				Return True
			ElseIf (startTime1 < endTime2) AndAlso _
						 (endTime1 > startTime2) Then
				'Overlap
				Return True
			Else
				Return False
			End If

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try

	End Function

	Public Function GetISODateTimeString(ByVal dateString As String) As String

		Try
			'== Takes in a general date string and reformats it as an ISO standard date string
      Dim retval As String = ""
      Dim inputDate As DateTime = Date.Parse(dateString)
      retval = CStr(inputDate.Year.ToString() & "-" & inputDate.Month.ToString().PadLeft(2, Char.Parse("0")) & "-" & inputDate.Day.ToString().PadLeft(2, Char.Parse("0")))
      If inputDate.Ticks > 0 Then
        retval = retval & " " & CStr(inputDate.Hour.ToString()) & ":" & CStr(inputDate.Minute.ToString()) & ":" & CStr(inputDate.Second.ToString())
      End If
      Return retval

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try
    Return Nothing

  End Function

  Public Function TruncateTimeToInterval(ByVal theTime As DateTime, ByVal interval As Integer) As DateTime

    'Truncate the time value to the an even interval of 
    'the hour based on the TimeIncrement of the schedule
    Try
      Dim remainder As Integer = MinutesLeftPerDay(GetTime(theTime))
      remainder -= remainder Mod interval
      Return DateAdd(DateInterval.Minute, MinutesPerDay - remainder, PivotTime)
    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try

  End Function

  Public Function MinutesLeftPerDay(ByVal timeValue As DateTime) As Integer

    Try
      Dim lastMinute As DateTime
      lastMinute = DateAdd(DateInterval.Minute, MinutesPerDay, PivotTime)
      Return GetIntlInteger(DateDiff(DateInterval.Minute, timeValue, lastMinute))

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try

  End Function

  Public Function TimeIncrementsFromStartOfDay(ByVal startTime As Date, ByVal timeIncrement As Integer) As Integer
    Dim minutes As Integer = CType(DateDiff(DateInterval.Minute, PivotTime, startTime), Integer)
    If timeIncrement <= 0 Then
      Return 0
    Else
      Return minutes \ timeIncrement
    End If
  End Function

  Public Function ToVCALDateTime(ByVal theTime As Date, ByVal includeTime As Boolean) As String
    Try
      Dim retval As String = ""
      retval = Format(theTime, "yyyyMMdd")
      If includeTime Then
        retval &= "T" & Format(theTime, "HHmm") & "00Z"
      End If
      Return retval
    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try
    Return Nothing

  End Function

	Public Function ToVCALDateTime(ByVal theTime As Date) As String
		Try
			Return ToVCALDateTime(theTime, True)
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing
  End Function

  Public Function FromVCALDateTime(ByVal text As String) As DateTime

    Try
      text = StripToChar(text, ":", True)
      text = text.Replace("T", "")
      Dim startDateTime As DateTime

      'Calculate the date
      startDateTime = DateSerial(GetIntlInteger(text.Substring(0, 4)), GetIntlInteger(text.Substring(4, 2)), GetIntlInteger(text.Substring(6, 2)))

      'If this text has time in it then use the time
      If VCALHasTime(text) Then
        startDateTime = startDateTime.Add(New TimeSpan(GetIntlInteger(text.Substring(8, 2)), GetIntlInteger(text.Substring(10, 2)), GetIntlInteger(text.Substring(12, 2))))
      End If

      'If text.EndsWith("Z") Then startDateTime = startDateTime.ToLocalTime() 'Convert from GMT only if "Z"
      'startDateTime = startDateTime.ToLocalTime()   'Convert from GMT Always
      Return startDateTime

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try

  End Function

	Public Function VCALHasTime(ByVal text As String) As Boolean

		Try
			'Date AND time is 14 chars. Otherwise this is a date only
			text = StripToChar(text, ":", True)
			text = text.Replace("T", "")
			text = text.Replace("Z", "")
			Return (text.Length = 14)

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try

	End Function

#End Region

#Region "AppPath"

	Public Function AppPath() As String

		Try
			Dim retval As String = Application.ExecutablePath
			retval = New System.IO.DirectoryInfo(retval).Parent.FullName
			If Not retval.EndsWith("\") Then retval &= "\"
			Return retval
			'Return Application.StartupPath

		Catch ex As Exception
			System.Diagnostics.EventLog.WriteEntry(System.Reflection.Assembly.GetExecutingAssembly.FullName, ex.ToString())
		End Try
    Return Nothing

	End Function

#End Region

#Region "Insert/SetCombo"

	Public Function InSet(ByVal CheckValue As Object, ByVal ParamArray Values() As Object) As Boolean

		Dim ii As Integer
		For ii = 0 To UBound(Values)
			If CheckValue Is Values(ii) Then
				Return True
			End If
		Next ii
		Return False

	End Function

	Public Sub SetCombo(ByVal cboBox As ComboBox, ByVal value As String, ByVal useText As Boolean)

		Dim ii As Integer

		Try
			If useText Then

				For ii = 0 To cboBox.Items.Count - 1
					If System.Globalization.CultureInfo.CurrentCulture.CompareInfo.Compare(CStr(cboBox.Items(ii)), value, Globalization.CompareOptions.IgnoreCase) = 0 Then
						cboBox.SelectedIndex = ii
						Return
					End If
				Next ii

			Else

				For ii = 0 To cboBox.Items.Count - 1
					If GetIntlInteger(CType(cboBox.Items(ii), String)) = GetIntlInteger(value) Then
						cboBox.SelectedIndex = ii
						Return
					End If
				Next ii

			End If

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try

	End Sub

#End Region

#Region "XML Methods"

	Public Function GetNode(ByVal xmlNode As Xml.XmlNode, ByVal XPath As String) As Xml.XmlNode

		Try
			Dim node As Xml.XmlNode
			node = xmlNode.SelectSingleNode(XPath)
			Return node
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function GetNodeValue(ByVal XMLDoc As Xml.XmlDocument, ByVal XPath As String, ByVal defaultValue As String) As String

		Try
			Return GetNodeValue(XMLDoc.DocumentElement, XPath, defaultValue)
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function GetNodeValue(ByVal XMLDoc As Xml.XmlNode, ByVal XPath As String, ByVal defaultValue As String) As String

		Try
			Dim node As Xml.XmlNode
			node = XMLDoc.SelectSingleNode(XPath)
			If node Is Nothing Then
				Return defaultValue
			Else
				Return node.InnerText
			End If
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function GetNodeXML(ByVal XMLDoc As Xml.XmlDocument, ByVal XPath As String, ByVal defaultValue As String, ByVal useOuter As Boolean) As String
		Try
			Dim node As Xml.XmlNode
			node = XMLDoc.SelectSingleNode(XPath)
			If node Is Nothing Then
				Return defaultValue
			ElseIf useOuter Then
				Return node.OuterXml
			Else
				Return node.InnerXml
			End If
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

  End Function

	Public Function GetNodeXML(ByVal XMLDoc As Xml.XmlDocument, ByVal XPath As String, ByVal defaultValue As String) As String
		Return GetNodeXML(XMLDoc, XPath, defaultValue, False)
	End Function

#End Region

#Region "File Operations"

	Public Function SaveFile(ByVal path As String, ByVal text As String) As Boolean

		Try

			'Remove the file if necessary
			If System.IO.File.Exists(path) Then
				Call System.IO.File.Delete(path)
			End If

      Dim SW As IO.StreamWriter
      SW = System.IO.File.AppendText(path)
			Call SW.Write(text)
			Call SW.Close()
			Return True
		Catch ex As Exception
			Call ErrorModule.SetErr(ex.ToString & "FileName:" & path)
		End Try

	End Function

	Public Function LoadFile(ByVal path As String) As String

		Try
      Dim SW As IO.StreamReader
      Dim retval As String = ""
      SW = System.IO.File.OpenText(path)
			retval = SW.ReadToEnd()
			Call SW.Close()
			Return retval
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	'Serialize an object to file in SOAP format.
	Public Sub SaveSoapToFile(ByVal fileName As String, ByVal o As Object)

		Try
			' Open a file stream for output.
			Dim fs As System.IO.FileStream = New System.IO.FileStream(fileName, System.IO.FileMode.Create)
			' Create a SOAP formatter for this stream.
			Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.File))
			' Serialize the array to the file stream, and close the stream.
			sf.Serialize(fs, o)
			fs.Close()
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try

	End Sub

	'Deserialize an object from a file in SOAP format.
	Public Function LoadSoapFromFile(ByVal fileName As String) As Object

		Try
			If Not System.IO.File.Exists(fileName) Then Return Nothing
			'Open a file stream for input.
			Dim fs As System.IO.FileStream = New System.IO.FileStream(fileName, System.IO.FileMode.Open)
			' Create a SOAP formatter for this stream.
			Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.File))

      ' Deserialize the contents of the file stream into an object.
      Dim retval As Object
      retval = sf.Deserialize(fs)
			' close the stream.
      fs.Close()
      Return retval

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function CloneObject(ByVal obj As Object) As Object

		Try
			' Create a memory stream and a formatter.
			Dim ms As New System.IO.MemoryStream(4000)
			Dim bf As New BinaryFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))
			' Serialize the object into the stream.
			Call bf.Serialize(ms, obj)
			' Position streem pointer back to first byte.
			Call ms.Seek(0, SeekOrigin.Begin)
			' Deserialize into another object.
			Dim retval As Object = bf.Deserialize(ms)
			' release memory.
			Call ms.Close()
			Return retval

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function ObjectToXML(ByVal obj As Object) As String

		Try
			' Create a memory stream and a formatter.
			Dim ms As New System.IO.MemoryStream(1000)
			Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))
			' Serialize the object into the stream.
			Call sf.Serialize(ms, obj)
			' Position stream pointer back to first byte.
			Call ms.Seek(0, SeekOrigin.Begin)
			Dim arr As Array = Array.CreateInstance(GetType(Byte), GetIntlInteger(ms.Length))
			Call ms.Read(CType(arr, Byte()), 0, GetIntlInteger(ms.Length))
			Dim byteArr() As Byte = ms.ToArray()
			Dim ii As Integer
      Dim retval As String = ""
      For ii = 0 To UBound(byteArr)
        retval &= Chr(byteArr(ii))
      Next
      ' release memory.
      Call ms.Close()
      Return retval

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try
    Return Nothing

  End Function

  Public Function XMLToObject(ByVal xml As String) As Object


    Try
      Dim retval As Object

      ' Create a memory stream and a formatter.
      Dim ms As New System.IO.MemoryStream(1000)
      Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))

      Dim arr As Array = Array.CreateInstance(GetType(Byte), xml.Length)
      Dim charArr() As Char = xml.ToCharArray()
      Dim byteArr(xml.Length) As Byte

      Dim ii As Integer
      Dim S As String = ""
      For ii = 0 To xml.Length - 1
        byteArr(ii) = CByte(Asc(charArr(ii)))
        S &= Chr(byteArr(ii))
      Next

      Call ms.Write(byteArr, 0, xml.Length)
      Call ms.Seek(0, SeekOrigin.Begin)

      retval = sf.Deserialize(ms)

      ' release memory.
      Call ms.Close()
      Return retval

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try
    Return Nothing

  End Function

	'Public Function LoadFile(ByVal filename As String) As String

	'  Try
	'    Dim sr As StreamReader = File.OpenText(filename)
	'    Dim retval As String = sr.ReadToEnd()
	'    Call sr.Close()
	'    Return retval
	'  Catch ex As Exception
	'    Call ErrorModule.SetErr(ex)
	'  End Try

	'End Function

	'Public Function SaveFile(ByVal filename As String, ByVal text As String) As Boolean

	'  Try
	'    Dim sw As New StreamWriter(filename)
	'    Call sw.Write(text)
	'    Call sw.Close()
	'    Return True
	'  Catch ex As Exception
	'    Call ErrorModule.SetErr(ex)
	'  End Try

	'End Function

#End Region

#Region "CalculateSortIndex"

	Public Sub CalculateSortIndex(ByVal viewmode As Gravitybox.Controls.Schedule.ViewModeConstants, _
																ByVal rectInfo As Gravitybox.Objects.AppointmentRectangleInfo, _
																ByVal MainObject As Gravitybox.Controls.Schedule)

		Dim dateIndex As Double
		Dim timeIndex1 As Double
		Dim timeIndex2 As Double
		Dim roomIndex As Double
		Dim providerIndex As Double
		Dim resourceIndex As Double
		Dim length As Integer

		Try
			Select Case viewmode
				Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Week
					dateIndex = DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate)
					timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					length = rectInfo.Length
					rectInfo.SortIndexStart = dateIndex + timeIndex1
					rectInfo.SortIndexEnd = dateIndex + timeIndex2
				Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
					dateIndex = CDbl(DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate))
					'timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					'timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					timeIndex1 = 0
					timeIndex2 = 0
					roomIndex = rectInfo.StartRoom
					rectInfo.SortIndexStart = (dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex1
					rectInfo.SortIndexEnd = (dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex2
				Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
					dateIndex = CDbl(DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate))
					'timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					'timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					timeIndex1 = 0
					timeIndex2 = 0
					providerIndex = rectInfo.StartProvider
					rectInfo.SortIndexStart = (dateIndex * MainObject.ProviderCollection.VisibleCount) + providerIndex + timeIndex1
					rectInfo.SortIndexEnd = (dateIndex * MainObject.ProviderCollection.VisibleCount) + providerIndex + timeIndex2
        Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
          dateIndex = CDbl(DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate))
          'timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
          'timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
          timeIndex1 = 0
          timeIndex2 = 0
          resourceIndex = rectInfo.StartResource
          rectInfo.SortIndexStart = (dateIndex * MainObject.ResourceCollection.VisibleCount) + resourceIndex + timeIndex1
          rectInfo.SortIndexEnd = (dateIndex * MainObject.ResourceCollection.VisibleCount) + resourceIndex + timeIndex2
        Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
          timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
          timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
          roomIndex = rectInfo.StartRoom
          length = rectInfo.Length
          rectInfo.SortIndexStart = roomIndex + timeIndex1
          rectInfo.SortIndexEnd = roomIndex + timeIndex2
				Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
					'timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					'timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					timeIndex1 = 0
					timeIndex2 = 0
					roomIndex = rectInfo.StartRoom
					providerIndex = rectInfo.StartProvider
					rectInfo.SortIndexStart = (providerIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex1
					rectInfo.SortIndexEnd = (providerIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex2
				Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
					timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					providerIndex = rectInfo.StartProvider
					length = rectInfo.Length
					rectInfo.SortIndexStart = providerIndex + timeIndex1
					rectInfo.SortIndexEnd = providerIndex + timeIndex2
				Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
					dateIndex = DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate)
					timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					length = rectInfo.Length
					rectInfo.SortIndexStart = dateIndex + timeIndex1
					rectInfo.SortIndexEnd = dateIndex + timeIndex2
				Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
					dateIndex = DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate)
					timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					roomIndex = rectInfo.StartRoom
					length = rectInfo.Length
					rectInfo.SortIndexStart = (dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex1
					rectInfo.SortIndexEnd = (dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex2
        Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
          dateIndex = DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate)
          timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
          timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
          providerIndex = rectInfo.StartProvider
          length = rectInfo.Length
          rectInfo.SortIndexStart = (dateIndex * MainObject.ProviderCollection.VisibleCount) + providerIndex + timeIndex1
          rectInfo.SortIndexEnd = (dateIndex * MainObject.ProviderCollection.VisibleCount) + providerIndex + timeIndex2
        Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
          dateIndex = CDbl(DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate))
          timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
          timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
          providerIndex = rectInfo.StartProvider
          rectInfo.SortIndexStart = (dateIndex * MainObject.ProviderCollection.VisibleCount) + providerIndex + timeIndex1
          rectInfo.SortIndexEnd = (dateIndex * MainObject.ProviderCollection.VisibleCount) + providerIndex + timeIndex2
        Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
          dateIndex = CDbl(DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate))
          timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime)) / (MinutesPerDay * MainObject.RoomCollection.Count)
          timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime)) / (MinutesPerDay * MainObject.RoomCollection.Count)
          roomIndex = rectInfo.StartRoom / (MinutesPerDay * MainObject.RoomCollection.Count)
          'rectInfo.SortIndexStart = (dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex1
          'rectInfo.SortIndexEnd = (dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex + timeIndex2
          rectInfo.SortIndexStart = dateIndex + timeIndex1 + roomIndex
          rectInfo.SortIndexEnd = dateIndex + timeIndex2 + roomIndex
        Case Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull
          dateIndex = DateDiff(DateInterval.Day, PivotDate, rectInfo.StartDate)
          timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
          timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
          length = rectInfo.Length
          rectInfo.SortIndexStart = dateIndex + timeIndex1
          rectInfo.SortIndexEnd = dateIndex + timeIndex2
				Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
					timeIndex1 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.StartTime) / MinutesPerDay)
					timeIndex2 = CDbl(DateDiff(DateInterval.Minute, PivotTime, rectInfo.EndTime) / MinutesPerDay)
					resourceIndex = rectInfo.StartResource
					length = rectInfo.Length
					rectInfo.SortIndexStart = resourceIndex + timeIndex1
					rectInfo.SortIndexEnd = resourceIndex + timeIndex2
				Case Else
					Call ErrorModule.ViewmodeErr()
			End Select

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try

	End Sub

#End Region

#Region "String Operations"

	Public Function StripToChar(ByVal text As String, ByVal theChar As String) As String
		Return StripToChar(text, theChar, False)
	End Function

	Public Function StripToChar(ByVal text As String, ByVal theChar As String, ByVal include As Boolean) As String

		Try
			'Dim index As Integer = text.IndexOf(theChar)
			Dim index As Integer = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(text, theChar)
			If index = -1 Then
				Return text
			ElseIf include Then
				Return text.Substring(index + 1, text.Length - index - theChar.Length)
			Else
				Return text.Substring(index + 1, text.Length - index)
			End If

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

#End Region

#Region "CreateVCSAppointment"

  Public Function CreateVCSAppointment(ByVal appointmentList As AppointmentList, ByVal filename As String, ByVal useUniversalTime As Boolean) As Boolean

    Try

      Dim text As String = CreateVCSAppointment(appointmentList, useUniversalTime)

      'Create the .VCS file.
      Dim sw As New StreamWriter(filename)
      Call sw.Write(text)
      Call sw.Close()

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try

  End Function

  Public Function CreateVCSAppointment(ByVal appointmentList As AppointmentList, ByVal useUniversalTime As Boolean) As String

    Dim startDateText As String = ""
    Dim endDateText As String = ""
    Dim nowDateText As String = ""
    Dim tmeZoneBias As Integer
    Dim startDate As DateTime
    Dim endDate As DateTime
    Dim text As String = ""
    Dim appointment As Appointment

    Try

      'VCS uses GMT so all values must be adjusted according to
      'your Time Zone.  Mountain Time (Denver) is -7
      'TimeZone Offset from GMT is always Negative.  Make it positive.
      tmeZoneBias = Date.Now.Subtract(Date.UtcNow).Hours

      'Create the text for the file
      text = ""
      text &= "BEGIN:VCALENDAR" & ControlChars.CrLf
      text &= "PRODID: -//Gravitybox Schedule.NET v1.1" & ControlChars.CrLf
      text &= "VERSION:1.1" & ControlChars.CrLf

      For Each appointment In appointmentList

        If useUniversalTime Then
          startDate = appointment.StartDateTime.ToUniversalTime
          endDate = appointment.EndDateTime.ToUniversalTime
        Else
          startDate = appointment.StartDateTime
          endDate = appointment.EndDateTime
        End If

        'Format user-supplied data in VCS required format.
        'Note that the style "Hhnnss" returns time in 24-hour format.
        startDateText = ToVCALDateTime(startDate, Not appointment.IsEvent)
        endDateText = ToVCALDateTime(endDate, Not appointment.IsEvent)
        nowDateText = ToVCALDateTime(DateTime.Now)

        'Appointment Start
        text &= "BEGIN:VEVENT" & ControlChars.CrLf
        text &= "DTSTAMP:" & nowDateText & ControlChars.CrLf
        text &= "DTSTART:" & startDateText & ControlChars.CrLf
        text &= "DTEND:" & endDateText & ControlChars.CrLf
        If Not (appointment.Room Is Nothing) Then
          text &= "LOCATION:" & appointment.Room.Text.Replace(ControlChars.CrLf, " \n") & ControlChars.CrLf
        Else
          text &= "LOCATION:" & ControlChars.CrLf
        End If

        'Access: Public/Private
        If appointment.Access = AppointmentAccessConstants.AccessPublic Then
          text &= "CLASS:PUBLIC" & ControlChars.CrLf
        ElseIf appointment.Access = AppointmentAccessConstants.AccessPrivate Then
          text &= "CLASS:PRIVATE" & ControlChars.CrLf
        ElseIf appointment.Access = AppointmentAccessConstants.AccessConfidential Then
          text &= "CLASS:CONFIDENTIAL" & ControlChars.CrLf
        End If

        'Alarm
        If (appointment.Alarm.Reminder <> 0) Then
          Dim reminderTime As Date = appointment.Alarm.ReminderDateTime
          If useUniversalTime Then reminderTime = appointment.Alarm.ReminderDateTime.ToUniversalTime
          text &= "TRIGGER:" & ToVCALDateTime(reminderTime) & ControlChars.CrLf
        End If

        'Other properties
        text &= "SUMMARY:" & appointment.Subject.Replace(ControlChars.CrLf, " \n") & ControlChars.CrLf
        text &= "DESCRIPTION:" & appointment.Text.Replace(ControlChars.CrLf, " \n") & ControlChars.CrLf
        text &= "NOTES:" & appointment.Notes.Replace(ControlChars.CrLf, " \n") & ControlChars.CrLf
        text &= "UID:" & appointment.Key & ControlChars.CrLf
        If Not (appointment.Priority Is Nothing) Then
          text &= "PRIORITY:" & appointment.Priority.ToString & ControlChars.CrLf
        End If

        '**************************************************
        'Conditional includes
        If appointment.IsFlagged Then
          text &= "ISFLAGGED:" & appointment.IsFlagged.ToString.ToUpper & ControlChars.CrLf
        End If

        If appointment.MinLength <> -1 Then
          text &= "MINLENGTH:" & appointment.MinLength.ToString & ControlChars.CrLf
        End If

        If appointment.MaxLength <> -1 Then
          text &= "MAXLENGTH:" & appointment.MaxLength.ToString & ControlChars.CrLf
        End If

        '**************************************************
        'Load categories if need be
        If appointment.CategoryList.Count > 0 Then
          text &= "CATEGORIES:"
          Dim category As Category
          Dim ii As Integer = 0
          For Each category In appointment.CategoryList
            text &= category.Text.Replace(ControlChars.CrLf, " \n")
            If ii < appointment.CategoryList.Count - 1 Then text &= "," 'Add a comma for all but last
            ii += 1
          Next
          text &= ControlChars.CrLf
        End If

        '**************************************************
        'Load providers if need be
        If appointment.ProviderList.Count > 0 Then
          text &= "PROVIDERS:"
          Dim provider As Provider
          Dim ii As Integer
          For Each provider In appointment.ProviderList
            text &= provider.Text.Replace(ControlChars.CrLf, " \n")
            If ii < appointment.ProviderList.Count - 1 Then text &= "," 'Add a comma for all but last
            ii += 1
          Next
          text &= ControlChars.CrLf
        End If

        'Appointment Footer
        text &= "END:VEVENT" & ControlChars.CrLf

      Next

      'File Footer
      text &= "END:VCALENDAR" & ControlChars.CrLf

      Return text

    Catch ex As Exception
      Call ErrorModule.SetErr(ex)
    End Try
    Return Nothing

  End Function

#End Region

#Region "LoadResourceString"

	'Public Function LoadResourceString(ByVal id As Integer) As String

	'  Try
	'    Dim resource As New System.Resources.ResourceManager("ProjectResources", System.Reflection.Assembly.GetExecutingAssembly)
	'    Return resource.GetString(id.ToString())
	'  Catch ex As Exception
	'    Call ErrorModule.SetErr(ex)
	'  End Try

	'End Function

#End Region

#Region "CreateBrush"

	Public Function CreateBrush(ByVal appearance As Gravitybox.Objects.Appearance, ByVal rect As Rectangle) As Brush
		Dim rect2 As New RectangleF(rect.Left, rect.Top, rect.Width, rect.Height)
		Return CreateBrush(appearance, rect2)
	End Function

	Public Function CreateBrush(ByVal appearance As Gravitybox.Objects.Appearance, ByVal rect As RectangleF) As Brush

		If (rect.Width <= 0) OrElse (rect.Height <= 0) Then
			rect = New RectangleF(rect.X, rect.Y, 1, 1)
		End If

		Try
			Dim myColor As Color = appearance.BackColor
			Dim myColor2 As Color = appearance.BackColor2

			If appearance.HatchStyle = Drawing2D.HatchStyle.Min Then
				'This is NO hatch brush
				If appearance.BackGradientStyle = GradientStyleConstants.None Then
					Return New SolidBrush(myColor)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.Horizontal Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.Horizontal)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.Vertical Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.Vertical)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.BackwardDiagonal Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.BackwardDiagonal)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.ForwardDiagonal Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.ForwardDiagonal)
				End If

			Else
				'This is Hatch brush
				Return New Drawing2D.HatchBrush(appearance.HatchStyle, appearance.HatchColor, myColor)

			End If

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function CreateBrush(ByVal appearance As Gravitybox.Objects.AppointmentAppearance, ByVal rect As Rectangle) As Brush
		Dim rect2 As New RectangleF(rect.Left, rect.Top, rect.Width, rect.Height)
		Return CreateBrush(appearance, rect2)
	End Function

	Public Function CreateBrush(ByVal appearance As Gravitybox.Objects.AppointmentAppearance, ByVal rect As RectangleF) As Brush

		If (rect.Width <= 0) OrElse (rect.Height <= 0) Then
			rect = New RectangleF(rect.X, rect.Y, 1, 1)
		End If

		Try
			Dim myColor As Color
			Dim myColor2 As Color
			If appearance.Transparency = 0 Then
				myColor = appearance.BackColor
				myColor2 = appearance.BackColor2
			Else
				myColor = System.Drawing.Color.FromArgb(255 - GetIntlInteger(appearance.Transparency * 2.55), appearance.BackColor)
				myColor2 = System.Drawing.Color.FromArgb(255 - GetIntlInteger(appearance.Transparency * 2.55), appearance.BackColor2)
			End If

			If appearance.HatchStyle = Drawing2D.HatchStyle.Min Then
				'This is NO hatch brush
				If appearance.BackGradientStyle = GradientStyleConstants.None Then
					Return New SolidBrush(myColor)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.Horizontal Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.Horizontal)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.Vertical Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.Vertical)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.BackwardDiagonal Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.BackwardDiagonal)
				ElseIf appearance.BackGradientStyle = GradientStyleConstants.ForwardDiagonal Then
					Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.ForwardDiagonal)
				End If

			Else
				'This is Hatch brush
				Return New Drawing2D.HatchBrush(appearance.HatchStyle, appearance.HatchColor, myColor)

			End If

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function CreateBrush(ByVal appearance As Gravitybox.Objects.AppointmentHeaderAppearance, ByVal rect As Rectangle) As Brush
		Dim rect2 As New RectangleF(rect.Left, rect.Top, rect.Width, rect.Height)
		Return CreateBrush(appearance, rect2)
	End Function

	Public Function CreateBrush(ByVal appearance As Gravitybox.Objects.AppointmentHeaderAppearance, ByVal rect As RectangleF) As Brush

		If (rect.Width <= 0) OrElse (rect.Height <= 0) Then
			rect = New RectangleF(rect.X, rect.Y, 1, 1)
		End If

		Try
			Dim myColor As Color
			Dim myColor2 As Color

			If appearance.Transparency = 0 Then
				myColor = appearance.BackColor
				myColor2 = appearance.BackColor2
			Else
				myColor = System.Drawing.Color.FromArgb(255 - GetIntlInteger(appearance.Transparency * 2.55), appearance.BackColor)
				myColor2 = System.Drawing.Color.FromArgb(255 - GetIntlInteger(appearance.Transparency * 2.55), appearance.BackColor2)
			End If

			If appearance.BackGradientStyle = GradientStyleConstants.None Then
				Return New SolidBrush(myColor)
			ElseIf appearance.BackGradientStyle = GradientStyleConstants.Horizontal Then
				Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.Horizontal)
			ElseIf appearance.BackGradientStyle = GradientStyleConstants.Vertical Then
				Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.Vertical)
			ElseIf appearance.BackGradientStyle = GradientStyleConstants.BackwardDiagonal Then
				Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.BackwardDiagonal)
			ElseIf appearance.BackGradientStyle = GradientStyleConstants.ForwardDiagonal Then
				Return New System.Drawing.Drawing2D.LinearGradientBrush(rect, myColor, myColor2, Drawing2D.LinearGradientMode.ForwardDiagonal)
			End If
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing
  End Function

#End Region

#Region "CreateGhostedPen"

	Public Function CreateGhostedPen() As Pen
		Return CreateGhostedPen(1)
	End Function

	Public Function CreateGhostedPen(ByVal borderWidth As Integer) As Pen
		Return New System.Drawing.Pen(GhostedPenColor, borderWidth)
	End Function

#End Region

#Region "CreateGhostedBrush"

	Public Function CreateGhostedBrush() As Brush
		Return New SolidBrush(GhostedBrushColor)
	End Function

#End Region

#Region "CreateBorderPen"

	Public Function CreateBorderPen(ByVal appearance As Gravitybox.Objects.AppointmentAppearance) As Pen
		Try
			Return CreateBorderPen(appearance, appearance.BorderWidth)
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing
  End Function

	Public Function CreateBorderPen(ByVal appearance As Gravitybox.Objects.AppointmentAppearance, ByVal borderWidth As Integer) As Pen
		Try
			If appearance.Ghosted Then
				Return New System.Drawing.Pen(Color.FromArgb(GhostedAlpha, appearance.BorderColor), borderWidth)
			Else
				Return New System.Drawing.Pen(appearance.BorderColor, borderWidth)
			End If
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing
  End Function

	Public Function CreateBorderPen(ByVal appearance As Gravitybox.Objects.Appearance) As Pen
		Try
			Return New System.Drawing.Pen(appearance.BorderColor, appearance.BorderWidth)
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing
  End Function

#End Region

#Region "CreateTextPen"

	Public Function CreateTextPen(ByVal appearance As Gravitybox.Objects.AppointmentAppearance) As Pen

		Try
			Return New System.Drawing.Pen(appearance.ForeColor)
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function CreateTextPen(ByVal appearance As Gravitybox.Objects.Appearance) As Pen

		Try
			Return New System.Drawing.Pen(appearance.ForeColor)
		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

#End Region

#Region "CreateFont"

	Public Function CreateFont(ByVal appearance As Gravitybox.Objects.Appearance, ByVal fontFamily As System.Drawing.FontFamily) As Font
		Return CreateFont(appearance, fontFamily, appearance.FontSize)
	End Function

	Public Function CreateFont(ByVal appearance As Gravitybox.Objects.Appearance, ByVal fontFamily As System.Drawing.FontFamily, ByVal fontSize As Single) As Font

		Try
			Dim fontStyle As fontStyle
			If appearance.FontBold Then fontStyle = fontStyle Or fontStyle.Bold
			If appearance.FontItalics Then fontStyle = fontStyle Or fontStyle.Italic
			If appearance.FontStrikeout Then fontStyle = fontStyle Or fontStyle.Strikeout
			If appearance.FontUnderline Then fontStyle = fontStyle Or fontStyle.Underline
			Return New Font(fontFamily, fontSize, fontStyle, appearance.FontUnit)

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

#End Region

#Region "CreateStringFormat"

	Public Function CreateStringFormat(ByVal appearance As Gravitybox.Objects.Appearance) As System.Drawing.StringFormat

		Try
			Dim sf As New System.Drawing.StringFormat(appearance.StringFormatFlags)
			sf.Alignment = appearance.Alignment
			sf.LineAlignment = appearance.TextVAlign
			sf.Trimming = appearance.TextTrimming
			Return sf

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

#End Region

#Region "Split String"

	Public Function SplitString(ByVal text As String, ByVal delimiter As String) As String()

		Return Microsoft.VisualBasic.Strings.Split(text, delimiter, , CompareMethod.Text)

		'Try
		'  Dim retval As New ArrayList
		'  Dim startIndex As Integer = 0
		'  Dim index As Integer = text.ToLower.IndexOf(delimiter)
		'  While index > -1
		'    retval.Add(text.Substring(startIndex, index - startIndex))
		'    startIndex = index
		'    index = text.ToLower.IndexOf(delimiter, index + 1)
		'  End While
		'  Dim a As Array = retval.ToArray
		'  Return CType(a, System.String())
		'Catch ex As Exception
		'  ErrorModule.SetErr(ex)
		'End Try
		'Return CType((New ArrayList).ToArray, String())

	End Function

#End Region

#Region "GetMax"

	Public Function GetMax(ByVal value1 As Integer, ByVal value2 As Integer) As Integer
		If value1 > value2 Then
			Return value1
		Else
			Return value2
		End If
	End Function

#End Region

#Region "String Compare"

	Public Function StringMatch(ByVal s1 As String, ByVal s2 As String, ByVal ignoreCase As Boolean) As Boolean

		If (s1 = Nothing) Then
			If (s2 = Nothing) Then
				Return True
			Else
				Return False
			End If
		Else
			If (s2 = Nothing) Then
				Return False
			ElseIf (s1.Length <> s2.Length) Then
				Return False
			ElseIf (s1.Length = 0) Then
				Return True
			End If
		End If

		Return (System.Globalization.CultureInfo.CurrentCulture.CompareInfo.Compare(s1, s2, Globalization.CompareOptions.IgnoreCase) = 0)

	End Function

#End Region

#Region "ConvertRectangle"

	Public Function ConvertRectangle(ByVal rect As System.Drawing.Rectangle) As System.Drawing.RectangleF
		Return New System.Drawing.RectangleF(rect.X, rect.Y, rect.Width, rect.Height)
	End Function

	Public Function ConvertRectangle(ByVal rect As System.Drawing.RectangleF) As System.Drawing.Rectangle
		Return New System.Drawing.Rectangle(GetIntlInteger(rect.X), GetIntlInteger(rect.Y), GetIntlInteger(rect.Width), GetIntlInteger(rect.Height))
	End Function

#End Region

#Region "GetColor"

	Public Function GetColor(ByVal colorValue As String) As System.Drawing.Color
		Try
			Dim newValue As Integer = GetIntlInteger(colorValue)
			Return GetColor(newValue)
		Catch ex As Exception
			Return System.Drawing.Color.Black
		End Try
	End Function

	Public Function GetColor(ByVal colorValue As Integer) As System.Drawing.Color
		Try
			Dim a As Byte = CByte(((colorValue And &HFF000000) \ &H1000000) And &HFF)
			Dim r As Byte = CByte(((colorValue And &HFF0000) \ &H10000) And &HFF)
			Dim g As Byte = CByte(((colorValue And &HFF00) \ &H100) And &HFF)
			Dim b As Byte = CByte((colorValue And &HFF))
			Return System.Drawing.Color.FromArgb(a, r, g, b)
		Catch ex As Exception
			Return System.Drawing.Color.Black
		End Try
	End Function

#End Region

#Region "GetIntlInteger"

	Public Function GetIntlInteger(ByVal value As String) As Integer

		Dim ni As New System.Globalization.NumberFormatInfo
		ni.CurrencyDecimalDigits = 0
		ni.CurrencyDecimalSeparator = "."
		ni.NumberDecimalDigits = 0
		ni.NumberDecimalSeparator = "."

		Try
			'Dim index As Integer = value.IndexOf(".")
			Dim index As Integer = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(value, ".")

			If index <> -1 Then
				value = value.Substring(0, index)
			End If
			'index = value.IndexOf(",")
			index = System.Globalization.CultureInfo.CurrentCulture.CompareInfo.IndexOf(value, ",")
			If index <> -1 Then
				value = value.Substring(0, index)
			End If
		Catch ex As Exception
			ErrorModule.SetErr(ex)
		End Try

		Try
			'Return Integer.Parse(value, ni)
			Return Convert.ToInt32(value, ni)
		Catch ex As Exception
			Dim frame As New System.Diagnostics.StackFrame(True)
			Dim s As String = frame.ToString()
			ErrorModule.SetErr("Value: " & value & ControlChars.CrLf & "Stack Trace: " & s & ControlChars.CrLf & ex.ToString())
		End Try

	End Function

	Public Function GetIntlInteger(ByVal value As [Enum]) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Gravitybox.Controls.Schedule.TimeIncrementConstants) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Gravitybox.Objects.RecurrenceEndConstants) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Gravitybox.Objects.RecurrenceIntervalConstants) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Gravitybox.Objects.RecurrenceOrdinalConstants) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Gravitybox.Objects.RecurrenceOrdinalDayConstants) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Gravitybox.Objects.RecurrenceDayConstants) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Gravitybox.Objects.RecurrenceSubTypeConstants) As Integer
		Return GetIntlInteger(value.ToString("d"))
	End Function

	Public Function GetIntlInteger(ByVal value As Single) As Integer
		Return GetIntlInteger(value.ToString)
	End Function

	Public Function GetIntlInteger(ByVal value As Double) As Integer
		Return GetIntlInteger(value.ToString)
	End Function

	Public Function GetIntlInteger(ByVal value As Long) As Integer
		Return GetIntlInteger(value.ToString)
	End Function

	Public Function GetIntlInteger(ByVal value As Object) As Integer
		Return GetIntlInteger(value.ToString)
	End Function

#End Region

#Region "Delegate Helpers"

	Public Function RemoveAllEventHooks(ByVal MasterDelegate As [Delegate], ByRef delegateArray As ArrayList) As [Delegate]

		Try
			Dim del As RefreshDelegate
			delegateArray = New ArrayList
			If Not (MasterDelegate Is Nothing) Then
				For Each del In MasterDelegate.GetInvocationList
					Try
						Try
							delegateArray.Add(del)
							MasterDelegate = CType(System.Delegate.Remove(MasterDelegate, del), RefreshDelegate)
						Catch
						End Try
					Catch ex As Exception
						'Do Nothing
					End Try
				Next
			End If

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		End Try
		Return MasterDelegate

	End Function


#End Region

#Region "GetProjectFileAsString"

	Public Function GetProjectFileAsStream(ByVal fileName As String) As System.IO.Stream

		Try
			Dim asbly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
			Dim stream As System.IO.Stream = asbly.GetManifestResourceStream(fileName)
      Dim sr As System.IO.StreamReader = New System.IO.StreamReader(stream, System.Text.Encoding.UTF8)
			Return sr.BaseStream
		Catch ex As Exception
			ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

	Public Function GetProjectFileAsString(ByVal fileName As String) As String

		Try
			Dim asbly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
			Dim stream As System.IO.Stream = asbly.GetManifestResourceStream(fileName)
			Dim sr As System.IO.StreamReader = New System.IO.StreamReader(stream, System.Text.Encoding.UTF8)
			Return sr.ReadToEnd
		Catch ex As Exception
			ErrorModule.SetErr(ex)
		End Try
    Return Nothing

	End Function

#End Region

#Region "GetAlarmPivotValue"

	Public Function GetAlarmPivotValue(ByVal theDate As Date) As Single

		Try
			Dim dayIndex As Integer = GetIntlInteger(DateDiff(DateInterval.Day, PivotDate, GetDate(theDate.Date)))
			Dim timeIndex As Single = CSng(DateDiff(DateInterval.Minute, PivotTime, TimeSerial(theDate.Hour, theDate.Minute, 0)))
			Dim pivotValue As Single = (dayIndex + (timeIndex / MinutesPerDay))
			Return pivotValue
		Catch ex As Exception
			ErrorModule.SetErr(ex)
		End Try

	End Function

#End Region

#Region "IsTypeOf"

  Public Function IsTypeOf(ByVal checkType As System.Type, ByVal baseType As System.Type) As Boolean
    Return (checkType Is baseType) Or checkType.IsSubclassOf(baseType)
  End Function

#End Region

	Public Function ViewmodeHasDate(ByVal viewmode As Gravitybox.controls.Schedule.ViewModeConstants) As Boolean

		Select Case viewmode
			Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
			Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
			Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
			Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
			Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.Week
      Case Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull
      Case Else
        Return False
    End Select
		Return True

	End Function

#Region "GetDateByViewMode"

	'This method determine if the viewmode supports dates and if NOt returns the NoDate value
	Public Function GetDateByViewMode(ByVal viewmode As Gravitybox.controls.Schedule.ViewModeConstants, ByVal theDate As DateTime) As DateTime

		If ViewmodeHasDate(viewmode) Then
			Return theDate
		Else
			Return DefaultNoDate
		End If

	End Function

#End Region

#Region "IsNumeric"

	Public Function IsNumeric(ByVal c As Char) As Boolean
		Return ("0" <= c) AndAlso (c <= "9")
	End Function

	Public Function IsNumeric(ByVal s As String) As Boolean
		Return Microsoft.VisualBasic.Information.IsNumeric(s)
	End Function

	Public Function IsNumeric(ByVal o As Object) As Boolean
		Return ScheduleGlobals.IsNumeric(o.ToString)
	End Function

#End Region

#Region "SetErr"

	Public Sub SetErr(ByVal text As String)

		Try
			'Write the error the event log
			If Not EventLog.SourceExists("Gravitybox") Then
				EventLog.CreateEventSource("Gravitybox", "Gravitybox")
			End If
			EventLog.WriteEntry("Gravitybox", text, EventLogEntryType.Error)

			'#If DEBUG Then
			'Show the error form
			Dim F As New Gravitybox.Forms.ErrorForm(text)
			F.ShowDialog()
			'#Else
			'MsgBox(text, MsgBoxStyle.Exclamation, "Error!")
			'#End If

		Catch ex As Exception
			'Do Nothing
		End Try

	End Sub

	'Public Sub SetErr(ByVal ex As Exception)
	'	call ErrorModule.SetErr(ex.ToString)
	'End Sub

	Public Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
		ErrorModule.SetErr(e.Exception)
	End Sub

#End Region

End Module
