using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class Gender
    {
        public Gender()
        {
            Artists = new HashSet<Artist>();
            Customers = new HashSet<Customer>();
            ProjectGenders = new HashSet<ProjectGender>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<ProjectGender> ProjectGenders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
