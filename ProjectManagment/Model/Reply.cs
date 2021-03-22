using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagment.Model
{
    class Reply
    {
        public long Id = DateTime.Now.Ticks;
        public long CommentID { get; set; }
        public string ReplyString { get; set; }
    }
}
