using System.Text.Json;
using WebSite.Models;

namespace WebSite.Services
{
    public class CarService
    {
        //constructor
        public CarService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        //add property of type "IWebHostEnvironment"
        public IWebHostEnvironment WebHostEnvironment { get; }

        //one more property for the "JsonFileName":
        /*
        private String JsonFileName { 
            get{
                //get has to return the full location of your JSON file as a string
                //Web Host Env.+ website root path
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
            }
        }
        */
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "cars.json");

        public IEnumerable<Car> GetCars()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Car[]>
                (jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
        }
    }//class
}//namespace