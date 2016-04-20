using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutbreakLauncher
{
    class ModFile
    {
        public string Name;
        public bool NeedsUpdate;

        public ModFile (string Name, bool NeedsUpdate)
        {
            this.Name = Name;
            this.NeedsUpdate = NeedsUpdate;
        }
    }
}
