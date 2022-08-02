using PhoneBookAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Domain.Entities
{
    public class Communication:BaseEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string Information { get; set; }      
        public Contacts Contact { get; set; }
    }
}
