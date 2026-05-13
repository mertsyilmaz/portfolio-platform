using System.ComponentModel.DataAnnotations;

namespace Identity.Infrastructure.Security
{
    public class JwtOptions
    {
        public const string SectionName = "Jwt";

        [Required]
        public string Key { get; set; } = null!;

        [Required]
        public string Issuer { get; set; } = null!;

        [Required]
        public string Audience { get; set; } = null!;

        [Range(1, 168)]
        public int AccessTokenExpirationHours { get; set; } = 1;
    }
}
