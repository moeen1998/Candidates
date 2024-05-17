using System.ComponentModel.DataAnnotations;

namespace Candidates.Core.DTOs
{
    public class CandidateDTO
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime BestCallTimeInterval { get; set; }

        [Url]
        public string LinkedInProfileUrl { get; set; }

        [Url]
        public string GitHubProfileUrl { get; set; }

        [Required]
        [MinLength(5)]
        public string Comments { get; set; }

    }
}
