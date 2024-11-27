using ConsoleApp25_11_2024.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp25_11_2024.Contexts
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
