using PhoneBookAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Domain.Entities
{
    public class Report:BaseEntity
    {
        public string State { get; set; }
        public string DirectoryPath { get; set; }
        public Contacts Contact { get; set; }
    }
}
