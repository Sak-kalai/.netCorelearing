using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAppCorelearning.Models;

namespace TestAppCorelearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository empRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger<HomeController> logger;

        public  HomeController(IEmployeeRepository empRepository,IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            this.empRepository = empRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public IActionResult Index()
        {
          //throw new Exception("Getting Error");
           var employees= empRepository.GetEmployees();
            return View();
        }
    }
}