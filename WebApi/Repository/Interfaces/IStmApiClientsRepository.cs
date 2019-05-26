using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IStmApiClientsRepository
    {
         StmApiClients GetItemByAPIKey(string APIKey);
        Task<IList<StmApiClients>> GetItems(int pageIndex, int rowsPerPage);
    }
}
