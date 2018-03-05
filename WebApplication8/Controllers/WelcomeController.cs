using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication8.Controllers
{
    public class WelcomeController : Controller
    {
public string Index()
		{
			return "Welcome to Joe's page";
		}

		public string WelcomePage ()
		{
			return "This is my Welcome Page";
		}
    }
}