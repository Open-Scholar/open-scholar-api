using AutoMapper;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Dtos.UserNotificationDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;
using OpenScholarApp.Shared.CustomExceptions.UserNotificationExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly IMapper _mapper;

        public UserNotificationService(IUserNotificationRepository userNotificationRepository, IMapper mapper)
        {
            _userNotificationRepository = userNotificationRepository;
            _mapper = mapper;
        }

        public async Task<Response<UserNotificationPagedDto<UserNotificationDto>>> GetUserNotificationsAsync(string userId, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (items, unreadCount, totalCount) = await _userNotificationRepository.GetByUserIdAndMarkAsReadPagedAsync(userId, pageNumber, pageSize);
                var notificationDtos = _mapper.Map<List<UserNotificationDto>>(items);

                var result = new UserNotificationPagedDto<UserNotificationDto>
                {
                    Items = notificationDtos,
                    TotalItems = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                    UnreadCount = unreadCount
                };

                return new Response<UserNotificationPagedDto<UserNotificationDto>>() { IsSuccessfull = true, Result = result};
            }
            catch (UserNotificationDataException ex)
            {
                return new Response<UserNotificationPagedDto<UserNotificationDto>>() { IsSuccessfull = false, Errors = new List<string>{ ex.Message}};
            }
        }

        public async Task<Response<UserNotificationCountDto>> GetUnreadNotificationsCount(string userId)
        {
            try
            {
                int count = await _userNotificationRepository.UnreadNotificationsCount(userId);
                var userNotificationCountDto = new UserNotificationCountDto { NotificationsCount = count };
                return new Response<UserNotificationCountDto>(userNotificationCountDto); 
            }
            catch (UserNotificationDataException ex)
            {
                return new Response<UserNotificationCountDto> { IsSuccessfull = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<Response> MarkNotificationAsReadAsync(string userId, int notificationId)
        {
            await _userNotificationRepository.MarkAsReadAsync(notificationId);
            return new Response { IsSuccessfull = true };
        }
    }
}
