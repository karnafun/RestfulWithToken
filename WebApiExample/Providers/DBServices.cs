using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WebApiExample.Data;
using WebApiExample.Models;


namespace WebApiExample.Providers
{
	public class DBServices
	{

		public List<User> GetUsers() {

			return MockData_Users.AllUsers;
		} 
	} 
}