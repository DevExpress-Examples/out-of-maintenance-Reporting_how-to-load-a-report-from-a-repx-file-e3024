using System.Net;
using System.Net.Browser;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Printing;
// ...

namespace SL_LoadRepxDemo {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            bool httpResult = WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);
            bool httpsResult = WebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp);
        }

        private void openReport_Click(object sender, RoutedEventArgs e) {
            ReportPreviewModel model = new ReportPreviewModel() { ServiceUri = "../MyReportService.svc", ReportTypeName = "EUDReport.repx" };
            preview.Model = model;
            model.CreateDocumentError += model_CreateDocumentError;
            model.CreateDocument();
        }

        void model_CreateDocumentError(object sender, FaultEventArgs e) {

        }
    }
}
