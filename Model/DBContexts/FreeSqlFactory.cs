using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBContexts
{
    public static class FreeSqlFactory
    {
        private static IFreeSql? fsql = null;
        private static object _locker = new object();
        static FreeSqlFactory()
        {
            lock (_locker)
            {
                fsql = new FreeSql.FreeSqlBuilder()
                    .UseConnectionString(FreeSql.DataType.MySql, @"Database=ControlPanel;Data Source=139.196.161.54;Port=3306;User Id=ControlPanel;Password=Fwmcp7GKktYfrKj5;Charset=utf8;TreatTinyAsBoolean=false;")
                    .UseAutoSyncStructure(true).Build();
            }
        }

        public static IFreeSql CreateFSql()
        {
#pragma warning disable CS8603 // 可能返回 null 引用。
            return fsql;
#pragma warning restore CS8603 // 可能返回 null 引用。
        }
    }
}
