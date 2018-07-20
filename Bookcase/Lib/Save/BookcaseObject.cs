using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public class BookcaseObject : StardewValley.Object, IIdentifiable
    {
        public Identifier Identifier => identifier;
        private ObjectIdentifier identifier;
    }
}
