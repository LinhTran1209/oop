using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Bank
    {
        private List<Account> accounts;
        public Bank()
        {
            accounts = new List<Account>();
        }
        public void addAccount()
        {
            Account account = new Account();
            account.createAccount();
            accounts.Add(account);
        }
        public void addAccount(Account account)
        {
            accounts.Add(account);
        }
        public void calculateMoneys()
        {
            if (accounts != null) 
                foreach (var account in accounts)
                    account.calculateMoney();
        }
        public Account findAccount(string accountNumber)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNumber) return account;
            }
            return null;
        }
        public void deposit(string accountNumber, string date, double money)
        {
            Account account = findAccount(accountNumber);
            if (account != null) account.deposit(date, money);
        }
        public void withdraw(string accountNumber, string date, double money)
        {
            Account account = findAccount(accountNumber);
            if (account != null) account.withdraw(date, money);
        }
        public void printAccounts()
        {
            foreach (var account in accounts)
            {
                account.printAccount();
            }
        }
    }
    class Account
    {
        private static int count = 0;
        private string accountNumber;
        private string name;
        private string cmnd;
        private double money;
        private double interestRate;
        public string AccountNumber
        {
            get { return accountNumber; }
        }
        private List<Transaction> transactions;
        public Account() { }
        public Account(string name, string cmnd, double money, double interestRate)
        {
            this.accountNumber = automatically();
            this.name = name;
            this.cmnd = cmnd;
            this.money = money;
            this.interestRate = interestRate;
            transactions = new List<Transaction>();
        }
        private string automatically() //Tự động tăng số hiệu tài khoản
        {
            count++;
            return "AC" + count.ToString();
        }
        public void createAccount()
        {
            this.accountNumber = automatically();
            Console.Write("Nhập số CMND: ");
            this.cmnd = Console.ReadLine();
            Console.Write("Nhập tên account: ");
            this.name = Console.ReadLine();
            // Mới tạo tài khoản thì tiền là 0
            this.money = 0;
            Console.Write("Nhập lãi suất: ");
            this.interestRate = double.Parse(Console.ReadLine());
            transactions = new List<Transaction>();
        }
        public void deposit(string date, double money)//phương thức gửi tiền
        {
            this.money += money;
            Transaction transaction = new Transaction(date, "Gửi tiền", money);
            transactions.Add(transaction);
        }
        public void withdraw(string date, double money)//phương thức rút tiền
        {
            if (money < this.money)
            {
                this.money -= money;
                Transaction transaction = new Transaction(date, "Rút tiền", money);
                transactions.Add(transaction);
            }
            else throw new Exception("Tiền rút nhiều hơn tiền trong tài khoản");
        }
        public void calculateMoney()//tính lãi cập nhật lại tiền
        {
            this.money = this.money * (1 + this.interestRate/100);
        }
        public void printAccount()
        {
            Console.WriteLine($"{"Mã tk",5}  {"Tên tk", 10}  {"CMND",12}  {"Tiền", 10}");
            Console.WriteLine($"{accountNumber,5}  {name,10}  {cmnd,12}  {money,10}");
            Console.WriteLine("----------------------------------------------------------");
            if (transactions.Count > 0)
            {
                foreach (Transaction transaction in transactions)
                {
                    Console.WriteLine(transaction.printTransaction());
                }
            }
            else throw new Exception("Tài khoản chưa có giao dịch");
            Console.WriteLine();
        }
    }
    class Transaction
    {
        protected string date;
        protected string type;
        protected double money;

        public Transaction(string date, string type, double money)
        {
            this.date = date;
            this.type = type;
            this.money = money;
        }
        public string printTransaction()
        {
            return $"-- {date, 10}  {type, -15}  {money, 20}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Bank bank = new Bank();
            Account a1 = new Account("Alice", "901", 100, 5);
            Account a2 = new Account("Bob", "902", 50, 5);
            Account a3 = new Account("Alice", "901", 200, 10);
            Account a4 = new Account("Eve", "903", 200, 10);
            bank.addAccount(a1);
            bank.addAccount(a2);
            bank.addAccount(a3);
            bank.addAccount(a4);
            bank.deposit("AC1", "15/07/2023", 100);
            bank.deposit("AC1", "31/07/2023", 100);
            bank.deposit("AC2", "1/07/2023", 150);
            bank.deposit("AC2", "15/07/2023", 150);
            bank.deposit("AC3", "5/07/2023", 200);
            bank.deposit("AC4", "31/07/2023", 250);
            bank.withdraw("AC1", "20/07/2023", 10);
            bank.withdraw("AC2", "10/08/2023", 20);
            bank.withdraw("AC3", "10/07/2023", 30);
            bank.withdraw("AC4", "20/09/2023", 40);
            bank.printAccounts();
            Console.WriteLine("\n\n\n");
            bank.calculateMoneys();
            bank.printAccounts();
            Console.ReadKey();
        }
    }
}
