using BusinessLayer.Interfaces;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
	public class EFProjectsRepository : IProgectsRepository
	{
		private EFDBContext _dbContext;
		public EFProjectsRepository(EFDBContext context) 
		{
			_dbContext = context;
		}

		public void DeleteProject(Project project)
		{
			_dbContext.Project.Remove(project);
			_dbContext.SaveChanges();
		}

		public IQueryable<Project> GetAllProjects(bool includeCompany = false)
		{
			if(includeCompany)
			{
				return _dbContext.Set<Project>().Include(x => x.Company).AsNoTracking().AsQueryable();
			}
			else
			{
				return _dbContext.Project.AsQueryable();
			}
		}

		public Project GetProjectById(int id, bool includeCompany = false)
		{
			if(includeCompany)
			{
				return _dbContext.Set<Project>().Include(x => x.Company).AsNoTracking().FirstOrDefault(x => x.Id == id);
			}
			else
			{
				return _dbContext.Project.FirstOrDefault(x => x.Id == id);
			}
		}

		public void SaveProject(Project project)
		{
			if(project.Id == 0)
			{
				_dbContext.Project.Add(project);
			}
			else
			{
				_dbContext.Entry(project).State = EntityState.Modified;
			}
			_dbContext.SaveChanges();
		}
	}
}
