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
    public class ProjectService
    {
        private DataManager _dataManager;

        public ProjectService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public ProjectViewModel ProjectDBModelToView(int projectID)
        {
            var project = new ProjectViewModel()
            {
                Project = _dataManager.Projects.GetProjectById(projectID),
            };
            return project;
        }

        public ProjectEditModel GetProjectEditModel(int projectID)
        {
            var dbProject = _dataManager.Projects.GetProjectById(projectID);
            var editProject = new ProjectEditModel()
            {
                Id = dbProject.Id,
                CompanyId = dbProject.CompanyId,
                Name = dbProject.Name,
                Description = dbProject.Description
            };
            return editProject;
        }

        public ProjectViewModel SaveProjectEditModelToDb(ProjectEditModel projectEditModel)
        {
            Project project;
            if(projectEditModel.Id != 0)
            {
                project = _dataManager.Projects.GetProjectById(projectEditModel.Id);
            }
            else
            {
                project = new Project();
            }
            project.Name = projectEditModel.Name;
            project.Description = projectEditModel.Description;
            project.CompanyId = projectEditModel.CompanyId;

            _dataManager.Projects.SaveProject(project);

            return ProjectDBModelToView(project.Id);
        }

        public ProjectEditModel CreateNewProjectEditModel(int companyId)
        {
            return new ProjectEditModel() { CompanyId = companyId };
        }

        //public ProjectEditModel CreateNewProjectEditModelWithUser(int userId)
        //{
        //    return new ProjectEditModel() { UserId}
        //}
    }
}
