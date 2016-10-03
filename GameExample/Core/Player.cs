using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameExample.Core
{
    public class Player
    {
        public string ConnectionId { get; set; }

        public string Name { get; set; }

        public List<int> Hand { get; set; }
    }
}