using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class UsagePurpose
    {
        public UsagePurpose()
        {
            ProjectUsagePurposes = new HashSet<ProjectUsagePurpose>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProjectUsagePurpose> ProjectUsagePurposes { get; set; }
    }
}
