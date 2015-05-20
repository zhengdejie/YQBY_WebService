using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using YQBY_REST.ServiceModel;
using YQBY_REST.ServiceModel.Tables;
using ServiceStack.OrmLite;
using ServiceStack.Configuration;
using ServiceStack.OrmLite.MySql;
using System.Data;

namespace YQBY_REST.ServiceInterface
{
    public class MyServices : Service
    {
        OrmLiteConnectionFactory dbFactory;
        public MyServices()
        {
            var appSettings = new AppSettings();
            dbFactory = new OrmLiteConnectionFactory(appSettings.Get("DB_CONNECT"), MySqlDialectProvider.Instance);
        }
        public object Any(Login request)
        {
            List<Users> results = new List<Users>();
            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                try
                {
                    results = db.Select<Users>(q => q.Tel == request.Tel && q.Password == request.Password);
                }
                catch (Exception e)
                {
                    return new loginResponse { Status = Status.EXCEPTION };
                }

            }

            return new loginResponse { Status = Status.OK, Count = results.Count(), Result = results };
        }
    }
}