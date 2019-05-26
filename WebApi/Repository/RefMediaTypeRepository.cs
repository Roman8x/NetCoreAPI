using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class RefMediaTypeRepository : IRefMediaTypeRepository
    {
        private readonly DP_MainContext _context;
        public RefMediaTypeRepository(DP_MainContext context) { _context = context; }

        public IList <RefMediaType > GetItems( )
        {
            var result = _context.RefMediaType.ToList();         
            return result;
        }
    }
}
