using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments
{
    internal class Payment : IComparable<Payment>
    {
        public string Фамилия { get; set; } //Фамилия
        public double Оклад { get; set; } //Оклад
        public int Year; // Год поступления на работу
        public int Год
        {
            get
            { return Year; }
            set
            {
                if (value <= 2024 && value >= 1980)
                {
                    Year = value;
                }
                else value = 0;
            }
        }
        public double ProcentBonus; //Процент надбавки
        public double Процентный_Бонус // свойство для проверки информации
        {
            get { return ProcentBonus; }
            set
            {
                if (value > 0)
                {
                    ProcentBonus = value;
                }
                else value = 0;
            }
        }
        public int GivenAmount; //Начисленная сумма
        public int Выплачено // свойство для проверки иформации
        {
            get { return GivenAmount; }
            set
            {
                if (value >= 0)
                {
                    GivenAmount = value;
                }
                else value = 0;
            }
        }
        public double ProcentWithheldAmount; //Удержанная сумма в процентах
        public double Долг_в_процентах // свойство для проверки иформации
        {
            get { return ProcentWithheldAmount; }
            set
            {
                if (value >= 0)
                {
                    ProcentWithheldAmount = value;
                }
                else value = 0;
            }
        }
        public Payment(string LastName, double Salary, int Year, double ProcentBonus, int GivenAmount, double ProcentWithheldAmount)//Заполняемый конструктор
        {
            this.Фамилия = LastName;
            this.Оклад = Salary;
            this.Год = Year;
            this.Процентный_Бонус = ProcentBonus;
            this.Выплачено = GivenAmount;
            this.Долг_в_процентах = ProcentWithheldAmount;

        }
        public Payment()//пустой конструктор
        {
            Фамилия = "";
            Оклад = 0;
            Year = 1980;
            ProcentBonus = 0;
            GivenAmount = 0;
            ProcentWithheldAmount = 0;
        }
        public double CalculationGivenAmount()//выданная сумма
        {
            return Оклад + (Оклад * ProcentBonus) - (Оклад - ProcentWithheldAmount);
        }
        public double CalculationWithheldAmount()//удержанная сумма
        {
            return Оклад * ProcentWithheldAmount;
        }
        public int Experience()//стаж работы
        {
            return 2024 - Year;
        }
        public double PencionDeductions()//пенсионный взнос
        {
            return Оклад * 0.22;
        }
        public double TaxDeductions()//НДС
        {
            return Оклад * 0.13;
        }
        public static Payment operator +(Payment p1, Payment p2)
        {
            if (p1.Experience() < p2.Experience()) { return new Payment(p2.Фамилия, p1.Оклад + p2.Оклад, p1.Year, p1.ProcentBonus + p2.ProcentBonus, p1.GivenAmount, p1.ProcentWithheldAmount); }
            else
            {
                return new Payment(p1.Фамилия, p1.Оклад + p2.Оклад, p2.Year, p1.ProcentBonus + p2.ProcentBonus, p2.GivenAmount, p2.ProcentWithheldAmount);
            }
        }
        public override string ToString()
        {
            return this.Фамилия + ";"  + this.Оклад + ";" + this.Year  +
                ";" + this.ProcentBonus + ";" + this.GivenAmount +
                ";" + this.ProcentWithheldAmount;
        }
        public int CompareTo(Payment? obj)
        {
            if (this.Year > obj.Year)
                return 1;
            if (this.Year < obj.Year)
                return -1;
            else
                return 0;
        }
    }
}
