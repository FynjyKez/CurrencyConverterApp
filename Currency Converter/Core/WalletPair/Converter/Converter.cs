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
        public static double ConvertVallueWallet(IWallet FromWallet, IWallet InWallet)
        {
            double Value = FromWallet.GetValue();
            int Nominal = FromWallet.GetCourse().Nominal;
            double CurrencyCourse = FromWallet.GetCourse().Value;

            double Value2 = InWallet.GetValue();
            int Nominal2 = InWallet.GetCourse().Nominal;
            double CurrencyCourse2 = InWallet.GetCourse().Value;

            return 0;
        }


    }
}
