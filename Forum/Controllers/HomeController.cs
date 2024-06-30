using Forum.DataAccess.UnitOfWork;
using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Callback(string returnUrl = "/")
        {
            if (User != null && !User.Claims.IsNullOrEmpty())
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                Person person = _unitOfWork.PersonRepository.GetPerson(userId);
                if (person == null)
                {
                    person = new Person
                    {
                        UserId = userId,
                        Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                        FirstName = User.Claims.FirstOrDefault(c => c.Type.Contains("givenname"))?.Value,
                        LastName = User.Claims.FirstOrDefault(c => c.Type.Contains("surname"))?.Value
                    };

                    _unitOfWork.PersonRepository.Add(person);
                    _unitOfWork.PersonRepository.Save();
                }
            }

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
