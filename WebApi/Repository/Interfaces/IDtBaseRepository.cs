using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IDtBaseRepository
    {
        Task<IList<DtBase>> GetItems(int pageIndex, int rowsPerPage);
    }
}
