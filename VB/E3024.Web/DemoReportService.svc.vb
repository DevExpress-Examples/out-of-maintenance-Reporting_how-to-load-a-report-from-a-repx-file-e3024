Imports Microsoft.VisualBasic
Imports System.Configuration
Imports System.IO
Imports System.Web
Imports DevExpress.Data.Utils.ServiceModel
Imports DevExpress.XtraReports.Service
Imports DevExpress.XtraReports.UI

Namespace E3024.Web
	<SilverlightFaultBehavior> _
	Public Class DemoReportService
		Inherits ReportService
		Protected Overrides Function CreateReportByName(ByVal reportName As String) As DevExpress.XtraReports.UI.XtraReport
			Return New XtraReport()
		End Function

		Protected Overrides Function LoadReportLayout(ByVal reportName As String) As Byte()
			Dim layoutFile As String = Path.Combine(GetReportsFolder(), reportName)
			Return File.ReadAllBytes(layoutFile)
		End Function

		Private Shared Function GetReportsFolder() As String
			If HttpContext.Current IsNot Nothing Then
				Return HttpContext.Current.Server.MapPath("~/App_Data/")
			End If
			Return ConfigurationManager.AppSettings("reportsFolder")
		End Function
	End Class
End Namespace
