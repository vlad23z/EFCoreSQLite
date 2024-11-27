using ExpensesTrackerLibrary.Models;

using Microsoft.EntityFrameworkCore;


namespace ExpensesTrackerLibrary.Contexts
{
    public class ExpensesTrackerContext : DbContext 
    {
        public DbSet<Category>Categories { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public ExpensesTrackerContext()
        {
            //Удаляем базу если она есть


            //Создаем новую
            Database.EnsureCreated();
        }
        //метод подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite("Data Source=Expenses.db");
        }
    }
}
