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
    public sealed class UserRoute: Entity
    {
        public UserRoute(Guid Id, Guid userId, Guid routeId, DateTime? updatedAt, bool deleted) : base(Id)
        {
            UserId = userId;
            RouteId = routeId;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }

        public UserRoute() { }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required, ForeignKey("Route")]
        public Guid RouteId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}
