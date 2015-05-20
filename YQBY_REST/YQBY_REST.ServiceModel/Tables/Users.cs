using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQBY_REST.ServiceModel.Tables
{
    public class Users
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Tel { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Marks { get; set; }
        public string Pic { get; set; }
        public double? Wallet { get; set; }
        public string Hobby { get; set; }
    }
}
