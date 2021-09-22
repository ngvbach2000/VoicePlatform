using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class Project
    {
        public Project()
        {
            ArtistProjectFiles = new HashSet<ArtistProjectFile>();
            CustomerProjectFiles = new HashSet<CustomerProjectFile>();
            CustomerProjects = new HashSet<CustomerProject>();
            ProjectCountries = new HashSet<ProjectCountry>();
            ProjectGenders = new HashSet<ProjectGender>();
            ProjectUsagePurposes = new HashSet<ProjectUsagePurpose>();
            ProjectVoiceStyles = new HashSet<ProjectVoiceStyle>();
        }

        public Guid Id { get; set; }
        public Guid Poster { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Description { get; set; }
        public string ReferenceLink { get; set; }
        public int Duration { get; set; }
        public DateTime ResponseDeadline { get; set; }
        public DateTime ProjectDeadline { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Customer PosterNavigation { get; set; }
        public virtual ICollection<ArtistProjectFile> ArtistProjectFiles { get; set; }
        public virtual ICollection<CustomerProjectFile> CustomerProjectFiles { get; set; }
        public virtual ICollection<CustomerProject> CustomerProjects { get; set; }
        public virtual ICollection<ProjectCountry> ProjectCountries { get; set; }
        public virtual ICollection<ProjectGender> ProjectGenders { get; set; }
        public virtual ICollection<ProjectUsagePurpose> ProjectUsagePurposes { get; set; }
        public virtual ICollection<ProjectVoiceStyle> ProjectVoiceStyles { get; set; }
    }
}
