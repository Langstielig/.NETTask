using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;

namespace ASP.NET_Project.Controllers
{
    public class CompanyController : Controller
    {
        private DataManager _dataManager;
        private ServiceManager _serviceManager;

        public CompanyController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _serviceManager = new ServiceManager(_dataManager);
        }

        public IActionResult Index(int companyId)
        {
            CompanyViewModel model;
            model = _serviceManager.Comp.CompanyDBToViewModelById(companyId);
            return View(model);
        }

        [HttpGet]
        public IActionResult CompanyEditor(int companyId)
        {
            CompanyEditModel model;
            if(companyId != 0)
            {
                model = _serviceManager.Comp.GetCompanyEditModel(companyId);
			}
            else
            {
                model = _serviceManager.Comp.CreateCompanyEditModel(); 
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveCompany(CompanyEditModel model)
        {
            _serviceManager.Comp.SaveCompanyEditModelToDB(model);
            return RedirectToAction("CompanyEditor", "Company", new { companyId = model.Id });
        }
    }
}
