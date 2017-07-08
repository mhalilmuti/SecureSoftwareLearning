using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SecureSoftware.Attributes
{
    public class Authorizee : AuthorizationFilterAttribute
    {
        public override async void OnAuthorization(HttpActionContext actionContext)
        {
            string userToken = string.Empty;

            if (actionContext.Request.Headers.Authorization != null)
            {
                userToken = actionContext.Request.Headers.Authorization.Parameter.ToString();
            }

          
        }

        private async Task<bool> CheckToken(string token, HttpActionContext context)
        {
            string sql = "SELECT level FROM tokens WHERE token='" + token + "'";

            DatabaseAccess db = new DatabaseAccess();
            DataTable result = await db.ExecuteAsync(sql);

            if (result.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}