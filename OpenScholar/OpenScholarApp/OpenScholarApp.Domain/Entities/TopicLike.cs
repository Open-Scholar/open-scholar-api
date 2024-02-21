﻿namespace OpenScholarApp.Domain.Entities
{
    public class TopicLike
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
    }
}
