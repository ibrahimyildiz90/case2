using Newtonsoft.Json;

namespace MicroService.UI.Obilet.MVC.Models.SessionModels
{
    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
