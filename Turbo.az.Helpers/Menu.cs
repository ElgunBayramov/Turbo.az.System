using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az.Helpers
{
    public enum MenuStates : byte
    {
        BrandAll=1,
        BrandId,
        BrandAdd,
        BrandEdit,
        BrandRemove,

        ModelAll,
        ModelId,
        ModelAdd,
        ModelEdit,
        ModelRemove,

        CarsAll,
        CarsId,
        CarsAdd,
        CarsEdit,
        CarsRemove,

        All,
        Exit
    }
}
