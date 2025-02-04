using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Ex1
{
    class clsStudentBookSale:clsBookSale
    {
        bool blnStudetnDiscount;
        const float sngStudentDiscountRate = 0.15f;

        public clsStudentBookSale(string title, int quantity, decimal price, bool discount, 
            bool student):base(title, quantity, price, discount)
        {
            blnStudetnDiscount = student;
        }

        public bool StudentDiscount
        {
            get { return blnStudetnDiscount; }
            set { blnStudetnDiscount = value; }
        }
        public override decimal DiscountAmount()
        {
            decimal decDiscountAmount;
            decDiscountAmount = base.DiscountAmount();

            if (StudentDiscount)
            {
                decDiscountAmount += ExtendedPrice() * Convert.ToDecimal(sngStudentDiscountRate);
            }
            return decDiscountAmount;
        }
    }
}
