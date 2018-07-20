using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public abstract class Identifier
    {
        public Identifier(string modID, string type)
        {
            this.ModID = modID;
            ItemType = Type.GetType(type, false, true);
        }
        /// <summary>
        /// Some identifier
        /// </summary>
        public string ModID;
        public Type ItemType;
        /// <summary>
        /// If this Type is currently injected into the game
        /// </summary>
        public bool Registered;
        public override string ToString()
        {
            return $"{ModID}:{ItemType}";
        }
    }
}
