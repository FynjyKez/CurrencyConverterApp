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
    class CoreCurrencyConverter
    {
        private static CoreCurrencyConverter MainCore;
        const string DefoutCharCodeFirstValute = "USD";
        const double DefoutValueFirstValute = 1;
        const string DefoutCharCodeSecondValute = "RUB";

        public bool SuccsessLoad { get; private set; } = false;
        public bool ChangeFirstWallet { get; set; } = false;
        public bool ChangeSecondWallet { get; set; } = false;

        WalletPair.WalletPair CoreWalletPair;
        DictionaryOfNationalCurrencies CoreDictionaryOfCurrencies;

        /// <summary>
        /// Доступ к экземппляру
        /// </summary>
        /// <returns></returns>
        public static CoreCurrencyConverter GetCore()
        {
            if (MainCore == null)
                MainCore = new CoreCurrencyConverter();
            return MainCore;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public CoreCurrencyConverter()
        {
            LoadDefoultData();
        }

        public delegate void LoadDictionary();
        public event LoadDictionary ErrorLoadDictionary;
        public event LoadDictionary SuccessLoadDictionary;

        /// <summary>
        /// Загрузка данных по умолчанию
        /// </summary>
        public void LoadDefoultData()
        {
            SetDefoultDictionary();
            if (SuccsessLoad)
            {
                SetDefoultWalletPair();
            }
        }

        /// <summary>
        /// Установить словари курсов валют по умолчанию
        /// </summary>
        private void SetDefoultDictionary()
        {
            CoreDictionaryOfCurrencies = new DictionaryOfNationalCurrencies();
            CoreDictionaryOfCurrencies.SetDictionary(
                JsonParser.ParseString(DataLoader.DataLoader.LoadData()));
            if(!CoreDictionaryOfCurrencies.DictionaryIsVoid())
            { 
                CoreDictionaryOfCurrencies.AddCurrency(new RubleCurrency());
                SuccsessLoad = true;
                SuccessLoadDictionary?.Invoke();
            }
            else
            {
                SuccsessLoad = false;
                ErrorLoadDictionary?.Invoke();
            }
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
        
        /// <summary>
        /// Доступ к первому кошельку
        /// </summary>
        /// <returns></returns>
        private IWallet FirstWallet()
        {
            return CoreWalletPair.GetFirstWallet();
        }
        /// <summary>
        /// Доступ ко второму кошельку
        /// </summary>
        /// <returns></returns>
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
        public void SetFirstWalletValue(string Value) {
            CoreWalletPair.ChangeValueWallet(FirstWallet(), Convert.ToDouble(Value));
        }
        /// <summary>
        /// Установить значение для второго кошелька
        /// </summary>
        /// <param name="Value"></param>
        public void SetSecondWalletValue(string Value) {
            CoreWalletPair.ChangeValueWallet(SecondWallet(), Convert.ToDouble(Value));
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
            CoreWalletPair.ChangeCurrencyWallet(FirstWallet(), CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
            //FirstWallet().SetCourse(CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
        }
        /// <summary>
        /// Установить валюту первому кошельку по Коду
        /// </summary>
        /// <param name="CharCode"></param>
        public void SetSecondWalletCurrency(string CharCode)
        {
            CoreWalletPair.ChangeCurrencyWallet(SecondWallet(), CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
            //SecondWallet().SetCourse(CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
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
