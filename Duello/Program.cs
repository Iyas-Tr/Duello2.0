using System;
using System.Linq;
using Duello.Data;
using Microsoft.EntityFrameworkCore;

namespace Duello
{
    class Program
    {
        static void Main(string[] args)
        {
            using BudgetDatabase context = new BudgetDatabase();

            Console.WriteLine("Selamat datang di aplikasi budgeting anak kos Duello\nSilakan masukkan nama budget anda");
            string namaBudget = Console.ReadLine();
            Console.WriteLine("Silakan masukkan jumlah uang dari budget anda");
            double jumlahUang = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Budget dengan nama {namaBudget} dan jumlah {jumlahUang} IDR sudah dibuat!");
            var budget1 = new Budget(namaBudget, jumlahUang);
            budget1.tambahIncomeBudget(jumlahUang, DateTime.Now, "inisialisasi budget");
            var income1 = new Income("Inisialisasi", 0, DateTime.Now);
            income1.tambahTransaksi("inisialisasi income", 0, DateTime.Now);
            var expense1 = new Expense("Inisialisasi", 0, DateTime.Now);
            expense1.tambahTransaksi("inisialisasi expense", 0, DateTime.Now);
            context.Budgetss.Add(budget1);
            context.SaveChanges();

            void lakukanIncome()
            {
                Console.WriteLine("Masukkan nama income");
                string namaIncome = Console.ReadLine();
                Console.WriteLine("Masukkan jumlah income");
                double jumlahIncome = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Income {namaIncome} dengan jumlah {jumlahIncome} IDR sudah dimasukkan");
                budget1.tambahIncomeBudget(jumlahIncome, DateTime.Now, namaIncome);
                income1.tambahTransaksi(namaIncome, jumlahIncome, DateTime.Now);
                context.SaveChanges();
            }

            void lakukanExpense()
            {
                Console.WriteLine("Masukkan nama expense");
                string namaExpense = Console.ReadLine();
                Console.WriteLine("Masukkan jumlah expense");
                double jumlahExpense = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Expense {namaExpense} dengan jumlah {jumlahExpense} IDR sudah dimasukkan");
                budget1.tambahExpenseBudget(jumlahExpense, DateTime.Now, namaExpense);
                expense1.tambahTransaksi(namaExpense, jumlahExpense, DateTime.Now);
                context.SaveChanges();
            }

            Console.WriteLine("Selamat datang di menu utama. Silakan pilih apa yang ingin anda lakukan");
            bool Exit = false;
            while (!Exit)
            {
                Console.WriteLine("Masukkan 1 untuk tambah income.\n2 untuk tambah expense.");
                Console.WriteLine("3 untuk melihat seluruh income dan expense.\n4 untuk melihat seluruh income");
                Console.WriteLine("5 untuk melihat seluruh expense. \n6 untuk keluar dari aplikasi.");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        lakukanIncome();
                        Exit = false;
                        break;

                    case 2:
                        lakukanExpense();
                        Exit = false;
                        break;

                    case 3:
                        Console.WriteLine(budget1.GetBudgetHistory());
                        Exit = false;
                        break;

                    case 4:
                        Console.WriteLine(income1.GetHistoryIncome());
                        Exit = false;
                        break;

                    case 5:
                        Console.WriteLine(expense1.GetHistoryExpense());
                        Exit = false;
                        break;

                    case 6:
                        Console.WriteLine("Selamat tinggal");
                        Exit = true;
                        break;

                    default:
                        Console.WriteLine("Perintah tidak valid!");
                        Exit = false;
                        break;
                }
            }
        }
    }
}
