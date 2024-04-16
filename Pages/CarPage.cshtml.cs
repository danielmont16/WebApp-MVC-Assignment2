using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSite.Models;
using WebSite.Services;

namespace WebSite.Pages
{
    public class CarPageModel : PageModel
    {
        public CarService CarService;

        public IEnumerable<Car> Cars { get; set; } = default!;

        public CarPageModel(CarService carService)
        {
            CarService = carService;
        }
        public void OnGet()
        {
            Cars = CarService.GetCars();
        }
    }//class
}//namespace


