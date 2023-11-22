using Domain.Primitives;


namespace Domain.Entities
{
    public sealed class Publisher: Entity
    {

        public Publisher(Guid Id, string name, string abbreviation, decimal earnings, DateTime? updatedAt, bool deleted) : base(Id) 
        { 
            Name = name;
            Abbreviation = abbreviation;
            Earnings = earnings;
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }

        public Publisher() { }
        public string? Name { get; set; }      
        public string? Abbreviation { get; set; }       
        public decimal? Earnings { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }

    }
}
