Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.iCalendar
Imports WebApplication1.CustomCommands
Imports WebApplication1.Helpers

Namespace WebApplication1
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub ASPxScheduler1_PrepareAppointmentFormPopupContainer(ByVal sender As Object, ByVal e As ASPxSchedulerPrepareFormPopupContainerEventArgs)
			e.Popup.SettingsAdaptivity.Mode = PopupControlAdaptivityMode.Always
			e.Popup.SettingsAdaptivity.MaxWidth = Unit.Pixel(900)
			e.Popup.SettingsAdaptivity.VerticalAlign = PopupAdaptiveVerticalAlign.WindowCenter
			e.Popup.SettingsAdaptivity.MinWidth = Unit.Pixel(570)
		End Sub
		Protected Sub ASPxScheduler1_BeforeExecuteCallbackCommand(ByVal sender As Object, ByVal e As SchedulerCallbackCommandEventArgs)
			If e.CommandId = SchedulerCallbackCommandId.AppointmentSave Then
				e.Command = New CustomAppointmentSaveCallbackCommand(CType(sender, ASPxScheduler))
			End If
		End Sub
	End Class
End Namespace