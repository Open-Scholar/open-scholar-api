﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Dtos.UniversityAccDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.UniversityExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class UniversityAccService : IUniversityAccService
    {
        private readonly IUniversityAccRepository _universityRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UniversityAccService(IUniversityAccRepository universityRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateUniversityAsync(AddUniversityAccDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var university = _mapper.Map<UniversityAcc>(addDto);
                var user = await _userManager.FindByIdAsync(addDto.UserId);

                if (user == null)
                    throw new UniversityAccDataException("User not found");

                if (user.IsProfileCreated == true)
                    return new Response<AddStudentDto>("Account already exists");

                if (user.AccountType != AccountType.University)
                    return new Response<AddStudentDto>("You can only create University account type");

                university.User = user;
                await _universityRepository.Add(university);
                user.IsProfileCreated = true;
                await _userManager.UpdateAsync(user);
                response.IsSuccessfull = true;
                return response;
            }
            catch (UniversityAccDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the University: {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteUniversityAsync(int id)
        {
            try
            {
                var existingUniversity = await _universityRepository.GetByIdInt(id);

                if (existingUniversity == null)
                {
                    return new Response() { Errors = new List<string> { $"University with Id {id} not found" }, IsSuccessfull = false };
                }

                await _universityRepository.RemoveEntirely(existingUniversity);
                return Response.Success;
            }
            catch (UniversityAccDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the University {ex.Message}" } };
            }
        }

        public async Task<Response<List<UniversityAccDto>>> GetAllUniversitiesAsync()
        {
            try
            {
                var universities = await _universityRepository.GetAllWithUserAsync();
                var universitiesDtos = _mapper.Map<List<UniversityAccDto>>(universities);
                return new Response<List<UniversityAccDto>>() { IsSuccessfull = true, Result = universitiesDtos };
            }
            catch (UniversityAccDataException ex)
            {
                return new Response<List<UniversityAccDto>>() { Errors = new List<string> { $"An error occurred while fetching all Universities: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<UniversityAccDto>> GetUniversityByIdAsync(int id)
        {
            try
            {
                var university = await _universityRepository.GetByIdInt(id);
                if (university == null)
                {
                    return new Response<UniversityAccDto>() { Errors = new List<string> { $"University with Id {id} not found" }, IsSuccessfull = false };
                }

                var universityDto = _mapper.Map<UniversityAccDto>(university);
                return new Response<UniversityAccDto>() { IsSuccessfull = true, Result = universityDto };
            }
            catch (UniversityAccDataException ex)
            {
                return new Response<UniversityAccDto> { Errors = new List<string> { $"An error occurred while fetching the University {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateUniversityAsync(int id, UpdateUniversityAccDto updateDto)
        {
            try
            {
                var response = new Response();
                var existingUniversity = await _universityRepository.GetByIdInt(id);

                if (existingUniversity == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"University with ID {id} not found.") };
                    return response;
                }

                await _universityRepository.Update(existingUniversity);
                return response;
            }
            catch (UniversityAccDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the University {ex.Message}" } };
            }
        }
    }
}
