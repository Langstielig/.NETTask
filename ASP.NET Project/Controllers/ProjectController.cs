using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using PresentationLayer;

namespace ASP.NET_Project.Controllers
{
	public class ProjectController : Controller
	{
		private DataManager _dataManager;
		private ServiceManager _serviceManager;

		public ProjectController(DataManager dataManager)
		{
			_dataManager = dataManager;
			_serviceManager = new ServiceManager(_dataManager);
		}

		public IActionResult Index(int projectId)
		{
			ProjectViewModel model;
			model = _serviceManager.Proj.ProjectDBModelToView(projectId);
			return View(model);
		}

		[HttpGet]
		public IActionResult ProjectEditor(int projectId, int companyId = 0)
		{
			ProjectEditModel model;
			if(projectId != 0)
			{
				model = _serviceManager.Proj.GetProjectEditModel(projectId);
			}
            else
            {
				model = _serviceManager.Proj.CreateNewProjectEditModel(companyId);
            }
            return View(model);
		}

		[HttpPost]
		public IActionResult SaveProject(ProjectEditModel model) 
		{
			_serviceManager.Proj.SaveProjectEditModelToDb(model);
			return RedirectToAction("ProjectEditor", "Project", new { projectId = model.Id});
		}
	}
}
