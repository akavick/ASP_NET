using System.Collections.Generic;





namespace AspNetCore_05.Models
{

    public class Phone
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }



    public interface IRepository
    {
        List<Phone> GetPhones();
    }
    public class PhoneRepository : IRepository
    {
        public List<Phone> GetPhones()
        {
            return new List<Phone>
            {
                new Phone {Title="iPhone 7", Price=56000},
                new Phone {Title="Idol S4", Price=26000 },
                new Phone {Title="Elite x3", Price=55000 },
                new Phone {Title="Honor 8", Price=23000 },
                new Phone {Title="Pixel XL", Price= 40000 }
            };
        }
    }
}