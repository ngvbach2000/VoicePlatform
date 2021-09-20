using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities
{
    public partial class Project
    {
        public Project()
        {
            CustomerProjects = new HashSet<CustomerProject>();
            ProjectCountries = new HashSet<ProjectCountry>();
            ProjectGenders = new HashSet<ProjectGender>();
            ProjectVoiceStyles = new HashSet<ProjectVoiceStyle>();
        }

        public Guid Id { get; set; }
        public Guid Poster { get; set; }
        public string Comment { get; set; }
        public int? Rate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Customer PosterNavigation { get; set; }
        public virtual ICollection<CustomerProject> CustomerProjects { get; set; }
        public virtual ICollection<ProjectCountry> ProjectCountries { get; set; }
        public virtual ICollection<ProjectGender> ProjectGenders { get; set; }
        public virtual ICollection<ProjectVoiceStyle> ProjectVoiceStyles { get; set; }
    }
}
