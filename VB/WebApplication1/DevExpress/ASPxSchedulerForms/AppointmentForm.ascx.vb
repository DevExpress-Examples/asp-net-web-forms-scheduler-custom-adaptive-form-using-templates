Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports DevExpress.XtraScheduler
Imports DevExpress.Web
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal
Imports System.Collections
Imports System.Collections.Generic
Imports DevExpress.XtraScheduler.Localization
Imports DevExpress.Web.ASPxScheduler.Localization
Imports DevExpress.Utils
Imports System.Web.UI.WebControls
Imports DevExpress.Utils.Localization
Imports DevExpress.Web.ASPxScheduler.Controls

Partial Public Class AppointmentForm
	Inherits SchedulerFormControl
	Public Overrides ReadOnly Property ClassName() As String
		Get
			Return "ASPxAppointmentForm"
		End Get
	End Property

	Public ReadOnly Property CanShowReminders() As Boolean
		Get
			Return (CType(Parent, AppointmentFormTemplateContainer)).Control.Storage.EnableReminders
		End Get
	End Property

	Public ReadOnly Property ResourceSharing() As Boolean
		Get
			Return (CType(Parent, AppointmentFormTemplateContainer)).Control.Storage.ResourceSharing
		End Get
	End Property
	Public ReadOnly Property ResourceDataSource() As IEnumerable
		Get
			Return (CType(Parent, AppointmentFormTemplateContainer)).ResourceDataSource
		End Get
	End Property

	Public ReadOnly Property TimeZonesEnabled() As Boolean
		Get
			Return (CType(Parent, AppointmentFormTemplateContainer)).TimeZonesEnabled
		End Get
	End Property

	Protected Overrides Sub OnLoad(ByVal e As EventArgs)
		MyBase.OnLoad(e)
		Localize()
		tbSubject.Focus()
	End Sub
	Private Sub Localize()
		appointmentFormMainLayout.FindItemOrGroupByName("itemSubject").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Subject)
		appointmentFormMainLayout.FindItemOrGroupByName("itemLocation").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Location)
		appointmentFormMainLayout.FindItemOrGroupByName("itemLabel").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Label)
		appointmentFormMainLayout.FindItemOrGroupByName("itemStart").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_StartTime)
		appointmentFormMainLayout.FindItemOrGroupByName("itemEnd").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_EndTime)

		appointmentFormMainLayout.FindItemOrGroupByName("itemStatus").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Status)
		appointmentFormMainLayout.FindItemOrGroupByName("itemAllDay").Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_AllDayEvent)

		Dim multipleResourceItem As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("itemResourceMultiple")
		Dim singleResourceItem As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("itemResourceSingle")
		singleResourceItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Resource)
		multipleResourceItem.Caption = singleResourceItem.Caption
		multipleResourceItem.Visible = ResourceSharing
		singleResourceItem.Visible = Not ResourceSharing

		Dim reminderItem As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("itemReminder")
		reminderItem.Visible = CanShowReminders
		reminderItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Reminder)

		Dim timeZoneItem As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("itemTimeZone")
		timeZoneItem.Visible = TimeZonesEnabled
		timeZoneItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_TimeZone)

		Dim recInfoItem As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("itemRecurrenceInfo")
		recInfoItem.Caption = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_Recurrence)

		cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Daily), "Daily")
		cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Weekly), "Weekly")
		cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Monthly), "Monthly")
		cbRecurrenceType.Items.Add(ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Caption_RecurrenceType_Yearly), "Yearly")

		btnOk.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonOk)
		btnCancel.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonCancel)
		btnDelete.Text = ASPxSchedulerLocalizer.GetString(ASPxSchedulerStringId.Form_ButtonDelete)

		btnOk.Wrap = DefaultBoolean.False
		btnCancel.Wrap = DefaultBoolean.False
		btnDelete.Wrap = DefaultBoolean.False
	End Sub
	Public Overrides Sub DataBind()
		MyBase.DataBind()

		Dim container As AppointmentFormTemplateContainer = CType(Parent, AppointmentFormTemplateContainer)
		Dim apt As Appointment = container.Appointment
		Dim appointmentStorage As IAppointmentStorageBase = container.Control.Storage.Appointments
		Dim label As IAppointmentLabel = appointmentStorage.Labels.GetById(apt.LabelKey)
		Dim status As IAppointmentStatus = appointmentStorage.Statuses.GetById(apt.StatusKey)

		'SUBJECT
		tbSubject.Text = apt.Subject

		'LOCATION
		tbLocation.Text = apt.Location

		'LABEL
		edtLabel.ValueType = apt.LabelKey.GetType()
		edtLabel.SelectedIndex = appointmentStorage.Labels.IndexOf(label)
		edtLabel.DataSource = container.LabelDataSource
		edtLabel.DataBindItems()

		'STATUS
		edtStatus.ValueType = apt.StatusKey.GetType()
		edtStatus.SelectedIndex = appointmentStorage.Statuses.IndexOf(status)
		edtStatus.DataSource = container.StatusDataSource
		edtStatus.DataBindItems()

		'START
		edtStartDate.Date = apt.Start
		edtStartTime.DateTime = apt.Start

		'END
		edtEndDate.Date = apt.End
		edtEndTime.DateTime = apt.End

		'ALL DAY
		chkAllDay.Checked = apt.AllDay

		'REMINDER
		cbReminder.ValueType = GetType(String)
		cbReminder.DataSource = container.ReminderDataSource
		cbReminder.DataBindItems()
		cbReminder.Items.Insert(0, New ListEditItem("None", "None"))

		If apt.HasReminder Then
			cbReminder.Value = apt.Reminder.TimeBeforeStart.ToString()
		Else
			cbReminder.SelectedIndex = 0
		End If

		'DESCRIPTION
		tbDescription.Text = apt.Description

		'RESOURCE
		PopulateResourceEditors(apt, container)

		'TIME ZONE
		If TimeZonesEnabled Then
			cbTimeZone.DataSource = TimeZoneInfo.GetSystemTimeZones()
			cbTimeZone.ValueField = "Id"
			cbTimeZone.TextField = "DisplayName"
			cbTimeZone.DataBind()
			cbTimeZone.Value = container.TimeZoneId
			cbTimeZone.Enabled = apt.Type = AppointmentType.Normal OrElse apt.Type = AppointmentType.Pattern
		End If

		'RECCURRENCE
		PopulateRecurrenceFormEditors(container)

		schedulerStatusInfo.MasterControlID = container.Control.ID

		'btnOk.ClientSideEvents.Click = container.SaveHandler;
		btnCancel.ClientSideEvents.Click = container.CancelHandler
		btnDelete.ClientSideEvents.Click = container.DeleteHandler
		JSProperties.Add("cpHasExceptions", apt.HasExceptions)
		btnDelete.Enabled = Not container.IsNewAppointment
	End Sub

	Private Sub PopulateRecurrenceFormEditors(ByVal container As AppointmentFormTemplateContainer)
		Dim recInfoItem As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("itemRecurrenceInfo")
		Dim recInfoTypeGroup As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("groupRecurrenceType")
		Dim recInfoRangeGroup As LayoutItemBase = appointmentFormMainLayout.FindItemOrGroupByName("groupRecurrenceRange")

		recInfoItem.Visible = container.ShouldShowRecurrence
		recInfoTypeGroup.Visible = container.ShouldShowRecurrence
		recInfoRangeGroup.Visible = container.ShouldShowRecurrence

		If container.IsRecurring Then
			chkRecurrence.Checked = True
			recInfoTypeGroup.ClientVisible = True
			recInfoRangeGroup.ClientVisible = True

			cbRecurrenceType.Value = container.RecurrenceType.ToString()

			dailyControl.Periodicity = container.RecurrencePeriodicity
			dailyControl.WeekDays = container.RecurrenceWeekDays

			weeklyControl.Periodicity = container.RecurrencePeriodicity
			weeklyControl.WeekDays = container.RecurrenceWeekDays

			monthlyControl.DayNumber = container.RecurrenceDayNumber
			monthlyControl.Periodicity = container.RecurrencePeriodicity
			monthlyControl.Start = container.RecurrenceStart
			monthlyControl.WeekDays = container.RecurrenceWeekDays
			monthlyControl.WeekOfMonth = container.RecurrenceWeekOfMonth

			yearlyControl.DayNumber = container.RecurrenceDayNumber
			yearlyControl.Month = container.RecurrenceMonth
			yearlyControl.Start = container.RecurrenceStart
			yearlyControl.WeekDays = container.RecurrenceWeekDays
			yearlyControl.WeekOfMonth = container.RecurrenceWeekOfMonth

			rangeControl.OccurrenceCount = container.RecurrenceOccurrenceCount
			rangeControl.Range = container.RecurrenceRange
			rangeControl.End = container.RecurrenceEnd
		Else
			chkRecurrence.Checked = False
			cbRecurrenceType.SelectedIndex = 0
			recInfoTypeGroup.ClientVisible = False
			recInfoRangeGroup.ClientVisible = False
		End If
	End Sub

	Private Sub PopulateResourceEditors(ByVal apt As Appointment, ByVal container As AppointmentFormTemplateContainer)
		If ResourceSharing Then
			Dim edtMultiResource As ASPxListBox = TryCast(ddResource.FindControl("edtMultiResource"), ASPxListBox)
			edtMultiResource.DataSource = container.ResourceDataSource
			edtMultiResource.DataBindItems()
			If edtMultiResource Is Nothing Then
				Return
			End If
			SetListBoxSelectedValues(edtMultiResource, apt.ResourceIds)
			Dim multiResourceString As List(Of String) = GetListBoxSelectedItemsText(edtMultiResource)
			Dim stringResourceNone As String = SchedulerLocalizer.GetString(SchedulerStringId.Caption_ResourceNone)
			ddResource.Value = stringResourceNone
			If multiResourceString.Count > 0 Then
				ddResource.Value = String.Join(", ", multiResourceString.ToArray())
			End If
			ddResource.JSProperties.Add("cp_Caption_ResourceNone", stringResourceNone)
		Else
			edtResource.DataSource = container.ResourceDataSource
			edtResource.DataBindItems()

			If (Not Object.Equals(apt.ResourceId, EmptyResourceId.Id)) Then
				edtResource.Value = apt.ResourceId.ToString()
			Else
				edtResource.Value = SchedulerIdHelper.EmptyResourceId
			End If
		End If
	End Sub
	Private Function GetListBoxSelectedItemsText(ByVal listBox As ASPxListBox) As List(Of String)
		Dim result As New List(Of String)()
		For Each editItem As ListEditItem In listBox.Items
			If editItem.Selected Then
				result.Add(editItem.Text)
			End If
		Next editItem
		Return result
	End Function
	Private Sub SetListBoxSelectedValues(ByVal listBox As ASPxListBox, ByVal values As IEnumerable)
		listBox.Value = Nothing
		For Each value As Object In values
			Dim item As ListEditItem = listBox.Items.FindByValue(value.ToString())
			If item IsNot Nothing Then
				item.Selected = True
			End If
		Next value
	End Sub
	Protected Overrides Sub PrepareChildControls()
		Dim container As AppointmentFormTemplateContainer = CType(Parent, AppointmentFormTemplateContainer)
		Dim control As ASPxScheduler = container.Control

		MyBase.PrepareChildControls()
	End Sub
	Protected Overrides Function GetChildEditors() As ASPxEditBase()
		Dim edits() As ASPxEditBase = { tbSubject, chkAllDay, edtStartDate, edtEndDate, edtStartTime, edtEndTime, tbLocation, edtLabel, edtStatus, edtResource, GetMultiResourceEditor(), cbReminder, cbTimeZone, tbDescription, chkRecurrence, cbRecurrenceType }


		Return edits
	End Function
	Private Function GetMultiResourceEditor() As ASPxEditBase
		If ddResource IsNot Nothing Then
			Return TryCast(ddResource.FindControl("edtMultiResource"), ASPxEditBase)
		End If
		Return Nothing
	End Function
	Protected Overrides Function GetChildButtons() As ASPxButton()
		Dim buttons() As ASPxButton = { btnOk, btnCancel, btnDelete }
		Return buttons
	End Function
	Protected Overrides Function GetChildControls() As Control()
		Return New Control() { dailyControl, weeklyControl, monthlyControl, yearlyControl, rangeControl }
	End Function
	Protected Overrides Function GetDefaultButton() As WebControl
		Return btnOk
	End Function
	Protected Overrides Sub PrepareLocalization(ByVal localizationCache As SchedulerLocalizationCache)
		localizationCache.Add(SchedulerStringId.Msg_RecurrenceExceptionsWillBeLost)
		localizationCache.Add(SchedulerStringId.Msg_Warning)
	End Sub
End Class
