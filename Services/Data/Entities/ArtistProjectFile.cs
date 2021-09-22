using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class ArtistProjectFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid ProjectId { get; set; }
        public int MediaType { get; set; }
        public Guid CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Artist CreateByNavigation { get; set; }
        public virtual Project Project { get; set; }
    }
}
