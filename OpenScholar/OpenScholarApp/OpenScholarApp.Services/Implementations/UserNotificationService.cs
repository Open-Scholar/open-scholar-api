using AutoMapper;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Dtos.UserNotificationDto;
using OpenScholarApp.Services.Interfaces;
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

        public async Task<UserNotificationPagedDto<UserNotificationDto>> GetUserNotificationsAsync(string userId, int pageNumber = 1, int pageSize = 10)
        {
            var (items, unreadCount, totalCount) = await _userNotificationRepository.GetByUserIdAndMarkAsReadPagedAsync(userId, pageNumber, pageSize);
            var notificationDtos = _mapper.Map<List<UserNotificationDto>>(items);

            return new UserNotificationPagedDto<UserNotificationDto>
            {
                Items = notificationDtos,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                UnreadCount = unreadCount
            };
        }

        public async Task<Response> GetUnreadNotificationsCount(string userId)
        {
            int count = await _userNotificationRepository.UnreadNotificationsCount(userId);
            return new Response($"UnreadNotifications Count for the user: {count} ");
        }

        public async Task<Response> MarkNotificationAsReadAsync(string userId, int notificationId)
        {
            await _userNotificationRepository.MarkAsReadAsync(notificationId);
            return new Response { IsSuccessfull = true };
        }
    }
}
