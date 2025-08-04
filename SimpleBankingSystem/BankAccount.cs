using System.ComponentModel.DataAnnotations;

namespace SimpleBankingSystem
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public string Bvn { get; set; }
        public string Pin { get; set; } 
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, string accountHolder, string bvn, string pin)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Bvn = bvn;
            Pin = pin;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;

            Console.WriteLine($"Deposit of {amount} Successfull! \n\n");
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;

                Console.WriteLine($"{amount} was debited from your account \n\n");
            }
            else
            {
                Console.WriteLine($"Transaction Failed: Insufficient account balance \n\n");
            }
        }

        public void checkBalance()
        {
            Console.WriteLine($"Your account balance as at {DateTime.Now} is {Balance}.00 naira \n\n");
        }

        public void DisplayAccountName(string accountNumber)
        {
            if(AccountNumber == accountNumber)
            {
                Console.WriteLine($"Account Name - {AccountHolder}");
            }
        }

       
    }
}
