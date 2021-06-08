using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Duello
{
    public class Budget
    {
        public int Id { get; set; }
        public string NamaBudget { get; set; }
        public double JumlahUang { get; set; }
        public Budget(string namaBudget, double jumlahUang)
        {
            NamaBudget = namaBudget;
            JumlahUang = jumlahUang;
        }

        private List<TotalBudget> allTotal = new List<TotalBudget>();

        public void tambahIncomeBudget(double jumlahIncome, DateTime date, string namaIncome)
        {
            if (jumlahIncome <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(jumlahIncome), "Income tidak boleh bernilai negatif");
            }
            var income = new TotalBudget(jumlahIncome, date, namaIncome);
            allTotal.Add(income);
        }
        public void tambahExpenseBudget(double jumlahExpense, DateTime date, string namaExpense)
        {
            if (jumlahExpense <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(jumlahExpense), "Expense tidak boleh bernilai negatif, sistem akan mengubah ke negatif secara otomatis");
            }
            var expense = new TotalBudget(-jumlahExpense, date, namaExpense);
            allTotal.Add(expense);
        }
        public string GetBudgetHistory()
        {
            var report = new System.Text.StringBuilder();

            double jumlahUang = 0;
            report.AppendLine("Tanggal\t\tJumlah\tBudget\tNota");
            foreach (var item in allTotal)
            {
                jumlahUang += item.Jumlah;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Jumlah}\t{jumlahUang}\t{item.Nama}");
            }

            return report.ToString();
        }

        public virtual void getHistory() { }
    }
}
