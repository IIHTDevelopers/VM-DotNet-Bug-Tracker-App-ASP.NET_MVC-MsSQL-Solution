
using BugTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerApp.DAL.Interface
{
    public interface IBugTrackerRepository
    {
        IEnumerable<Bug> GetBugs();
        Bug GetBugByID(int BugId);
        Bug InsertBug(Bug Bug);
        int DeleteBug(int BugId);
        bool UpdateBug(Bug Bug);
        void Save();
    }
}