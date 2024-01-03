using BugTrackerApp.DAL.Interface;
using BugTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BugTrackerApp.DAL.Repository
{
    public class BugTrackerRepository : IBugTrackerRepository
    {
        private BugTrackerDbContext _context;
        public BugTrackerRepository(BugTrackerDbContext Context)
        {
            this._context = Context;
        }
        public IEnumerable<Bug> GetBugs()
        {
             return _context.Bugs.ToList();
        }
        public Bug GetBugByID(int id)
        {
            return _context.Bugs.Find(id);
        }
        public Bug InsertBug(Bug Bug)
        {
            return _context.Bugs.Add(Bug);
        }
        public int DeleteBug(int BugID)
        {
            Bug Bug = _context.Bugs.Find(BugID);
            var res= _context.Bugs.Remove(Bug);
            return res.Id;
        }
        public bool UpdateBug(Bug Bug)
        {
            var res= _context.Entry(Bug).State = EntityState.Modified;
            return res.Equals("Bug");
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
