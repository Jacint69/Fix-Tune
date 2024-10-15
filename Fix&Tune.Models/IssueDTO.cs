using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fix_Tune.Models
{
    public class IssueDTO
    {
        
        public int IssueID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        

    }
}
