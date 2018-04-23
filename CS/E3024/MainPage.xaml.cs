using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Printing;

namespace E3024 {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        private void loadReportButton_Click(object sender, RoutedEventArgs e) {
            ReportPreviewModel model = new ReportPreviewModel() { ServiceUri = "../DemoReportService.svc", ReportName = "EUDReport.repx" };
            preview.Model = model;
            model.CreateDocument();
        }
    }
}
