using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOauth.Models
{
    public class Credential 
    {
        [Key]
        public string Token { get; set; }
        public string AccessToken { get; set; }
        public long MemberId { get; set; }
        public string RefreshToken { get; set; }
        public CredentialScope CredentialScope { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public CredentialStatus Status { get; set; }

        [JsonIgnore]
        public Member Member { get; set; }

        public static Credential GenerateCridential(long memberId, CredentialScope credentialScope)
        {
            var token = Guid.NewGuid().ToString();
            var timeNow = DateTime.Now;
            return new Credential
            {                                                             
                Token = token,
                AccessToken = token,
                MemberId = memberId,
                RefreshToken = Guid.NewGuid().ToString(),
                CredentialScope = CredentialScope.Basic,
                CreatedAt = timeNow,
                UpdatedAt = timeNow,
                ExpiredAt = timeNow.AddDays(7),
                Status = CredentialStatus.Activated
            };
        }
    }

    public enum CredentialStatus
    {
        Activated = 1,
        Deactivated = 0
    }

    public enum CredentialScope
    {
        Basic = 1,
        SongApi = 2,
        Gallery = 3
    }
}
