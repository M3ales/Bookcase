using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookcase.Lib;
using StardewValley;
using Object = StardewValley.Object;

namespace Bookcase.Objects
{
    public class ObjectTypeRegistry : Registry<Object>
    {
        public override Object Get(string identifier)
        {
            return base.Get(identifier);
        }

        public override Object Get(string modID, string objectID)
        {
            return base.Get(modID, objectID);
        }

        public override Object Get(Identifier identifier)
        {
            return base.Get(identifier);
        }

        public override Identifier GetIdentifier(Object obj)
        {
            return base.GetIdentifier(obj);
        }

        public override void Register(Identifier identifier, Object obj)
        {
            base.Register(identifier, obj);
        }
    }
}
