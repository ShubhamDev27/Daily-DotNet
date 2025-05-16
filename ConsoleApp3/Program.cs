using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_5
{
    abstract class Account
    {
        private static int cnt = 1;
        readonly int Id;
        private string name;
        protected double balance;
        private static double rate = 0.7;
        const double minbal = 1000;

        public Account(string name, double balance)
        {
            if (balance < minbal)
            {
                throw new Exception("Balance must be more than minimum balance !");
            }
            Id = cnt++;
            this.name = name;
            this.balance = balance;
        }

        public abstract void withdraw(double amt);

        public void Deposite(double amt)
        {
            balance += amt;
        }
        static Account()
        {
            Console.WriteLine("Welcome to Bank Of Mine !");
        }
        public override string ToString()
        {
            return $"Id: {Id},Name : {name},Sallary : {balance},";
        }

    }
    class Saving : Account
    {
        private string type;
        public Saving(string name, double balance, string type) : base(name, balance)
        {
            this.type = type;

        }
        public override void withdraw(double amt)
        {
            if (amt <= 0)
            {
                throw new Exception("amount must be positive !");
            }
            else
            {
                balance -= amt;
            }
        }
    }
    class Current : Account
    {
        private string type;

        public Current(string name, double balance, string type) : base(name, balance)
        {
            this.type = type;

        }
        public override void withdraw(double amt)
        {
            if (amt <= 0)
            {
                throw new Exception("amount must be positive !");
            }
            else
            {
                balance += amt;
            }
        }
    }
    public class program
    {
        static void Main(string[] args)
        {
            try
            {
                Account[] a1 = new Account[2];
                a1[0] = new Saving("Shubham", 65000, "Saving");
                a1[1] = new Current("Adwait", 75000, "Current");

                foreach (Account a in a1)
                {
                    a.Deposite(2000);
                    Console.WriteLine(a);
                    a.withdraw(5000);
                    Console.WriteLine(a);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e.Message);
            }
        }
    }
}
