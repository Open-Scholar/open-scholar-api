using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.StudentExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUniversityRepository _universityRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentService(IStudentRepository studentRepository, IFacultyRepository facultyRepository, IUniversityRepository universityRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
            _facultyRepository = facultyRepository;
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public async Task<Response> CreateStudentAsync(AddStudentDto studentDto, string userId)
        {
            try
            {
                var response = new Response();
                var student = _mapper.Map<Student>(studentDto);
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                    return new Response<AddStudentDto>("User Not found");

                if (user.IsProfileCreated == true)
                    return new Response<AddStudentDto>("Account already exists");

                if(user.AccountType != AccountType.Student)
                    return new Response<AddStudentDto>("You can only create Student account type");

                student.User = user;
                student.ApplicationUserId = userId;
                

                var faculty = await _facultyRepository.GetByIdInt(studentDto.FacultyId);
                if (faculty == null)
                    return new Response<AddStudentDto>("Faculty Not Found!");

                student.FacultyId = studentDto.FacultyId;
                student.Faculty = faculty;

                var university = await _universityRepository.GetByIdInt(studentDto.UniversityId);
                if (university == null)
                    return new Response<AddStudentDto>("University Not Found!");

                student.UniversityId = studentDto.UniversityId;
                student.University = university;

                user.IsProfileCreated = true;
                await _studentRepository.Add(student);
                await _userManager.UpdateAsync(user);
                response.IsSuccessfull = true;
                return response;
            }
            catch (StudentDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the student: {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateStudentAsync(string userId, UpdateStudentDto updatedStudentDto)
        {
            try
            {
                var existingStudent = await _studentRepository.GetByUserIdAsync(userId);
                if (existingStudent == null)
                    return new Response<UpdateStudentDto>("Student not found.");

                var updatedStudent = _mapper.Map(updatedStudentDto, existingStudent);
                var result = _studentRepository.Update(updatedStudent);
                return new Response<UpdateStudentDto> {IsSuccessfull = true, Result = updatedStudentDto };
            }
            catch (StudentDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the student {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteStudentAsync(int id)
        {
            try
            {
                var existingStudent = await _studentRepository.GetByIdInt(id);
                if (existingStudent == null)
                    return new Response() { Errors = new List<string> { $"Student with Id {id} not found" }, IsSuccessfull = false };

                await _studentRepository.RemoveEntirely(existingStudent);
                return Response.Success;
            }
            catch (StudentDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the student {ex.Message}" } };
            }
        }

        public async Task<Response<StudentDto>> GetStudent(string userId)
        {
            try
            {
                var student = await _studentRepository.GetByUserIdAsync(userId);
                if (student == null)
                    return new Response<StudentDto>() { Errors = new List<string> { $"Student not found" }, IsSuccessfull = false };

                var studentDto = _mapper.Map<StudentDto>(student);
                return new Response<StudentDto>() { IsSuccessfull = true, Result = studentDto };
            }
            catch (StudentDataException ex)
            {
                return new Response<StudentDto> { Errors = new List<string> { $"An error occurred while fetching the student {ex.Message}" } };
            }
        }

        public async Task<Response<List<StudentDto>>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _studentRepository.GetAllWithUserAsync();
                var studentDtos = _mapper.Map<List<StudentDto>>(students);
                return new Response<List<StudentDto>>() { IsSuccessfull = true, Result = studentDtos};
            }
            catch (StudentDataException ex)
            {
                return new Response<List<StudentDto>>() { Errors = new List<string> { $"An error occurred while fetching all students: {ex.Message}" }, IsSuccessfull = false };
            }
        }
    }
}
