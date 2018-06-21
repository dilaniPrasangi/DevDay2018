using System.Collections.Generic;

namespace TIQRI.Devday.Models.ViewModel
{
    public class FeedbackType : EntityBase
    {
        public string FeedbackTypeName { get; set; }
        public List<Feedback> Feedbacks { get; set; }

    }
}