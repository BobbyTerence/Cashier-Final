using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashRegister
{
    internal class CashRegister
    {
        const double SALES_TAX = .06;
        private RetailItem item;
        private int itemQuan;
        private double subTotal;
        private double taxTotal;

        public double calcSub() //Calculates the subTotal
        {
            subTotal = item.UnitPrice * itemQuan;

            return subTotal; //Return value to Main class
        }

        public double calcTax() //Calculates tax amount
        {
            taxTotal = subTotal * SALES_TAX;

            return taxTotal; //Return value to Main class
        }

        public double calcTotal() // calculates the total of this transaction
        {
            return subTotal + taxTotal;
            /*
             * No need to create a variable for total in this class
             * since it is just returning the value to the Main class
             * and then the use for this class is over
             */
        }

        public CashRegister(RetailItem item, int quantity)
        {
            if (quantity > item.UnitOH) //Throw Exception if the given quantity is greater than the quantity on hand
            {
                throw new ArgumentException();
            }

            this.item = item;
            itemQuan = quantity;

            item.UnitOH = item.UnitOH - quantity;
        }
    }
}
