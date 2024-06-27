using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace cashRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double subTotal = 0.0; //Running subTotal for all sales
            double taxTotal = 0.0; //Running total from tax for all sales
            double total = 0.0; //Running total transaction for all sales

            //Create variables to store user input
            string item = "";

            //Create the object that will be for sale
            RetailItem audio = new RetailItem("Audio Book", 50, 8.50);
            RetailItem paperback = new RetailItem("Paperback Book", 50, 12.25);
            RetailItem hardback = new RetailItem("Hardback Book", 10, 20.00);

            //Display name of Store
            WriteLine("Welcome to the Paper Garden");
            WriteLine("Here is what we have on sale");

            //List Items available and their cost
            WriteLine("    Items Available");
            WriteLine("------------------------");
            WriteLine("Item: {0}, Quantity: {1}, Price: {2}", audio.Descrip, audio.UnitOH, audio.UnitPrice.ToString("C2"));
            WriteLine("Item: {0}, Quantity: {1}, Price: {2}", paperback.Descrip, paperback.UnitOH, paperback.UnitPrice.ToString("C2"));
            WriteLine("Item: {0}, Quantity: {1}, Price: {2}", hardback.Descrip, hardback.UnitOH, hardback.UnitPrice.ToString("C2"));

            //Create a loop to continually ask the customer if they would like to buy more
            do
            {
                try
                {
                    Write("Enter the first word of the Item you would like to buy or QUIT to end the transaction: ");
                    item = ReadLine().ToUpper();

                    switch (item) //Use a switch case to determine which object we are using for a CashRegister object
                    {
                        case "AUDIO":
                            itemPurchase(audio, ref subTotal, ref taxTotal, ref total);
                            break;
                        case "PAPER":
                            itemPurchase(paperback, ref subTotal, ref taxTotal, ref total);
                            break;
                        case "HARD":
                            itemPurchase(hardback, ref subTotal, ref taxTotal, ref total);
                            break;
                        case "QUIT":
                            Display(subTotal, taxTotal, total);
                            break;
                        default:
                            throw new ArgumentException();
                            break;
                    }
                }
                catch
                {
                    WriteLine("Invalind input, please try again");
                }
                
            } while (item != "QUIT");
        }

        //Create a method that will run in the switch case to prompt user for quantity and then calculate
        public static void itemPurchase(RetailItem item,ref double subTotal, ref double taxTotal, ref double total)
        {
            int quantity = 0;
            Write("How many {0}s are you wanting to buy: ", item.Descrip);
            quantity = Convert.ToInt32(ReadLine());
            CashRegister audioPurchase = new CashRegister(item, quantity);
            subTotal += audioPurchase.calcSub();
            taxTotal += audioPurchase.calcTax();
            total += audioPurchase.calcTotal();
            WriteLine("Remaining {0}s on hand: {1}", item.Descrip, item.UnitOH);
        }

        public static void Display(double sub, double tax, double total)
        {
            WriteLine("Subtotal: {0}\n" +
                "Sales Tax: {1}\n" +
                "Total: {2}", sub.ToString("c2"), tax.ToString("c2"), total.ToString("c2"));
        }
    }
}

