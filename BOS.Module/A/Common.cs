using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOS
{
    public static class Common
    {       
        public static DateTime GetServerTime(DevExpress.Xpo.Session session)
        {
            FunctionOperator op = new FunctionOperator(FunctionOperatorType.Now);
            //XPObjectType表没有数据时，dt = null
            object dt = session.Evaluate(typeof(DevExpress.Xpo.XPObjectType), op, null);

            //object dt = session.ExecuteScalar("SELECT GETDATE() AS Result");
            return (DateTime)dt;
        }

        /// <summary>
        /// prefix开头，第二位大写的文本，如FRd
        /// </summary>        
        public static bool IsFPrefix(char prefix, string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            if (text.Length < 2) return false;

            return text[0] == prefix && text[1] >= 'A' && text[1] <= 'Z';
        }
    }
}
