using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_Datareader
{
    public class DBReader : IDataReader
    {
        public IEnumerable<Person> GetPeople()
        {
            List<Person> personList = new List<Person>();
            personList.Add(new Person { Id = 0, FirstName = "Adam", LastName = "Björk", Age = 27 });
            personList.Add(new Person { Id = 1, FirstName = "Johannes", LastName = "Andersson", Age = 27 });
            personList.Add(new Person { Id = 2, FirstName = "Albert", LastName = "Einstein", Age = 140 });
            personList.Add(new Person { Id = 3, FirstName = "Donald", LastName = "Duck", Age = 89 });

            return personList;
        }
    }
}
