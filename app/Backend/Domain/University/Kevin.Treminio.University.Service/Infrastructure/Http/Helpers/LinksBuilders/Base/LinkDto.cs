namespace Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base
{
    public class LinkDto
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public LinkDto()
        {

        }
        public LinkDto(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
