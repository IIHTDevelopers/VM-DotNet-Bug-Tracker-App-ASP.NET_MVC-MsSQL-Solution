using BugTrackerApp.DAL.Interface;
using BugTrackerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTrackerApp.DAL.Repository
{
    public class BugTrackerService : IBugTrackerInterface
    {
        private IBugTrackerRepository _repo;
        public BugTrackerService(IBugTrackerRepository repo)
        {
            this._repo = repo;
        }

        public int DeleteBug(int BugId)
        {
            var res= _repo.DeleteBug(BugId);
            return res;
        }

        public Bug GetBugByID(int BugId)
        {
            return _repo.GetBugByID(BugId);
        }
        public void Save()
        {
            _repo.Save();
        }


        IEnumerable<Bug> IBugTrackerInterface.GetBugs()
        {
            return _repo.GetBugs();
        }

        Bug IBugTrackerInterface.InsertBug(Bug Bug)
        {
            return _repo.InsertBug(Bug);
        }

        bool IBugTrackerInterface.UpdateBug(Bug Bug)
        {
            return _repo.UpdateBug(Bug);
        }
    }
}