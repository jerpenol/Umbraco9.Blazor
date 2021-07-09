using System.Collections.Generic;
using Umbraco9.Blazor.Web.App_Code;

namespace Umbraco9.Blazor.Web.Shared
{
    public partial class Alerts
    {
        public List<AlertModel> ActiveAlerts { get; set; }

        protected override void OnInitialized()
        {
            ActiveAlerts = new List<AlertModel>
            {
                new AlertModel
                {
                    Title = "Umbraco ❤ Blazor",
                    Text = "Initial alert",
                    Type = "info"
                }
            };
        }

        private void CloseAlert(AlertModel alert)
        {
            ActiveAlerts.Remove(alert);
        }

        private void FetchAlert()
        {
            ActiveAlerts.Add(new AlertModel
            {
                Title = "Umbraco ❤ Blazor",
                Text = "A new alert!",
                Type = "success"
            });
        }
    }
}
