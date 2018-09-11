using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SamHumanResourcesReservationSystem.Controllers
{
    public class RsApplicationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View());
        }
    }
}