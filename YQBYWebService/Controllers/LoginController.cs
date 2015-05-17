using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YQBYWebService.Common;
using YQBYWebService.Interface;
using YQBYWebService.Models;
using YQBYWebService.Service;

namespace YQBYWebService.Controllers
{
    public class LoginController : ApiController
    {
        ILoginServiceInterface userService = LoginService.getUserService();

        //GET 获取User信息

        //[HttpGet]
        //public HttpResponseMessage GetUsers()
        //{
        //    return Utils_ResponseMessage.toJson(userService.CheckLoginPermission());
        //}

        //[HttpGet]
        //public HttpResponseMessage GetUsers(int id)
        //{
        //    return Utils_ResponseMessage.toJson(userService.CheckLoginPermission(id));
        //}

        //POST 根据用户输入的账号与密码信息核实是否成功登入
        [HttpPost]
        public HttpResponseMessage GetUsers([FromBody]User_Model user)
        {
            return Utils_ResponseMessage.toJson(userService.CheckLoginPermission(user));
        }
    }
}
