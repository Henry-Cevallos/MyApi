using System;
using System.Threading;

namespace Activity4
{

    class Activity4
    {
        static void Main(string[] args)
        {
            var myCheckingAccount = new CheckingBankAccount(1100.23, "Bob Smith");
            var accountEncryptor = new AccountEncryptor();
            var securityCompany = new SecurityCompany();

            accountEncryptor.AccountEncrypted += securityCompany.onAccountEncrypted;
           
            accountEncryptor.Encrypt(myCheckingAccount);
        }
    }

    interface BankAccount
    {
        public double Balance
        {
            get;
            set;
        }
        public string AccountHolder
        {
            get;
            set;
        }

        private void Transaction(double amount)
        {
            Balance += amount;
        }
    }

    class CheckingBankAccount: BankAccount
    {
        public double Balance
        {
            get;
            set;
        }

        public string AccountHolder
        {
            get;
            set;
        }


        private void Transaction(double amount)
        {
            Balance += amount;
        }

        public CheckingBankAccount(double balance, string accountHolder)
        {
            Balance = balance;
            AccountHolder = accountHolder;
        }

    }

    class AccountEncryptor
    {
        public delegate void AcountEncryptorEventHandler(object source, EventArgs args);

        public event AcountEncryptorEventHandler AccountEncrypted;

        public void Encrypt(CheckingBankAccount checkingAccount)
        {
            Console.WriteLine("Encrpting Information...");
            OnAccountEncrypted();
        }

        protected virtual void OnAccountEncrypted()
        {
            if(AccountEncrypted != null)
            {
                AccountEncrypted(this, EventArgs.Empty);
            }
        }

    }

    class SecurityCompany
    {
        public void onAccountEncrypted(object source, EventArgs e)
        {
            Console.WriteLine("Bank acoount information Encrypted.");
        }
    }

}