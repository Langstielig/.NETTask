using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IProgectsRepository
	{
		IQueryable<Project> GetAllProjects(bool includeCompany = false);
		Project GetProjectById(int id, bool includeCompany = false);
		void SaveProject(Project project);	
		void DeleteProject(Project project);	
	}
}
