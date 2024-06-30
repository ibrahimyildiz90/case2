using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using UAParser;
using System.Net;
using System.Reflection.Metadata;

using MicroServices.Services.Obilet.Application.Services;
using MicroServices.Services.Obilet.Application.Dtos.Session;
using MicroServices.Services.Obilet.Application.Dtos.Bus;
using MicroService.UI.Obilet.MVC.Models.BusModels;
using MikroServices.UI.Obilet.MVC.Mapping;

namespace MicroService.UI.Obilet.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        private readonly ILogger<HomeController> _logger;

        private readonly IBusService _busService;
        private readonly ISessionService _sessionService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        string sessionCookie;
        const string cookieKey = "session";
        #endregion

        #region Ctor
        public HomeController(ILogger<HomeController> logger, IBusService busService, ISessionService sessionService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _busService = busService;
            _sessionService = sessionService;
            _httpContextAccessor = httpContextAccessor;
            CreateSession();
        }
        #endregion

        #region Methods
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(sessionCookie))
                sessionCookie = GetCookie(cookieKey);

            var deviceSession = JsonConvert.DeserializeObject<SessionDto>(sessionCookie);

            var busLocationData = _busService.GetBusLocations(deviceSession);

            var busLocationList = new List<SelectListItem>();
            foreach (var location in busLocationData.Data)
            {
                busLocationList.Add(new SelectListItem { Text = location.Name, Value = location.Id.ToString() });
            }

            ViewBag.BusLocationList = new SelectList(busLocationList, "Value", "Text");
            return View();
        }

        public ActionResult FindJourney(int origin, int destination, DateTime departureDate)
        {
            var request= new BusJourneyReqDto() { OriginId = origin, DestinationId = destination, DepartureDate = departureDate.ToString("yyyy-MM-dd") };

            var deviceSession = JsonConvert.DeserializeObject<SessionDto>(sessionCookie);
            var busJourneyList = _busService.GetBusJourneys(request, deviceSession);

            var journeylist= busJourneyList.Data.OrderBy(o => o.Journey.Departure).ToList();

            var viewModel = ObjectMapper.Mapper.Map<List<BusJourneyViewModel>>(journeylist);


            return View("JourneyIndex", viewModel);
        }

        private void CreateSession()
        {

            sessionCookie = GetCookie(cookieKey);

            if (string.IsNullOrEmpty(sessionCookie))
            {
                var session = JsonConvert.SerializeObject(_sessionService.GetSession().Data);

                AddCookie(session);
            }            
        }

        private void AddCookie(string value)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieKey, value, cookieOptions);

            sessionCookie = value;
        }

        private string? GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }
        #endregion
    }
}