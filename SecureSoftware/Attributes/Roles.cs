using Repositories;
using SecureSoftware.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SecureSoftware.Attributes
{
    public class Roles : ActionFilterAttribute
    {
        public override async void OnActionExecuting(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            var ticket = AuthStartUp.authServerConfig.AccessTokenFormat.Unprotect(token.Parameter.ToString());

            string user = ticket.Properties.Dictionary["id"].ToString();
            if (await Credential.CheckIsEmployee(user) == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.Unauthorized, "Unauthorized access!");
            }

        }
    }

}