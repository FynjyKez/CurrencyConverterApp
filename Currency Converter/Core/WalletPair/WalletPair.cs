using Currency_Converter.Core.WalletPair.Wallet;
using Currency_Converter.Core.WalletPair.Converter;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Core.WalletPair
{
    /// <summary>
    /// Класс пары кошельков
    /// <c>FirstWallet</c> и <c>SecondWallet</c> однотипные объекты между которыми происходит вычесления относительно их параметров.
    /// </summary>
    class WalletPair : IWalletPair
    {
        IWallet FirstWallet;
        IWallet SecondWallet;

        public WalletPair()
        {
        }
        public WalletPair(IWallet FirstWallet, IWallet SecondWallet)
        {
            this.FirstWallet = FirstWallet;
            this.SecondWallet = SecondWallet;
            SecondWallet.SetValue(Converter.Converter.ConvertValueWallet(FirstWallet, SecondWallet));
        }

        public IWallet GetFirstWallet()
        {
            return FirstWallet;
        }
        public IWallet GetSecondWallet()
        {
            return SecondWallet;
        }

        public void ChangeValueWallet(IWallet Wallet, double Value)
        {
            if (Object.ReferenceEquals(Wallet, FirstWallet))
            {
                FirstWallet.SetValue(Value);
                SecondWallet.SetValue(Converter.Converter.ConvertValueWallet(FirstWallet, SecondWallet));
            }
            else if (Object.ReferenceEquals(Wallet, SecondWallet))
            {
                SecondWallet.SetValue(Value);
                SecondWallet.SetValue(Converter.Converter.ConvertValueWallet(SecondWallet,FirstWallet));
            }
        }
        public void ChangeCurrencyWallet(IWallet Wallet, ICurrency Currensy)
        {
            if (Object.ReferenceEquals(Wallet, FirstWallet))
            {
                FirstWallet.SetCourse(Currensy);
                SecondWallet.SetValue(Converter.Converter.ConvertValueWallet(FirstWallet, SecondWallet));
            }
            else if (Object.ReferenceEquals(Wallet, SecondWallet))
            {
                SecondWallet.SetCourse(Currensy);
                SecondWallet.SetValue(Converter.Converter.ConvertValueWallet(SecondWallet, FirstWallet));
            }
        }

        


    }
}
