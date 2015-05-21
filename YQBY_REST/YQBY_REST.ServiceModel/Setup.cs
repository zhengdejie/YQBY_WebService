using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YQBY_REST.ServiceModel.Tables;

namespace YQBY_REST.ServiceModel
{
    [Route("/api/setup", "POST")]
    public class Setup : IReturn<SetupResponse>
    {
        public string Password { get; set; }
        public string Tel { get; set; }

    }
    public class SetupResponse
    {
        public Status Status { get; set; }
        public int Count { get; set; }
        public List<Users> Result { get; set; }
        public string ExceptionContent { get; set; }

    }
}
