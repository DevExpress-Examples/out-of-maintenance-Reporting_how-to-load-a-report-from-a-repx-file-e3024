using System;
using System.IO;
using System.Configuration;
using System.ServiceModel;
using System.Web;
using DevExpress.XtraReports.Service;
using DevExpress.XtraReports.Service.DataContracts;
using DevExpress.XtraReports.Service.Native;
using DevExpress.XtraReports.UI;
// ...

namespace SL_LoadRepxDemo.Web {
    public class MyReportService : ReportService {
        protected override XtraReport CreateReportByName(string reportTypeName) {
            try {
                XtraReport report = new XtraReport();
                string fileName;
                HttpContext context = HttpContext.Current;
                // The Report Service does not require the ASP.NET compatibility mode anymore.
                // Therefore, you cannot rely on HttpContext, because it can be null.
                // Now, to define reports folder, either enable the ASP.NET mode (and use Server.MapPath(...)),
                // or use the "configuration" parameter in the web.config file.
                if (context != null) {
                    fileName = context.Server.MapPath("~/App_Data/EUDReport.repx");
                }
                else {
                    fileName = Path.Combine(ConfigurationManager.AppSettings["reportsFolder"], reportTypeName);
                }
                report.LoadLayout(fileName);
                return report;
            }
            catch (Exception exception) {
                throw new FaultException(exception.Message);
            }
        }
    }

}