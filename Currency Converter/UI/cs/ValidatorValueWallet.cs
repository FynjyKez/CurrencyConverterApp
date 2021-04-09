using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.UI.cs
{
    static class ValidatorValueWallet
    {
        const string NOT_FIRST_CHARS = "0,.";
        const char SINGLE_CHAR_DOT = '.';
        const char SINGLE_CHAR_COMMA = ',';
        const int MAX_SINGLE_CHAR = 1;

        /// <summary>
        /// Проверка валидации для текстового поля кошелька
        /// </summary>
        /// <param name="NewText">Строка для валидации</param>
        /// <returns>Если валидация провалена, возращает <c>true</c>. Если валидация пройдена <c>false</c></returns>
        public static bool HasErrors(string NewText)
        {
            if(NewText.Length == 0)
            {
                return true;
            }
            if (NOT_FIRST_CHARS.Any(c => c == NewText.First()))
            {
                return true;
            }
            if (NewText.Count(c => c == SINGLE_CHAR_DOT || c == SINGLE_CHAR_COMMA) > MAX_SINGLE_CHAR || 
                NewText.Any(c => !(char.IsDigit(c) || c == SINGLE_CHAR_DOT || c == SINGLE_CHAR_COMMA)))
            {
                return true;
            }


            return false;
        }
    }
}
