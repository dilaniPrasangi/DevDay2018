
using System.ComponentModel.DataAnnotations;

namespace TIQRI.Devday.Models.ViewModel
{
    public class Feedback : EntityBase
    {
        public int FeedbackScore { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(1000)]
        public string Comment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FeedbackTypeId { get; set; }
        public FeedbackType FeedbackType { get; set; }
        public int FeedbackQuestionId { get; set; }
        public FeedbackQuestion FeedbackQuestion { get; set; }
    }
}