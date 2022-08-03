using PhoneBookAPI.Application.Repositories;
using PhoneBookAPI.Domain.Entities;
using PhoneBookAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookAPI.Persistence.Repositories
{
    public class ReportWriteRepository : WriteRepository<Report>, IReportWriteRepository
    {
        public ReportWriteRepository(PhoneBookAPIDbContext context) : base(context)
        {
        }
    }
}
