using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Filter;

namespace WebApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    internal  class DtBasesController : ControllerBase
    {
        private readonly IDtBaseRepository _dtBaseRepository;

        public DtBasesController(IDtBaseRepository dtBaseRepository)
        {             
            _dtBaseRepository = dtBaseRepository;
        }

       

        // GET: DtBases/Details/1/5
        [HttpGet("{pageNumber}/{rowsPerPage}" )]
        [Route ("Details") ]
        public async Task < IActionResult >  GetPage( int pageNumber, int rowsPerPage)
        {
            var result = await _dtBaseRepository.GetItems(pageNumber, rowsPerPage);
            return Ok(result);
        }   
    }
}
