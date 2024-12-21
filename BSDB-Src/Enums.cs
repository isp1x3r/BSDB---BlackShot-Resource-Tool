using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercenary
{
    public enum GameVersion
    {
        GLB = 0,
        SEA = 1
    }
    public enum BSDBStatus
    {
        Encrypted = 0,
        Decrypted = 1,
        Corrupt = 2
    }
    
    public enum StatusLevel
    {
        Success  = 0,
        Notify1  = 1,
        Notify2  = 2,
        Error    = 3
    }

    public enum NifPackEdition
    {
        Aimbot = 0,
        Bodybot = 1,
        Inconspicuous = 2
    }
}
