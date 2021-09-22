using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class VoiceStyle
    {
        public VoiceStyle()
        {
            ArtistVoiceStyles = new HashSet<ArtistVoiceStyle>();
            ProjectVoiceStyles = new HashSet<ProjectVoiceStyle>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistVoiceStyle> ArtistVoiceStyles { get; set; }
        public virtual ICollection<ProjectVoiceStyle> ProjectVoiceStyles { get; set; }
    }
}
