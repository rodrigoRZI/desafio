using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IP.Desafio.Api.Filters
{
    public class ModelStateFilter : IActionFilter
    {
        public ModelStateFilter() { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> list = (
                    from modelState in context.ModelState.Values 
                    from error in modelState.Errors 
                    select error.ErrorMessage
                    ).ToList();

                context.Result = new JsonResult(list)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
