using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Domain.Model
{
    public class Role
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<UserInRole> UserInRoles { get; set; }

        public Role()
        {

            UserInRoles = new HashSet<UserInRole>();
        }
    }
}
