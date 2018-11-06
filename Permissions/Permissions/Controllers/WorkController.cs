using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Permissions.Authorization;
using Permissions.DAL;
using Permissions.DAL.FakeRepository;
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



        [Authorize(Policies.CanViewFirstPage)]
        public IActionResult FirstPage()
        {
            var repositoryRequests = _repository.Requests;

            return View(repositoryRequests);
        }



        [Authorize(Policies.CanViewSecondPage)]
        public IActionResult SecondPage(int id)
        {
            var request = _repository.Requests.SingleOrDefault(r => r.RequestId == id);

            if (request is null)
            {
                return NotFound();
            }

            return View(request);
        }



        [Authorize(Policies.CanViewThirdPage)]
        public IActionResult ThirdPage()
        {
            return View();
        }
    }

}