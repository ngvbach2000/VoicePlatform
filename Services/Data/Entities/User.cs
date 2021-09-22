using System;
using System.Collections.Generic;

#nullable disable

namespace VoicePlatform.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Artists = new HashSet<Artist>();
            Customers = new HashSet<Customer>();
            InverseUpdateByNavigation = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public Guid GenderId { get; set; }
        public string Status { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdateBy { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual User UpdateByNavigation { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<User> InverseUpdateByNavigation { get; set; }
    }
}
