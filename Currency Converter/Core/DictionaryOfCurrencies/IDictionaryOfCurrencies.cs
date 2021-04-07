using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;

namespace Currency_Converter.Core.DictionaryOfCurrencies
{

    interface IDictionaryOfCurrencies
    {
        Dictionary<string, ICurrency> GetList();
        Dictionary<string, ICurrency> SetList(IDictionaryOfCurrencies Dictionary);
        ICurrency AddCurrency(string CharCode, int Nominal, string Name, int Value);
        ICurrency FindCurrencyByKey(string Key);
    }
}
