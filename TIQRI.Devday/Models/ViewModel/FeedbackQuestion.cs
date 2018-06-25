
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TIQRI.Devday.Models.ViewModel
{
    public class FeedbackQuestion : EntityBase
    {
        [MaxLength(1000)]
        public string Question { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}