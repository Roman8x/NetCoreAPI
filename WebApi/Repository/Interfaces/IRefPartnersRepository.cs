using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    interface IRefPartnersRepository
    {
        Task<IList<RefPartners>> GetItems(int pageIndex, int rowsPerPage);
    }
}
