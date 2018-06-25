using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Services
{
    public class FeedbackService 
    {
        private AppContext db;

        public FeedbackService(AppContext appContext)
        {
            db = appContext;

        }

        public IQueryable<Feedback> GetAll()
        {
            return db.Feedbacks.Include(f => f.FeedbackQuestion).Include(f => f.FeedbackType).Include(f => f.User);
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int? id)
        {
            return await db.Feedbacks.FindAsync(id);
        }

        public async void Post(Feedback feedback)
        {
            db.Feedbacks.Add(feedback);
            await db.SaveChangesAsync();
        }

        public async void Edit(Feedback feedback)
        {
            db.Entry(feedback).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Delete(Feedback feedback)
        {
            db.Feedbacks.Remove(feedback);
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}