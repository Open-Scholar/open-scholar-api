using AutoMapper;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.AcademicMaterialDto;
using OpenScholarApp.Dtos.AuthorDto;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Dtos.BookStoreDto;
using OpenScholarApp.Dtos.FacultyDto;
using OpenScholarApp.Dtos.ProfessorDto;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Dtos.SubjectDto;
using OpenScholarApp.Dtos.UniversityDto;

namespace OpenScholarApp.Mappers.MapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, RemoveBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AddAuthorDto>().ReverseMap();
            CreateMap<Author, RemoveAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();

            CreateMap<AcademicMaterial, AcademicMaterialDto>().ReverseMap();
            CreateMap<AcademicMaterial, AddAcademicMaterialDto>().ReverseMap();
            CreateMap<AcademicMaterial, RemoveAcademicMaterialDto>().ReverseMap();
            CreateMap<AcademicMaterial, UpdateAcademicMaterialDto>().ReverseMap();

            CreateMap<BookSeller, BookSellerDto>().ReverseMap();
            CreateMap<BookSeller, AddBookSellerDto>().ReverseMap();
            CreateMap<BookSeller, RemoveBookSellerDto>().ReverseMap();
            CreateMap<BookSeller, UpdateBookSellerDto>().ReverseMap();

            CreateMap<BookStore, BookStoreDto>().ReverseMap();
            CreateMap<BookStore, AddBookStoreDto>().ReverseMap();
            CreateMap<BookStore, RemoveBookStoreDto>().ReverseMap();
            CreateMap<BookStore, UpdateBookStoreDto>().ReverseMap();

            CreateMap<Faculty, FacultyDto>().ReverseMap();
            CreateMap<Faculty, AddFacultyDto>().ReverseMap();
            CreateMap<Faculty, RemoveFacultyDto>().ReverseMap();
            CreateMap<Faculty, UpdateFacultyDto>().ReverseMap();

            CreateMap<Professor, ProfessorDto>().ReverseMap();
            CreateMap<Professor, AddProfessorDto>().ReverseMap();
            CreateMap<Professor, RemoveProfessorDto>().ReverseMap();
            CreateMap<Professor, UpdateProfessorDto>().ReverseMap();

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, RemoveStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, AddSubjectDto>().ReverseMap();
            CreateMap<Subject, RemoveSubjectDto>().ReverseMap();
            CreateMap<Subject, UpdateSubjectDto>().ReverseMap();

            CreateMap<University, UniversityDto>().ReverseMap();
            CreateMap<University, AddUniversityDto>().ReverseMap();
            CreateMap<University, RemoveUniversityDto>().ReverseMap();
            CreateMap<University, UpdateUniversityDto>().ReverseMap();
        }
        
    }
}
