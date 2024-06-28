namespace MikroServices.UI.Obilet.MVC.Models.BusModels
{
    public class JourneyViewModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Currency { get; set; }
    }
}
