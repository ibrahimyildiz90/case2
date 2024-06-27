using Newtonsoft.Json;

namespace MicroService.UI.Obilet.MVC.Models.BusModels
{
    public class BusLocation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
