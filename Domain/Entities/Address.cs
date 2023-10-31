using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Address : Entity
    {
        public int IxAddress { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Zip { get; set; }
        [Required]
        public double LAT { get; set; }
        [Required]
        public double LNG { get; set; }

        public string? Comments { get; set; }
        [Required]
        public bool Bagged { get; set; }

        public List<Route>? Routes { get; set; }

    }
}
