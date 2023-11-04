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
        public UserRoute(Guid Id, Guid userId, Guid routeId) : base(Id)
        {
            UserId = userId;
            RouteId = routeId;
        }

        public UserRoute() { }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required, ForeignKey("Route")]
        public Guid RouteId { get; set; }
    }
}
