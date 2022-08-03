using PhoneBookAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Domain.Entities
{
    public class Contact:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<Communication> Communications { get; set; }
        public ICollection<Report> Reports { get; set; }

    }
}
