using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagment.Model
{
    class Reaction
    {
        long Id = DateTime.Now.Ticks;
        public long ReactedToId { get; set; }
        public long ReactedById { get; set; }
    }
}
