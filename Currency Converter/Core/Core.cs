using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies;
using Currency_Converter.Core.WalletPair;
using Currency_Converter.Core.WalletPair.Wallet;

namespace Currency_Converter.Core
{
    class Core
    {
        IWalletPair CoreWalletPair;
        IDictionaryOfCurrencies CoreDictionaryOfCurrencies;

        Core()
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
            this.CoreDictionaryOfCurrencies = new DictionaryOfCurrencies.DictionaryOfCurrencies();
            
        }

        private void SetDefoultWalletPair()
        {
            this.CoreWalletPair = new WalletPair.WalletPair(
                new Wallet(1, CoreDictionaryOfCurrencies.FindCurrencyByKey("USD")),
                new Wallet(0, CoreDictionaryOfCurrencies.FindCurrencyByKey("RUB"))
                );

        }
        



    }
}
