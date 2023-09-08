using Microsoft.AspNetCore.Mvc;
using WebApplication_test.Models.EntityManager;
using WebApplication_test.Models.ViewModel;
using WebApplication_test.Models;

namespace WebApplication_test.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserManager um = new UserManager();
                if (!um.IsLoginNameExist(user.LoginName))
                {
                    um.AddUserAccount(user);
                    // FormsAuthentication.SetAuthCookie(user.FirstName, false);
                    return RedirectToAction("", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = new UserManager().GetAllUsers();

            return View();
        }
    }
}
