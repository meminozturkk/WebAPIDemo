using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
	public class PersonRepository
	{
		private static PersonRepository personRepository;
		private List<Person> persons { get; set; }

		public PersonRepository()
		{
			persons = new List<Person>();
		}
		public static PersonRepository GetPersonRepository()
		{
			if (personRepository == null)
			{
				personRepository = new PersonRepository();
			}
			return personRepository;
		}

		public void Add(Person person)
		{
			persons.Add(person);
		}
		public IEnumerable<Person> GetPersonList()
		{
			return persons;
		}
		public Person GetPersonByName(string name)
		{
			return persons.First(person => person.Name == name);
		}
		public List<Person> GetPersonByMatchingName(string nameToken)
		{
			return persons.Where(n => n.Name.StartsWith(nameToken)).ToList();
		}
	}
}