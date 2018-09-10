using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib
{
    public class Registry<T>
    {
        protected Dictionary<Identifier, T> registry;

        public Registry()
        {
            registry = new Dictionary<Identifier, T>();
        }

        internal virtual Dictionary<Identifier, T> RegistryData { get { return registry; } }

        public virtual void Register(Identifier identifier, T obj)
        {
            if (registry.ContainsKey(identifier))
                throw new ArgumentException($"Cannot Register type '{obj.GetType()}' with duplicate identifier '{identifier}'");
            registry.Add(identifier, obj);
        }

        public virtual T Get(string identifier)
        {
            return Get(new Identifier(identifier));
        }

        public virtual T Get(string modID, string objectID)
        {
            return Get(new Identifier(modID, objectID));
        }
        
        public virtual Identifier GetIdentifier(T obj)
        {
            foreach(KeyValuePair<Identifier, T> kvp in registry)
            {
                if (kvp.Value.Equals(obj))
                    return kvp.Key;
            }
            throw new ArgumentException($"Specified type {obj.GetType()} is not present in the registry.");
        }

        public virtual T Get(Identifier identifier)
        {
            if (registry.TryGetValue(identifier, out T value))
                return value;
            throw new KeyNotFoundException($"Cannot find key '{identifier}' ");
        }
    }
}