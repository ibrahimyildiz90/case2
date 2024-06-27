using MicroService.UI.Obilet.MVC.Models.SessionModels;
using MicroService.UI.Obilet.MVC.Models;
using MicroService.UI.Obilet.MVC.Models.BusModels;

namespace MicroService.UI.Obilet.MVC.Interfaces
{
    public interface IIntegrationService
    {
        Task<Response<DeviceSession>> GetSession(SessionRequest sessionRequest);
        Task<Response<List<BusLocation>>> GetBusLocations(Request<string> request);
        Task<Response<List<BusJourney>>> GetBusJourneys(Request<BusJourneyData> request);
    }
}
