using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Company : Entity
    {
        public Company(Guid Id, CompanyStatus companyStatus, CompanyType companyType, string name, string phone, string email, DateTime? createDate, DateTime? updatedAt, bool deleted) : base(Id)
        {
            CompanyStatus = companyStatus;
            CompanyType = companyType;
            Name = name;
            Phone = phone;
            Email = email;
            CreateDate = createDate;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }
        public Company() { }
        public CompanyStatus? CompanyStatus { get; set; }
        public CompanyType? CompanyType { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set;}
        public string? Email { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }

    }
}
