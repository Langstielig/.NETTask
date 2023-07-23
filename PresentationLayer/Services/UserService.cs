using BusinessLayer;
using Data.Entities;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Services
{
	public class UserService
	{
		private DataManager _dataManager;
		private ProjectService _projectService;

		public UserService(DataManager dataManager)
		{
			_dataManager = dataManager;
			_projectService = new ProjectService(dataManager);
		}

		public UserViewModel SaveUserEditModelToDB(UserEditModel userEditModel)
		{
			User userDbModel;
			if (userEditModel.Id != 0)
			{
				userDbModel = _dataManager.Users.GetUserById(userEditModel.Id);
			}
			else
			{
				userDbModel= new User();
			}
			var company = _dataManager.Companies.GetCompanyById(userEditModel.CompanyId);

			userDbModel.Name = userEditModel.Name;
			userDbModel.Surname = userEditModel.Surname;
			userDbModel.Email = userEditModel.Description;
			userDbModel.CompanyId = userEditModel.CompanyId;
			userDbModel.Company = company;

			_dataManager.Users.SaveUser(userDbModel);

			return UserDBToViewModelById(userDbModel.Id);
		}

		public UserViewModel UserDBToViewModelById(int id)
		{
			var user = _dataManager.Users.GetUserById(id, true);

			List<ProjectViewModel> projectsList = new List<ProjectViewModel>();
			foreach (var project in user.Projects)
			{
				projectsList.Add(_projectService.ProjectDBModelToView(project.Id));
			}
			return new UserViewModel() { User = user, Projects = projectsList };
		}

		public UserEditModel GetUserEditModel(int id = 0)
		{
			if (id != 0)
			{
				var userDB = _dataManager.Users.GetUserById(id);
				var userEditModel = new UserEditModel()
				{
					Id = userDB.Id,
					Name = userDB.Name,
					Surname = userDB.Surname,
					Description = userDB.Email,
					CompanyId = userDB.CompanyId
				};
				return userEditModel;
			}
			else
			{
				return new UserEditModel() { };
			}
		}

		public List<UserViewModel> GetUsersList()
		{
			var users = _dataManager.Users.GetAllUsers();
			List<UserViewModel> usersList = new List<UserViewModel>();
			foreach (var user in users)
			{
				usersList.Add(UserDBToViewModelById(user.Id));
			}
			return usersList;
		}

		public UserEditModel CreateUserEditModel()
		{
			return new UserEditModel() {  }; //тут можно засунуть companyId
		}
	}
}
