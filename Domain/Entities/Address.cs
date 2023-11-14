using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Address : Entity
    {

                      
        public Address(Guid Id, AddressStatus addressStatus, AddressType addressType, string street, string city, string state, string zip, double lat, double lng, string comments, bool bagged,  DateTime createDate, byte[] version, DateTimeOffset updatedAt, bool deleted) : base(Id)
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
            Version = version;
            UpdatedAt = updatedAt;
            Deleted = deleted;
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

        public byte[] Version { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public bool Deleted { get; set; }

        public List<RouteAddress>? RouteAddresses { get; set; }
    }
}
