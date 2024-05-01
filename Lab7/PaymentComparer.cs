using Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal class PaymentComparer
    {
        public int Compare(Payment? p1, Payment? p2)
        {
            if (p1 == null|| p2 == null)
                throw new ArgumentException("Некорректное значение параметра");
            return p1.Experience() - p2.Experience();
        }
    }
}
