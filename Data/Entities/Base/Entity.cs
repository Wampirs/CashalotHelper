using CashalotHelper.Data.Interfaces;
using System;

namespace CashalotHelper.Data.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
