using MicroServices.Services.Obilet.Application.Dtos.Bus;
using MicroServices.Services.Obilet.Application.Dtos.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Application.Services
{
    public interface IBusService
    {
        MicroService.Shared.Dtos.Response<List<BusLocationDto>> GetBusLocations(SessionDto session);
        MicroService.Shared.Dtos.Response<List<BusJourneyDto>> GetBusJourneys(BusJourneyReqDto data, SessionDto session);
    }
}
