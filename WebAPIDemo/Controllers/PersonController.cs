using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
	public class PersonController : Controller
	{
		// GET: Person
		public async Task<ActionResult> Index()
		{
			using (HttpClient client = new HttpClient())
			{

				string personListServiceUrl = GetPersonListServiceUrl();

				IEnumerable<Person> personList = await CallPersonListServiceAsync(client, personListServiceUrl);

				return View(personList);
			}
		}
		private string GetPersonListServiceUrl()
		{
			return Url.RouteUrl("DefaultApi", new { httproute = true, controller = "PersonService" }, Request.Url.Scheme);
		}

		private async Task<IEnumerable<Person>> CallPersonListServiceAsync(HttpClient client, string serviceUrl)
		{
			HttpResponseMessage response = await client.GetAsync(serviceUrl);

			IEnumerable<Person> persons = await response.Content.ReadAsAsync<IEnumerable<Person>>();

			return persons;
		}
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<ActionResult> Create(Person person)
		{
			using (HttpClient client = new HttpClient())
			{

				string personListServiceUrl = GetPersonListServiceUrl();

				HttpResponseMessage response = await client.PostAsJsonAsync(personListServiceUrl, person);

				Person createdPerson = await response.Content.ReadAsAsync<Person>();

				return View(createdPerson);
			}
		}
		public ActionResult IndexWithAjax()
		{
			return View();
		}
	}

}
