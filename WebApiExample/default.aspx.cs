using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApiExample.Providers;

namespace WebApiExample
{
	public partial class _default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			DBServices db = new DBServices();
			db.GetUsers(); 
		}
	}
}