using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace DI_WebAPI.DataReader
{
    public class FileReader : IDataReader
    {
        public List<Person> GetData()
        {
            List<Person> personList = new List<Person>();
            string[] personData = File.ReadLines("DataReader/personFile.txt").ToArray();

            foreach (var p in personData)
            {
                string[] split = p.Split(",");
                personList.Add(new Person { Id = int.Parse(split[0]), FirstName = split[1], LastName = split[2], Age = int.Parse(split[3]) });
            }
            return personList;
        }
    }
}
