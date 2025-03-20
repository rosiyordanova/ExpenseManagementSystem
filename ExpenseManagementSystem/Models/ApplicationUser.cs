using Microsoft.AspNetCore.Identity;
using ExpenseManagementSystem.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Transaction> Transactions { get; set; }
}
