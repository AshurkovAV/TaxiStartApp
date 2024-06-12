using TaxiStartApp.Models.Park;
using TaxiStartApp.Services;

namespace TaxiStartApp.Common.Data.Park
{
    public static class DataStorage
    {
        private static HttpClientJob httpClientJob = new HttpClientJob();
        static DataStorage()
        {
        }

        public static int _startIndex;
        public static int _batchSize;


        public static IEnumerable<ContactTaxiPark> GetBlogs()
        {
            return CreateBlogs();
        }
        public static int GetTotalCount()
        {
            return httpClientJob.GetParksCountAsync().Result;
        }
        static List<ContactTaxiPark> CreateBlogs()
        {
            var result = httpClientJob.GetParksTruncatedAsync(_batchSize, _startIndex);
            var con = new List<ContactTaxiPark>();
            foreach (var contact in result.Result)
            {
                // var resultCar = httpClientJob.GetCarsAsync(contact.Id);
                // resultCar.Result.OrderBy(x => x.Id).FirstOrDefault().CarsPictures.FirstOrDefault(c=>);
                con.Add(new ContactTaxiPark(contact));
                if (contact.CarAvatar != null)
                {
                    con.FirstOrDefault(x => x.Id == contact.Id).CarAvatar = ImageSource.FromStream(() => new MemoryStream(contact.CarAvatar));
                }
            }
            return con;

        //    return new List<ContactTaxiPark>() {
        //        new ContactTaxiPark(1, "DevExtreme Roadmap (Angular, React, Vue, jQuery)", "Vlada",                                               new DateTime(2023,2,22), "", 2, "devextreme_roadmap", "https://community.devexpress.com/blogs/javascript/archive/2023/02/22/devextreme-components-roadmap-2023-1.aspx"),
        //        new ContactTaxiPark(1, "Blazor Editors — Command Buttons", "Margarita",                                                           new DateTime(2023,2,22), "", 2, "blazor_editors_buttons","https://community.devexpress.com/blogs/aspnet/archive/2023/02/22/Blazor-Editors-Command-Buttons-v22-2.aspx"),
        //        new ContactTaxiPark(1, "DevExpress Reports Roadmap (Survey Inside)", "Dmitry",                                                    new DateTime(2023,2,21), "", 2, "reporting_roadmap", "https://community.devexpress.com/blogs/reporting/archive/2023/02/21/devexpress-reports-v23-1-june-2023-roadmap-survey-inside.aspx"),
        //        new ContactTaxiPark(1, "Announcing DevExpress Mobile UI for .NET MAUI", "Anthony",                                                new DateTime(2023,2,21), "", 2, "maui_release","https://community.devexpress.com/blogs/mobile/archive/2023/02/22/announcing-devexpress-mobile-ui-for-net-maui-v22-2.aspx"),
        //        new ContactTaxiPark(1, "Office File API & Office-Inspired UI Controls Roadmap (Survey Inside)", "Dmitry",                         new DateTime(2023,2,21), "", 2, "office_roadmap","https://community.devexpress.com/blogs/office/archive/2023/02/21/office-file-api-office-inspired-ui-controls-v23-1-june-2023-roadmap-survey-inside.aspx"),
        //        new ContactTaxiPark(1, "DevExpress BI Dashboard Roadmap (Survey Inside)", "Dmitry",                                               new DateTime(2023,2,21), "", 2, "dashboard_roadmap","https://community.devexpress.com/blogs/analytics/archive/2023/02/21/devexpress-bi-dashboard-v23-1-june-2023-roadmap-survey-inside.aspx"),
        //        new ContactTaxiPark(1, "Reporting — Serial Shipping Container Code (SSCC-18): A Solution for Walmart's Packaging Needs", "Boris", new DateTime(2023,2,20), "", 2, "reporting_serial_shipping","https://community.devexpress.com/blogs/reporting/archive/2023/02/20/reporting-serial-shipping-container-code-sscc-18-a-solution-for-walmart-39-s-packaging-needs.aspx"),
        //        new ContactTaxiPark(1, "DevExpress.Drawing Graphics Library — Update — Package Dependencies and Font Libraries", "Poline",        new DateTime(2023,2,16), "", 2, "devextreme__fonts","https://community.devexpress.com/blogs/news/archive/2023/02/16/devexpress-drawing-graphics-library-v22-2-4-update-package-dependencies-and-font-libraries.aspx"),
        //        new ContactTaxiPark(1, "DevExpress WinForms Roadmap", "Bogdan",                                                                   new DateTime(2023,2,16), "", 2, "winforms_roadmap","https://community.devexpress.com/blogs/winforms/archive/2023/02/16/devexpress-winforms-roadmap-23-1.aspx"),
        //        new ContactTaxiPark(1, "XAF Roadmap (Cross-Platform .NET App UI & Web API Service)", "Dennis",                                    new DateTime(2023,2,9),  "", 2, "xaf_roadmap","https://community.devexpress.com/blogs/xaf/archive/2023/02/09/xaf-2023-1-roadmap-cross-platform-net-app-ui-and-web-api-service.aspx"),
        //        new ContactTaxiPark(1, "Blazor Reporting — Quick Start with New Project Templates", "Boris",                                      new DateTime(2023,2,6),  "", 2, "blazor_reporting","https://community.devexpress.com/blogs/reporting/archive/2023/02/06/blazor-reporting-quick-start-with-new-project-templates.aspx"),
        //        new ContactTaxiPark(1, "Blazor Toolbar — Data Binding", "Elena",                                                                  new DateTime(2023,2,1),  "", 2, "blazor_toolbar","https://community.devexpress.com/blogs/aspnet/archive/2023/02/01/Blazor-Toolbar-Data-Binding-_2800_v22.2_2900_.aspx"),
        //        new ContactTaxiPark(1, "9 Tips to Reduce WPF App Startup Time", "Andrey",                                                         new DateTime(2023,1,26), "", 2, "wpf9tips","https://community.devexpress.com/blogs/wpf/archive/2023/01/26/9-tips-to-reduce-wpf-app-startup-time.aspx"),
        //        new ContactTaxiPark(1, ".NET MAUI Controls — Material Design 3", "Anthony",                                                       new DateTime(2023,1,25), "", 2, "maui_md3","https://community.devexpress.com/blogs/mobile/archive/2023/01/25/net-maui-controls-v22-2-material-design-3.aspx"),
        //        new ContactTaxiPark(1, "Blazor Accordion — Single Selection", "Elena",                                                            new DateTime(2023,1,19), "", 2, "blazor_accordion","https://community.devexpress.com/blogs/aspnet/archive/2023/01/19/blazor-accordion-single-selection-v22-2.aspx"),
        //        new ContactTaxiPark(1, ".NET MAUI — Hot Reload Support", "Kseniya",                                                               new DateTime(2023,1,17), "", 2, "maui_hotreload","https://community.devexpress.com/blogs/mobile/archive/2023/01/17/net-maui-hot-reload-support.aspx"),
        //        new ContactTaxiPark(1, "Blazor Grid — Export Data to Excel", "Lana",                                                              new DateTime(2023,1,17), "", 2, "blazor_excel_export","https://community.devexpress.com/blogs/aspnet/archive/2023/01/17/blazor-grid-export-data-to-excel-v22-2.aspx"),
        //        new ContactTaxiPark(1, "Blazor — New Window Component", "Margarita",                                                              new DateTime(2023,1,13), "", 2, "blazor_window","https://community.devexpress.com/blogs/aspnet/archive/2023/01/13/blazor-new-window-component-v22-2.aspx"),
        //        new ContactTaxiPark(1, "DevExtreme Calendar for Angular, React, Vue and jQuery — Show Week Numbers", "Vlada",                     new DateTime(2023,1,12), "", 2, "devextreme_calendar","https://community.devexpress.com/blogs/javascript/archive/2023/01/12/devextreme-calendar-angular-react-vue-jquery-show-week-numbers-v22-2.aspx"),
        //        new ContactTaxiPark(1, "WPF TreeList Control — Load Nodes Asynchronously", "Andrey",                                              new DateTime(2023,1,11), "", 2, "treelist_asynchronous_loading","https://community.devexpress.com/blogs/wpf/archive/2023/01/11/wpf-treelist-control-load-nodes-asynchronously-v22-2.aspx"),
        //        new ContactTaxiPark(1, "Blazor Grid — Integrated Editor Appearance", "Lana",                                                      new DateTime(2023,1,9),  "", 2, "blazor_integrated_editor","https://community.devexpress.com/blogs/reporting/archive/2023/02/06/blazor-reporting-quick-start-with-new-project-templates.aspx"),
        //        new ContactTaxiPark(1, ".NET MAUI — Your Feedback Counts", "Alex",                                                                new DateTime(2023,1,9),  "", 2, "maui_feedback","https://community.devexpress.com/blogs/mobile/archive/2023/01/09/maui.aspx"),
        //        new ContactTaxiPark(1, "Content Security Policy for BI Dashboard & Reporting — Say No To Unsafe JavaScript Evaluation!", "Margarita", new DateTime(2023,1,4),"", 3, "dashboard_report_security","https://community.devexpress.com/blogs/reporting/archive/2023/01/09/content-security-policy-for-bi-dashboard-amp-reporting-say-no-to-unsafe-javascript-evaluation.aspx"),
        //        new ContactTaxiPark(1, "Blazor Grid — Search Box", "Lana",                                                                            new DateTime(2023,1,4),"", 3, "blazor_searchbox","https://community.devexpress.com/blogs/aspnet/archive/2023/01/04/blazor-grid-search-box-v22-2.aspx"),
        //        new ContactTaxiPark(1, "Blazor — Hybrid Support", "Margarita",                                                                        new DateTime(2023,1,4),"", 3, "blazor_hybrid","https://community.devexpress.com/blogs/aspnet/archive/2023/01/04/blazor-hybrid-support-v22.2.aspx"),

        //};

        }
    }
}
