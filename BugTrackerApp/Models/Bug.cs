using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BugName { get; set; }
        public bool IsCompleted { get; set; }
        public string Notes { get; set; }
    }

}