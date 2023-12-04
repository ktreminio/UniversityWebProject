namespace Kevin.Treminio.University.Service.Application.Dtos
{
    public class CourseResourceParameters
    {
        const int maxPageSize = 20;
        const int defaultPageSize = 10;
        const int defaultPageNumber = 1;

        private int? _pageSize = defaultPageSize;
        private int? _pageNumber = defaultPageNumber;

        public string? SearchQuery { get; set; } = "";
        public string? OrderBy { get; set; } = "Title";
        public string? Fields { get; set; } = "";
        public int? PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value == null ? defaultPageNumber : value;
        }
        public int? PageSize
        {
            get => _pageSize;
            set => _pageSize = value > maxPageSize ? maxPageSize : value;
        }
    }
}
