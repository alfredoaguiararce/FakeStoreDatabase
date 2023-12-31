﻿namespace FakeStore.Database.Models
{
    public class FakeUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Archived { get; set; }
        public bool IsAdmin { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
