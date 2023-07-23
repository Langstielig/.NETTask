using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
