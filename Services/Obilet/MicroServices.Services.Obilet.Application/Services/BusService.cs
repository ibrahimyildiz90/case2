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
    public class BusService : IBusService
    {
        private readonly IIntegrationService _integrationService;

        public BusService(IIntegrationService integrationService)
        {
            _integrationService = integrationService;
        }

        public MicroService.Shared.Dtos.Response<List<BusJourneyDto>> GetBusJourneys(BusJourneyReqDto busJourneyReqDto, SessionDto session)
        {
            try
            {
                var busJourneysRequest = new Request<BusJourneyReqDto>() { DeviceSession = session, Data = busJourneyReqDto };

                var busJourneysResponse = _integrationService.GetBusJourneys(busJourneysRequest).Result;
                if (busJourneysResponse.Status != "Success")
                    throw new Exception($"Error on GetBusJourneys. Details:{busJourneysResponse.Message}");

                var data = busJourneysResponse.Data;
                return MicroService.Shared.Dtos.Response<List<BusJourneyDto>>.Success(data, 200);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public MicroService.Shared.Dtos.Response<List<BusLocationDto>> GetBusLocations(SessionDto session)
        {
            try
            {
                var busLocationsRequest = new Request<string>() { DeviceSession = session };

                var busLocationsResponse = _integrationService.GetBusLocations(busLocationsRequest).Result;
                if (busLocationsResponse.Status != "Success")
                    throw new Exception($"Error on GetBusLocations. Details:{busLocationsResponse.Message}");

                var data = busLocationsResponse.Data;
                return MicroService.Shared.Dtos.Response<List<BusLocationDto>>.Success(data, 200);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
