using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportSystemApp.Models
{
    public class AspNetUsersEdit
    {
        public AspNetUsersEdit()
        {
            
            this.AspNetRoles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserCity { get; set; }
        public string UserCountry { get; set; }

        public string RoleName { get; set; }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}