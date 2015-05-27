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
using System.IO;
using System.Text;
using System.Diagnostics;

namespace YQBY_REST.ServiceInterface
{
    public class MyServices : Service
    {
        OrmLiteConnectionFactory dbFactory;
        AppSettings appSettings;
        public MyServices()
        {
            appSettings = new AppSettings();
            dbFactory = new OrmLiteConnectionFactory(appSettings.Get("DB_CONNECT"), MySqlDialectProvider.Instance);
        }
        /// <summary>
        /// Login      Check Tel and Password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public object Any(Login request)
        {
            try
            {
                Users results = new Users();
                using (IDbConnection db = dbFactory.OpenDbConnection())
                {
                    results = db.Select<Users>(q => q.Tel == request.Tel && q.Password == request.Password).FirstOrDefault();
                }
                return new LoginResponse { Status = Status.OK, Count = 1, Result = results };
            }
            catch (Exception e)
            {
                return new LoginResponse { Status = Status.EXCEPTION, ExceptionContent = e.ToString() };
            }            
        }
        /// <summary>
        /// Setup      
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public object Any(Setup request)
        {
            try
            {
                List<Users> results = new List<Users>();
                using (IDbConnection db = dbFactory.OpenDbConnection())
                {
                    db.InsertOnly(new Users { Tel = request.Tel, Password = request.Password }, q => q.Insert(p => new { p.Tel, p.Password }));
                }
                return new SetupResponse { Status = Status.OK, Count = results.Count(), Result = results };
            }
            catch (Exception e)
            {
                return new SetupResponse { Status = Status.EXCEPTION, ExceptionContent = e.ToString() };
            }            
        }
        /// <summary>
        /// Get APK_Version
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public object Get(APKVersion apkversion)
        {
            try
            {
                string apk_Path = appSettings.Get("APK_PATH");
                string apk_VersionName = "";
                string apk_VersionCode = "";

                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"APK\APK_VERSION.txt", Encoding.Default))
                {
                    string s;
                    int i = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        i++;
                        if (i == 1)
                        {
                            apk_VersionName = s;
                        }
                        if (i == 2)
                        {
                            apk_VersionCode = s;
                        }

                    }
                }
                return new APKVersionResponse { Status = Status.OK, Apk_Path = apk_Path, APK_Name = apk_VersionName, APK_Code = apk_VersionCode };
            }
            catch (Exception e)
            {
                return new APKVersionResponse { Status = Status.EXCEPTION, ExceptionContent = e.ToString() };
            }           
        }
    }
}