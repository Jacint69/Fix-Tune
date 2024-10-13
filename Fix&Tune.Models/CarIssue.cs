using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Models
{
    [Table("CarIssues")]
    public class CarIssue
    {
        public int CarIssueId {  get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }

        [ForeignKey(nameof(Issue))]
        public int IssueId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Issue Issue { get; set; }    
    }
}
