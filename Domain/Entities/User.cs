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
        public User(Guid Id, UserStatus userStatus, UserType userType, string userName, string hash, string firstName, string lastName, string cellPhone, string email, DateTime? createDate, DateTime? updatedAt, bool deleted) : base(Id) { 
            UserStatus = userStatus;
            UserType = userType;
            UserName = userName;
            Hash = hash;
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            Email = email;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }
        public User() { }
        public UserStatus? UserStatus { get; set; }
        public UserType? UserType { get; set; }
        public string? UserName { get; set; }
        public string? Hash { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CellPhone {  get; set; }
        public string? Email { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }

    }
}
