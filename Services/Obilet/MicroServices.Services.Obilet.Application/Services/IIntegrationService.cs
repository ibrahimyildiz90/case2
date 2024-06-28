using MicroServices.Services.Obilet.Application.Dtos;
using MicroServices.Services.Obilet.Application.Dtos.Bus;
using MicroServices.Services.Obilet.Application.Dtos.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Application.Services
{
    public interface IIntegrationService
    {
        Task<Response<SessionDto>> GetSession(SessionReqDto sessionRequest);
        Task<Response<List<BusLocationDto>>> GetBusLocations(Request<string> request);
        Task<Response<List<BusJourneyDto>>> GetBusJourneys(Request<BusJourneyReqDto> busJourneyReqDto);
    }
}
