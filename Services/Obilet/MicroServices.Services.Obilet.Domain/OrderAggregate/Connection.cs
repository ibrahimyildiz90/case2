using MicroServices.Services.Obilet.Domain.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.OrderAggregate
{
    public class Connection : ValueObject
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { IpAddress, Port };
        }
    }
}
