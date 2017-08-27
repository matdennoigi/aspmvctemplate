using StudentInformationSystem.WebFramework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Web.Models.Student
{
    public class LoginModel : BaseModel
    {
        [ResourceDisplayName("Account.Login.Field.Username")]
        [AllowHtml]
        public string Username { set; get; }

        [ResourceDisplayName("Account.Login.Field.Password")]
        [AllowHtml]
        public string Password { set; get; }

        [ResourceDisplayName("Account.Login.Field.RememberMe")]
        public bool RememberMe { set; get; }
    }
}