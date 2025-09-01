using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CountryAPI.Models;

namespace CountryAPI.Controllers
{
    public class CountryController : ApiController
    {
       
        private static List<Country> countries = new List<Country>()
        {
            new Country { ID = 1, CountryName = "Russia", Capital = "Moscow" },
            new Country { ID = 2, CountryName = "India", Capital = "New Delhi" },
        };

        public IHttpActionResult Get()
        {
            return Ok(countries);
        }

       
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

        public IHttpActionResult Post([FromBody] Country newCountry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            newCountry.ID = countries.Max(c => c.ID) + 1;
            countries.Add(newCountry);
            return CreatedAtRoute("DefaultApi", new { id = newCountry.ID }, newCountry);
        }

       
        public IHttpActionResult Put(int id, [FromBody] Country updatedCountry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;

            return Ok(country);
        }

        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return Ok();
        }
    }
}
