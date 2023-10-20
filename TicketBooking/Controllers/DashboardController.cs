using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using TicketBooking.Model;

namespace TicketBooking.Controllers
{
    [ApiController]
    [Route("dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private static readonly string[] Cities = new[]
        {
        "Chennai", "New Delhi", "Mumbai", "Hyderabad", "Bangalore", "Ahmedabad", "Cochin", "Trichy", "Pune", "Hyderabad"
        };

        private static readonly string[] ChennaiTheatres = new[]
        {
            "Sathyam cinemas", "Sivasakthi Cinemas", "PVR : VR Mall", "PVR : Palazzo", "PVR : Inox"
        };

        private static readonly string[] TirunelveliTheatres = new[]
        {
            "Rathna cinemas", "PSS Cinemas", "Ram Muthuram", "PTT"
        };

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("load-cities")]
        public IEnumerable<string> GetCityLists()
        {
            return Cities.ToArray();
        }

        [HttpGet]
        [Route("{city}/load-theatres")]
        public IEnumerable<string> GetCityLists([FromRoute] string city)
        {
            List<string> theatres = new List<string>();
            if (!string.IsNullOrWhiteSpace(city))
            {
                if (City.Chennai.ToString().Equals(city))
                {
                    theatres.AddRange(ChennaiTheatres.ToList());
                }

                if (City.Tirunelveli.ToString().Equals(city))
                {
                    theatres.AddRange(TirunelveliTheatres.ToList());
                }
            }

            return theatres;
        }
    }
}
