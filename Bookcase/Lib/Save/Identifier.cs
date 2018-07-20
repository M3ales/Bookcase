using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public class Identifier
    {
        public Identifier(string modID, string type)
        {
            this.ModID = modID;
            ItemType = Type.GetType(type, false, true);
            Registered = false;
        }
        /// <summary>
        /// Some identifier
        /// </summary>
        public string ModID;
        public Type ItemType;
        public string TypeToString()
        {
            return ItemType.ToString();//change this to cater for named IDs
        }
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
