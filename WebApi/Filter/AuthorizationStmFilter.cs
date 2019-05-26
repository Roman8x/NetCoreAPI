using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Filter
{
    public class AuthorizationStmFilter : Attribute,  IAuthorizationFilter
    {
        private const string API_KEY = "API_KEY";
        private readonly IStmApiClientsRepository _stmApiClientsRepository;
        public AuthorizationStmFilter(IStmApiClientsRepository stmApiClientsRepository) {
            // StmApiClientsRepository          
            _stmApiClientsRepository = stmApiClientsRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Ищем API_KEY в заголовке 
            StringValues sv ;
            if (context.HttpContext.Request.Headers.TryGetValue(API_KEY, out sv) )
              {              
                var res = _stmApiClientsRepository.GetItemByAPIKey(sv.FirstOrDefault());
                if (res != null)
                    return;
            }

            // Ищем API_KEY в качестве параметра в строке запроса 
            var q = context.HttpContext.Request.Query;
            if (q.TryGetValue(API_KEY,out  sv)) {
                var res = _stmApiClientsRepository.GetItemByAPIKey(sv.FirstOrDefault());
                if (res != null)
                    return;
            }

            context.Result = new ContentResult()
            {
                Content = "You are unauthorized!!",
                StatusCode = 401
                  
        };
    }
    }
}
