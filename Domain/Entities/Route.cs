using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Route: Entity
    {
        public Route(Guid Id, RouteStatus routeStatus, RouteType routeType, string name, DateTime createDate): base(Id)
        {
            RouteStatus = routeStatus;
            RouteType = routeType;
            Name = name;
            CreateDate = createDate;
        }
        public Route() { }

        public RouteStatus RouteStatus { get; set; }
        public RouteType RouteType { get; set; }
        public string? Name { get; set; }           
        public DateTime? CreateDate { get; set; }
        public List<RouteAddress>? RouteAddresses { get; set; }

    }
}
