using Domain.Primitives;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public sealed class CompanyPublisher : Entity
    {
        public CompanyPublisher(Guid Id, Guid companyId, Guid publisherId) : base( Id )
        {
            CompanyId = companyId;
            PublisherId = publisherId;
        }

        public CompanyPublisher() { }

        [Required, ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        [Required, ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }

        public Company? Company { get; set; }
        public Publisher? Publisher { get; set; }


    }
}
