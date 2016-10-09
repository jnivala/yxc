using System.Collections.Generic;

namespace Yxc.Entities.v1.zone
{
    // ReSharper disable All
    public class GetSoundProgramList
    {
        public int response_code { get; set; }
        /// <summary>
        /// R-N602 v 1.12 returns empty array.
        /// </summary>
        public List<string> sound_program_list { get; set; }
    }
    // ReSharper restore All
}
