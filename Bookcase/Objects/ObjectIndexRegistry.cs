using Bookcase.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = StardewValley.Object;
namespace Bookcase.Objects
{
    internal class ObjectIndexRegistry : Registry<int>
    {

        internal Object GetObjectFromIndex(int index)
        {
            foreach(KeyValuePair<Identifier, int> kvp in registry)
            {
                if(kvp.Value == index)
                {
                    return BookcaseMod.ObjectTypeRegistry.Get(kvp.Key);
                }
            }
            throw new ArgumentException($"Index '{index}' not present in ObjectIndexRegistry.");
        }

        internal int GetObjectIndex(Object obj) {
            Identifier id = BookcaseMod.ObjectTypeRegistry.GetIdentifier(obj);
            return registry[id];
        }

        public override void Register(Identifier identifier, int obj)
        {
            if (registry.ContainsValue(obj))
                throw new ArgumentException($"Duplicate index '{obj}' found in Registry. Only one-to-one mappings allowed.");
            base.Register(identifier, obj);
        }
    }
}
