using AutoMapper;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.AcademicMaterialDto;
using OpenScholarApp.Dtos.ApplicationUserDtos;
using OpenScholarApp.Dtos.AuthorDto;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Dtos.BookRatingDto;
using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Dtos.BookStoreDto;
using OpenScholarApp.Dtos.FacultyDto;
using OpenScholarApp.Dtos.PdfFileDto;
using OpenScholarApp.Dtos.ProfessorDto;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Dtos.SubjectDto;
using OpenScholarApp.Dtos.TopicCommentDto;
using OpenScholarApp.Dtos.TopicDto;
using OpenScholarApp.Dtos.UniversityDto;

namespace OpenScholarApp.Mappers.MapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            //Book Mappings
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            //Author Mappings
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AddAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            //AcademicMaterial Mappings
            CreateMap<AcademicMaterial, AcademicMaterialDto>().ReverseMap();
            CreateMap<AcademicMaterial, AddAcademicMaterialDto>().ReverseMap();
            CreateMap<AcademicMaterial, UpdateAcademicMaterialDto>().ReverseMap();
            //BookSeller Mappings
            CreateMap<BookSeller, BookSellerDto>().ReverseMap();
            CreateMap<BookSeller, AddBookSellerDto>().ReverseMap();
            CreateMap<BookSeller, UpdateBookSellerDto>().ReverseMap();
            //BookStore Mappings
            CreateMap<BookStore, BookStoreDto>().ReverseMap();
            CreateMap<BookStore, AddBookStoreDto>().ReverseMap();
            CreateMap<BookStore, UpdateBookStoreDto>().ReverseMap();
            //Faculty Mappings
            CreateMap<Faculty, FacultyDto>().ReverseMap();
            CreateMap<Faculty, AddFacultyDto>().ReverseMap();
            CreateMap<Faculty, UpdateFacultyDto>().ReverseMap();
            //Professor Mappings
            CreateMap<Professor, ProfessorDto>().ReverseMap();
            CreateMap<Professor, AddProfessorDto>().ReverseMap();
            CreateMap<Professor, UpdateProfessorDto>().ReverseMap();
            //Student Mappings
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            //Subject Mappings
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, AddSubjectDto>().ReverseMap();
            CreateMap<Subject, UpdateSubjectDto>().ReverseMap();
            //University Mappings
            CreateMap<University, UniversityDto>().ReverseMap();
            CreateMap<University, AddUniversityDto>().ReverseMap();
            CreateMap<University, UpdateUniversityDto>().ReverseMap();
            //BookRating Mappings
            CreateMap<BookRating, BookRatingDto>().ReverseMap();
            CreateMap<BookRating, AddBookRatingDto>().ReverseMap();
            CreateMap<BookRating, UpdateBookRatingDto>().ReverseMap();
            //Topic Mappings
            CreateMap<Topic, TopicDto>().ReverseMap();
            CreateMap<Topic, AddTopicDto>().ReverseMap();
            CreateMap<Topic, UpdateTopicDto>().ReverseMap();
            //TopicComment Mappings
            CreateMap<TopicComment, TopicCommentDto>().ReverseMap();
            CreateMap<TopicComment, AddTopicCommentDto>().ReverseMap();
            CreateMap<TopicComment, UpdateTopicCommentDto>().ReverseMap();
            //ApplicationUser Mappings
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, ResetPasswordDto>().ReverseMap();
            CreateMap<ApplicationUser, ForgotPasswordDto>().ReverseMap();
            //PdfFileDto
            CreateMap<DocFile, DocFileDto>().ReverseMap();
        }
    }
}
