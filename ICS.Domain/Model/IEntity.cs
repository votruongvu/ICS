using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS.Domain.Model
{
    public abstract class IEntity<Tkey>
    {
        [Key]
        public Tkey Id { get; set; }
    }
}
