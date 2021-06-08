using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duello
{
    public class Income : Budget
    {
        public DateTime Tanggal { get; set; }
        public Income(string namaBudget, double jumlahUang, DateTime tanggal) : base(namaBudget, jumlahUang)
        {
            NamaBudget = namaBudget;
            JumlahUang = jumlahUang;
            Tanggal = tanggal;
        }

        private List<Income> listIncome = new List<Income>();

        public void tambahTransaksi(string NamaIncome, double JumlahIncome, DateTime Date)
        {
            var tempIncome = new Income(NamaIncome, JumlahIncome, Date);
            listIncome.Add(tempIncome);
        }

        public string GetHistoryIncome()
        {
            var report = new System.Text.StringBuilder();

            double totalUang = 0;
            report.AppendLine("Tanggal\t\tJumlah\tBudget\tNota");
            foreach (var item in listIncome)
            {
                totalUang += item.JumlahUang;
                report.AppendLine($"{item.Tanggal.ToShortDateString()}\t{item.JumlahUang}\t{totalUang}\t{item.NamaBudget}");
            }

            return report.ToString();
        }
    }
}
