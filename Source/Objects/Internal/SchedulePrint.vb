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

Namespace Gravitybox.Objects

  Friend Class SchedulePrint

#Region "Class Members"

    'Private Variables
    Private ScheduleObject As Controls.Schedule
    Private CurrentPage As Integer
    Private CanvasColumns As Integer
    Private CanvasRows As Integer
    Private PageCount As Integer
    Private MyGraphics As Graphics
    Private OffScreenImage As Image
    Private WithEvents MyPrintPreview As New PrintPreviewDialog
    Private WithEvents MyDocument As New System.Drawing.Printing.PrintDocument
    Private OrigMinDate As DateTime
    Private OrigMaxDate As DateTime
    Private OrigStartTime As DateTime
    Private OrigDayLength As Integer
    Private OrigRedraw As Boolean
    Private FirstVisibleColumn As Integer
    Private FirstVisibleRow As Integer
    Private DialogSettings As PrintDialogSettings
    Private PageNumber As Integer = 1
    Private HeaderHeight As Integer = 0
    Private FooterHeight As Integer = 0
    'Private PageWidth As Integer = 0
    'Private PageHeight As Integer = 0
    Private OrigScheduleWidth As Integer = -1
    Private OrigScheduleHeight As Integer = -1

    Private HeaderTextHeight As Integer = 0
    Private FooterTextHeight As Integer = 0
    Private PageNumberTextHeight As Integer = 0

#End Region

#Region "Constructor"

    Friend Sub New(ByVal dialogSettings As PrintDialogSettings, ByVal schedule As Controls.Schedule)

      Try
        Me.DialogSettings = dialogSettings
        ScheduleObject = schedule
        Call SetupSchedule(dialogSettings)

        'Initialize to pleasing defaults
        MyPrintPreview.PrintPreviewControl.Columns = 2
        MyPrintPreview.PrintPreviewControl.Rows = 1
        MyPrintPreview.PrintPreviewControl.StartPage = 0
				MyPrintPreview.PrintPreviewControl.Zoom = dialogSettings.Zoom / 100.0

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Property Implementations"

    Public ReadOnly Property PrinterWidth() As Integer
      Get
        Return PrintClientRectangle.Width
      End Get
    End Property

    Public ReadOnly Property PrinterHeight() As Integer
      Get
        Return PrintClientRectangle.Height
      End Get
    End Property

    Public ReadOnly Property PrintClientRectangle() As Rectangle
      Get
        Return New Rectangle(Me.DialogSettings.PageSettings.Margins.Left, Me.DialogSettings.PageSettings.Margins.Top, MyPrintPreview.Document.PrinterSettings.DefaultPageSettings.Bounds.Width - Me.DialogSettings.PageSettings.Margins.Right - Me.DialogSettings.PageSettings.Margins.Left, MyPrintPreview.Document.PrinterSettings.DefaultPageSettings.Bounds.Height - Me.DialogSettings.PageSettings.Margins.Bottom - Me.DialogSettings.PageSettings.Margins.Top)
      End Get
    End Property

    Public ReadOnly Property PageImageHeight() As Integer
      Get
        Dim headerValue As Integer
        Dim footerValue As Integer
        Select Case DialogSettings.PageNumberPosition
          Case PrintDialogSettings.PrintPositionConstants.LeftTop, PrintDialogSettings.PrintPositionConstants.RightTop
            headerValue = GetMax(Me.HeaderTextHeight, Me.PageNumberTextHeight)
          Case PrintDialogSettings.PrintPositionConstants.LeftBottom, PrintDialogSettings.PrintPositionConstants.RightBottom
            footerValue = GetMax(Me.FooterTextHeight, Me.PageNumberTextHeight)
        End Select
        Dim retval As Integer = Me.PrinterHeight - (headerValue + footerValue)
        If retval < 0 Then retval = 0 'Error Correct
        Return retval
      End Get
    End Property

#End Region

