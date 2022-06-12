using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashalotHelper.Data.Entities.Base;

namespace CashalotHelper.Data.Entities
{
    public class Configuration : Entity
    {
        public string Property { get; set; }
        public string Value { get; set; }
        
    }
}
