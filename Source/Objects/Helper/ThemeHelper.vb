Imports Gravitybox.Objects
Imports Gravitybox.Controls

Friend Class ThemeHelper

#Region "SetupStyle"

	Public Shared Sub SetupStyleTheme(ByVal schedule As Gravitybox.Controls.Schedule, ByVal theme As Schedule.ThemeConstants)
		Select Case theme
			Case Gravitybox.Controls.Schedule.ThemeConstants.Office2003
				SetupStyleOffice2003(schedule)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Office2007
				SetupStyleOffice2007(schedule)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Olive
				'Olive
				Dim colorDark As Color = Color.FromArgb(&HB6, &HA4, &H67)
				Dim colorLight As Color = Color.FromArgb(&HE2, &HE5, &HCC)
				Dim colorMiddle As Color = Color.FromArgb(&HBA, &HC8, &H9E)
				Dim colorText As Color = Color.FromArgb(&H58, &H58, &H58)
				SetupStyleTheme2(schedule, colorDark, colorLight, colorMiddle, colorText)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Sunny
				'Sunny
				Dim colorDark As Color = Color.FromArgb(&HFF, &HB6, &H9)
				Dim colorLight As Color = Color.FromArgb(&HFF, &HF5, &HA8)
				Dim colorMiddle As Color = Color.FromArgb(&HF9, &HF3, &H5C)
				Dim colorText As Color = Color.FromArgb(&H93, &H19, &H7)
				SetupStyleTheme2(schedule, colorDark, colorLight, colorMiddle, colorText)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Energy
				'Energy
				Dim colorDark As Color = Color.FromArgb(&HFF, &H2F, &H9)
				Dim colorLight As Color = Color.FromArgb(&HFF, &HD0, &HA8)
				Dim colorMiddle As Color = Color.FromArgb(&HF8, &HB6, &H5D)
				Dim colorText As Color = Color.FromArgb(&H93, &H19, &H7)
				SetupStyleTheme2(schedule, colorDark, colorLight, colorMiddle, colorText)
		End Select
	End Sub

	Private Shared Sub SetupStyleOffice2003(ByVal Schedule1 As Gravitybox.Controls.Schedule)

		Schedule1.AutoRedraw = False
		Try
			Schedule1.EventHeader.Appearance.BackColor = Color.FromArgb(&HA6, &HC0, &HE1)
			Schedule1.EventHeader.Appearance.BorderColor = Schedule1.EventHeader.Appearance.BackColor
			Schedule1.EventHeader.Appearance.BorderWidth = 0

			'Grid Appearance
			Schedule1.Appearance = New GridAppearance
			Schedule1.Appearance.BackColor = Color.FromArgb(&HFF, &HFF, &HD6)
			Schedule1.Appearance.BorderWidth = 0
			Schedule1.Appearance.ItemLineColor = Color.FromArgb(&HE6, &HDF, &HB1)
			Schedule1.Appearance.ItemLineWidth = 1
			Schedule1.Appearance.MajorLineColor = Color.FromArgb(&HE6, &HDF, &HB1)
			Schedule1.Appearance.MajorLineWidth = 1
			Schedule1.Appearance.MinorLineColor = Color.FromArgb(&HE6, &HDF, &HB1)
			Schedule1.Appearance.MinorLineWidth = 1

			'Column Header
			Schedule1.ColumnHeader.Appearance = New Appearance
			Schedule1.ColumnHeader.Appearance.BackColor = Color.FromArgb(&HEC, &HE9, &HD8)
			Schedule1.ColumnHeader.Appearance.BorderColor = Color.FromArgb(&HAC, &HA9, &H98)
			Schedule1.ColumnHeader.Appearance.ForeColor = Color.Black
			Schedule1.ColumnHeader.Appearance.FontSize = 8
			Schedule1.ColumnHeader.Appearance.Alignment = StringAlignment.Center

			'Row Header
			Schedule1.RowHeader.Appearance = New Appearance
			Schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(&HEC, &HE9, &HD8)
			Schedule1.RowHeader.Appearance.BorderColor = Color.FromArgb(&HAC, &HA9, &H98)
			Schedule1.RowHeader.Appearance.ForeColor = Color.Black
			Schedule1.RowHeader.Appearance.FontSize = 8
			Schedule1.RowHeader.Appearance.Alignment = StringAlignment.Near

			'Selector
			Schedule1.Selector.Appearance = New Appearance
			Schedule1.Selector.Appearance = New Appearance()
			Schedule1.Selector.Appearance.BackColor = Color.FromArgb(&H29, &H4C, &H7A)

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		Finally
			Schedule1.AutoRedraw = True
		End Try

	End Sub

	Private Shared Sub SetupStyleOffice2007(ByVal Schedule1 As Gravitybox.Controls.Schedule)

		Schedule1.AutoRedraw = False
		Try
			Schedule1.EventHeader.Appearance.BackColor = Color.FromArgb(&HA6, &HC0, &HE1)
			Schedule1.EventHeader.Appearance.BorderColor = Schedule1.EventHeader.Appearance.BackColor
			Schedule1.EventHeader.Appearance.BorderWidth = 0

			'Grid Appearance
			Schedule1.Appearance = New GridAppearance
			Schedule1.Appearance.BackColor = Color.White
			Schedule1.Appearance.BorderWidth = 0
			Schedule1.Appearance.ItemLineColor = Color.FromArgb(&H5D, &H8C, &HC9)
			Schedule1.Appearance.ItemLineWidth = 1
			Schedule1.Appearance.ItemLineWidth = 2
			Schedule1.Appearance.MajorLineColor = Color.FromArgb(&HA5, &HBF, &HE1)
			Schedule1.Appearance.MajorLineWidth = 1
			Schedule1.Appearance.MinorLineColor = Color.FromArgb(&HD5, &HE1, &HF1)
			Schedule1.Appearance.MinorLineWidth = 1

			'Column Header
			Schedule1.ColumnHeader.Appearance = New Appearance
			Schedule1.ColumnHeader.Appearance.BackColor = Color.FromArgb(&HE4, &HEC, &HF6)
			Schedule1.ColumnHeader.Appearance.BackColor2 = Color.FromArgb(&HD0, &HDE, &HEF)
			Schedule1.ColumnHeader.Appearance.BackGradientStyle = GradientStyleConstants.Vertical
			Schedule1.ColumnHeader.Appearance.BorderColor = Color.FromArgb(&H8D, &HAE, &HD9)
			Schedule1.ColumnHeader.Appearance.ForeColor = Color.Black
			Schedule1.ColumnHeader.Appearance.FontSize = 8
			Schedule1.ColumnHeader.Appearance.Alignment = StringAlignment.Center

			'Row Header
			Schedule1.RowHeader.Appearance = New Appearance
			Schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(&HD6, &HE2, &HF1)
			Schedule1.RowHeader.Appearance.BackColor2 = Color.FromArgb(&HF5, &HBB, &H4E)
			Schedule1.RowHeader.Appearance.BorderColor = Color.FromArgb(&H68, &H93, &HCC)
			Schedule1.RowHeader.Appearance.ForeColor = Color.FromArgb(&H68, &H93, &HCC)
			Schedule1.RowHeader.Appearance.FontSize = 8
			Schedule1.RowHeader.Appearance.Alignment = StringAlignment.Near

			'Selector
			Schedule1.Selector.Appearance = New Appearance
			Schedule1.Selector.Appearance = New Appearance()
			Schedule1.Selector.Appearance.BackColor = Color.FromArgb(&H29, &H4C, &H7A)

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		Finally
			Schedule1.AutoRedraw = True
		End Try

	End Sub

	Private Shared Sub SetupStyleTheme2(ByVal Schedule1 As Gravitybox.Controls.Schedule, ByVal colorDark As Color, ByVal colorLight As Color, ByVal colorMiddle As Color, ByVal colorText As Color)

		Schedule1.AutoRedraw = False
		Try
			Schedule1.EventHeader.Appearance.BackColor = colorLight
			Schedule1.EventHeader.Appearance.BorderColor = Schedule1.EventHeader.Appearance.BackColor
			Schedule1.EventHeader.Appearance.BorderWidth = 0

			'Grid Appearance
			Schedule1.Appearance = New GridAppearance
			Schedule1.Appearance.BackColor = colorLight
			Schedule1.Appearance.BorderWidth = 0
			Schedule1.Appearance.ItemLineColor = colorDark
			Schedule1.Appearance.ItemLineWidth = 1
			Schedule1.Appearance.ItemLineWidth = 2
			Schedule1.Appearance.MajorLineColor = colorDark
			Schedule1.Appearance.MajorLineWidth = 1
			Schedule1.Appearance.MinorLineColor = colorMiddle
			Schedule1.Appearance.MinorLineWidth = 1

			'Column Header
			Schedule1.ColumnHeader.Appearance = New Appearance
			Schedule1.ColumnHeader.Appearance.BackColor = colorLight
			Schedule1.ColumnHeader.Appearance.BackColor2 = colorMiddle
			Schedule1.ColumnHeader.Appearance.BackGradientStyle = GradientStyleConstants.Vertical
			Schedule1.ColumnHeader.Appearance.BorderColor = colorDark
			Schedule1.ColumnHeader.Appearance.ForeColor = colorText
			Schedule1.ColumnHeader.Appearance.FontSize = 8
			Schedule1.ColumnHeader.Appearance.Alignment = StringAlignment.Center

			'Row Header
			Schedule1.RowHeader.Appearance = New Appearance
			Schedule1.RowHeader.Appearance.BackColor = colorMiddle
			Schedule1.RowHeader.Appearance.BorderColor = colorDark
			Schedule1.RowHeader.Appearance.ForeColor = colorText
			Schedule1.RowHeader.Appearance.FontSize = 8
			Schedule1.RowHeader.Appearance.Alignment = StringAlignment.Near

			'Selector
			Schedule1.Selector.Appearance = New Appearance
			Schedule1.Selector.Appearance = New Appearance()
			Schedule1.Selector.Appearance.BackColor = colorDark

		Catch ex As Exception
			Call ErrorModule.SetErr(ex)
		Finally
			Schedule1.AutoRedraw = True
		End Try

	End Sub

