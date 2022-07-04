using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashalotHelper.Services.FsControler
{
    public interface IFSControler
    {
        public bool IsAccessibly (string path);
    }
}
