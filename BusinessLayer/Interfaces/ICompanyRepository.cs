using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface ICompanyRepository
	{
		IQueryable<Company> GetAllCompanies(bool includeProjects = false);
		Company GetCompanyById(int id, bool includeProjects = false);
		void SaveCompany(Company company);	
		void DeleteCompany(Company company);
	}
}