#Region "SetupSchedule"

    Private Sub SetupSchedule(ByVal dialogSettings As PrintDialogSettings)

      Try
        'Cache original schedule settings
        OrigMinDate = ScheduleObject.MinDate
        OrigMaxDate = ScheduleObject.MaxDate
        OrigStartTime = ScheduleObject.StartTime
        OrigDayLength = ScheduleObject.DayLength
        FirstVisibleColumn = ScheduleObject.Visibility.FirstVisibleColumn
        FirstVisibleRow = ScheduleObject.Visibility.FirstVisibleRow

        OrigRedraw = ScheduleObject.AutoRedraw
        ScheduleObject.AutoRedraw = False

        MyPrintPreview.Document = MyDocument
        MyPrintPreview.Document.PrinterSettings.DefaultPageSettings.Landscape = Me.DialogSettings.PageSettings.Landscape
        MyPrintPreview.Document.DefaultPageSettings.Landscape = Me.DialogSettings.PageSettings.Landscape

        'Cache the the Page width/height
        'PageWidth = MyPrintPreview.Document.PrinterSettings.DefaultPageSettings.Bounds.Width - (Me.DialogSettings.PageSettings.Margins.Left + Me.DialogSettings.PageSettings.Margins.Right)
        'PageHeight = MyPrintPreview.Document.PrinterSettings.DefaultPageSettings.Bounds.Height - (Me.DialogSettings.PageSettings.Margins.Top + Me.DialogSettings.PageSettings.Margins.Bottom)
        ScheduleObject.Visibility.PrinterPageWidth = Me.PrinterWidth
        ScheduleObject.Visibility.PrinterPageHeight = Me.PrinterHeight

        If ScheduleObject.ColumnHeader.AutoFit OrElse ScheduleObject.IsHeaderFixed Then
          OrigScheduleWidth = ScheduleObject.Width
          ScheduleObject.Width = Me.PrinterHeight
        End If

        If ScheduleObject.RowHeader.AutoFit OrElse ScheduleObject.IsHeaderFixed Then
          OrigScheduleHeight = ScheduleObject.Height
          ScheduleObject.Height = Me.PrinterHeight
        End If

        'Setup schedule to the specified values
        Call ScheduleObject.SetMinMaxDate(dialogSettings.StartDate, dialogSettings.EndDate)
        ScheduleObject.StartTime = dialogSettings.StartTime
        ScheduleObject.DayLength = dialogSettings.DayLength
        ScheduleObject.VScroll1.Value = 0
        ScheduleObject.HScroll1.Value = 0

        'Calculate the header/footer height
        OffScreenImage = New Bitmap(100, 100)
        MyGraphics = Graphics.FromImage(OffScreenImage)
        HeaderTextHeight = GetIntlInteger(MyGraphics.MeasureString("W", CreateFont(dialogSettings.HeaderAppearance, ScheduleObject.Font.FontFamily)).Height)
        FooterTextHeight = GetIntlInteger(MyGraphics.MeasureString("W", CreateFont(dialogSettings.FooterAppearance, ScheduleObject.Font.FontFamily)).Height)
        PageNumberTextHeight = GetIntlInteger(MyGraphics.MeasureString("W", CreateFont(dialogSettings.PageNumberAppearance, ScheduleObject.Font.FontFamily)).Height)

        'Raise the setup event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.PrintSetupEventArgs(HeaderTextHeight, FooterTextHeight)
        ScheduleObject.FireEventPrintSetup(Me, eventParam1)
        HeaderTextHeight = eventParam1.HeaderHeight
        FooterTextHeight = eventParam1.FooterHeight

        'If page numbers OR header text then there is a header
        If (dialogSettings.HeaderText <> "") OrElse _
           (((dialogSettings.PageNumberPosition = PrintDialogSettings.PrintPositionConstants.LeftTop) OrElse _
           (dialogSettings.PageNumberPosition = PrintDialogSettings.PrintPositionConstants.RightTop))) Then
          HeaderHeight = HeaderTextHeight
        End If

        'If page numbers OR footer text then there is a footer
        If (dialogSettings.FooterText <> "") OrElse _
           (((dialogSettings.PageNumberPosition = PrintDialogSettings.PrintPositionConstants.LeftBottom) OrElse _
           (dialogSettings.PageNumberPosition = PrintDialogSettings.PrintPositionConstants.RightBottom))) Then
          FooterHeight = FooterTextHeight
        End If

        'Calculate the total number of pages vertical and horizontal
        CanvasColumns = ScheduleObject.Visibility.TotalWidth \ Me.PrinterWidth
        If (ScheduleObject.Visibility.TotalWidth Mod Me.PrinterWidth) > 0 Then
          CanvasColumns += 1
        End If
				If Me.PageImageHeight = 0 Then
					CanvasRows = 0
				Else
					CanvasRows = ScheduleObject.Visibility.TotalHeight \ Me.PageImageHeight
					If (ScheduleObject.Visibility.TotalHeight Mod Me.PageImageHeight) > 0 Then
						CanvasRows += 1
					End If
				End If

				'Calculate the page count
				PageCount = CanvasColumns * CanvasRows
				PageNumber = dialogSettings.PageStartNumber

				MyPrintPreview.PrintPreviewControl.Columns = CanvasColumns
				MyPrintPreview.PrintPreviewControl.Rows = CanvasRows

				'****************************************
				'Draw the schedule
				Dim width As Integer = ScheduleObject.Visibility.TotalWidth + 1
				Dim height As Integer = ScheduleObject.Visibility.TotalHeight + 1
				If ScheduleObject.IsHeaderFixed Then
					width = Me.PrinterWidth
					height = Me.PrinterHeight
				End If

				If width <= 0 Then width = 1
				If height <= 0 Then height = 1
				OffScreenImage = New Bitmap(width, height)
				MyGraphics = Graphics.FromImage(OffScreenImage)

				Dim Canvas As New Gravitybox.Drawing.DrawScheduleMain(ScheduleObject)
				Call Canvas.InternalRefresh(MyGraphics)
				'****************************************

			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub ResetSchedule()

      'Redraw the schedule as it was originaly was
      Try
        Me.PageNumber = DialogSettings.PageStartNumber
        Call ScheduleObject.SetMinMaxDate(OrigMinDate, OrigMaxDate)
        ScheduleObject.StartTime = OrigStartTime
        ScheduleObject.DayLength = OrigDayLength
        ScheduleObject.AutoRedraw = OrigRedraw
        ScheduleObject.Visibility.FirstVisibleColumn = FirstVisibleColumn
        ScheduleObject.Visibility.FirstVisibleRow = FirstVisibleRow
        ScheduleObject.OnRefresh()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "GetMarginRectangle"

		'Private Function GetMarginRectangle(ByVal g As Graphics, ByVal inchRect As System.Drawing.Printing.Margins) As System.Drawing.Printing.Margins

		'	Dim scalingFactor As PointF = New PointF(1.0F / g.DpiX, 1.0F / g.DpiY)
		'	Dim retval As New System.Drawing.Printing.Margins
		'	retval.Left = CInt(inchRect.Left * scalingFactor.X)
		'	retval.Right = CInt(inchRect.Right * scalingFactor.X)
		'	retval.Top = CInt(inchRect.Top * scalingFactor.Y)
		'	retval.Bottom = CInt(inchRect.Bottom * scalingFactor.Y)
		'	Return retval

		'End Function

