using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.WalletPair.Wallet;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;

namespace Currency_Converter.Core.WalletPair
{
    
    interface IWalletPair
    {
        IWallet GetFirstWallet();
        IWallet GetSecondWallet();
        void ChangeValueWallet(IWallet Wallet, double Value);
        void ChangeCurrencyWallet(IWallet Wallet, ICurrency Currensy);
    }
}
