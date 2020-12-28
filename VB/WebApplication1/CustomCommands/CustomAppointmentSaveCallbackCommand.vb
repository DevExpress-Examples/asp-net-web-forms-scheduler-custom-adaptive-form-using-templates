Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Controls
Imports DevExpress.Web.ASPxScheduler.Internal
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Internal
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace WebApplication1.CustomCommands
	Public Class CustomAppointmentSaveCallbackCommand
		Inherits AppointmentFormSaveCallbackCommand
		Public Sub New(ByVal control As ASPxScheduler)
			MyBase.New(control)
		End Sub

		Protected Overrides Sub AssignControllerValues()
			MyBase.AssignControllerValues()
		End Sub

		Protected Overrides Sub AssignControllerRecurrenceValues(ByVal clientStart As DateTime)
			'base.AssignControllerRecurrenceValues(clientStart);
			If ShouldShowRecurrence() Then

				Dim patternCopy As Appointment = Controller.PrepareToRecurrenceEdit()
				Dim rinfo As IRecurrenceInfo = patternCopy.RecurrenceInfo

				Dim cbRecurrenceType As ASPxComboBox = TryCast(FindControlByID("cbRecurrenceType"), ASPxComboBox)
				Dim dailyControl As DailyRecurrenceControl = TryCast(FindControlByID("dailyControl"), DailyRecurrenceControl)
				Dim weeklyControl As WeeklyRecurrenceControl = TryCast(FindControlByID("weeklyControl"), WeeklyRecurrenceControl)
				Dim monthlyControl As MonthlyRecurrenceControl = TryCast(FindControlByID("monthlyControl"), MonthlyRecurrenceControl)
				Dim yearlyControl As YearlyRecurrenceControl = TryCast(FindControlByID("yearlyControl"), YearlyRecurrenceControl)

				Dim rangeControl As RecurrenceRangeControl = TryCast(FindControlByID("rangeControl"), RecurrenceRangeControl)

				Select Case cbRecurrenceType.Value
					Case "Daily"
						rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Daily
						rinfo.Periodicity = dailyControl.ClientPeriodicity
						rinfo.WeekDays = dailyControl.ClientWeekDays
					Case "Weekly"
						rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Weekly
						rinfo.Periodicity = weeklyControl.ClientPeriodicity
						rinfo.WeekDays = weeklyControl.ClientWeekDays
					Case "Monthly"
						rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Monthly
						rinfo.DayNumber = monthlyControl.ClientDayNumber
						rinfo.Periodicity = monthlyControl.ClientPeriodicity
						rinfo.WeekDays = monthlyControl.ClientWeekDays
						rinfo.WeekOfMonth = monthlyControl.ClientWeekOfMonth
					Case "Yearly"
						rinfo.Type = DevExpress.XtraScheduler.RecurrenceType.Yearly
						rinfo.DayNumber = yearlyControl.ClientDayNumber
						rinfo.Month = yearlyControl.ClientMonth
						rinfo.WeekDays = yearlyControl.ClientWeekDays
						rinfo.WeekOfMonth = yearlyControl.ClientWeekOfMonth
					Case Else
				End Select

				Dim [end] As DateTime = rangeControl.ClientEnd
				If (Not patternCopy.AllDay) AndAlso Control.TimeZoneHelper IsNot Nothing Then
					[end] = Control.TimeZoneHelper.FromClientTime([end])
				End If
				CType(rinfo, IInternalRecurrenceInfo).UpdateRange(clientStart, [end], rangeControl.ClientRange, rangeControl.ClientOccurrenceCount, patternCopy)

				Controller.ApplyRecurrence(patternCopy)
			End If
		End Sub

		Protected Overrides Function FindControlByID(ByVal id As String) As System.Web.UI.Control
			Return FindTemplateControl(TemplateContainer, id)
		End Function

		Private Function FindTemplateControl(ByVal RootControl As System.Web.UI.Control, ByVal id As String) As System.Web.UI.Control
			Dim foundedControl As System.Web.UI.Control = RootControl.FindControl(id)
			If foundedControl Is Nothing Then
				For Each item As System.Web.UI.Control In RootControl.Controls
					foundedControl = FindTemplateControl(item, id)
					If foundedControl IsNot Nothing Then
						Exit For
					End If
				Next item
			End If
			Return foundedControl
		End Function
	End Class
End Namespace