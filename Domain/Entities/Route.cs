using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Route: Entity
    {
        public Route(Guid Id, string name, DateTime createDate): base(Id)
        {
            CreateDate = createDate;
            Name = name;
        }
        public Route() { }
        public string? Name { get; set; }           
        public DateTime? CreateDate { get; set; }
        public List<RouteAddress>? RouteAddresses { get; set; }

    }
}
