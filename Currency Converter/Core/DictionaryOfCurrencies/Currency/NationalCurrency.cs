using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies.Currency
{
    class NationalCurrency : ICurrency
    {
        [JsonProperty("CharCode")]
        public string CharCode { get; set; }
        [JsonProperty("Nominal")]
        public int Nominal { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Value")]
        public double Value { get; set; }

        public NationalCurrency(string CharCode, int Nominal, string Name, double Value)
        {
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
            this.Value = Value;
        }
    }
}
