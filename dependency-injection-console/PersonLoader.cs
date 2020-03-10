using System;
using System.Collections.Generic;
using DI_Datareader;

namespace dependency_injection_console
{
    class PersonLoader
    {
        public DBReader dbReader;
        public FileReader fileReader;

        public PersonLoader(string type)
        {
            if (type == "db") {
                dbReader = new DBReader();
            }
            else if (type == "fr") {
                fileReader = new FileReader();
            }
        }

        public IEnumerable<Person> GetPeopleData()
        {
            if (dbReader != null) {
                return dbReader.GetPeople();
            }
            else if (fileReader != null) {
                return fileReader.GetPeople();
            }

            return new List<Person>();
        }
    }
}
