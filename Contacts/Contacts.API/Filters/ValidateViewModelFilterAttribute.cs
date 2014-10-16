//using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Contacts.API.Filters
{
    public class ValidateViewModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                //var errors = modelState.Keys.SelectMany(k => modelState[k].Errors)
                //                       .Select(m => m.ErrorMessage).ToArray();
                actionContext.Response = actionContext.Request
                                                      .CreateErrorResponse(HttpStatusCode.BadRequest,
                                                                           modelState);
            }
        }
    }
}