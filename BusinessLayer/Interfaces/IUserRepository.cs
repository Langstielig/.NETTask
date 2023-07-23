
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IUserRepository
	{
		IQueryable<User> GetAllUsers(bool includeProjects = false);
		User GetUserById(int id, bool includeProjects = false);
		void SaveUser(User user);
		void DeleteUser(User user);
	}
}
