using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Bilet2._2.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prefession { get;set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string?   TwitterUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? FacebookUrl { get; set; }

        public bool IsDeleted { get; set; }
    }
}
