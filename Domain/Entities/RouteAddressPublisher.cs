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
    public sealed class RouteAddressPublisher: Entity
    {
        public RouteAddressPublisher(Guid Id, Guid routeAddressId, Guid publisherId, DateTime? updatedAt, bool deleted) : base(Id)
        {
            RouteAddressId = routeAddressId;
            PublisherId = publisherId;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }

        [Required, ForeignKey("RouteAddress")]
        public Guid RouteAddressId { get; set; }        

        [Required, ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public RouteAddress? RouteAddress { get; set; }
        public Publisher? Publisher { get; set; }

    }
}
