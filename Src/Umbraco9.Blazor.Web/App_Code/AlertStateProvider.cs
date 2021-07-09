using System;
using System.Collections.Generic;

namespace Umbraco9.Blazor.Web.App_Code
{
    public class AlertStateProvider
    {
        private Queue<AlertModel> Alerts { get; }

        public AlertStateProvider()
        {
            Alerts = new Queue<AlertModel>();

            Alerts.Enqueue(new AlertModel
            {
                Title = "Umbraco ❤ Blazor",
                Text = "Initial alert",
                Type = "info"
            });
        }

        public bool Any()
        {
            return Alerts.Count > 0;
        }

        public void Enqueue(AlertModel alert)
        {
            if (alert.IsValid())
            {
                Alerts.Enqueue(alert);
                NotifyStateChanged();
            }
        }

        public bool TryDequeue(out AlertModel queuedAlert)
        {
            if (Alerts.TryDequeue(out queuedAlert))
            {
                NotifyStateChanged();

                return true;
            }

            return false;
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
