using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GridTest_001.Models;

namespace GridTest_001.Repositories
{
    public static class Repository
    {
        public static ObservableCollection<Person> Persons { get; }
        public static int CurrentPersonId { get; private set; }

        static Repository()
        {
            var r = new Random();

            var letters = Enumerable
                          .Range(Convert.ToInt32('a'), 26)
                          .Select(Convert.ToChar)
                          .ToList();

            var persons = Enumerable
                          .Range(1, 20)
                          .Select(i => new Person
                          {
                              Id = ++CurrentPersonId,
                              FirstName = letters.OrderBy(l => r.Next())
                                                 .Take(r.Next(3, 11))
                                                 .Aggregate(new StringBuilder(), (sb, c) => sb.Append(c))
                                                 .ToString(),
                              LastName = letters.OrderBy(l => r.Next())
                                                .Take(r.Next(3, 11))
                                                .Aggregate(new StringBuilder(), (sb, c) => sb.Append(c))
                                                .ToString()
                          })
                          .ToList();

            Persons = new ObservableCollection<Person>(persons);

            Persons.CollectionChanged += Records_CollectionChanged;
        }

        private static void Records_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }
    }
}
