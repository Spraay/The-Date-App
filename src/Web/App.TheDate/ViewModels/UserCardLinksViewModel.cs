namespace Web.TheDate.ViewModels
{
    public class UserCardLinkViewModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string LinkText { get; set; }
        public object RouteValues { get; set; }
        public object LinkHtmlAttributes { get; set; }
        public string IconText { get; set; }
        public object IconHtmlAttributes { get; set; }
    }
}
