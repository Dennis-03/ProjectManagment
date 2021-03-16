using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagment.Model
{
    class Task
    {
        public long ID = DateTime.Now.Ticks;
        public string TaskString { get; set; }
        public Constants.PriorityEnum Priority;
        public string AssignedTo { get; set; }
        public string AssignedBy { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
