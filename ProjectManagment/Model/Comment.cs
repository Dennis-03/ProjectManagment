using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagment.Model
{
    class Comment
    {   
        public long Id = DateTime.Now.Ticks;
        public long ParentId { get; set; }
        public long TaskID { get; set; }
        public string CommentString { get; set; }
    }
}
