using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies.Currency
{

    interface ICurrency
    {
        string CharCode { get; set; }
        int Nominal { get; set; }
        string Name { get; set; }
        double Value { get; set; }
    }
}
