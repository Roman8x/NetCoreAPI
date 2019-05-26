using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Repository
{
    public class RefPartnersRepository : IRefPartnersRepository
    {
        private readonly DP_MainContext _context;        
        public RefPartnersRepository(DP_MainContext context) { _context = context; }

        public async Task<IList<RefPartners>> GetItems(int pageIndex , int rowsPerPage )
        {
            var result = from entity in _context.RefPartners
                         select entity;

            PaginatedList<RefPartners> t = await PaginatedList<RefPartners>.CreateAsync(result, pageIndex, rowsPerPage);
            return t.ToList<RefPartners>();
        }
    }
}
