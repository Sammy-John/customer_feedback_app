using CustomerFeedbackApp.Data;
using CustomerFeedbackApp.Models;
using Microsoft.AspNetCore.Mvc;

public class FeedbackController : Controller
{
    private readonly ApplicationDbContext _context;

    public FeedbackController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action to display the feedback form
    public IActionResult Index()
    {
        return View(); // Ensure this matches the Index.cshtml view file
    }

    // Action to handle feedback submission
    [HttpPost]
    public async Task<IActionResult> SubmitFeedback(Feedback feedback)
    {
        if (ModelState.IsValid)
        {
            _context.Feedbacks?.Add(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View("Index");
    }
}
