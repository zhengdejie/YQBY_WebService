using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQBY_REST.ServiceModel
{
    [Route("/api/apkversion", "GET")]
    public class APKVersion : IReturn<APKVersionResponse>
    {
        //public string Apk_Path { get; set; }
        //public string APK_Name { get; set; }
        //public string APK_Code { get; set; }
    }

    public class APKVersionResponse
    {
        public Status Status { get; set; }
        public string Apk_Path { get; set; }
        public string APK_Name { get; set; }
        public string APK_Code { get; set; }
        public string ExceptionContent { get; set; }

    }
}
