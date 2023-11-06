using Domain.Primitives;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public sealed class CompanyRoute : Entity
    {
        public CompanyRoute(Guid Id, Guid companyId, Guid routeId) : base(Id)
        {
            CompanyId = companyId;
            RouteId = routeId;
        }

        public CompanyRoute() { }

        [Required, ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        [Required, ForeignKey("Route")]
        public Guid RouteId { get; set; }

        public Company? Company { get; set; }
        public Route? Route { get; set; }


    }
}
