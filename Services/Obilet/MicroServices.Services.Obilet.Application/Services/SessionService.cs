using MicroServices.Services.Obilet.Application.Dtos;
using MicroServices.Services.Obilet.Application.Dtos.Bus;
using MicroServices.Services.Obilet.Application.Dtos.Session;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace MicroServices.Services.Obilet.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly IIntegrationService _integrationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IIntegrationService integrationService, IHttpContextAccessor httpContextAccessor)
        {
            _integrationService = integrationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public SessionDto GetSession()
        {
            try
            {
                var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
                var uaParser = Parser.GetDefault();
                ClientInfo client = uaParser.Parse(userAgent);
                var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                var sessionRequest = new SessionReqDto()
                {
                    Type = 1,
                    Connection = new Connection { IpAddress = ipAddress, Port = "5117" },
                    Browser = new Browser { Name = client.UserAgent.Family, Version = $"{client.UserAgent.Major}.{client.UserAgent.Minor}" }
                };

                var sessionResponse = _integrationService.GetSession(sessionRequest).Result;
                if (sessionResponse.Status != "Success")
                    throw new Exception($"Error on GetSession. Details:{sessionResponse.Message}");

                var data = sessionResponse.Data;
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
