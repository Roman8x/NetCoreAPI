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
    internal class RefMediaTypeController : ControllerBase
    {        
        private readonly IRefMediaTypeRepository _refMediaTypeRepository;

        public RefMediaTypeController(IRefMediaTypeRepository refMediaTypeRepository)
        {            
            _refMediaTypeRepository = refMediaTypeRepository;
        }


        // GET: RefMediaType
        [HttpGet()]
        public  IActionResult Get( )
        {
            var result = _refMediaTypeRepository.GetItems( );
            return Ok(result);
        }

    }
}
