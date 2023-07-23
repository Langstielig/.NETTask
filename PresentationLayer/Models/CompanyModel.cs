using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class CompanyViewModel : PageViewModel
    {
        public Company Company { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
    }

    public class CompanyEditModel : PageEditModel
    {

    }
}
