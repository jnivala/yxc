using System.Collections.Generic;

namespace Yxc.Entities.v1.Netusb
{
    // ReSharper disable All
    public class GetListInfo
    {
        public int response_code { get; set; }
        public int menu_layer { get; set; }
        public int max_line { get; set; }
        public int index { get; set; }
        public int playing_index { get; set; }
        public string menu_name { get; set; }
        public List<ListInfo> list_info { get; set; }

        public class ListInfo
        {
            public string text { get; set; }
            public string thumbnail { get; set; }
            public int attribute { get; set; }
        }
    }
    // ReSharper restore All
}
