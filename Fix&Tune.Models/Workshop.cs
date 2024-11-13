using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Models
{
    public class Workshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkshopId {  get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]

        public string Address { get; set; }

        [Required]
        //Fő telephely
        public bool MainWorkshop {  get; set; }

    }
}
