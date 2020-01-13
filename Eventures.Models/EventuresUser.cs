using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Models
{
    public class EventuresUser : IdentityUser
    {
        public EventuresUser()
        {
        }

        [Key]
        public string UniqueCitizenNumber { get; set; }     

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual IdentityRole Role { get; set; }
    }
}
