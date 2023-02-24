using Microsoft.AspNetCore.Mvc;
using PartialViewExample.Models;

namespace PartialViewExample.ViewComponents
{
    public class DetailsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city) // 'city' code passed from details view
        {
            return View(city); // we return "~/Shared/Components/Details/Default.cshtml
        }
    }
}
