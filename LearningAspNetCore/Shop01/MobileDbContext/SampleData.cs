using System.Linq;

using Shop01.Models;





namespace Shop01.MobileDbContext
{

    public static class SampleData
    {
        public static void Initialize(MobileContext context)
        {
            if (context.Phones.Any())
            {
                return;
            }

            context.Phones.AddRange
            (
                 new Phone
                 {
                     Name = "iPhone 6S",
                     Company = "Apple",
                     Price = 600
                 },
                 new Phone
                 {
                     Name = "Samsung Galaxy Edge",
                     Company = "Samsung",
                     Price = 550
                 },
                 new Phone
                 {
                     Name = "Lumia 950",
                     Company = "Microsoft",
                     Price = 500
                 }
            );

            context.SaveChanges();
        }
    }

}