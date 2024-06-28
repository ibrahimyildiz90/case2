using MikroServices.UI.Obilet.MVC.Models.BusModels;
using Newtonsoft.Json;

namespace MicroService.UI.Obilet.MVC.Models.BusModels
{
    public class BusJourneyViewModel
    {    
        public string OriginLocation { get; set; }  
        public string DestinationLocation { get; set; }      
        public JourneyViewModel Journey { get; set; }
    }

}
