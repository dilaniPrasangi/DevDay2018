using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TIQRI.Devday.Models.ViewModel
{
    public class FeedbackType : EntityBase
    {
        [MaxLength(1000)]
        public string FeedbackTypeName { get; set; }
        public List<Feedback> Feedbacks { get; set; }

    }
}