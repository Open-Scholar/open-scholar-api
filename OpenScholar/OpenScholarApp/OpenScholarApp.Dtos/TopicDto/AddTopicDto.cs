﻿namespace OpenScholarApp.Dtos.TopicDto
{
    public class AddTopicDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    }
}
