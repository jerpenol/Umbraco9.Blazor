using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Umbraco9.Blazor.Web.App_Code;

namespace Umbraco9.Blazor.Web.Shared
{
    public partial class Alerts
    {
        [Parameter] public int? MaximumNumberOfAlerts { get; set; }
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
            if(MaximumNumberOfAlerts.HasValue && ActiveAlerts.Count >= MaximumNumberOfAlerts.Value)
            {
                ActiveAlerts.RemoveAt(0);
            }

            ActiveAlerts.Add(new AlertModel
            {
                Title = "Umbraco ❤ Blazor",
                Text = "A new alert!",
                Type = "success"
            });
        }
    }
}
