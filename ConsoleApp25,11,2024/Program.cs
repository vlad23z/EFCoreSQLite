using ConsoleApp25_11_2024.Contexts;
using ConsoleApp25_11_2024.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new ExpensesTrackerContext()) {

            //context.Categories.Add(new Category { Name="Food" });
            //context.Categories.Add(new Category { Name="Transportation" });

            //context.SaveChanges();


            context.Expenses.Add(new Expense
            {
                Date= DateTime.Now, 
                Amount=50,
                Description="Diner",
                Category=context.Categories.FirstOrDefault()

            });
        
        context.SaveChanges();
        
            var expenses=context.Expenses.ToList();
            foreach (var expense in expenses)
            {
                Console.WriteLine($"Date: {expense.Date}, Amount: {expense.Amount}, Description: {expense.Description}, Category: {expense.Category.Name}");
            }

        }


>>>>>>> Stashed changes
    }
}