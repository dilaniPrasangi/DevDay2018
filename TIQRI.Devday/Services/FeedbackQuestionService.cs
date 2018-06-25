
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Services
{
    public class FeedbackQuestionService
    {
        private AppContext db;

        public FeedbackQuestionService(AppContext appContext)
        {
            db = appContext;
        }

        public async Task<List<FeedbackQuestion>> GetAll()
        {
            return await db.FeedbackQuestions.ToListAsync();
        }

        public async Task<FeedbackQuestion> GetFeedbackQuestionByIdAsync(int? id)
        {
            return await db.FeedbackQuestions.FindAsync(id);
        }

        public async void Post(FeedbackQuestion feedbackQuestion)
        {
            db.FeedbackQuestions.Add(feedbackQuestion);
            await db.SaveChangesAsync();
        }

        public async void Edit(FeedbackQuestion feedbackQuestion)
        {
            db.Entry(feedbackQuestion).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Delete(FeedbackQuestion feedbackQuestion)
        {
            db.FeedbackQuestions.Remove(feedbackQuestion);
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}