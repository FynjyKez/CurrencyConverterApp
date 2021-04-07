using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.WalletPair.Wallet;

namespace Currency_Converter.Core.WalletPair.Converter
{
    static class Converter
    {
        public static double ConvertValueWallet(IWallet FromWallet, IWallet ToWallet)
        {
            double Value = FromWallet.GetValue();
            int Nominal = FromWallet.GetCourse().Nominal;
            double CurrencyCourse = FromWallet.GetCourse().Value;

            int Nominal2 = ToWallet.GetCourse().Nominal;
            double CurrencyCourse2 = ToWallet.GetCourse().Value;

            return (CurrencyCourse * Nominal2) / (Value * CurrencyCourse2 * Nominal);
        }


    }
}
