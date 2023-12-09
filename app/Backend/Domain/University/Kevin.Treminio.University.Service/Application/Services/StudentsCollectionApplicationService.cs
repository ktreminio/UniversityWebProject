using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Application.Interfaces;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Http.Results.StudentCollections;

namespace Kevin.Treminio.University.Service.Application.Services
{
    public partial class UniversityApplicationService : IUniversityApplicationService
    {
        public async Task<GetStudentCollectionResult> GetStudentsCollectionAsync(List<Guid> studentIds)
        {
            GetStudentCollectionResult result = new GetStudentCollectionResult();
            var students = await _unitOfWork.Students.GetStudentsAsync(studentIds);

            if(!students.Any())
            {
                result.StudentFound = false;
                return result;
            }

            result.StudentFound = true;
            result.StudentsCollection = _mapper.Map<IEnumerable<StudentDto>>(students);

            return result;
        }

        public async Task<CreateStudentCollectionResult> CreateStudentCollectionAsync(IEnumerable<StudentForCreationDto> studentCollection)
        {
            CreateStudentCollectionResult result = new CreateStudentCollectionResult();
            var students = _mapper.Map<IEnumerable<Student>>(studentCollection);

            foreach (var student in students)
            {
                await _unitOfWork.Students.AddStudentAsync(student);
            }

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an student collection failed on save.");
            }

            result.StudentsCollection = _mapper.Map<IEnumerable<StudentDto>>(students);
            result.StudentIdsAsString = string.Join(",", result.StudentsCollection.Select(s => s.StudentId));

            return result;
        }
    }
}
