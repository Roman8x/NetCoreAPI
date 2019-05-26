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
    public class RefPartnersController : ControllerBase
    {        
        private readonly IRefPartnersRepository _refPartnersRepository;

        public RefPartnersController (IRefPartnersRepository refPartnersRepository)
        {            
            _refPartnersRepository = refPartnersRepository;
        }


        // GET: DtBases
        [HttpGet("{pageNumber}/{rowPerPage}")]
        public async Task<IActionResult> Get(int pageNumber, int rowPerPage)
        {
            var result = await _refPartnersRepository.GetItems(pageNumber, rowPerPage);
            return Ok(result);
        }
    }
}
