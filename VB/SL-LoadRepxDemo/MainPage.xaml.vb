Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Browser
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Printing
' ...

Namespace SL_LoadRepxDemo
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			Dim httpResult As Boolean = WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp)
			Dim httpsResult As Boolean = WebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp)
		End Sub

		Private Sub openReport_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim model As New ReportPreviewModel() With {.ServiceUri = "../MyReportService.svc", .ReportName = "EUDReport.repx"}
			preview.Model = model
			AddHandler model.CreateDocumentError, AddressOf model_CreateDocumentError
			model.CreateDocument()
		End Sub

		Private Sub model_CreateDocumentError(ByVal sender As Object, ByVal e As FaultEventArgs)

		End Sub
	End Class
End Namespace
