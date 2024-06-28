using MicroServices.Services.Obilet.Domain.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.OrderAggregate
{
    public class BusLocation : ValueObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Id, Name };
        }
    }
}
