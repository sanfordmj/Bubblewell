using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class User: Entity
    {
        public User(Guid Id, UserStatus userStatus, UserType userType, string userName, string password, string firstName, string lastName, string email, DateTime createDate) : base(Id) { 
            UserStatus = userStatus;
            UserType = userType;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public UserStatus? UserStatus { get; set; }
        public UserType? UserType { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
