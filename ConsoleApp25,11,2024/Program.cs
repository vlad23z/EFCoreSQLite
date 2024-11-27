using ConsoleApp25_11_2024.Contexts;
using ConsoleApp25_11_2024.Models;
using ConsoleApp25_11_2024.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new ExpensesTrackerContext()) {

            var repo = new ExpenseRepository(context);

            var categories =repo.GetAllCategories();



            repo.AddExpense(new Expense
            {
                Date = DateTime.Now,
                Amount = 12,
                Description = "Taxi",
                Category =categories.Skip(1).FirstOrDefault()

            });

            
        
            foreach(var expense in repo.GetAllExpenses()) 
            {
                Console.WriteLine($"Date: {expense.Date}, Amount: {expense.Amount}, Description: {expense.Description}, Category: {expense.Category.Name}");
            }

        }



    }
}