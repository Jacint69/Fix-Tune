using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fix_Tune.Models
{
    public class User : IdentityUser
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime DateOfRegistration {  get; set; }
     
        public virtual ICollection<Car> Cars { get; set; }

        public User()
        {
            Cars=new HashSet<Car>();
        }


    }
}
