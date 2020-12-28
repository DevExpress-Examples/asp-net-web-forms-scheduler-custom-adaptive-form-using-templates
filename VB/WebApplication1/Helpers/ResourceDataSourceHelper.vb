Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Web

Namespace WebApplication1.Helpers
	Public Class ResourceDataSourceHelper
		Public Sub New()
		End Sub

		Public Shared Function GetCustomResources() As List(Of CustomResource)
			Dim list As New List(Of CustomResource)()
			For i As Integer = 1 To 3
				list.Add(New CustomResource() With {.Caption = "Resource " & i.ToString(), .Color = Color.LightCoral, .ResourceId = i})
			Next i
			Return list
		End Function
	End Class

	Public Class CustomResource
		Public Sub New()
		End Sub

		Private privateCaption As String
		Public Property Caption() As String
			Get
				Return privateCaption
			End Get
			Set(ByVal value As String)
				privateCaption = value
			End Set
		End Property
		Private privateColor As Color
		Public Property Color() As Color
			Get
				Return privateColor
			End Get
			Set(ByVal value As Color)
				privateColor = value
			End Set
		End Property
		Private privateResourceId As Integer
		Public Property ResourceId() As Integer
			Get
				Return privateResourceId
			End Get
			Set(ByVal value As Integer)
				privateResourceId = value
			End Set
		End Property
	End Class
End Namespace