#End Region

#Region "SetupAppointment"

	Public Shared Sub SetupStyleAppointmentTheme(ByVal schedule As Schedule, ByVal theme As Schedule.ThemeConstants)

		Select Case theme
			Case Gravitybox.Controls.Schedule.ThemeConstants.Office2003
				SetupAppointmentStyleOffice2003(schedule)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Office2007
				SetupAppointmentStyleOffice2007(schedule)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Olive
				'Olive
				Dim colorDark As Color = Color.FromArgb(&HB6, &HA4, &H67)
				Dim colorLight As Color = Color.FromArgb(&HE2, &HE5, &HCC)
				Dim colorMiddle As Color = Color.FromArgb(&HBA, &HC8, &H9E)
				Dim colorText As Color = Color.FromArgb(&H58, &H58, &H58)
				SetupAppointmentStyle(schedule, colorDark, colorLight, colorMiddle, colorText)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Energy
				Dim colorDark As Color = Color.FromArgb(&HFF, &H2F, &H9)
				Dim colorLight As Color = Color.FromArgb(&HFF, &HD0, &HA8)
				Dim colorMiddle As Color = Color.FromArgb(&HF8, &HB6, &H5D)
				Dim colorText As Color = Color.FromArgb(&H93, &H19, &H7)
				SetupAppointmentStyle(schedule, colorDark, colorLight, colorMiddle, colorText)
			Case Gravitybox.Controls.Schedule.ThemeConstants.Sunny
				Dim colorDark As Color = Color.FromArgb(&HFF, &HB6, &H9)
				Dim colorLight As Color = Color.FromArgb(&HFF, &HF5, &HA8)
				Dim colorMiddle As Color = Color.FromArgb(&HF9, &HF3, &H5C)
				Dim colorText As Color = Color.FromArgb(&H93, &H19, &H7)
				SetupAppointmentStyle(schedule, colorDark, colorLight, colorMiddle, colorText)
		End Select
	End Sub

	Private Shared Sub SetupAppointmentStyle(ByVal schedule As Schedule, ByVal colorDark As Color, ByVal colorLight As Color, ByVal colorMiddle As Color, ByVal colorText As Color)

		'Create an Appointment appearance
		Dim appearance As AppointmentAppearance = New AppointmentAppearance()
		appearance.BackColor = Color.White
		'appearance.BackColor = colorLight
		'appearance.BackColor2 = colorMiddle
		'appearance.BackGradientStyle = GradientStyleConstants.Vertical
		appearance.BorderColor = colorDark
		appearance.ForeColor = colorText
		appearance.FontBold = False
		appearance.IsRound = True
		appearance.FontSize = 8
		appearance.ShadowSize = 5
		schedule.DefaultAppointmentAppearance = appearance

		Dim headerAppearance As New AppointmentHeaderAppearance
		headerAppearance.FontBold = True
		headerAppearance.BackColor = colorLight
		headerAppearance.BorderColor = colorDark
		headerAppearance.ForeColor = colorText
		schedule.DefaultAppointmentHeaderAppearance = headerAppearance

	End Sub

	Private Shared Sub SetupAppointmentStyleOffice2003(ByVal schedule As Schedule)

		'Create an Appointment appearance
		Dim appearance As AppointmentAppearance = New AppointmentAppearance()
		appearance.BackColor = Color.White
		appearance.BorderColor = Color.Black
		appearance.FontBold = False
		appearance.IsRound = False
		appearance.FontSize = 8
		appearance.ShadowSize = 5
		schedule.DefaultAppointmentAppearance = appearance

		Dim headerAppearance As New AppointmentHeaderAppearance
		headerAppearance.FontBold = True
		headerAppearance.BackColor = Color.White
		headerAppearance.BorderColor = appearance.BorderColor
		headerAppearance.ForeColor = appearance.ForeColor
		schedule.DefaultAppointmentHeaderAppearance = headerAppearance

	End Sub

	Private Shared Sub SetupAppointmentStyleOffice2007(ByVal schedule As Schedule)

		'Create an Appointment appearance
		Dim appearance As AppointmentAppearance = New AppointmentAppearance()
		appearance.BackColor = Color.White
		appearance.BackColor2 = Color.FromArgb(&HC0, &HD3, &HEA)
		appearance.BackGradientStyle = GradientStyleConstants.Vertical
		appearance.BorderColor = Color.FromArgb(&H5D, &H8C, &HC9)
		appearance.FontBold = False
		appearance.IsRound = True
		appearance.FontSize = 8
		appearance.ShadowSize = 5
		schedule.DefaultAppointmentAppearance = appearance

		Dim headerAppearance As New AppointmentHeaderAppearance
		headerAppearance.FontBold = True
		headerAppearance.BackColor = Color.White
		headerAppearance.BorderColor = appearance.BorderColor
		headerAppearance.ForeColor = appearance.ForeColor
		schedule.DefaultAppointmentHeaderAppearance = headerAppearance

	End Sub

#End Region

End Class
