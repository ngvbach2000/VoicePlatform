using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Entities
{
    public partial class CustomerProject
    {
        public Guid ProjectId { get; set; }
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Project Project { get; set; }
    }
}
