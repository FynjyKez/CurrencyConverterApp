using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Currency_Converter.Core.DictionaryOfCurrencies
{
    static class JsonParser
    {
        public static string ErrorMessege { get; private set; }

        public static DictionaryOfNationalCurrencies ParseString(string Json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DictionaryOfNationalCurrencies>(Json);
            }
            catch (Exception ex)
            {
                ErrorMessege = ex.Message;
            }
            return null;
        }
    }
}
