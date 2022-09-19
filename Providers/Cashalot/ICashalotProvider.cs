using CashalotHelper.Models;
using System.Collections.Generic;

namespace CashalotHelper.Providers.Interfaces
{
    public interface ICashalotProvider
    {
        public List<Cashalot> Programs { get; }
    }
}
