using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

namespace ASP.NET_Project.Controllers
{
    public class UserController : Controller
    {
        private DataManager _dataManager;
        private ServiceManager _serviceManager;

        public UserController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManager = new ServiceManager(_dataManager);
        }

        public IActionResult Index(int userId)
        {
            UserViewModel model;
            model = _serviceManager.Usr.UserDBToViewModelById(userId);
            return View(model);
        }

        [HttpGet]
        public IActionResult UserEditor(int userId)
        {
            UserEditModel model;
            if (userId != 0)
            {
                model = _serviceManager.Usr.GetUserEditModel(userId);
            }
            else
            {
                model = _serviceManager.Usr.CreateUserEditModel();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveUser(UserEditModel model)
        {
            _serviceManager.Usr.SaveUserEditModelToDB(model);
            return RedirectToAction("UserEditor", "User", new { userId = model.Id });
        }
    }
}
