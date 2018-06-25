
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Services
{
    public class FeedbackTypeService
    {
        private AppContext db;

        public FeedbackTypeService(AppContext appContext)
        {
            db = appContext;
        }

        public async Task<List<FeedbackType>> GetAll()
        {
            return await db.FeedbackTypes.ToListAsync();
        }

        public async Task<FeedbackType> GetFeedbackTypeByIdAsync(int? id)
        {
            return await db.FeedbackTypes.FindAsync(id);
        }

        public async void Post(FeedbackType feedbackType)
        {
            db.FeedbackTypes.Add(feedbackType);
            await db.SaveChangesAsync();
        }

        public async void Edit(FeedbackType feedbackType)
        {
            db.Entry(feedbackType).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Delete(FeedbackType feedbackType)
        {
            db.FeedbackTypes.Remove(feedbackType);
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}