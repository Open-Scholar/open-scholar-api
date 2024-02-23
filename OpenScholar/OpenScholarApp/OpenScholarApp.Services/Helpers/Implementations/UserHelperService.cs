using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Services.Helpers.Interaces;

namespace OpenScholarApp.Services.Helpers.Implementations
{
    public class UserHelperService : IUserHelperService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IBookStoreRepository _bookStoreRepository;
        private readonly IBookSellerRepository _bookSellerRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserHelperService(UserManager<ApplicationUser> userManager,
                                 IUserRepository userRepository,
                                 IStudentRepository studentRepository, 
                                 IProfessorRepository professorRepository, 
                                 IBookStoreRepository bookStoreRepository, 
                                 IBookSellerRepository bookSellerRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _studentRepository = studentRepository;
            _professorRepository = professorRepository;
            _bookStoreRepository = bookStoreRepository;
            _bookSellerRepository = bookSellerRepository;
        }

        public async Task<string> GetUsername(ApplicationUser user)
        {
            if (user != null)
            {
                if (user.AccountType == AccountType.Student)
                {
                    //var student = user.Students?.FirstOrDefault(i => i.User.Id == user.Id);
                    var student = await _studentRepository.GetByUserIdAsync(user.Id);
                    if (student == null)
                        return "/";
                    var result = new string($"{student.FirstName} {student.LastName}");
                    return result;
                }

                if (user.AccountType == AccountType.Professor)
                {
                    //var professor = user.Professors?.FirstOrDefault(i => i.User.Id == user.Id);
                    var professor = await _professorRepository.GetByUserIdAsync(user.Id);
                    if (professor == null)
                        return "/";
                    var result = new string($"{professor.FirstName} {professor.LastName}");
                    return result;
                }

                if (user.AccountType == AccountType.BookSeller)
                {
                    //var bookSeller = user.BookSellers?.FirstOrDefault(i => i.User.Id == user.Id);
                    var bookSeller = await _bookSellerRepository.GetByUserIdAsync(user.Id);
                    if (bookSeller == null)
                        return "/";
                    var result = new string($"{bookSeller.FirstName} {bookSeller.LastName}");
                    return result;
                }

                if (user.AccountType == AccountType.BookStore)
                {
                    //var bookStore = user.BookStores?.FirstOrDefault(i => i.User.Id == user.Id);
                    var bookStore = await _bookStoreRepository.GetByUserIdAsync(user.Id);
                    if (bookStore == null)
                        return "/";
                    var result = new string($"{bookStore.Name}");
                    return result;
                }
            }
            return "Annonymus";
        }
    }
}
