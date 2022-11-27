using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Model.Entities
{
    //Role bazlı authentication için gerekli attributelar
    [Serializable]
    [Flags]
    public enum Role
    {
        None= 0,
        Member = 1,
        Admin = 3
    }

    public class AppUser:CoreEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public Role? Role { get; set; }
        public DateTime? BirthDate { get; set; }

        // Navigation Props Begin
        public List<Order> Orders { get; set; }
    }
}
