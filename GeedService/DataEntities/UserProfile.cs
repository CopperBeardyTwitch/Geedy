using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeedService.DataEntities
{
    public class UserProfile  
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string UserId { get; set; }
     
        [StringLength(12,ErrorMessage="Your Username must be between 4 and 12 characters", MinimumLength =4)]
        public string Username { get; set; }

        [StringLength(200, ErrorMessage = "You bio should be between 10 and 200 characters",MinimumLength = 10)]
        public string Bio { get; set; }

        public string ImageUrl { get; set; }

        public string FacebookId { get; set; }

        public string TwitterId { get; set; }

        public string LinkedInId { get; set; }
        public string InstagramId { get; set; }

        public DateTime Joined { get; set; }    
    }
}
