using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagment.Constants;
using ProjectManagment.Model;


namespace ProjectManagment.Model
{
    class ZTask
    {
        public long Id = DateTime.Now.Ticks;
        public string TaskName { get; set; }
        public PriorityEnum Priority;
        public uint AssignedTo { get; set; }
        public uint AssignedBy { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public List<Comment> comment { get; set; }
    }
}
