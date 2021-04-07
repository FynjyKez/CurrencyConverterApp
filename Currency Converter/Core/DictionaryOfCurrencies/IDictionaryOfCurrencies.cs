using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Converter.Core.DictionaryOfCurrencies.Currency;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies
{
    interface IDictionaryOfCurrencies
    {
        Dictionary<string, NationalCurrency> GetDictionary();
        Dictionary<string, NationalCurrency> SetDictionary(DictionaryOfNationalCurrencies Dictionary);
        NationalCurrency AddCurrency(NationalCurrency NewCurrency);
        NationalCurrency FindCurrencyByKey(string Key);
    }
}
