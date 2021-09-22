using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class ProjectVoiceStyle
    {
        public Guid ProjectId { get; set; }
        public Guid VoiceStyleId { get; set; }

        public virtual Project Project { get; set; }
        public virtual VoiceStyle VoiceStyle { get; set; }
    }
}
