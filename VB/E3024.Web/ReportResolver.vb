Imports System.ComponentModel.Composition
Imports System.Web
Imports DevExpress.XtraReports.Service.Extensions
Imports DevExpress.XtraReports.UI

<Export(GetType(IReportResolver))>
Public Class ReportResolver
    Implements IReportResolver
    Public Function Resolve(reportName As String, getParameters As Boolean) As XtraReport Implements IReportResolver.Resolve
        Dim layoutFile = GetReportPath(reportName)
        Return XtraReport.FromFile(layoutFile, True)
    End Function

    Shared Function GetReportPath(reportName As String) As String
        Return HttpContext.Current.Server.MapPath("~/App_Data/" & reportName & ".repx")
    End Function
End Class
