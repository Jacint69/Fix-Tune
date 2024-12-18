﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fix_Tune.Models
{
    public class Discount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscountId { get; set; }

        [ForeignKey(nameof(Service))]
        public int ServiceId {  get; set; }
        [Required]
        [Range(1,100)]
        public int DiscountPercentage { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Service? Service { get; set; }


    }
}
