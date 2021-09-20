using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities
{
    public partial class ArtistVoiceDemo
    {
        public Guid ArtistId { get; set; }
        public Guid VoiceDemoId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual VoiceDemo VoiceDemo { get; set; }
    }
}
