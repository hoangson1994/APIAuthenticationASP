using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOauth.Models
{
    public class CredentialRespone
    {
        public string Token { get; set; }
        public string SecretToken { get; set; }
        public long MemberId { get; set; }
        public long CreatedTimeMLS { get; set; }
        public long ExpiredTimeMLS { get; set; }
        public int Status { get; set; }
    }
}
