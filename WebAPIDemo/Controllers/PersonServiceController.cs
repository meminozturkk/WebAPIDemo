using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class PersonServiceController : ApiController
    {
        private PersonRepository RepositoryInstance { get { return PersonRepository.GetPersonRepository(); } }

        public IHttpActionResult GetPersonList()
        {
			IEnumerable<Person> persons = RepositoryInstance.GetPersonList();
			return Ok(persons);
		}
		public IHttpActionResult PostPerson(Person person)
		{
			
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			RepositoryInstance.Add(person);

			return Ok(person);
		}
	}
}
