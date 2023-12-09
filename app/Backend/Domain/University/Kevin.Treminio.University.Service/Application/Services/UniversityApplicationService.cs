using AutoMapper;
using Kevin.Treminio.University.Service.Application.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.UnitOfWork;

namespace Kevin.Treminio.University.Service.Application.Services
{
    public partial class UniversityApplicationService : IUniversityApplicationService
    {
        private readonly UniversityUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IStudentLinksBuilder _studentLinksBuilder;

        public UniversityApplicationService(
            UniversityUnitOfWork unitOfWork,
            IMapper mapper,
            IValidationService validationService,
            IStudentLinksBuilder studentLinksBuilder
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
            _studentLinksBuilder = studentLinksBuilder;
        }
    }
}
