using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities
{
    public partial class VoiceDemo
    {
        public VoiceDemo()
        {
            ArtistVoiceDemos = new HashSet<ArtistVoiceDemo>();
        }

        public Guid Id { get; set; }
        public string Url { get; set; }

        public virtual ICollection<ArtistVoiceDemo> ArtistVoiceDemos { get; set; }
    }
}
