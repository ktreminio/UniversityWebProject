using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Application.Interfaces;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Kevin.Treminio.University.Service.Infrastructure.Http.Results.Students;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Kevin.Treminio.University.Service.Application.Services
{
    public partial class UniversityApplicationService : IUniversityApplicationService
    {
        public async Task<GetStudentsResult> GetStudentsAsync(StudentResourceParameters studentResourceParameters)
        {
            GetStudentsResult result = new();
            _validationService.ValidateStudentResourceParameters(studentResourceParameters);
            var studentFromRepo = await _unitOfWork.Students.GetStudentsAsync(studentResourceParameters);
            var authors = _mapper.Map<IEnumerable<StudentDto>>(studentFromRepo);
            result.ShapedStudents = authors.ShapeData(studentResourceParameters.Fields);
            result.PaginationMetadata = _studentLinksBuilder.GetPaginationMetadata(studentFromRepo, studentResourceParameters);

            var links = _studentLinksBuilder.CreatePagedLinksForStudnets(studentResourceParameters, studentFromRepo.HasNext, studentFromRepo.HasPrevious);
            var shapedAuthorsWithLinks = _studentLinksBuilder.CreateDocumentationLinksForStudentShapeData(result.ShapedStudents, studentResourceParameters);
            result.linkedCollectionResource = new LinkedCollectionResource { Value = shapedAuthorsWithLinks, Links = links };

            return result;
        }

        public async Task<GetStudentByStudentIdResult> GetStudentByStudentIdAsync(Guid studentId, string fields)
        {
            GetStudentByStudentIdResult result = new();
            var studentFromRepo = await _unitOfWork.Students.GetStudentAsync(studentId);

            if (studentFromRepo == null)
            {
                return null;
            }

            var student = _mapper.Map<StudentDto>(studentFromRepo);
            result.ShapedStudent = student.ShapeData(fields);

            var links = _studentLinksBuilder.CreateDocumentationLinksForStudent(studentId, fields);
            result.LinksResource = new Dictionary<string, object>(result.ShapedStudent);
            result.LinksResource.Add("links", links);

            return result;
        }

        public async Task<CreateStudentResult> CreateStudentAsync(StudentForCreationDto student)
        {
            CreateStudentResult result = new();
            var validationResult = _validationService.ValidateStudentCreation(student);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var studentEntity = _mapper.Map<Student>(student);
            await _unitOfWork.Students.AddStudentAsync(studentEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an student failed on save.");
            }

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);
            result.ShapedStudent = studentToReturn.ShapeData(null);
            result.Success = true;

            var links = _studentLinksBuilder.CreateDocumentationLinksForStudent(studentToReturn.StudentId, null);
            result.LinksResource = new Dictionary<string, object>(result.ShapedStudent);
            result.LinksResource.Add("links", links);

            return result;
        }

        public async Task<bool> DeleteStudentAsync(Guid studentId)
        {
            var studentFromRepo = await _unitOfWork.Students.GetStudentAsync(studentId);
            if (studentFromRepo == null)
            {
                return false;
            }

            await _unitOfWork.Students.DeleteStudentAsync(studentFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting student {studentId} failed on save.");
            }

            return true;
        }

        public async Task<UpdateStudentResult> UpdateStudentAsync(Guid studentId, StudentForUpdateDto student)
        {
            UpdateStudentResult result = new();
            var validationResult = _validationService.ValidateStudentUpdate(student);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var studentFromRepo = await _unitOfWork.Students.GetStudentAsync(studentId);
            if (studentFromRepo == null)
            {
                var studentToAdd = _mapper.Map<Student>(student);
                studentToAdd.StudentId = studentId;

                await _unitOfWork.Students.AddStudentAsync(studentToAdd);

                if (!await _unitOfWork.SaveAsync())
                {
                    throw new Exception($"Upserting student {studentId} failed on save.");
                }

                result.StudentUpserted = _mapper.Map<StudentDto>(studentToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(student, studentFromRepo);
            await _unitOfWork.Students.UpdateStudentAsync(studentFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating student {studentId} failed on save.");
            }

            result.Success = true;
            return result;
        }

    }
}
