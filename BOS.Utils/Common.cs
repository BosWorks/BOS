using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS.Utils
{
    public static class Common
    {
        public static DateTime GetBirthday(string idCard)
        {
            if (idCard == null) throw new ArgumentNullException(nameof(idCard));

            try
            {
                return DateTime.Parse($"{idCard.Substring(6, 4)}-{idCard.Substring(10, 2)}-{idCard.Substring(12, 2)}");
            }
            catch
            {
                throw new FormatException("从身份证号：" + idCard + "中解析生日出错。");
            }
        }

        public static decimal FindNumber(string text)
        {
            string num = "";
            foreach (char c in text)
            {
                if (char.IsNumber(c) || c == '.')
                {
                    num += c;
                }
                else
                {
                    break;
                }
            }
            return decimal.Parse(num);
        }

        public static string CountAge(DateTime dtBirthday, DateTime dtNow, bool yearOrFull)
        {
            var intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }

            var intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }

            var intYear = dtNow.Year - dtBirthday.Year;
            string strAge = "?";
            {
                strAge = intYear.ToString() + "岁";
                if (yearOrFull)
                {
                    return strAge;
                }
            }

            {
                strAge += intMonth.ToString() + "月";
            }

            {
                if (strAge.Length == 0 || intDay > 0)
                {
                    strAge += intDay.ToString() + "天";
                }
            }

            return strAge;
        }

        public static string NextFileName(string[] files, string format, bool maxOrNext)
        {
            List<int> numList = new List<int>(files.Length);
            foreach (var f in files)
            {
                if (f.StartsWith(format))
                {
                    //"aaa".SubString(3) = ""
                    string numStr = f.Substring(format.Length);
                    if (numStr.Length == 0)
                    {
                        numList.Add(1);
                    }
                    else
                    {
                        int num;
                        if (int.TryParse(numStr, out num))
                        {
                            numList.Add(num);
                        }
                    }
                }
            }

            int lastNum;

            if (numList.Count == 0)
            {
                lastNum = 0;
            }
            else
            {
                if (maxOrNext)
                {
                    lastNum = numList.Max() + 1;
                }
                else
                {
                    numList.Sort();
                    lastNum = numList[numList.Count - 1] + 1;
                    int distance = numList[0] - 0;
                    for (int i = 1; i < numList.Count; i++)
                    {
                        int newDis = numList[i] - i;
                        if (newDis < distance)
                        {
                            distance = newDis;
                        }
                        else if (newDis > distance)
                        {
                            lastNum = i + distance;
                            break;
                        }
                    }
                }
            }

            return format + (lastNum == 0 ? string.Empty : lastNum.ToString());
        }

        //public static string ToBase64(Image img)
        //{
        //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

        //    MemoryStream memStream = new MemoryStream();

        //    binFormatter.Serialize(memStream, img);

        //    byte[] bytes = memStream.GetBuffer();

        //    return Convert.ToBase64String(bytes);
        //}

        //public static Image ToImage(string base64)
        //{
        //    byte[] bytes = Convert.FromBase64String(base64);

        //    MemoryStream memStream = new MemoryStream(bytes);

        //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

        //    return (Image)binFormatter.Deserialize(memStream);            
        //}

        public static void ExportResource(string rscPath, string savePath)
        {
            Stream xafml = null;
            FileStream fs = null;

            try
            {
                xafml = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(rscPath);
                fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
                byte[] buffer = new byte[1024];
                int length;

                while ((length = xafml.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, length);
                }
                fs.Flush();
            }            
            finally
            {
                if (xafml != null)
                {
                    xafml.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}
