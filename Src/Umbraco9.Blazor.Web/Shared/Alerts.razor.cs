using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Umbraco9.Blazor.Web.App_Code;

namespace Umbraco9.Blazor.Web.Shared
{
    public partial class Alerts
    {
        [Inject] public AlertStateProvider AlertState { get; set; }

        [Parameter] public int? MaximumNumberOfAlerts { get; set; }

        public List<AlertModel> ActiveAlerts { get; set; }

        protected override void OnInitialized()
        {
            ActiveAlerts = new List<AlertModel>();

            AlertState.OnChange += OnStateChanged;

            DequeueAlerts();
        }

        private void DequeueAlerts()
        {
            var pageSize = MaximumNumberOfAlerts ?? 5;
            for (int i = 0; i < pageSize; i++)
            {
                if (AlertState.TryDequeue(out var alert))
                {
                    if (ActiveAlerts.Count == MaximumNumberOfAlerts)
                    {
                        ActiveAlerts.RemoveAt(0);
                    }

                    ActiveAlerts.Add(alert);
                }
            }
        }

        private void CloseAlert(AlertModel alert)
        {
            ActiveAlerts.Remove(alert);
        }

        protected void OnStateChanged()
        {
            DequeueAlerts();

            StateHasChanged();
        }

        private void FetchAlert()
        {
            AlertState.Enqueue(new AlertModel
            {
                Title = "Umbraco ❤ Blazor",
                Text = "A new alert!",
                Type = "success"
            });

            DequeueAlerts();
        }
    }
}
