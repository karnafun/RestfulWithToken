using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using WebApiExample.App_Start;

namespace WebApiExample
{
	public class AuthenticationStartup
	{
		public void Configuration(IAppBuilder app) {

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			var myProvider = new ServerAuthenticationProvider(); 
			OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
			{
				
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				Provider = myProvider
			};

			app.UseOAuthAuthorizationServer(options);
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register(config);
		}
	}
}