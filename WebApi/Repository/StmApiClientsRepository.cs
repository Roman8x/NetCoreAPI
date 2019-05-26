using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Repository
{
    public class StmApiClientsRepository : IStmApiClientsRepository
    {
        private readonly DP_MainContext _context;
        public StmApiClientsRepository(DP_MainContext context) {
            _context = context;
        }

        public  StmApiClients  GetItemByAPIKey(string APIKey)
        {
            var result = _context.StmApiClients
                .Where(x => x.ApiKey.Equals(APIKey));
            return result.FirstOrDefault () ;
        }

        public async Task<IList<RefPartners>> GetItems(int pageIndex, int rowsPerPage)
        {
            var result = from entity in _context.RefPartners
                         select entity;

            PaginatedList<RefPartners> t = await PaginatedList<RefPartners>.CreateAsync(result, pageIndex, rowsPerPage);
            return t.ToList<RefPartners>();
        }
    }
}
