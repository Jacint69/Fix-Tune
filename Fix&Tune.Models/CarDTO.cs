using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Tune.Models
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public string UserId { get; set; }
        public List<IssueDTO> Issues { get; set; }
    }
}
