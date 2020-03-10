using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace DI_Datareader
{
    public class FileReader : IDataReader
    {
        public IFileLoader loader { get; set; }
        
        public FileReader()
        {
            loader = new FileLoader("DataReader/personFile.txt");
        }

        public IEnumerable<Person> ParseData(string data)
        {
            List<Person> personList = new List<Person>();
            var personData = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var p in personData)
            {
                string[] split = p.Split(",");
                personList.Add(new Person { Id = int.Parse(split[0]), FirstName = split[1], LastName = split[2], Age = int.Parse(split[3]) });
            }
            return personList;
        }

        public IEnumerable<Person> GetPeople()
        {
            var data = loader.LoadFile();
            var people = ParseData(data);

            return people;
        }


    }
}
