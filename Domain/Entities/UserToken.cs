using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class UserToken : Entity
    {
        public UserToken(Guid id, Guid userId, string token, DateTime? createDate, DateTime? expireDate, bool isExpired, bool isRevoked, DateTime? updatedAt, bool deleted) : base(id) 
        { 
            UserId = userId;
            Token = token;
            CreateDate = createDate;
            ExpireDate = expireDate;
            IsExpired = isExpired;
            IsRevoked = isRevoked;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }
        public UserToken() { }
        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }
        public string? Token {  get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ExpireDate { get; set;}
        public bool IsExpired { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public User? User { get; set; }
    }
}
