using Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public sealed class RouteAddress: Entity
    {
        public RouteAddress(Guid Id, Guid routeId, Guid addressId, bool visible, bool reviewed, int position, DateTime? updatedAt, bool deleted) : base(Id)
        {
            RouteId = routeId;
            AddressId = addressId;
            Visible = visible;
            Reviewed = reviewed;
            Position = position;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }

        public RouteAddress() { }

        [Required, ForeignKey("Route")]
        public Guid RouteId { get; set; }

        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }
        public bool Visible { get; set; }        
        public bool Reviewed { get; set; }        
        public int? Position { get; set; }        
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public Route? Route { get; set; }
        public Address? Address { get; set; }

    }
}
