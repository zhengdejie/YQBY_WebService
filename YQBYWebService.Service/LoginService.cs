using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YQBYWebService.Entities;
using YQBYWebService.Interface;
using YQBYWebService.Models;

namespace YQBYWebService.Service
{
    public class LoginService : ILoginServiceInterface
    {
        private static LoginService userService = new LoginService();
        public static ILoginServiceInterface getUserService()
        {
            return userService;
        }       

        public IEnumerable<User_Model> CheckLoginPermission(User_Model User)
        {
            using(friendsEntities db = new friendsEntities())
            {
                List<User_Model> list = new List<User_Model>();
                var query = db.users.Where(s => s.Tel == User.Tel && s.Password == User.Password).FirstOrDefault();
                if (query != null)
                {
                    list.Add(new User_Model
                    {
                        ID = query.ID,
                        Tel = query.Tel,
                        Password = query.Password,
                        Name = query.Name,
                        NickName = query.NickName,
                        Sex = query.Sex,
                        DateofBirth = query.DateofBirth,
                        Marks =query.Marks,
                        Pic = query.Pic,
                        Wallet = query.Wallet,
                        Hobby = query.Hobby

                    });
                    
                }
                return list;
            }          

        }

    }
}
