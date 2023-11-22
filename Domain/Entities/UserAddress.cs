using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class UserAddress: Entity
    {
        public UserAddress(Guid Id, Guid userId, Guid addressId, bool visible,  DateTime? updatedAt, bool deleted) : base(Id)
        {
            UserId = userId;
            AddressId = addressId;
            Visible = visible;            
            UpdatedAt = updatedAt;
            Deleted = deleted;
        }

        public UserAddress() { }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required, ForeignKey("Address")]
        public Guid AddressId { get; set; }
        public bool Visible { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public User? User { get; set; }
        public Address? Address { get; set; }
    }
}
