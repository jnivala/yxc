﻿using System.Collections.Generic;

namespace Yxc.Entities.v1.Zone
{
    // ReSharper disable All
    public class GetSoundProgramListResponse
    {
        public int response_code { get; set; }
        /// <summary>
        /// R-N602 v 1.12 returns empty array.
        /// </summary>
        public List<string> sound_program_list { get; set; }
    }
    // ReSharper restore All
}
