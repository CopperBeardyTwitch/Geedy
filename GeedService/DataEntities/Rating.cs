using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GeedService.Model
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string RatedUserName { get; set; }

        [Required]
        public string RaterUserName { get; set; }

        public DateTime TimeRated { get; set; }

        [Required]
        [Range(1,5)]
        public int GivenRating { get; set; }    
    }
}
