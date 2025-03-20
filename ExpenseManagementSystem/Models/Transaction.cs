﻿namespace ExpenseManagementSystem.Models;
public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
