using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvailityDemo.Controllers
{
    public class AvailityController : Controller
    {
        public IActionResult NewCustomerForm()
        {            
            return View();
        }
        [HttpGet]
        public IActionResult Success() //string message
        {
            return View();
        }
    }
}
