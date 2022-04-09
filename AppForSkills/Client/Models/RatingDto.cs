using System;

namespace AppForSkills.Client.Models
{
    public class RatingDto
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public bool ShowRatingButtons { get; set; } = false;
    }
}
