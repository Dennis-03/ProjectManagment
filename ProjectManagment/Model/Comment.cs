using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagment.Model
{
    class Comment
    {
        public long ID = DateTime.Now.Ticks;
        public long TaskID { get; set; }
        public string CommentString { get; set; }
    }
    class Reply : Comment
    {
        public long ID = DateTime.Now.Ticks;
    }
}
