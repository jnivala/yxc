using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yxc.Entities.v1
{
    public class EventData
    {
        // ReSharper disable All 
        public EventDataMain main { get; set; }

        public class EventDataMain
        {

            public string power { get;  set; }
            public string input { get;  set; }
            public int? volume { get;  set; }
            public bool? mute { get;  set; }
            public bool status_updated { get;  set; }
            public bool signal_info_updated { get;  set; }
        }
        // ReSharper restore All
    }
}
