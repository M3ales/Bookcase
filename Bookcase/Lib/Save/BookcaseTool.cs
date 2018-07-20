using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public abstract class BookcaseTool : StardewValley.Tool, IIdentifiable
    {
        public Identifier Identifier => identifier;
        private ObjectIdentifier identifier;
    }
}