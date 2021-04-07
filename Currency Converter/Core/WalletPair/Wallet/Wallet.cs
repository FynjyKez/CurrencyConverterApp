using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;

namespace Currency_Converter.Core.WalletPair.Wallet
{
    /// <summary>
    /// Класс кошелька.
    /// В переменной <c>Value</c> хранится количество валюты.
    /// В объекте <c>Course</c> хранятся данные о курсе данной валюты
    /// </summary>
    class Wallet : IWallet
    {
        private double Value
        {
            get
            {
                return Value;
            }
            set
            {
                if (value > .0 && value != Value)
                {
                    Value = value;
                }
            }
        }
        private ICurrency Course;


        public Wallet(double Value, ICurrency Course)
        {
            this.Value = Value;
            this.Course = Course;
        }

        public double GetValue()
        {
            return Value;
        }
        public double SetValue(double Value)
        {
            this.Value = Value;
            return this.Value;
        }

        public ICurrency GetCourse()
        {
            return Course;
        }
        public ICurrency SetCourse(ICurrency Course)
        {
            this.Course = Course;
            return this.Course;
        }

    }
}
