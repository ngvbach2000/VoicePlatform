using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities
{
    public partial class ProjectGender
    {
        public Guid ProjectId { get; set; }
        public Guid GenderId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Project Project { get; set; }
    }
}
