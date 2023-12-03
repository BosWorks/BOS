using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.ExpressApp
{
    public static class DevExt
    {
        public static ObjectType FindObject<ObjectType>(this IObjectSpace os, string criteria, params object[] args)
        {
            return os.FindObject<ObjectType>(CriteriaOperator.Parse(criteria, args));
        }
    }
}
namespace DevExpress.Xpo
{
    public static class DevExt
    {
        public static ClassType FindObject<ClassType>(this Session session, string criteria)
        {
            return session.FindObject<ClassType>(CriteriaOperator.Parse(criteria));
        }

        public static ClassType FindObject<ClassType>(this Session session, string criteria, params object[] args)
        {
            return session.FindObject<ClassType>(CriteriaOperator.Parse(criteria, args));
        }
    }
}

namespace DevExpress.Xpo.DB
{
    public static class DevExt
    {
        public static string GetDefaultString(this SelectStatementResultRow row, int index)
        {
            return row.Values[index] == null ? null : row.Values[index].ToString();
        }

        public static DateTime GetDefaultDateTime(this SelectStatementResultRow row, int index)
        {
            return row.Values[index] == null ? new DateTime() : Convert.ToDateTime(row.Values[index]);
        }
    }
}

namespace DevExpress.Xpo.Metadata
{
    public class BosCapAttribute : Attribute
    {
        public string Caption { get; set; }
        public BosCapAttribute(string caption)
        {
            Caption = caption;
        }
    }
}