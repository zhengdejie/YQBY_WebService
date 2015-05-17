using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YQBYWebService.Models;

namespace YQBYWebService.Interface
{
    public interface ILoginServiceInterface
    {
        IEnumerable<User_Model> CheckLoginPermission(User_Model User);
    }
}
