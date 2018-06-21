
using System.Collections.Generic;

namespace TIQRI.Devday.Models.ViewModel
{
    public class FeedbackQuestion : EntityBase
    {
        public string Question { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}