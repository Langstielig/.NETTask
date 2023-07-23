using BusinessLayer;
using PresentationLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class ServiceManager
    {
        DataManager _dataManager;
        private CompanyService _companyService;
        private ProjectService _projectService;
        private UserService _userService;

        public ServiceManager(DataManager dataManager) 
        {
            _dataManager = dataManager;
            _companyService = new CompanyService(_dataManager);
            _projectService = new ProjectService(_dataManager);
            _userService = new UserService(_dataManager);
        }

        public CompanyService Comp { get { return _companyService; } }
        public ProjectService Proj { get { return _projectService; } }
        public UserService Usr { get { return _userService; } }
    }
}
