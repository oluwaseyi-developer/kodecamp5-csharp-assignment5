namespace SimpleBankingSystem
{
    public class Progarm
    {
        // My Bank Account Repo (Manual Creation of Account)
        static List<BankAccount> accountsCreated = new List<BankAccount>
                                                   {
                                                       new BankAccount("0512345678", "Samuel Adetogun", "1234567890", "1234"),
                                                       new BankAccount("0523456789", "Maryann Uba", "2345678901", "2345"),
                                                       new BankAccount("0534567890", "Precious Udoibok", "3456789012", "3456"),
                                                       new BankAccount("0545678901", "Abdulsalam Abiola", "4567890123", "4567")
                                                   };

        public static void Main()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("********** Welcome to Simple Bank! **********");
                Console.WriteLine("1. Create An Account With Simple Bank");    // Dynamic Creation of Account
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit\n\n");

                Console.Write("Enter Your Respnse here: ");
                int response = int.Parse(Console.ReadLine());

                switch (response)
                {
                    case 1:
                        /* for this scenario I just wanted to ask for the user's name
                           and bvn, from there I will generate a unique account number for them.
                        */

                        Console.Write("Enter Your Full Name Here: ");
                        string nameInput = Console.ReadLine();
                        string fullName = AccountNameValidation(nameInput);


                        if (fullName == null)
                        {
                            Console.WriteLine("Account creation cancelled.\n");
                            break;
                        }


                        string bvn = BvnValidation();

                        if (bvn == null)
                        {
                            Console.WriteLine("Account creation cancelled.\n");
                            break;
                        }


                        //Generate Account Number
                        string accountNumber = GenerateAccountNumber();

                        // Creation of Pin
                        Console.Write($"Create Pin For Your New Generated Account {accountNumber} Here: ");
                        string pinInput = Console.ReadLine();
                        string pin = PinCreationValidation(pinInput);

                        if (pin == null)
                        {
                            Console.WriteLine("Account creation cancelled.\n");
                            break;
                        }

                        BankAccount createAccount = new BankAccount(accountNumber, fullName, bvn, pin);

                        // save account into repo 
                        accountsCreated.Add(createAccount);

                        Console.WriteLine($"Congratulations! Account Number {accountNumber} and Pin {pin} Created Successfully. \n\n");

                        break;

                    case 2:
                        var accountForDeposit = GetAccountFromUser();
                        if (accountForDeposit == null)
                        {
                            break;
                        }

                        Console.Write("Enter Your Deposit Amount Here: ");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        if (amount <= 0)
                        {
                            Console.WriteLine($"{amount} naira is too low for deposit.\n\n");
                            break;
                        }

                        accountForDeposit.Deposit(amount);
                        break;

                    case 3:
                        var accountForWithdraw = accountVerification();
                        if (accountForWithdraw == null)
                        {
                            break;
                        }

                        Console.Write("Enter Amount To Withdraw: ");
                        decimal amountForWithdraw = decimal.Parse(Console.ReadLine());

                        accountForWithdraw.Withdraw(amountForWithdraw);

                        break;

                    case 4:
                        var accountForBalance = accountVerification();

                        if(accountForBalance == null)
                        {
                            break;
                        }

                        accountForBalance.checkBalance();
                        break;

                    case 5:
                        isContinue = false;
                        Console.WriteLine("GoodBye!!!");
                        break;

                    default:
                        Console.WriteLine("Wrong Selection! \n\n");
                        break;
                }
            }

        }





        //********************************************* HELPER FUNCTIONS *********************************************


        // Account Name Validation
        static string AccountNameValidation(string fullName)
        {
            while (true)
            {

                if (!string.IsNullOrWhiteSpace(fullName) && fullName.All(c => char.IsLetter(c) || c == ' '))
                {
                    return fullName;
                }

                Console.WriteLine("Invalid Name. Please try again or type 'exit' to cancel.");
                Console.Write("Enter Full Name Again: ");
                fullName = Console.ReadLine();

                if (fullName?.ToLower() == "exit")
                {
                    return null;
                }

            }
        }

        // Bvn Validation
        static string BvnValidation()
        {
            while (true)
            {
                Console.Write("Enter Your Bvn Here: ");
                string bvn = Console.ReadLine();

                if (bvn?.ToLower() == "exit")
                {
                    return null;
                }

                // Validating the Bvn.
                if (string.IsNullOrEmpty(bvn) || !bvn.All(char.IsDigit) || bvn.Length != 10)
                {
                    Console.WriteLine("Invalid BVN. Must be 10 digits. Try again or type 'exit' to cancel.");
                    continue;
                }

                // Checking if the Bvn exist.
                if (accountsCreated.Any(b => b.Bvn == bvn))
                {
                    Console.WriteLine("BVN Already Exists. Try another or type 'exit' to cancel.");
                    continue;
                }

                return bvn;
            }
        }

        // Generate new unique account number for the customer that start with 05:
        static string GenerateAccountNumber()
        {
            string accountNumber;
            Random rnd = new Random();

            do
            {
                string random8Numbers = rnd.Next(0, 99999999).ToString("D8"); //This helps to make sure it's up to 8 digits
                accountNumber = "05" + random8Numbers;
            }
            while (accountsCreated.Exists(a => a.AccountNumber == accountNumber)); // Checking for uniqueness

            return accountNumber;
        }

        // Pin Creation Validation
        static string PinCreationValidation(string pin)
        {
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(pin) && pin.All(char.IsDigit) && pin.Length == 4)
                {
                    return pin;
                }

                Console.WriteLine("Invalid Pin. Please try again or type 'exit' to cancel.");
                Console.Write("Enter Pin Again: ");
                pin = Console.ReadLine();

                if (pin?.ToLower() == "exit")
                {
                    return null;
                }
            }
        }

        // Account Number Validation
        static string AccountNumberValidation(string accountNum)
        {
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(accountNum) && accountNum.All(char.IsDigit) && accountNum.Length == 10)
                {
                    return accountNum;
                }

                Console.WriteLine("Invalid Account. Please try again or type 'exit' to cancel.");
                Console.Write("Enter Account Again: ");
                accountNum = Console.ReadLine();

                if (accountNum?.ToLower() == "exit")
                {
                    return null;
                }
            }
        }

        static string isAccountExist()
        {
            Console.Write("Enter Account Number Here: ");
            string inputNumber = Console.ReadLine();
            string accountNumber = AccountNumberValidation(inputNumber);

            if (accountNumber == null)
            {
                return null;
            }

            if (!accountsCreated.Any(a => a.AccountNumber == accountNumber))
            {
                Console.WriteLine("Account Doesn't exist. Please try again or type 'exit' to cancel.");
                Console.Write("Enter Account Again: ");
                accountNumber = Console.ReadLine();

                if (accountNumber?.ToLower() == "exit")
                {
                    return null;
                }
            }

            return accountNumber;
        }

        static BankAccount GetAccountFromUser()
        {
            string accountNum = isAccountExist();

            if (accountNum == null)
            {
                return null;
            }

            var account = accountsCreated.FirstOrDefault(a => a.AccountNumber == accountNum);

            if (account == null)
            {
                Console.WriteLine("No account found with that number.");
                return null;
            }

            account.DisplayAccountName(accountNum);
            return account;
        }  

        static BankAccount accountVerification()
        {
            var account = GetAccountFromUser();

            int count = 0;

            while (true) 
            {
                count++;

                if (count <= 3)
                {
                    Console.Write("Enter Pin: ");
                    string pin = Console.ReadLine();

                    if (account.Pin != pin)
                    {
                        Console.WriteLine("Wrong Pin! \n");
                        continue;
                    }

                    return account;
                }
                else
                {
                    Console.WriteLine("You have exceeded the pin input limit \n\n");
                    return null;
                }
            }

        }

    }
}
