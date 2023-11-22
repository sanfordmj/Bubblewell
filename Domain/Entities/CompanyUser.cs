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
    public sealed class CompanyUser : Entity
    {
        public CompanyUser(Guid Id, Guid companyId, Guid userId, DateTime? updatedAt, bool deleted) : base(Id)
        {
            CompanyId = companyId;
            UserId = userId;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }

        public CompanyUser() { }

        [Required, ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public Company? Company { get; set; }
        public User? User { get; set; }
        
    }
}
