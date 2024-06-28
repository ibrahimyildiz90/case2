using MicroServices.Services.Obilet.Domain.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.OrderAggregate
{
    public class Session : ValueObject
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("browser")]
        public Browser Browser { get; set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Type, Connection, Browser };
        }
    }

}
