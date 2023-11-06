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
        public Company(Guid Id, CompanyStatus companyStatus, CompanyType companyType, string name, string phone, string email, DateTime createDate) : base(Id)
        {
            CompanyStatus = companyStatus;
            CompanyType = companyType;
            Name = name;
            Phone = phone;
            Email = email;
            CreateDate = createDate;
        }
        public Company() { }
        public CompanyStatus? CompanyStatus { get; set; }
        public CompanyType? CompanyType { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set;}
        public string? Email { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
