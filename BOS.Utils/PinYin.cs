using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS.Utils
{
    public static class PinYin
    {
        public static string GetPinyin(string value)
        {
            if (value == null) return "";

            string pinyin = "";
            foreach (char c in value)
            {
                if (!Microsoft.International.Converters.PinYinConverter.ChineseChar.IsValidChar(c))
                {
                    pinyin += c;
                    continue;
                }
                Microsoft.International.Converters.PinYinConverter.ChineseChar cc = new Microsoft.International.Converters.PinYinConverter.ChineseChar(c);
                pinyin += cc.Pinyins[0][0];
            }

            return pinyin.ToLower();
        }
    }
}
