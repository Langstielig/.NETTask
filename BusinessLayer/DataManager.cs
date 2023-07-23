using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class DataManager
	{
		private ICompanyRepository _companyRepository;
		private IProgectsRepository _progectsRepository;
		private IUserRepository _userRepository;

		public DataManager(ICompanyRepository companyRepository, IProgectsRepository progectsRepository, IUserRepository userRepository)
		{
			_companyRepository = companyRepository;
			_progectsRepository = progectsRepository;
			_userRepository = userRepository;
		}

		public ICompanyRepository Companies { get { return _companyRepository; } }
		public IProgectsRepository Projects { get { return _progectsRepository; } }
		public IUserRepository Users { get { return _userRepository; } }
	}
}
