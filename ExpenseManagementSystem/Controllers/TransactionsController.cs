using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManagementSystem.Models;

public class TransactionsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TransactionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var transactions = await _context.Transactions
            .Where(t => t.UserId == userId)
            .Include(t => t.Category)
            .ToListAsync();
        return View(transactions);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Transaction transaction)
    {
        transaction.UserId = _userManager.GetUserId(User);
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
