using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities‏
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        [EmailAddress(ErrorMessage = "The email address is invalid")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MinLength(6, ErrorMessage = "Your password must be at least 6 characters long")]
        public string Password { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}


