using MicroServices.Services.Obilet.Domain.Core;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.OrderAggregate
{
    public class BusJourney : Entity, IAggregateRoot
    {
        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

    }
}
