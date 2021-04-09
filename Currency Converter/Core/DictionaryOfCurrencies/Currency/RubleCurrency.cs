using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies.Currency
{
    public class RubleCurrency : NationalCurrency
    {
        const string RubleCharCode = "RUB";
        const int RubleNominal = 1;
        const string RubleName = "Рубль";
        const double RubleValue = 1.0;
        public RubleCurrency() : base(RubleCharCode, RubleNominal, RubleName, RubleValue) { }
    }
}
