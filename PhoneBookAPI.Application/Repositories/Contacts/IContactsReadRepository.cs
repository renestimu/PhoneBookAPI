using PhoneBookAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Application.Repositories
{
    public interface IContactsReadRepository:IReadRepository<Contacts>
    {
    }
}
