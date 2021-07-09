namespace Umbraco9.Blazor.Web.App_Code
{
    public class AlertModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Text) && !string.IsNullOrEmpty(Type);
        }
    }
}
