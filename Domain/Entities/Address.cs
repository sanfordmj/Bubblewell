using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Address : Entity
    {

                      
        public Address(Guid Id, AddressStatus addressStatus, AddressType addressType, string street, string city, string state, string zip, double lat, double lng, string comments, bool bagged,  DateTime createDate) : base(Id)
        {
            AddressStatus = addressStatus;
            AddressType = addressType;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            LAT = lat;
            LNG = lng;
            Comments = comments;
            Bagged = bagged;
            CreateDate = createDate;
        }
        public Address() { }

        public AddressStatus AddressStatus { get; set; }

        public AddressType AddressType { get; set; }

        public string? Street { get; set; }
      
        public string? City { get; set; }
        
        public string? State { get; set; }
       
        public string? Zip { get; set; }
        
        public double LAT { get; set; }
        
        public double LNG { get; set; }

        public string? Comments { get; set; }
        
        public bool Bagged { get; set; }

        public DateTime CreateDate { get; set; }
        public List<RouteAddress>? RouteAddresses { get; set; }
    }
}
