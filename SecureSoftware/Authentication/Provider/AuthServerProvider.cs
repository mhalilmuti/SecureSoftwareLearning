using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using DAL;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Claims;
using Repositories;
using Repositories.Models;
using Microsoft.Owin.Security;

namespace SecureSoftware.Authentication.Provider
{
    public class AuthServerProvider : OAuthAuthorizationServerProvider
    {

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            return base.TokenEndpointResponse(context);
        }

        public override Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
        {
            return base.ValidateTokenRequest(context);
        }

        public override Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
        {
            return base.AuthorizationEndpointResponse(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //   context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            this.UserName = context.UserName;
            this.Password = context.Password;

            string userType = context.Request.Headers["userType"].ToString();
            Credentials credential = null;
            switch (userType)
            {
                case "employee":
                    credential = await Credential.GetEmployee(this.UserName,this.Password);
                    break;
                case "customer":
                    credential = await Credential.GetCustomer(this.UserName,this.Password);
                    break;

                default:
                    break;
            }

            if (credential != null)
            {
              //  if (credential.password == _password)
              //  {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("sub", context.UserName));

                    var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        {"name", credential.name},
                        {"surname", credential.surname},
                        {"id", credential.id},
                        {"userType",userType }
                    });

                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
              //  }
              //  else
              //  {
               //     context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış!");
              //  }
            }
            else
            {
                context.SetError("invalid_user", "Giriş Hatalı!");
            }
        }
    }
}