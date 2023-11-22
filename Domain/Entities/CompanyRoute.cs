using Domain.Primitives;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public sealed class CompanyRoute : Entity
    {
        public CompanyRoute(Guid Id, Guid companyId, Guid routeId, DateTime? updatedAt, bool deleted) : base(Id)
        {
            CompanyId = companyId;
            RouteId = routeId;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }

        public CompanyRoute() { }

        [Required, ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        [Required, ForeignKey("Route")]
        public Guid RouteId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public Company? Company { get; set; }
        public Route? Route { get; set; }


    }
}
