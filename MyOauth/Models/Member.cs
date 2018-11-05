using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOauth.Models
{
    public class Member
    {
        public long ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Introduction { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
       
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public MemberStatus Status { get; set; }

        [JsonIgnore]
        public ICollection<Credential> Credentials { get; set; }

        public Member()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = MemberStatus.Activated;
        }
    }

    public enum MemberStatus
    {
        Activated = 1,
        Deactivated = 0
    }
}
