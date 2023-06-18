using System;
using System.Net.NetworkInformation;


public class CardHoler
{
    public String CardNum;
    public int pin;
    public String FirstName;
    public String LastName;
    public double balance;

    public CardHoler(string CardNum, int pin, string FirstName, string LastName, double balance)
    {
        this.CardNum = CardNum;
        this.pin = pin;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.balance = balance;
    }
    public String getNum()
    {
        return CardNum;
    }
    //upgrade stuff
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return FirstName;
    }
    public String getLastName()
    {
        return LastName;
    }
    public Double getBalance()
    {
        return balance;
    }

    //set
    public void setNum(String NewCardNum)
    {
        CardNum = NewCardNum;
    }
    public void setPin(int NewPin)
    {
        pin = NewPin;
    }
    public void setFirstName(String NewFirstName)
    {
        FirstName = NewFirstName;
    }
    public void setLastName(String NewLastName)
    {
        LastName = NewLastName;
    }
    public void setBalance(double NewBalance)
    {
        balance = NewBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please Choose From One Of The Following Options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Showbalance");
            Console.WriteLine("4. Exit");

        }
        void deposit(CardHoler currentUser)
        {
            Console.WriteLine("How much $$ would u like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }
        void withdraw(CardHoler currentUser)
        {
            Console.WriteLine("How much $$ would u like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                double newBalance = currentUser.getBalance() - withdraw;
                currentUser.setBalance(newBalance);
                Console.WriteLine("you're good to go! Thank you :)");
            }
        }
            void balance(CardHoler currentUser)
            {
                Console.WriteLine("Current balance :" + currentUser.getBalance());
            }

           List<CardHoler> cardHolers = new List<CardHoler>();
        cardHolers.Add(new CardHoler("121212123232322", 1212, "John", "Griffie", 150.31));
        cardHolers.Add(new CardHoler("121212123212866", 1213, "Kris", "Somaa", 140.31));
        cardHolers.Add(new CardHoler("121212867755757", 1214, "Manurio", "Sin", 170.31));
        cardHolers.Add(new CardHoler("121297866464666", 1215, "Dah", "Min", 107.21));

        //prompt user
        Console.WriteLine("welcome to simple ATM");
        Console.WriteLine("Please insert your debit card");
        String debitCardNum = "";
        CardHoler currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolers.FirstOrDefault(a => a.CardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch {
                    Console.WriteLine("Card not recognized. Please try again");
            }
        }
        Console.WriteLine("Please enter your pin :");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                
                if (currentUser.getPin()==userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Pin.Please try again");
                }
            }
            catch { 
                    Console.WriteLine("Incorrect Pin.Please try again");
            }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName()+" :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1)
            {
                deposit(currentUser);
            }else if(option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        Console.WriteLine("Thank you, have a nice day :)");


    }
}

