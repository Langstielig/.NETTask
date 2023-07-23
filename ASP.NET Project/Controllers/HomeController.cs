using ASP.NET_Project.Models;
using BusinessLayer;
using BusinessLayer.Interfaces;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer;
using PresentationLayer.Models;
using System.Diagnostics;

namespace ASP.NET_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private EFDBContext _dbContext;
        //private ICompanyRepository _companyRepository;
        private DataManager _dataManager;
        private ServiceManager _serviceManager;

        public HomeController(ILogger<HomeController> logger, /*EFDBContext context,  ICompanyRepository repository, */DataManager dataManager)
        {
            _logger = logger;
            //_dbContext = context;
            //_companyRepository = repository;
            _dataManager = dataManager;
            _serviceManager = new ServiceManager(dataManager);
        }

        public IActionResult Index()
        {
			//List<Company> companies = _dbContext.Company.Include(x => x.Projects).ToList();

			//IQueryable<Company> companies = _companyRepository.GetAllCompanies();

            //IQueryable<Company> companies = _dataManager.Companies.GetAllCompanies(true);

            List<CompanyViewModel> companies = _serviceManager.Comp.GetCompaniesList(); 
            return View(companies);
        }

        public IActionResult Users()
        {
            List<UserViewModel> users = _serviceManager.Usr.GetUsersList();
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}