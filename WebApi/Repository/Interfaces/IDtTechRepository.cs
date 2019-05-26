using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    interface IDtTechRepository
    {
        Task<IList<DtTech>> GetItems(int pageIndex, int rowsPerPage);
    }
}
