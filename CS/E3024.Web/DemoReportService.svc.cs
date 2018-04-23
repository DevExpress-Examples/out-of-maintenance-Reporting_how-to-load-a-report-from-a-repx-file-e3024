using System.Configuration;
using System.IO;
using System.Web;
using DevExpress.Data.Utils.ServiceModel;
using DevExpress.XtraReports.Service;
using DevExpress.XtraReports.UI;

namespace E3024.Web {
    [SilverlightFaultBehavior]
    public class DemoReportService : ReportService {
        protected override DevExpress.XtraReports.UI.XtraReport CreateReportByName(string reportName) {
            return new XtraReport();
        }

        protected override byte[] LoadReportLayout(string reportName) {
            string layoutFile = Path.Combine(GetReportsFolder(), reportName);
            return File.ReadAllBytes(layoutFile);
        }

        static string GetReportsFolder() {
            if(HttpContext.Current != null)
                return HttpContext.Current.Server.MapPath("~/App_Data/");
            return ConfigurationManager.AppSettings["reportsFolder"];
        }
    }
}
