using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerFeedbackApp.Data;
using CustomerFeedbackApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerFeedbackApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, string statusFilter, string typeFilter, int? pageNumber)
        {
            // Sorting parameters
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";

            // Filtering parameters
            ViewData["CurrentFilter"] = searchString;
            ViewData["StatusFilter"] = statusFilter;
            ViewData["TypeFilter"] = typeFilter;

            // Handle search and filter logic
            if (searchString != null || statusFilter != null || typeFilter != null)
            {
                pageNumber = 1; // Reset page number if any filter is applied
            }
            else
            {
                searchString = currentFilter; // Use existing filter for search
            }

            var feedbacks = from f in _context.Feedbacks
                            select f;

            // Apply Search Filter
            if (!String.IsNullOrEmpty(searchString))
            {
                feedbacks = feedbacks.Where(f => f.Name.Contains(searchString) || f.Email.Contains(searchString));
            }

            // Apply Status Filter
            if (!String.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                feedbacks = feedbacks.Where(f => f.Status == statusFilter);
            }

            // Apply Type Filter
            if (!String.IsNullOrEmpty(typeFilter) && typeFilter != "All Types")
            {
                feedbacks = feedbacks.Where(f => f.FeedbackType == typeFilter);
            }

            // Apply Sorting
            feedbacks = sortOrder switch
            {
                "name_desc" => feedbacks.OrderByDescending(f => f.Name),
                "Date" => feedbacks.OrderBy(f => f.SubmittedAt),
                "date_desc" => feedbacks.OrderByDescending(f => f.SubmittedAt),
                _ => feedbacks.OrderBy(f => f.Name),
            };

            int pageSize = 5;
            return View(await PaginatedList<Feedback>.CreateAsync(feedbacks.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // Redirect back to Index
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, string status)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                TempData["ErrorMessage"] = "Feedback not found."; // Error message
                return RedirectToAction(nameof(Index)); // Redirect back to Index
            }

            feedback.Status = status; // Update the status
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Status updated successfully!"; // Success message
            return RedirectToAction(nameof(Index)); // Redirect back to Index
        }

    }
}
