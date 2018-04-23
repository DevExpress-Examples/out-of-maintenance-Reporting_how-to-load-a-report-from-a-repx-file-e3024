Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Configuration
Imports System.ServiceModel
Imports System.Web
Imports DevExpress.XtraReports.Service
Imports DevExpress.XtraReports.Service.DataContracts
Imports DevExpress.XtraReports.Service.Native
Imports DevExpress.XtraReports.UI
' ...

Namespace SL_LoadRepxDemo.Web
	Public Class MyReportService
		Inherits ReportService
		Protected Overrides Function CreateReportByName(ByVal reportTypeName As String) As XtraReport
			Try
				Dim report As New XtraReport()
				Dim fileName As String
				Dim context As HttpContext = HttpContext.Current
				' The Report Service does not require the ASP.NET compatibility mode anymore.
				' Therefore, you cannot rely on HttpContext, because it can be null.
				' Now, to define reports folder, either enable the ASP.NET mode (and use Server.MapPath(...)),
				' or use the "configuration" parameter in the web.config file.
				If context IsNot Nothing Then
					fileName = context.Server.MapPath("~/App_Data/EUDReport.repx")
				Else
					fileName = Path.Combine(ConfigurationManager.AppSettings("reportsFolder"), reportTypeName)
				End If
				report.LoadLayout(fileName)
				Return report
			Catch exception As Exception
				Throw New FaultException(exception.Message)
			End Try
		End Function
	End Class

End Namespace