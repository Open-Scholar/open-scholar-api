using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.StudentExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public StudentService(IStudentRepository studentRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Response> CreateStudentAsync(AddStudentDto studentDto)
        {
            try
            {
                var response = new Response();
                var student = _mapper.Map<Student>(studentDto);
                var user = await _userManager.FindByIdAsync(studentDto.UserId);
                if (user == null)
                    return new Response<AddStudentDto>("User Not found");

                student.User = user;
                await _studentRepository.Add(student);
                response.IsSuccessfull = true;
                return response;
            }
            catch (StudentDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the student: {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateStudentAsync(int id, UpdateStudentDto updatedStudentDto)
        {
            try
            {
                var response = new Response();
                var existingStudent = await _studentRepository.GetByIdInt(id);

                if (existingStudent == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() {($"Student with ID {id} not found.")};
                    return response;
                }

                await _studentRepository.Update(existingStudent);
                return response;
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
                {
                    //return response.Errors($"Student with ID {id} not found.");
                    return new Response() { Errors = new List<string> { $"Student with Id {id} not found" }, IsSuccessfull = false };
                }

                await _studentRepository.RemoveEntirely(existingStudent);
                return Response.Success;
            }
            catch (StudentDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the student {ex.Message}" } };
            }
        }

        public async Task<Response<StudentDto>> GetStudentByIdAsync(int id)
        {
            try
            {
                var student = await _studentRepository.GetByIdInt(id);
                if (student == null)
                {
                    return new Response<StudentDto>() { Errors = new List<string> { $"Student with Id {id} not found" }, IsSuccessfull = false };
                }

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
