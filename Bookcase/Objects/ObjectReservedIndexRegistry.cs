using Bookcase.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Objects
{
    /// <summary>
    /// Objects reserved by base game, will allow edits to them from here in future.
    /// </summary>
    public class ObjectReservedIndexRegistry : Registry<int>
    {
        public override void Register(Identifier identifier, int obj)
        {
            if (registry.ContainsValue(obj))
                throw new ArgumentException($"Duplicate index '{obj}' found in Registry. Only one-to-one mappings allowed.");
            base.Register(identifier, obj);
        }

        public void CreateDefaultMappings(IDictionary<int, string> objectInformation)
        {
            foreach (KeyValuePair<int, string> kvp in objectInformation)
            {
                string oid = kvp.Value.Split('/')[0];
                if(objectInformation.Values.Count(x=>x.Split('/')[0] == oid) > 1)
                {
                    oid += kvp.Key;
                }
                oid = oid.Replace(" ", "").ToLower();
                BookcaseMod.logger.Info($"Loading '{kvp.Value.Split('/')[0]}' ({kvp.Key}) as {new Identifier("sdv",oid)}");
                Register(new Identifier("sdv", oid), kvp.Key);
            }
        }
    }
}