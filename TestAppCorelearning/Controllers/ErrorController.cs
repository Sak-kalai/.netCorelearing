using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestAppCorelearning.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeError(int statusCode)
        {
            var statusResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    logger.LogWarning($"Error Found 4040 {statusResult.OriginalPath}  query string {statusResult.OriginalQueryString}");
                    ViewBag.Path = statusResult.OriginalPath;
                    ViewBag.QS = statusResult.OriginalQueryString;
                    break;
                default:
                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"the path {exceptionHandler.Path} throw the exception {exceptionHandler.Error}");

            ViewBag.ExceptionPath = exceptionHandler.Path;
            ViewBag.ExceptionMessage = exceptionHandler.Error.Message;
            ViewBag.Stracktrace = exceptionHandler.Error.StackTrace;

            return View("Error");

        }
    }
}