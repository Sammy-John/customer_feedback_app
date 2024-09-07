using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerFeedbackApp.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty; // Initialize with an empty string

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty; // Initialize with an empty string

        [Required(ErrorMessage = "Feedback type is required")]
        public string FeedbackType { get; set; } = string.Empty; // Initialize with an empty string

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = string.Empty; // Initialize with an empty string

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}

