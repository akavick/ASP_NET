using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Permissions.DAL;
using Permissions.Models;



namespace Permissions.Controllers
{

    public class WorkController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly Repository _repository;



        public WorkController(IAuthorizationService authorizationService, Repository repository)
        {
            _authorizationService = authorizationService;
            _repository = repository;
        }



        public IActionResult FirstPage()
        {
            return View(_repository.Requests);
        }



        //[HttpPost]
        public IActionResult SecondPage(int id)
        {
            return View(_repository.Requests.SingleOrDefault(r => r.RequestId == id));
        }

    }

}