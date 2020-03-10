using System;
using System.Collections.Generic;
using DI_Datareader;

namespace dependency_injection_console
{
    class PersonLoaderDI
    {
        public IDataReader dataReader;

        // Constructor Injection
        public PersonLoaderDI(IDataReader pDataReader)
        {
            this.dataReader = pDataReader;
        }

        public IEnumerable<Person> GetPeopleData()
        {
            return dataReader.GetPeople();
        }  
    }
}
