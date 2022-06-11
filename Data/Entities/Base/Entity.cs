using System;
using CashalotHelper.Data.Interfaces;

namespace CashalotHelper.Data.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
