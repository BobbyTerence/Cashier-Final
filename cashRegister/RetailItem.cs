using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cashRegister
{
    internal class RetailItem
    {
        private string descrip;
        private int unitOH; //Units on Hand
        private double unitPrice;

        public string Descrip
        {
            get
            {
                return descrip;
            }
            set
            {
                descrip = value;
            }
        }

        public int UnitOH
        {
            get
            {
                return unitOH;
            }

            set
            {
                unitOH = value;
            }
        }

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
            }
        }

        //Constructor which accepts a value for all values
        public RetailItem(string descrip, int unitOH, double unitPrice)
        {
            this.descrip = descrip;
            this.unitOH = unitOH;
            this.unitPrice = unitPrice;
        }
    }
}
