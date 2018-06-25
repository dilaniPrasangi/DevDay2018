
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Services
{
    public class TrackService
    {
        private AppContext db;

        public TrackService(AppContext appContext)
        {
            db = appContext;
        }

        public async Task<List<Track>> GetAll()
        {
            return await db.Tracks.ToListAsync();
        }

        public async Task<Track> GetTrackByIdAsync(int? id)
        {
            return await db.Tracks.FindAsync(id);
        }

        public async void Post(Track track)
        {
            db.Tracks.Add(track);
            await db.SaveChangesAsync();
        }

        public async void Edit(Track track)
        {
            db.Entry(track).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async void Delete(Track track)
        {
            db.Tracks.Remove(track);
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}