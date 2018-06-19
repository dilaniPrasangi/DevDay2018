
namespace TIQRI.Devday.Models
{
    public class Track : EntityBase
    {
        public string TrackName { get; set; }
        public string Description { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}