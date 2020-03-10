using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_Datareader
{
    public interface IDataReader
    {
        public IEnumerable<Person> GetPeople();
    }
}
