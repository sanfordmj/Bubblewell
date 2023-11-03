using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Queries.GetAddressById
{
    public sealed record AddressResponse(Guid Id, AddressStatus AddressStatus, AddressType AddressType, string Street, string City, string State, string Zip, double Lat, double Lng, string Comments, bool Bagged, DateTime CreateDate);
}
