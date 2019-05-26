using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Repository
{
    public class DtBaseRepository : IDtBaseRepository
    {
        private readonly DP_MainContext _context;
  
        public DtBaseRepository(DP_MainContext context)
        {
            _context = context;
        }

        public async Task < IList<DtBase>  >  GetItems(int pageIndex, int rowsPerPage) {
            var result = from entity  in _context.DtBase
                         select entity;
         
            PaginatedList<DtBase> t = await PaginatedList<DtBase>.CreateAsync(result, pageIndex,    rowsPerPage);
            return t.ToList<DtBase>();
        }
    }
}
