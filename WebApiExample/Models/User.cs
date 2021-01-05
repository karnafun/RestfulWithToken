using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExample.Models
{
	public enum Roles { USER,ADMIN}
	public class User
	{
		public User(string firstName, string lastName, string password,  string role, string info)
		{
			FirstName = firstName;
			LastName = lastName;
			Password = password;			
			Info = info;
			if (role.ToLower() == "user")
				Role = Roles.USER;
			else
				Role = Roles.ADMIN;
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Password { get; set; }
	
		public Roles Role { get; set; }
		public string Info { get; set; }

		
	}
}