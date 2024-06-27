using MicroServices.Services.Obilet.Domain.Dtos.Bus;
using MicroServices.Services.Obilet.Domain.Dtos.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.Services
{
    public interface IBusService
    {
        List<BusLocationDto> GetBusLocations(SessionDto session);
        List<BusJourneyDto> GetBusJourneys(BusJourneyReqDto data, SessionDto session);
    }
}
