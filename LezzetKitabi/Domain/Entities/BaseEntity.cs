using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
