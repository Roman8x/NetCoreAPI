using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    internal class DtTechController : ControllerBase
    {     
        private readonly IDtTechRepository _dtTechRepository;

        public DtTechController(IDtTechRepository dtTechRepository)
        {            
            _dtTechRepository = dtTechRepository;
        }


        // GET: DtBases
        [HttpGet ("{pageNumber}/{rowPerPage}")]
        public async Task< IActionResult > Get(int pageNumber , int rowPerPage)
        {
            var result = await _dtTechRepository.GetItems(pageNumber, rowPerPage);
            return Ok(result);
        }
    }
}
