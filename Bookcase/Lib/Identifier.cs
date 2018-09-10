using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib
{
    public struct Identifier
    {
        #region Static Context
        public const char Separator = ':';
        /// <summary>
        /// Implicitly casts an Identifier to a concat of ModID, Separator, and ObjectID
        /// </summary>
        /// <param name="i">The identfier to cast</param>
        public static implicit operator string(Identifier i)
        {
            return i.ModID + Separator + i.ObjectID;
        }

        /// <summary>
        /// List of methods which are used to ensure a given Identifier is valid.
        /// </summary>
        internal static List<Func<string, string, bool>> ValidationRules = new List<Func<string, string, bool>>()
        {
            (mid,oid) => { return mid.ToLower() == mid && oid.ToLower() == oid; },
            (mid,oid) => { return !(mid.Equals("smapi") || oid.Equals("smapi")); },
            //(mid,oid) => { return !mid.Equals("sdv"); }
        };
        /// <summary>
        /// Applies the specified validation rules on the given objectID and modID. This is run automatically during Identifier construction.
        /// </summary>
        /// <param name="objectID">The objectID of the identfier to validate.</param>
        /// <param name="modID">The modID of the identfier to validate.</param>
        /// <returns>If the given parameters create a valid Identifier.</returns>
        public static bool ValidateIdentifier(string objectID, string modID)
        {
            foreach (var validator in ValidationRules)
            {
                if (!validator(modID, objectID))
                    return false;
            }
            return true;
        }
        #endregion
        #region Fields
        private readonly string objectID;
        private readonly string modID;
        #endregion
        #region Properties
        /// <summary>
        /// Bookcase Mod specific Object ID
        /// </summary>
        public string ObjectID => objectID;

        /// <summary>
        /// Bookcase Mod ID
        /// </summary>
        public string ModID => modID;
        #endregion

        public Identifier(string modID, string objectID)
        {
            if (!ValidateIdentifier(modID, objectID))
                throw new ArgumentException($"'{objectID}{Separator}{modID}' is not a valid Identifier.");
            this.objectID = objectID;
            this.modID = modID;
        }

        public Identifier(string identifier)
        {
            string[] data = identifier.Split(Identifier.Separator);
            if (data.Length != 2)
                throw new ArgumentException($"Identifier '{identifier}' does not conform to the standard [modID]{Identifier.Separator}[objectID].", "identifier");
            if (!ValidateIdentifier(data[0], data[1]))
                throw new ArgumentException($"'{identifier}' is not a valid Identifier.");
            this.modID = data[0];
            this.objectID = data[1];
        }

        public override int GetHashCode()
        {
            return 31 * ObjectID.GetHashCode() + ModID.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ModID}{Separator}{ObjectID}";
        }
    }
}