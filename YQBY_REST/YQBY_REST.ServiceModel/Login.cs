using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using YQBY_REST.ServiceModel.Tables;

namespace YQBY_REST.ServiceModel
{
    [Route("/api/login", "POST")]
    public class Login : IReturn<loginResponse>
    {
        public string Password { get; set; }
        public string Tel { get; set; }

    }
    public class loginResponse
    {
        public Status Status { get; set; }
        public int Count { get; set; }
        public List<Users> Result { get; set; }

    }
}