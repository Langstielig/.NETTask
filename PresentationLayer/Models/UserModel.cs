using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
	public class UserViewModel : PageViewModel
	{
		public User User { get; set; }
		public List<ProjectViewModel> Projects { get; set; }
	}

	public class UserEditModel : PageEditModel
	{
		[Required]
		public int CompanyId { get; set; }
		[Required]
		public string Surname { get; set; }
	}
}
