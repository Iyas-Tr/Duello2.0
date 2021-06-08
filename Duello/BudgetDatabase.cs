using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Duello.Data
{
    class BudgetDatabase : DbContext
    {
        public DbSet<Budget> Budgetss { get; set; }
        public DbSet<Income> Incomess { get; set; }
        public DbSet<Expense> Expensess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_Budget;Integrated Security=True");
        }
    }
}