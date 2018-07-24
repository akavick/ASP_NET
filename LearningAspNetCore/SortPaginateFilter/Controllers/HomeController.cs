using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SortPaginateFilter.Context;
using SortPaginateFilter.Models;





namespace SortPaginateFilter.Controllers
{





    public class HomeController : Controller
    {

        UsersContext db;





        public HomeController(UsersContext context)
        {
            this.db = context;
        }





        public async Task<IActionResult> Index(int? company, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<User> users = db.Users.Include(x => x.Company);

            if (company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }

            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);

                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);

                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);

                    break;
                case SortState.CompanyAsc:
                    users = users.OrderBy(s => s.Company.Name);

                    break;
                case SortState.CompanyDesc:
                    users = users.OrderByDescending(s => s.Company.Name);

                    break;
                default:
                    users = users.OrderBy(s => s.Name);

                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Companies.ToList(), company, name),
                Users = items
            };

            return View(viewModel);
        }





        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }





        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }





}
