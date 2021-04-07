using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;

namespace Currency_Converter.Core.WalletPair.Wallet
{
    /// <summary>
    /// Интерфейс кошелька
    /// </summary>
    interface IWallet
    {
        double GetValue();
        double SetValue(double Value);
        ICurrency GetCourse();
        ICurrency SetCourse(ICurrency Course);
    }
}
