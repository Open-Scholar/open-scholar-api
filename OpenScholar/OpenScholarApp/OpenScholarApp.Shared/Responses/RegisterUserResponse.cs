﻿using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Shared.Responses
{
    public class RegisterUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }
    }
}
