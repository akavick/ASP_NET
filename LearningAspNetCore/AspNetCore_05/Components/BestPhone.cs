using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspNetCore_05.Models;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;





namespace AspNetCore_05.Components
{

    public class BestPhone : ViewComponent
    {
        List<Phone> _phones;





        public BestPhone()
        {
            _phones = new List<Phone>
            {
                new Phone {Title = "iPhone 7", Price = 56000},
                new Phone {Title = "Idol S4", Price = 26000},
                new Phone {Title = "Elite x3", Price = 55000},
                new Phone {Title = "Honor 8", Price = 23000}
            };
        }





        public string Invoke()
        {
            var item = _phones.OrderByDescending(x => x.Price).Take(1).FirstOrDefault();

            return $"Самый дорогой телефон: {item.Title} Цена: {item.Price}";
        }
    }





    public class PhonesList : ViewComponent
    {
        IRepository repo;





        public PhonesList(IRepository r)
        {
            repo = r;
        }





        public IViewComponentResult Invoke(int maxPrice, int minPrice = 0)
        {
            //int count = repo.GetPhones().Count(x => x.Price < maxPrice && x.Price > minPrice);
            //return $"В диапазоне от {minPrice} до {maxPrice} найдено {count} модели(ей)";

            var item = repo.GetPhones().OrderByDescending(x => x.Price).Take(1).FirstOrDefault();
            var htmlString = new HtmlString($"<h3>Самый дорогой телефон: {item.Title} - {item.Price.ToString("c")}</h3>");

            return new HtmlContentViewComponentResult(htmlString);
        }
    }

}
