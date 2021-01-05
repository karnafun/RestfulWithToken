using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApiExample.Models;
using WebApiExample.Providers;

namespace WebApiExample
{
	public class ServerAuthenticationProvider : OAuthAuthorizationServerProvider
	{
		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			context.Validated();
		}


		
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			var identity = new ClaimsIdentity(context.Options.AuthenticationType);

			var users = new DBServices().GetUsers();
			foreach (User _u in users)
			{
				if (string.Format("{0}@{1}",_u.FirstName,_u.LastName).ToLower() == context.UserName.ToLower()
					&& _u.Password == context.Password ) {

					identity.AddClaim(new Claim(ClaimTypes.Role, _u.Role.ToString().ToLower()));
					identity.AddClaim(new Claim("username", _u.FirstName + "@" + _u.LastName));
					identity.AddClaim(new Claim(ClaimTypes.Name, "Hello " + _u.FirstName));
					context.Validated(identity);
					return;
				} 
				
			};
			context.SetError("invalid_grant", "Provided username and password is incorrect");
			return;
			//if (context.UserName == "admin" && context.Password == "admin")
			//{
			//	identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
			//	identity.AddClaim(new Claim("username", "admin"));
			//	identity.AddClaim(new Claim(ClaimTypes.Name, "Hello Admin"));
			//	context.Validated(identity);
			//}
			//else if (context.UserName == "user" && context.Password == "user")
			//{
			//	identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
			//	identity.AddClaim(new Claim("username", "user"));
			//	identity.AddClaim(new Claim(ClaimTypes.Name, "Hello user"));
			//	context.Validated(identity); 
			//}
			//else
			//{
			//	context.SetError("invalid_grant", "Provided username and password is incorrect");
			//	return;
			//}
		}

		//public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		//{
		//	var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

		//	ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

		//	if (user == null)
		//	{
		//		context.SetError("invalid_grant", "The user name or password is incorrect.");
		//		return;
		//	}

		//	ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
		//	   OAuthDefaults.AuthenticationType);
		//	ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
		//		CookieAuthenticationDefaults.AuthenticationType);

		//	AuthenticationProperties properties = CreateProperties(user.UserName);
		//	AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
		//	context.Validated(ticket);
		//	context.Request.Context.Authentication.SignIn(cookiesIdentity);
		//}
	}
}