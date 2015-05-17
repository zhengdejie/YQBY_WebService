using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQBYWebService.Models
{
    public class User_Model
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Tel { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool? Sex { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? Marks { get; set; }
        public string Pic { get; set; }
        public double? Wallet { get; set; }
        public string Hobby { get; set; }
    }
}
