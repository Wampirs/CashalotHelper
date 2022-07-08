using CashalotHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashalotHelper.Providers.Interfaces
{
    public interface ICashalotProvider
    {
        public List<Cashalot> Programs { get; }
    }
}
