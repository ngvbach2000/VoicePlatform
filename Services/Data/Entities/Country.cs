using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class Country
    {
        public Country()
        {
            ArtistCountries = new HashSet<ArtistCountry>();
            ProjectCountries = new HashSet<ProjectCountry>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistCountry> ArtistCountries { get; set; }
        public virtual ICollection<ProjectCountry> ProjectCountries { get; set; }
    }
}
