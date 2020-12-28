Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace WebApplication1.Helpers
	Public Class AppointmentDataSourceHelper
		Public Sub New()
		End Sub

		Public Shared Function GetCustomAppointmentsList() As List(Of CustomAppointment)
			If System.Web.HttpContext.Current.Session("CustomAppointmentsList") Is Nothing Then
				Dim appts As New List(Of CustomAppointment)()
				Dim resourcesList As List(Of CustomResource) = ResourceDataSourceHelper.GetCustomResources()
				Dim uniqueID As Integer = 0
				For Each resource In resourcesList
					If resource.ResourceId = 1 Then
						appts.Add(New CustomAppointment() With {.Id = uniqueID, .AllDay = False, .Description = "Some Test Description", .StartTime = DateTime.Now.Date.AddHours(12 + resource.ResourceId), .EndTime = DateTime.Now.Date.AddHours(15 + resource.ResourceId), .EventType = 1, .Label = 2, .ResourceId = resource.ResourceId, .Status = 3, .Subject = "Meeting", .RecurrenceInfo = "<RecurrenceInfo Start=""12/25/2020 13:00:00"" End=""01/21/2021 13:00:00"" Id=""8dc34c47-fc2b-49db-8f1c-9755c23057aa"" Periodicity=""3"" Range=""1"" FirstDayOfWeek=""0"" Version=""1""/>"})
						uniqueID += 1
					Else
						appts.Add(New CustomAppointment() With {.Id = uniqueID, .AllDay = False, .Description = "Some Test Description", .StartTime = DateTime.Now.Date.AddHours(12 + resource.ResourceId), .EndTime = DateTime.Now.Date.AddHours(15 + resource.ResourceId), .EventType = 0, .Label = 2, .ResourceId = resource.ResourceId, .Status = 3, .Subject = "Meeting"})
						uniqueID += 1
					End If
				Next resource
				System.Web.HttpContext.Current.Session("CustomAppointmentsList") = appts
			End If
			Return TryCast(System.Web.HttpContext.Current.Session("CustomAppointmentsList"), List(Of CustomAppointment))
		End Function

		Public Shared Function InsertCustomAppointment(ByVal newCustomAppointment As CustomAppointment) As Object
			Dim CustomAppointments As List(Of CustomAppointment) = GetCustomAppointmentsList()

			Dim lastCustomAppointmentID As Integer = If(CustomAppointments.Count = 0, 0, CustomAppointments.OrderBy(Function(c) c.Id).Last().Id)
			newCustomAppointment.Id = lastCustomAppointmentID + 1

			CustomAppointments.Add(newCustomAppointment)
			Return newCustomAppointment.Id
		End Function

		Public Shared Sub DeleteCustomAppointment(ByVal deletedCustomAppointment As CustomAppointment)
			Dim CustomAppointments As List(Of CustomAppointment) = GetCustomAppointmentsList()

			Dim currentCustomAppointment As CustomAppointment = CustomAppointments.FirstOrDefault(Function(c) c.Id.Equals(deletedCustomAppointment.Id))
			If currentCustomAppointment IsNot Nothing Then
				CustomAppointments.Remove(currentCustomAppointment)
			End If
		End Sub

		Public Shared Sub UpdateCustomAppointment(ByVal updatedCustomAppointment As CustomAppointment)
			Dim CustomAppointments As List(Of CustomAppointment) = GetCustomAppointmentsList()

			Dim currentCustomAppointment As CustomAppointment = CustomAppointments.FirstOrDefault(Function(c) c.Id.Equals(updatedCustomAppointment.Id))
			currentCustomAppointment.AllDay = updatedCustomAppointment.AllDay
			currentCustomAppointment.Description = updatedCustomAppointment.Description
			currentCustomAppointment.EndTime = updatedCustomAppointment.EndTime
			currentCustomAppointment.EventType = updatedCustomAppointment.EventType
			currentCustomAppointment.Label = updatedCustomAppointment.Label
			currentCustomAppointment.Location = updatedCustomAppointment.Location
			currentCustomAppointment.RecurrenceInfo = updatedCustomAppointment.RecurrenceInfo
			currentCustomAppointment.ReminderInfo = updatedCustomAppointment.ReminderInfo
			currentCustomAppointment.ResourceId = updatedCustomAppointment.ResourceId
			currentCustomAppointment.StartTime = updatedCustomAppointment.StartTime
			currentCustomAppointment.Status = updatedCustomAppointment.Status
			currentCustomAppointment.Subject = updatedCustomAppointment.Subject

			currentCustomAppointment.CustomInfo = updatedCustomAppointment.CustomInfo
		End Sub

	End Class


	Public Class CustomAppointment
		Private privateStartTime As DateTime
		Public Property StartTime() As DateTime
			Get
				Return privateStartTime
			End Get
			Set(ByVal value As DateTime)
				privateStartTime = value
			End Set
		End Property
		Private privateEndTime As DateTime
		Public Property EndTime() As DateTime
			Get
				Return privateEndTime
			End Get
			Set(ByVal value As DateTime)
				privateEndTime = value
			End Set
		End Property
		Private privateSubject As String
		Public Property Subject() As String
			Get
				Return privateSubject
			End Get
			Set(ByVal value As String)
				privateSubject = value
			End Set
		End Property
		Private privateStatus As Integer
		Public Property Status() As Integer
			Get
				Return privateStatus
			End Get
			Set(ByVal value As Integer)
				privateStatus = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
		Private privateLabel As Integer
		Public Property Label() As Integer
			Get
				Return privateLabel
			End Get
			Set(ByVal value As Integer)
				privateLabel = value
			End Set
		End Property
		Private privateLocation As String
		Public Property Location() As String
			Get
				Return privateLocation
			End Get
			Set(ByVal value As String)
				privateLocation = value
			End Set
		End Property
		Private privateAllDay As Boolean
		Public Property AllDay() As Boolean
			Get
				Return privateAllDay
			End Get
			Set(ByVal value As Boolean)
				privateAllDay = value
			End Set
		End Property
		Private privateEventType As Integer
		Public Property EventType() As Integer
			Get
				Return privateEventType
			End Get
			Set(ByVal value As Integer)
				privateEventType = value
			End Set
		End Property
		Private privateRecurrenceInfo As String
		Public Property RecurrenceInfo() As String
			Get
				Return privateRecurrenceInfo
			End Get
			Set(ByVal value As String)
				privateRecurrenceInfo = value
			End Set
		End Property
		Private privateReminderInfo As String
		Public Property ReminderInfo() As String
			Get
				Return privateReminderInfo
			End Get
			Set(ByVal value As String)
				privateReminderInfo = value
			End Set
		End Property
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
		Private privateResourceId As Object
		Public Property ResourceId() As Object
			Get
				Return privateResourceId
			End Get
			Set(ByVal value As Object)
				privateResourceId = value
			End Set
		End Property

		Private privateTimeZoneID As String
		Public Property TimeZoneID() As String
			Get
				Return privateTimeZoneID
			End Get
			Set(ByVal value As String)
				privateTimeZoneID = value
			End Set
		End Property

		Private privateCustomInfo As String
		Public Property CustomInfo() As String
			Get
				Return privateCustomInfo
			End Get
			Set(ByVal value As String)
				privateCustomInfo = value
			End Set
		End Property
	End Class
End Namespace