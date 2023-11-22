using Domain.Entities;
using Domain.Primitives;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Addresses.Commands.CreateAddress
{
    public sealed record class CreateAddressRequest(string SyncId, AddressStatus AddressStatus, AddressType AddressType, string Street, string City, string State, string Zip, double Lat, double Lng, string Comments, bool Bagged, DateTime? CreateDate, DateTime? UpdatedAt, bool Deleted);
}
