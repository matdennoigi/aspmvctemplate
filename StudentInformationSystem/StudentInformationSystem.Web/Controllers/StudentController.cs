using StudentInformationSystem.Core.Domain.Students;
using StudentInformationSystem.Services.Authentication;
using StudentInformationSystem.Services.Students;
using StudentInformationSystem.Web.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Web.Controllers
{
    public class StudentController : BasePublicController
    {
        #region Fields

        private IAuthenticationService authenticationService;
        private IStudentRegistrationService studentRegistrationService;
        private IStudentService studentService;

        #endregion

        #region Ctor

        public StudentController(IAuthenticationService authenticationService,
            IStudentRegistrationService studentRegistrationService,
            IStudentService studentService)
        {
            this.authenticationService = authenticationService;
            this.studentRegistrationService = studentRegistrationService;
            this.studentService = studentService;
        }

        #endregion

        #region Login/Logout

        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginResult = studentRegistrationService
                    .ValidateStudent(model.Username, model.Password);

                switch (loginResult) {

                    case StudentLoginResults.Successful:
                        var student = studentService.GetStudentByUsername(model.Username);
                        authenticationService.SignIn(student, model.RememberMe);

                        if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
                            return RedirectToAction("Index", "Home");

                        return Redirect(returnUrl);
                }

            }

            return View();
        }

        public virtual ActionResult Logout()
        {
            authenticationService.SingOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        //[Authorize(Roles = "reader")]
        [Authorize(Roles = "reader")]
        public ActionResult Details()
        {
            return View();
        }
    }
}