using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.WalletPair.Wallet;

namespace Currency_Converter.Core.WalletPair.Converter
{
    /// <summary>
    /// Класс конвертации валют
    /// </summary>
    static class Converter
    {
        /// <summary>
        /// Конвертация валюты из одного кошелька в валюту другого кошелька
        /// </summary>
        /// <param name="FromWallet">Кошелёк значение короторо переводится</param>
        /// <param name="ToWallet">Кошелёк в короторый переводится</param>
        /// <returns>Значение сконвертированной валюты второго кошелька</returns>
        public static double ConvertValueWallet(IWallet FromWallet, IWallet ToWallet)
        {
            return  (FromWallet.GetValue() * FromWallet.GetCourse().Value * ToWallet.GetCourse().Nominal) / (ToWallet.GetCourse().Value * FromWallet.GetCourse().Nominal);
        }


    }
}
