using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity(Guid Id) => this.Id = Id;

        protected Entity() { }

        public Guid Id { get; protected set; }
    }
}
