using Microsoft.AspNetCore.Mvc;
using PartialViewExample.Models;

namespace PartialViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/weather")]
        public IActionResult Index()
        {
            List<CityWeather> cities = new List<CityWeather>()
            {
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            };

            return View(cities); //passing the object to view
        }

        [Route("/weather/{cityCode}")]
        public IActionResult Details(string? cityCode)
        {
            if (cityCode == null)
            {
                return Content("CityCode cannot be null!");
            }
            List<CityWeather> cities = new List<CityWeather>()
            {
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
                new CityWeather() {CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
            }; // we create a list in order to compare our data that passed from Index view

            CityWeather? matchCities = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault(); // we compare the data and select the one which meets our requirements

            //return ViewComponent("Details", new { city = matchCities });   //we can also render viewcomponent directly from controller. In that case we won't be able to use default layout
            return View(matchCities); // we go /weather/{cityCode} url with a selected country code
        }   
    }
}