#End Region

#Region "ShowDialog"

		Friend Sub ShowDialog()

			Try
				MyPrintPreview.Controls(1).Controls(0).Text = Me.DialogSettings.PageLabelText
				MyPrintPreview.Controls(1).Controls(2).Text = Me.DialogSettings.CancelButtonText
				Dim toolbar As System.Windows.Forms.ToolBar = CType(MyPrintPreview.Controls(1), System.Windows.Forms.ToolBar)
				toolbar.Buttons(0).ToolTipText = Me.DialogSettings.PrintToolTip
				toolbar.Buttons(1).ToolTipText = Me.DialogSettings.ZoomToolTip
				toolbar.Buttons(3).ToolTipText = Me.DialogSettings.OnePageToolTip
				toolbar.Buttons(4).ToolTipText = Me.DialogSettings.TwoPagesToolTip
				toolbar.Buttons(5).ToolTipText = Me.DialogSettings.ThreePagesToolTip
				toolbar.Buttons(6).ToolTipText = Me.DialogSettings.FourPagesToolTip
				toolbar.Buttons(7).ToolTipText = Me.DialogSettings.SixPagesToolTip
			Catch ex As Exception
				'Do Nothing
			End Try

			Try
				MyDocument.PrinterSettings = Me.DialogSettings.PageSettings.PrinterSettings
				MyDocument.OriginAtMargins = False
				MyPrintPreview.Document = MyDocument
				MyPrintPreview.AllowDrop = False
				MyPrintPreview.ShowInTaskbar = True
				MyPrintPreview.SizeGripStyle = SizeGripStyle.Auto
				MyPrintPreview.StartPosition = Me.DialogSettings.StartPosition
				MyPrintPreview.Location = Me.DialogSettings.Location
				MyPrintPreview.Size = Me.DialogSettings.Size
				MyPrintPreview.WindowState = Me.DialogSettings.WindowState
				MyPrintPreview.FormBorderStyle = Me.DialogSettings.FormBorderStyle
				MyPrintPreview.Text = Me.DialogSettings.WindowText
				MyPrintPreview.Icon = Me.DialogSettings.Icon
				MyPrintPreview.ShowDialog()

				If (OrigScheduleWidth <> -1) Then ScheduleObject.Width = OrigScheduleWidth
				If (OrigScheduleHeight <> -1) Then ScheduleObject.Height = OrigScheduleHeight

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Event Handlers"

		Public Sub CloseClick(ByVal sender As Object, ByVal e As System.EventArgs)
			MyPrintPreview.Close()
		End Sub

