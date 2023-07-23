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
	public class EFCompaniesRepository : ICompanyRepository
	{
		private EFDBContext _dbContext;
		public EFCompaniesRepository(EFDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteCompany(Company company)
		{
			_dbContext.Company.Remove(company);
			_dbContext.SaveChanges();
		}

		public IQueryable<Company> GetAllCompanies(bool includeProjects = false)
		{
			if(includeProjects)
			{
				return _dbContext.Set<Company>().Include(x => x.Projects).AsNoTracking().AsQueryable();
			}
			else
			{
				return _dbContext.Company.AsQueryable();
			}
		}

		public Company GetCompanyById(int id, bool includeProjects = false)
		{
			if (includeProjects)
			{
				return _dbContext.Set<Company>().Include(x => x.Projects).AsNoTracking().FirstOrDefault(x => x.Id == id);
			}
			else
			{
				return _dbContext.Company.FirstOrDefault(x => x.Id == id);
			}
		}

		public void SaveCompany(Company company)
		{
			if(company.Id == 0)
			{
				_dbContext.Company.Add(company);
			}
			else
			{
				_dbContext.Entry(company).State = EntityState.Modified;
			}
			_dbContext.SaveChanges();
		}
	}
}
