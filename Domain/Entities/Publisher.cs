using Domain.Primitives;


namespace Domain.Entities
{
    public sealed class Publisher: Entity
    {

        public Publisher(Guid Id, string name, string abbreviation, decimal earnings) : base(Id) 
        { 
            Name = name;
            Abbreviation = abbreviation;
            Earnings = earnings;        
        }

        public string? Name { get; set; }
      
        public string? Abbreviation { get; set; }
       
        public decimal? Earnings { get; set; }

    }
}
