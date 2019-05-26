using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class StmApiClientsController : ControllerBase
    {
        private readonly IStmApiClientsRepository _stmApiClientsRepository;

        public StmApiClientsController(IStmApiClientsRepository stmApiClientsRepository)
        {
            _stmApiClientsRepository = stmApiClientsRepository;
        }



    }
}
