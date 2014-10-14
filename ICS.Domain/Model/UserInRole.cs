using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Domain.Model
{
    public class UserInRole: IEntity<Guid>
    {
        public Guid UserKey { get; set; }
        public Guid RoleKey { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
