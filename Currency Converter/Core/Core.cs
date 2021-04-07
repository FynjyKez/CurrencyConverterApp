using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;
using Currency_Converter.Core.WalletPair;
using Currency_Converter.Core.WalletPair.Wallet;

namespace Currency_Converter.Core
{
    class Core
    {
        const string DefoutCharCodeFirstValute = "USD";
        const double DefoutValueFirstValute = 1;
        const string DefoutCharCodeSecondValute = "RUB";

        WalletPair.WalletPair CoreWalletPair;
        DictionaryOfNationalCurrencies CoreDictionaryOfCurrencies;

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

        public double GetFirstWalletValue()
        {
            return FirstWallet().GetValue();
        }
        public double GetSecondWalletValue()
        {
            return SecondWallet().GetValue();
        }
        public void SetFirstWalletValue(double Value) {
            CoreWalletPair.ChangeValueWallet(FirstWallet(), Value);
        }
        public void SetSecondWalletValue(double Value) {
            CoreWalletPair.ChangeValueWallet(SecondWallet(), Value);
        }

        public string GetFirstWalletCurrencyCharCode() 
        {
            return FirstWallet().GetCourse().CharCode;
        }
        public string GetSecondWalletCurrencyCharCode() 
        {
            return SecondWallet().GetCourse().CharCode;
        }

        public void SetFirstWalletCurrency(string CharCode)
        {
            FirstWallet().SetCourse(CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
        }
        public void SetSecondWalletCurrency(string CharCode)
        {
            SecondWallet().SetCourse(CoreDictionaryOfCurrencies.FindCurrencyByKey(CharCode));
        }

        public Dictionary<string, NationalCurrency> GetDictionnaryOfCurrencies()
        {
            return CoreDictionaryOfCurrencies.GetDictionary();
        }
    }
}
