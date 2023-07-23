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
	public class EFUsersRepository : IUserRepository
	{
		private EFDBContext _dbContext;
		public EFUsersRepository(EFDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void DeleteUser(User user)
		{
			_dbContext.User.Remove(user);
			_dbContext.SaveChanges();
		}

		public IQueryable<User> GetAllUsers(bool includeProjects = false)
		{
			if (includeProjects)
			{
				return _dbContext.Set<User>().Include(x =>  x.Projects).AsNoTracking().AsQueryable();
			}
			else
			{
				return _dbContext.User.AsQueryable();
			}
		}

		public User GetUserById(int id, bool includeProjects = false)
		{
			if (includeProjects)
			{
				return _dbContext.Set<User>().Include(x => x.Projects).AsNoTracking().FirstOrDefault(x => x.Id == id);
			}
			else
			{
				return _dbContext.User.FirstOrDefault(x => x.Id == id);
			}
		}

		public void SaveUser(User user)
		{
			if (user.Id == 0)
			{
				_dbContext.User.Add(user);
			}
			else
			{
				_dbContext.Entry(user).State = EntityState.Modified;
			}
			_dbContext.SaveChanges();
		}
	}
}
