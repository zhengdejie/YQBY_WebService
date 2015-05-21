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
        /// <summary>
        /// Login      Check Tel and Password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                    return new LoginResponse { Status = Status.EXCEPTION, ExceptionContent = e.ToString() };
                }

            }

            return new LoginResponse { Status = Status.OK, Count = results.Count(), Result = results };
        }
        /// <summary>
        /// Setup      
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public object Any(Setup request)
        {
            List<Users> results = new List<Users>();
            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                try
                {
                    db.InsertOnly(new Users { Tel = request.Tel, Password = request.Password }, q => q.Insert(p => new { p.Tel, p.Password }));
                }
                catch (Exception e)
                {
                    return new SetupResponse { Status = Status.EXCEPTION, ExceptionContent = e.ToString() };
                }

            }

            return new SetupResponse { Status = Status.OK, Count = results.Count(), Result = results };
        }
    }
}