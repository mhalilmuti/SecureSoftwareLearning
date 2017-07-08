using SecureSoftware.Authentication.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(SecureSoftware.Authentication.AuthStartUp))]
namespace SecureSoftware.Authentication
{
    public class AuthStartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            AuthConfig(appBuilder);

            WebApiConfig.Register(httpConfig);
            appBuilder.UseWebApi(httpConfig);

        }

        private void AuthConfig(IAppBuilder appBuilder)
        {
            OAuthAuthorizationServerOptions authServerConfig = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new AuthServerProvider()
            };

            appBuilder.UseOAuthAuthorizationServer(authServerConfig);
            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}