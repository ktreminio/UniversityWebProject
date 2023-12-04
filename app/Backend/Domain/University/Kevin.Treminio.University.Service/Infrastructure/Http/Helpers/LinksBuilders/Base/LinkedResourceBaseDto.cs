namespace Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base
{
    public abstract class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