#End Region

#Region "Print"

		Public Sub Print()

			Try
				MyDocument.PrinterSettings = Me.DialogSettings.PageSettings.PrinterSettings
				Call MyDocument.Print()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "MyDocument Events"

		Private Sub MyDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles MyDocument.PrintPage

			Try
        e.PageSettings.Color = Me.DialogSettings.PageSettings.Color
        e.PageSettings.Margins = Me.DialogSettings.PageSettings.Margins
				e.PageSettings.PaperSize = Me.DialogSettings.PageSettings.PaperSize
				e.PageSettings.PaperSource = Me.DialogSettings.PageSettings.PaperSource
				e.PageSettings.PrinterResolution = Me.DialogSettings.PageSettings.PrinterResolution
        e.PageSettings.PrinterSettings = Me.DialogSettings.PageSettings.PrinterSettings

        Dim marginRect As Rectangle = Me.PrintClientRectangle

				'Print the header
				If HeaderHeight > 0 Then
					Dim rect As New Rectangle(marginRect.Left, marginRect.Top, marginRect.Width, HeaderTextHeight)

					'Raise an event to the client to inform of progress
					Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforePrintSectionEventArgs(e.Graphics, Me.PageNumber, rect)
					Call ScheduleObject.FireEventBeforePrintHeader(Me, eventParam1)
					If Not eventParam1.Handled Then
						Dim textFont As Font = CreateFont(DialogSettings.HeaderAppearance, ScheduleObject.Font.FontFamily)
						Dim stringFormat As StringFormat = CreateStringFormat(DialogSettings.HeaderAppearance)
						Dim textPen As Pen = CreateTextPen(DialogSettings.HeaderAppearance)
						e.Graphics.DrawString(DialogSettings.HeaderText, textFont, textPen.Brush, ConvertRectangle(rect), stringFormat)
						textPen.Dispose()
						textFont.Dispose()
					End If
				End If

				'Print the footer
				If FooterHeight > 0 Then
					Dim rect As New Rectangle(marginRect.Left, marginRect.Bottom - FooterTextHeight, Me.PrinterWidth, FooterTextHeight)

					'Raise an event to the client to inform of progress
					Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforePrintSectionEventArgs(e.Graphics, Me.PageNumber, rect)
					Call ScheduleObject.FireEventBeforePrintFooter(Me, eventParam1)
					If Not eventParam1.Handled Then
						Dim textFont As Font = CreateFont(DialogSettings.FooterAppearance, ScheduleObject.Font.FontFamily)
						Dim stringFormat As StringFormat = CreateStringFormat(DialogSettings.FooterAppearance)
						Dim textPen As Pen = CreateTextPen(DialogSettings.FooterAppearance)
						e.Graphics.DrawString(DialogSettings.FooterText, textFont, textPen.Brush, ConvertRectangle(rect), stringFormat)
						textPen.Dispose()
						textFont.Dispose()
					End If
				End If

				'Print the page number
				If DialogSettings.PageNumberPosition <> PrintDialogSettings.PrintPositionConstants.None Then
					Dim textFont As Font = CreateFont(DialogSettings.PageNumberAppearance, ScheduleObject.Font.FontFamily)
					Dim rect As System.Drawing.Rectangle
					Dim pageNumberText As String = DialogSettings.PageHeader & Me.PageNumber.ToString
					Dim textSize As SizeF = e.Graphics.MeasureString(pageNumberText, textFont)
					textSize.Width += 2
					Select Case DialogSettings.PageNumberPosition
						Case PrintDialogSettings.PrintPositionConstants.LeftTop
							rect = New Rectangle(marginRect.Left, marginRect.Top, GetIntlInteger(textSize.Width), GetIntlInteger(textSize.Height))
						Case PrintDialogSettings.PrintPositionConstants.LeftBottom
							rect = New Rectangle(marginRect.Left, marginRect.Bottom - GetIntlInteger(textSize.Height), GetIntlInteger(textSize.Width), GetIntlInteger(textSize.Height))
						Case PrintDialogSettings.PrintPositionConstants.RightTop
							rect = New Rectangle(marginRect.Right - GetIntlInteger(textSize.Width), marginRect.Top, GetIntlInteger(textSize.Width), GetIntlInteger(textSize.Height))
						Case PrintDialogSettings.PrintPositionConstants.RightBottom
							rect = New Rectangle(marginRect.Right - GetIntlInteger(textSize.Width), marginRect.Bottom - GetIntlInteger(textSize.Height), GetIntlInteger(textSize.Width), GetIntlInteger(textSize.Height))
					End Select

					'Raise an event to the client to inform of progress
					Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforePrintSectionEventArgs(e.Graphics, Me.PageNumber, rect)
					Call ScheduleObject.FireEventBeforePrintPageNumber(Me, eventParam1)
					If Not eventParam1.Handled Then
						Dim stringFormat As StringFormat = CreateStringFormat(DialogSettings.PageNumberAppearance)
						Dim textPen As Pen = CreateTextPen(DialogSettings.PageNumberAppearance)
						e.Graphics.DrawString(pageNumberText, textFont, textPen.Brush, ConvertRectangle(rect), stringFormat)
						textPen.Dispose()
					End If
					textFont.Dispose()

				End If

				'Print the image if there is one
				If Me.PageImageHeight > 0 Then
					Dim srcRect As RectangleF = New RectangleF(Me.PrinterWidth * (CurrentPage Mod CanvasColumns), Me.PageImageHeight * (CurrentPage \ CanvasColumns), Me.PrinterWidth, Me.PageImageHeight)
					Dim destRect As RectangleF = New RectangleF(marginRect.Left, marginRect.Top + Me.HeaderHeight, marginRect.Width, Me.PageImageHeight)
					e.Graphics.DrawImage(OffScreenImage, destRect, srcRect, GraphicsUnit.Pixel)
				End If

				'Check for End of File or End Of Printing Selection.
				If CurrentPage + 1 >= PageCount Or _
				 (MyDocument.PrinterSettings.PrintRange = System.Drawing.Printing.PrintRange.SomePages _
				 And CurrentPage + 1 >= MyDocument.PrinterSettings.ToPage) Then

					e.HasMorePages = False
				Else
					CurrentPage += 1
					e.HasMorePages = True
				End If

				'If this is the last page then repaint the schedule 
				'with original settings before anyone is the wiser
				If Not e.HasMorePages Then
					Call ResetSchedule()
				End If

				'Raise an event to the client to inform of progress
				Dim eventParam As New Gravitybox.Objects.EventArgs.PrintEventArgs(CurrentPage, PageCount)
				Call ScheduleObject.FireEventPrintProgress(Me, eventParam)

				'Was the print canceled programmatically
				If eventParam.Cancel Then
					e.HasMorePages = False
					Call ScheduleObject.FireEventPrintCanceled()
				End If

				'Increment to the next page number
        Me.PageNumber += 1

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub MyDocument_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles MyDocument.QueryPageSettings

			Try
        'The cancel was choosen from the popup dialog 
        e.PageSettings.Landscape = Me.DialogSettings.PageSettings.Landscape
				If e.Cancel Then
					Call ScheduleObject.FireEventPrintCanceled()
					CurrentPage = 0
					PageNumber = 1
				Else
					e.PageSettings.Margins = Me.DialogSettings.PageSettings.Margins
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub MyDocument_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyDocument.EndPrint
			'Reset the printing cache
			CurrentPage = 0
			PageNumber = 1
		End Sub

#End Region

	End Class

End Namespace