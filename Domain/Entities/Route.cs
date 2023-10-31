using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Route: Entity
    {
        public Route(Guid Id, string name, DateTime createDate): base(Id)
        {
            CreateDate = createDate;
            Name = name;
        }
        
        public string? Name { get; set; }           
        public DateTime? CreateDate { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
