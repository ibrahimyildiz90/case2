using MicroServices.Services.Obilet.Domain.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.OrderAggregate
{
    public class Browser : ValueObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return new object[] { Name, Version };
        }
    }
}
