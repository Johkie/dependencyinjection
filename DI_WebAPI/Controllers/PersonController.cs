using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_WebAPI.DataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IDataReader _dataReader;
        public PersonController(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        [HttpGet]
        public IEnumerable<Person> GetPersons()
        {
            return _dataReader.GetData();
        }
    }
}