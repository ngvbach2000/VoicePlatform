using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistCountries = new HashSet<ArtistCountry>();
            ArtistVoiceDemos = new HashSet<ArtistVoiceDemo>();
            ArtistVoiceStyles = new HashSet<ArtistVoiceStyle>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid GenderId { get; set; }
        public string Status { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateBy { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual User UpdateByNavigation { get; set; }
        public virtual ICollection<ArtistCountry> ArtistCountries { get; set; }
        public virtual ICollection<ArtistVoiceDemo> ArtistVoiceDemos { get; set; }
        public virtual ICollection<ArtistVoiceStyle> ArtistVoiceStyles { get; set; }
    }
}
