using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class ProjectCountry
    {
        public Guid ProjectId { get; set; }
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Project Project { get; set; }
    }
}
