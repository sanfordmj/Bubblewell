using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class UserAddress: Entity
    {
        public UserAddress(Guid Id, Guid userId, Guid addressId, bool visible,  DateTime modifyDate) : base(Id)
        {
            UserId = userId;
            AddressId = addressId;
            Visible = visible;            
            ModifyDate = modifyDate;
        }

        public UserAddress() { }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }

        public bool Visible { get; set; }

        public DateTime? ModifyDate { get; set; }

        public User? User { get; set; }

        public Address? Address { get; set; }
    }
}
