using BusinessLayer;
using Data.Entities;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
    public class CompanyService
    {
        private DataManager _dataManager;
        private ProjectService _projectService;

        public CompanyService(DataManager dataManager) 
        { 
            _dataManager = dataManager;
            _projectService = new ProjectService(dataManager);
        }

        public CompanyViewModel SaveCompanyEditModelToDB(CompanyEditModel companyEditModel)
        {
            Company companyDbModel;
            if(companyEditModel.Id != 0)
            {
                companyDbModel = _dataManager.Companies.GetCompanyById(companyEditModel.Id);
            }
            else
            {
                companyDbModel = new Company();
            }
            companyDbModel.Name = companyEditModel.Name;
            companyDbModel.Description = companyEditModel.Description;

            _dataManager.Companies.SaveCompany(companyDbModel);

            return CompanyDBToViewModelById(companyDbModel.Id);
        }

        public CompanyViewModel CompanyDBToViewModelById(int id)
        {
            var company = _dataManager.Companies.GetCompanyById(id, true);

            List<ProjectViewModel> projectsList = new List<ProjectViewModel>();
            foreach (var project in company.Projects)
            {
                projectsList.Add(_projectService.ProjectDBModelToView(project.Id));
            }
            return new CompanyViewModel() { Company = company, Projects = projectsList };
        }

        public CompanyEditModel GetCompanyEditModel(int id = 0)
        {
            if(id != 0)
            {
                var companyDB = _dataManager.Companies.GetCompanyById(id);
                var companyEditModel = new CompanyEditModel() 
                { 
                    Id = companyDB.Id, 
                    Name = companyDB.Name, 
                    Description = companyDB.Description
                };
                return companyEditModel;
            }
            else
            {
                return new CompanyEditModel() { };
            }
        }

        public List<CompanyViewModel> GetCompaniesList()
        {
            var companies = _dataManager.Companies.GetAllCompanies();
            List<CompanyViewModel> companiesList = new List<CompanyViewModel>();
            foreach (var company in companies)
            {
                companiesList.Add(CompanyDBToViewModelById(company.Id));
            }
            return companiesList;
        }

        public CompanyEditModel CreateCompanyEditModel()
        {
            return new CompanyEditModel() { };
        }
    }
}
