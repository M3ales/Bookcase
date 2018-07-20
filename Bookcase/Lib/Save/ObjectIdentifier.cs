using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI.Events;
namespace Bookcase.Lib.Save
{
    public class ObjectIdentifier : Identifier
    {
        public ObjectIdentifier(string modID, string type) : base(modID, type)
        {
        }
        public int GameID;

        /// <summary>
        /// Implicit cast from Identifier to GameID (int)
        /// </summary>
        /// <param name="i"></param>
        public static implicit operator int(ObjectIdentifier i)
        {
            if (i == null)
                throw new InvalidCastException("Cannot cast null to int");
            if (!i.Registered)
                throw new InvalidOperationException($"Cannot get non registered type {i}");
            return i.GameID;
        }
    }
}
