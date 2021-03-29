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
        public DateTime commentedDateTime { get; set; }

        private List<Reaction> _Reaction = new List<Reaction>();
        public List<Reaction> Reaction { get { return _Reaction; } set { _Reaction = value; } }
    }
}
