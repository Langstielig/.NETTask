using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class ProjectViewModel : PageViewModel
    {
        public Project Project { get; set; }
    }

    public class ProjectEditModel : PageEditModel
    {
        [Required]
        public int CompanyId { get; set; }
    }
}
