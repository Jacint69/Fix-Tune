﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fix_Tune.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        public string PlateNumber { get; set; }

      //  public bool Status { get;set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual User? User { get; set; } 

        [JsonIgnore]
        public virtual ICollection<Issue> Issues { get; set; }

        public Car()
        {
            Issues=new HashSet<Issue>();
         //   Status = false;
        }


    }
}
