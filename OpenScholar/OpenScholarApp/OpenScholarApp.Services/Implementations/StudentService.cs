using AutoMapper;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.StudentExceptions;
using OpenScholarApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Response> CreateStudentAsync(AddStudentDto studentDto)
        {
            try
            {
                var response = new Response();
                var student = _mapper.Map<Student>(studentDto);
                await _studentRepository.Add(student);
                response.IsSuccessfull = true;
                return response;
            }
            catch (StudentDataException ex)
            {
                // Log the exception here.
                return new Response { Errors = new List<string> { $"An error occurred while creating the student: {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateStudentAsync(string id, UpdateStudentDto updatedStudentDto)
        {
            try
            {
                var response = new Response();
                var existingStudent = await _studentRepository.GetById(id);

                if (existingStudent == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() {("Student with ID {id} not found.")};
                    return response;
                }

                // Update existingStudent properties here based on updatedStudentDto.
                // Example: existingStudent.FirstName = updatedStudentDto.FirstName;

                await _studentRepository.Update(existingStudent);
                return response;
            }
            catch (StudentDataException ex)
            {
                // Log the exception here.
                return new Response { Errors = new List<string> { $"An error occurred while updating the student {ex.Message}" } };
                //return Response.($"An error occurred while updating the student: {ex.Message}");
            }
        }

        public async Task<Response> DeleteStudentAsync(string id)
        {
            try
            {
                var existingStudent = await _studentRepository.GetById(id);

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
                // Log the exception here.
                return new Response { Errors = new List<string> { $"An error occurred while deleting the student {ex.Message}" } };
            }
        }

        public async Task<Response<StudentDto>> GetStudentByIdAsync(string id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                if (student == null)
                {
                    return new Response<StudentDto>() { Errors = new List<string> { $"Student with Id {id} not found" }, IsSuccessfull = false };
                }

                var studentDto = _mapper.Map<StudentDto>(student);
                return new Response<StudentDto>() { IsSuccessfull = true, Result = studentDto };
            }
            catch (StudentDataException ex)
            {
                // Log the exception here.
                return new Response<StudentDto> { Errors = new List<string> { $"An error occurred while fetching the student {ex.Message}" } };
            }
        }

        public async Task<Response<List<StudentDto>>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _studentRepository.GetAll();
                var studentDtos = _mapper.Map<List<StudentDto>>(students);
                //return Response<List<StudentDto>>.Success(studentDtos);
                return new Response<List<StudentDto>>() { IsSuccessfull = true, Result = studentDtos};
            }
            catch (StudentDataException ex)
            {
                // Log the exception here.
                return new Response<List<StudentDto>>() { Errors = new List<string> { $"An error occurred while fetching all students: {ex.Message}" }, IsSuccessfull = false };
            }
        }
    }
}
