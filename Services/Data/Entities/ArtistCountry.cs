using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class ArtistCountry
    {
        public Guid ArtisId { get; set; }
        public Guid CountryId { get; set; }

        public virtual Artist Artis { get; set; }
        public virtual Country Country { get; set; }
    }
}
