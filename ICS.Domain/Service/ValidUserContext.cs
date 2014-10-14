using ICS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace ICS.Domain.Service
{
    public class ValidUserContext
    {
        public IPrincipal Principal { get; set; }
        public UserInRole User { get; set; }

        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
