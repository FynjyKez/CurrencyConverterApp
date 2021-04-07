using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;
using Currency_Converter.Core.WalletPair.Wallet;

namespace Currency_Converter.Core
{
    /// <summary>
    /// Главное ядро доступа к функциям 
    /// </summary>
    class Core
    {
        private static Core MainCore;
        const string DefoutCharCodeFirstValute = "USD";
        const double DefoutValueFirstValute = 1;
        const string DefoutCharCodeSecondValute = "RUB";

        WalletPair.WalletPair CoreWalletPair;
        DictionaryOfNationalCurrencies CoreDictionaryOfCurrencies;

        public static Core GetCore()
        {
            if (MainCore == null)
                MainCore = new Core();
            return MainCore;
        }

        public Core()
        {
            try
            {
                SetDefoultDictionary();   
                SetDefoultWalletPair();
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// Установить словари курсов валют по умолчанию
        /// </summary>
        private void SetDefoultDictionary()
        {
                CoreDictionaryOfCurrencies = new DictionaryOfCurrencies.DictionaryOfNationalCurrencies();
                CoreDictionaryOfCurrencies.SetDictionary(
                    JsonParser.ParseString(
                        new DataLoader.DataLoader().LoadData()
                        )
                    );
                CoreDictionaryOfCurrencies.AddCurrency(new RubleCurrency());

        }
        /// <summary>
        /// Установить кошельки валют по умолчанию
        /// </summary>
        private void SetDefoultWalletPair()
        {
            CoreWalletPair = new WalletPair.WalletPair(
                new Wallet(DefoutValueFirstValute, CoreDictionaryOfCurrencies.FindCurrencyByKey(DefoutCharCodeFirstValute)),
                new Wallet(CoreDictionaryOfCurrencies.FindCurrencyByKey(DefoutCharCodeSecondValute))
                );

        }
        
        private IWallet FirstWallet()
        {
            return CoreWalletPair.GetFirstWallet();
        }
        private IWallet SecondWallet()
        {
            return CoreWalletPair.GetSecondWallet();
        }

        /// <summary>
        /// Значение первого кошелька
        /// </summary>
        /// <returns><c>double</c></returns>
        public double GetFirstWalletValue()
        {
            return FirstWallet().GetValue();
        }
        /// <summary>
        /// Значение второго кошелька
        /// </summary>
        /// <returns><c>double</c></returns>
        public double GetSecondWalletValue()
        {
            return SecondWallet().GetValue();
        }
        /// <summary>
        /// Установить значение для первого кошелька
        /// </summary>
        /// <param name="Value"></param>
        public void SetFirstWalletValue(double Value) {
            CoreWalletPair.ChangeValueWallet(FirstWallet(), Value);
        }
        /// <summary>
        /// Установить значение для второго кошелька
        /// </summary>
        /// <param name="Value"></param>
        public void SetSecondWalletValue(double Value) {
            CoreWalletPair.ChangeValueWallet(SecondWallet(), Value);
        }

        /// <summary>
        /// Получить Код первого кошелька
        /// </summary>
        /// <returns></returns>
        public string GetFirstWalletCurrencyCharCode() 
        {
            return FirstWallet().GetCourse().CharCode;
        }
        /// <summary>
        /// Получить Код Второго кошелька
        /// </summary>
        /// <returns></returns>
        public string GetSecondWalletCurrencyCharCode() 
        {
            return SecondWallet().GetCourse().CharCode;
        }

        /// <summary>
        /// Установить валюту первому кошельку по Коду
        /// </summary>
        /// <param name="CharCode"></param>
        public void SetFirstWalletCurrency(string CharCode)
        {
            FirstWallet().SetCourse(CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
        }
        /// <summary>
        /// Установить валюту первому кошельку по Коду
        /// </summary>
        /// <param name="CharCode"></param>
        public void SetSecondWalletCurrency(string CharCode)
        {
            SecondWallet().SetCourse(CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
        }

        /// <summary>
        /// Получить Словарь курсов валют
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, NationalCurrency> GetDictionnaryOfCurrencies()
        {
            return CoreDictionaryOfCurrencies.GetDictionary();
        }
    }
}
