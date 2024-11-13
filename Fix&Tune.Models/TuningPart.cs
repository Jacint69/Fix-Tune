using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Models
{
    public enum TuningPartType
    {
        DieselInjector, Turbo, InterCooler, Camshaft
    }
    public class TuningPart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TuningPartID {  get; set; }

        [Required]
        public TuningPartType TuningPartType { get; set;}

        [Required]
        public string Name { get; set; }

        [Required]
        [Length(1000,1000000)]
        public int Price { get; set; }


    }
}
