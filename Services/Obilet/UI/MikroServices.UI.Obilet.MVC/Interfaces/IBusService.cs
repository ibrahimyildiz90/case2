using MicroService.UI.Obilet.MVC.Models.BusModels;
using MicroService.UI.Obilet.MVC.Models.SessionModels;
using System.Collections.Generic;

namespace MicroService.UI.Obilet.MVC.Interfaces
{
    public interface IBusService
    {
        List<BusLocation> GetBusLocations(DeviceSession session);
        List<BusJourney> GetBusJourneys(BusJourneyData data, DeviceSession session);
    }
}
