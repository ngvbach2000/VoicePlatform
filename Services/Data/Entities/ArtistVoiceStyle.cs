using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class ArtistVoiceStyle
    {
        public Guid ArtistId { get; set; }
        public Guid VoiceStyleId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual VoiceStyle VoiceStyle { get; set; }
    }
}
