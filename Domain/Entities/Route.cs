using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Route: Entity
    {
        public Route(Guid Id, RouteStatus routeStatus, RouteType routeType, string name, DateTime createDate, DateTime updatedAt, bool deleted): base(Id)
        {
            RouteStatus = routeStatus;
            RouteType = routeType;
            Name = name;
            CreateDate = createDate;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }
        public Route() { }

        public RouteStatus RouteStatus { get; set; }
        public RouteType RouteType { get; set; }
        public string? Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public List<RouteAddress>? RouteAddresses { get; set; }

    }
}
