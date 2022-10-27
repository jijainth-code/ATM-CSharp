using System;


public class cardholder
{

    string firstname;
    string lastname;
    string cardnum;
    int pin;
    double balance;

    public cardholder(string firstname, string lastname, string cardnum, int pin, double balance)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.cardnum = cardnum;
        this.pin = pin;
        this.balance = balance;
    }

    public string getnum() { return cardnum; }
    public string getfirstname() { return firstname; }
    public string getlastname() { return lastname; }
    public double getbalance() { return balance; }
    public int getpin() { return pin; }

    public void setpin(int newpin) { pin = newpin; }
    public void setbalance(double newbalance) { balance = newbalance; }

    

    public static void Main(String[] args)
    {
        void options()
        {
            Console.WriteLine("Press 1 to Deposit ");
            Console.WriteLine("Press 2 to Withdraw");
            Console.WriteLine("Press 3 to view your balance");
            Console.WriteLine("Press 4 to change your Pin");
            Console.WriteLine("Press 5 to Exit");
        }

        void deposit(cardholder currentuser)
        {
            Console.WriteLine("Enter the amount you want to deposite :");
            double deposit = Double.Parse(Console.ReadLine());

            currentuser.setbalance(currentuser.balance + deposit);
            Console.WriteLine("deposited " + deposit + " . Total Balance = " + currentuser.getbalance());
        }

        void withdraw(cardholder currentuser)
        {
            Console.WriteLine("Enter the amount you want to withdraw :");
            double withdraw = Double.Parse(Console.ReadLine());
            if (withdraw > currentuser.getbalance())
            {
                Console.WriteLine("Withdraw amount exceeds currennt Balance");
            }
            else
            {
                currentuser.setbalance(currentuser.getbalance() - withdraw);
                Console.WriteLine("Withdraw Successfull ! . Total Balance = " + currentuser.getbalance());
            }

        }

        void viewblc(cardholder currentuser)
        {
            Console.WriteLine(" Total Balance = " + currentuser.getbalance());
        }

        void changepin(cardholder currentuser)
        {
            Console.WriteLine("Enter the new Pin : ");
            int newp = int.Parse(Console.ReadLine());
            currentuser.setpin(newp);
        }

        List<cardholder> cardhold = new List<cardholder>();
        cardhold.Add(new cardholder ("John", "Griffith", "4532772818527395", 1234, 156.31));
        cardhold.Add(new cardholder( "Ashley", "Jones", "4532761841325802", 4321, 321.13));
        cardhold.Add(new cardholder( "Frida", "Dickerson", "5128381368581872", 9999, 105.59));
        cardhold.Add(new cardholder( "Muneeb", "Harding", "6011188364697109", 2468, 851.84));
        cardhold.Add(new cardholder( "Dawn", "Smith", "3490693153147110", 4826, 54.27));


        cardholder currentuser;

        void welcome()
        {
            Console.WriteLine("Welcome to Eos Banking");
            string usernumber = "";
            int userpin = 0;


            Console.WriteLine("Enter your UserNumber : ");

            while (true)
            {
                try
                {
                    usernumber = Console.ReadLine();
                    currentuser = cardhold.FirstOrDefault(a => a.cardnum == usernumber);
                    if (currentuser != null) { break; }
                    else { Console.WriteLine("Invalid UserName , Try again ."); }
                }
                catch
                {
                    Console.WriteLine("Invalid UserName , Try again .");
                }
            }

            Console.WriteLine("Enter your Pin : ");

            while (true)
            {
                try
                {
                    userpin = int.Parse(Console.ReadLine());
                    if (userpin == currentuser.pin)
                    {
                        Console.WriteLine("Access Granted");
                        break;
                    }
                    else { Console.WriteLine("Invalid Pin , Try again ."); }
                }
                catch
                {
                    Console.WriteLine("Invalid Pin , Try again .");
                }
            }

            Console.WriteLine("Welcome " + currentuser.getfirstname());
           
        }

        welcome();

        int opt = 0;
        do
        {
            options();
            try
            {
                opt = int.Parse(Console.ReadLine());

            }
            catch
            {

            }

            if (opt == 1) { deposit(currentuser); }
            else if (opt == 2) { withdraw(currentuser); }
            else if (opt == 3) { viewblc(currentuser); }
            else if (opt == 4) { changepin(currentuser); }
            else if (opt == 5) {
                Console.WriteLine("Thank you , Remainder : Dont go Broke ;)  /n/n ");
                opt = 0;
                welcome(); }

            

        }

        while (opt != 5);
            Console.WriteLine("Thank you , Remainder : Dont go Broke ;)  ");
        






    }
}