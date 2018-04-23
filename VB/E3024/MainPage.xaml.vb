Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Printing

Namespace E3024
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub loadReportButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim model As New ReportPreviewModel() With {.ServiceUri = "../DemoReportService.svc", .ReportName = "EUDReport.repx"}
			preview.Model = model
			model.CreateDocument()
		End Sub
	End Class
End Namespace
