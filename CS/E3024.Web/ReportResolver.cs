using System.ComponentModel.Composition;
using System.Web;
using DevExpress.XtraReports.Service.Extensions;
using DevExpress.XtraReports.UI;

namespace E3024.Web {
    [Export(typeof(IReportResolver))]
    public class ReportResolver : IReportResolver {
        #region IReportResolver Members

        XtraReport IReportResolver.Resolve(string reportName, bool getParameters) {
            string layoutFile = GetReportPath(reportName);
            return XtraReport.FromFile(layoutFile, true);
        }

        #endregion

        static string GetReportPath(string reportName) {
            return HttpContext.Current.Server.MapPath("~/App_Data/" + reportName + ".repx");
        }
    }
}