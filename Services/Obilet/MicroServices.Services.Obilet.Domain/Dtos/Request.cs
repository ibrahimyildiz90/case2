using MicroServices.Services.Obilet.Domain.Dtos.Session;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroServices.Services.Obilet.Domain.Dtos
{
    public class Request<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";

        [JsonProperty("device-session")]
        public SessionDto DeviceSession { get; set; }
    }
}
