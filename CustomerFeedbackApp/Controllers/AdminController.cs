using Microsoft.AspNetCore.Mvc;
using CustomerFeedbackApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomerFeedbackApp.Models;

namespace CustomerFeedbackApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Explicitly check if _context.Feedbacks is null
            var feedbacks = _context.Feedbacks != null
                ? await _context.Feedbacks.ToListAsync()
                : new List<Feedback>(); // Return an empty list if Feedbacks is null

            return View(feedbacks);
        }


    }
}
