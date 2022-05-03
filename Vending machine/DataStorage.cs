using System;
using System.Collections.Generic;
using System.Text;
using InputCollectionAndValidation;

namespace Vending_machine
{
    public class userModel
    {
        public int moneyPool;
    }

    public class productModel
    {
        public string name;
        public int price;
        public string usageType;
        public void use()
        {
            Console.WriteLine($"You { usageType } the { name }.");
        }
        public void examine()
        {
            Console.WriteLine($"The { name } costs { price }.");
        }
    }

    public class cola : productModel
    {
        public void setProperties()
        {
            name = "Cola";
            price = 12;
            usageType = "drink";
        }
    }
    public class chips : productModel
    {
        public void setProperties()
        {
            name = "chips";
            price = 28;
            usageType = "eat";
        }
    }
    public class iceTea : productModel
    {
        public void setProperties()
        {
            name = "Ice tea";
            price = 16;
            usageType = "drink";
        }
    }
    public class programBehaviour : IVending
    {
        public int purchase(int balance)
        {
            //initalising the products in this method
            cola coke = new cola();
            coke.setProperties();
            chips pringles = new chips();
            pringles.setProperties();
            iceTea tea = new iceTea();
            tea.setProperties();

            bool another = true;

            while (another)
            {
                Console.WriteLine($"You see three items: {coke.name}, {pringles.name}, {tea.name}\nWhich one do you wish to purchace.\nOr type \"exit\" to go back to the main menu.");
                string holder = Console.ReadLine();
                while (!(holder == coke.name || holder == pringles.name || holder == tea.name || holder != "exit"))
                {
                    Console.WriteLine("Your input was invalid, please try again.");
                    holder = Console.ReadLine();
                }
                Console.WriteLine($"You purchace a {holder}, would you like to use this item? (yes/no)");
                string useHolder = Console.ReadLine().ToLower();
                while (!(useHolder == "yes" || useHolder == "no"))
                {
                    Console.WriteLine("Your input was invalid, please try again.");
                    useHolder = Console.ReadLine().ToLower();
                }
                if (holder == coke.name)
                {
                    if (balance < coke.price)
                    {
                        Console.WriteLine($"You cannot afford the {coke.name}.");
                    }
                    else
                    {
                        balance -= coke.price;
                        if (useHolder == "yes")
                        {
                            coke.use();
                        } 
                    }
                }
                if (holder == pringles.name)
                {
                    if (balance < pringles.price)
                    {
                        Console.WriteLine($"You cannot afford the {pringles.name}.");
                    }
                    else
                    {
                        balance -= pringles.price;
                        if (useHolder == "yes")
                        {
                            pringles.use();
                        }
                    }
                }
                if (holder == tea.name)
                {
                    if (balance < tea.price)
                    {
                        Console.WriteLine($"You cannot afford the {tea.name}.");
                    }
                    else
                    {
                        balance -= tea.price;
                        if (useHolder == "yes")
                        {
                            tea.use();
                        }
                    }
                }
                Console.WriteLine("Would you like to purcase another item? (yes/no)");
                useHolder = Console.ReadLine().ToLower();
                while (!(useHolder == "yes" || useHolder == "no"))
                {
                    Console.WriteLine("Your input was invalid, please try again.");
                    useHolder = Console.ReadLine().ToLower();
                }
                if (useHolder == "no")
                {
                    another = false;
                }
            }
            Console.Read();
            return balance;
        }
        public void showAll()
        {
            //initalising the products in this method
            cola coke = new cola();
            coke.setProperties();
            chips pringles = new chips();
            pringles.setProperties();
            iceTea tea = new iceTea();
            tea.setProperties();

            Console.WriteLine("You see three products;");
            coke.examine();
            pringles.examine();
            tea.examine();

            Console.Read();
        }
        public int insertMoney()
        {
            inAndOut validator = new inAndOut();
            string holder;
            int[] denominations = new int[8] { 1000, 500, 100, 50, 20, 10, 5, 1 };
            bool toInsert = true;
            int inserted = 0;
            while (toInsert)
            {
                int insertHolder = 0;
                Console.WriteLine("What size note would you like to insert? (1000, 500, 100, 50, 20, 10, 5, 1)\nOr type \"exit\" to go back to the main menu.");
                holder = Console.ReadLine().ToLower();
                if (holder != "exit")
                {
                    insertHolder = validator.isInt(holder);
                }
                else
                {
                    toInsert = false;
                }
                foreach (int note in denominations)
                {
                    if (insertHolder == note)
                    {
                        Console.WriteLine("Your note has be inserted successfully.");
                        inserted += insertHolder;
                    }
                }
            }
            return inserted;
        }
        public void endTransaction(int remainder)
        {
            int[] denominations = new int[8] { 1000, 500, 100, 50, 20, 10, 5, 1 };
            int[] returnedNotes = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < denominations.Length; i++)
            {
                while (remainder > denominations[i])
                {
                    remainder -= denominations[i];
                    returnedNotes[i]++;
                }
            }
            for (int i = 0; i < returnedNotes.Length; i++)
            {
                if (returnedNotes[i] > 0)
                {
                    Console.WriteLine($"You recieve { returnedNotes[i] } { denominations[i] }kr notes,");
                }
            }
            Console.Read();
        }
    }
}
