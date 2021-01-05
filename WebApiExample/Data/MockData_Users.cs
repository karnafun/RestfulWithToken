using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExample.Models;

namespace WebApiExample.Data
{
	static public class MockData_Users
	{

		static public List<User> AllUsers = new List<User>(){

		new User("Dor","Danai","Aa123456","admin", "Lorem Lorem Ipsum Ipsumz"),
		new User("Mister","Miagi","Aa123456","admin", "Lorem Lorem Ipsum Ipsumz"),
		new User("Bob","Marly","Aa123456","user", "Lorem Lorem Ipsum Ipsumz"),
		new User("John","Doe","Aa123456","user", "Lorem Lorem Ipsum Ipsumz"),
		new User("Erez","Akale","Aa123456","user", "Lorem Lorem Ipsum Ipsumz"),
		};
	}
}