using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Repository
{
    public class DtTechRepository : IDtTechRepository
    {
        private readonly DP_MainContext _context; // DP_MainContext context
 

        public DtTechRepository(DP_MainContext context) {
            _context = context;
        }


        public async Task<IList<DtTech>> GetItems(int pageIndex, int rowsPerPage)
        {
            var result = from entity in _context.DtTech
                         select entity;

            PaginatedList<DtTech> t = await PaginatedList<DtTech>.CreateAsync(result, pageIndex,    rowsPerPage);
            return t.ToList<DtTech>();
        }
    }
}
