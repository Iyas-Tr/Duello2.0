using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duello
{
    public class Expense : Budget
    {
        public DateTime Tanggal { get; set; }
        public Expense(string namaBudget, double jumlahUang, DateTime tanggal) : base(namaBudget, jumlahUang)
        {
            NamaBudget = namaBudget;
            JumlahUang = jumlahUang;
            Tanggal = tanggal;
        }
        private List<Expense> listExpense = new List<Expense>();
        public void tambahTransaksi(string NamaExpense, double JumlahExpense, DateTime Date)
        {
            var tempExpense = new Expense(NamaExpense, JumlahExpense, Date);
            listExpense.Add(tempExpense);
        }

        public string GetHistoryExpense()
        {
            var report = new System.Text.StringBuilder();

            double totalUang = 0;
            report.AppendLine("Tanggal\t\tJumlah\tBudget\tNota");
            foreach (var item in listExpense)
            {
                totalUang += item.JumlahUang;
                report.AppendLine($"{item.Tanggal.ToShortDateString()}\t{item.JumlahUang}\t{totalUang}\t{item.NamaBudget}");
            }

            return report.ToString();
        }
    }
}
