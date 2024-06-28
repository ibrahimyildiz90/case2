using MicroServices.Services.Obilet.Domain.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.OrderAggregate
{
    public class Journey : ValueObject
    {
        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Origin, Destination, Departure, Arrival, OriginalPrice, Currency };
        }
    }

}
