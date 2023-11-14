using Domain.Primitives;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Datasync.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.TableEntities
{
    public sealed class AddressSync : InMemoryTableData
    {
        
        public AddressStatus AddressStatus { get; set; }

        public AddressType AddressType { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        public double LAT { get; set; }

        public double LNG { get; set; }

        public string? Comments { get; set; }

        public bool Bagged { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
