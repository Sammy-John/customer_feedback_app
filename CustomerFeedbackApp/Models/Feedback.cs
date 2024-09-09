using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerFeedbackApp.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Feedback type is required")]
        public string FeedbackType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        // New Status property
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; } = "Pending"; // Default value set to "Pending"
    }
}

