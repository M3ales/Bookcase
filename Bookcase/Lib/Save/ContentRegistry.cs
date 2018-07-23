using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;
using Newtonsoft.Json;

namespace Bookcase.Lib.Save
{
    public class ContentRegistry<T> where T : XMLInfo
    {
        private ContentRegistry()
        {
            registery = new List<XMLInfo>();
        }
        public ContentRegistry(params object[] args) : this()
        {

        }
        private List<XMLInfo> registery;
        public void Register(T item)
        {
            if (registery.Count(i => i == item) == 0)
                registery.Add(item);
        }
    }
    public interface IContentInfo<T>
    {
        /// <summary>
        /// Gets a formatted string representing the object as if it was stored in an XNB file.
        /// </summary>
        /// <returns></returns>
        string GetContentString();//1 create entry
        /// <summary>
        /// Attempts to construct an instance based on the currently stored information
        /// </summary>
        /// <returns></returns>
        T TryConstructType();//2 construct instance of type
        bool Equals(T obj);
        Identifier Identifier { get; }
    }

    public abstract class ContentInfo<T> : IContentInfo<T>
    {
        public Identifier Identifier => identifier;
        private Identifier identifier;

        public virtual bool Equals(T obj)
        {
            return false;
        }

        public virtual string GetContentString()
        {
            return "null";
        }

        public abstract T TryConstructType();
    }
    public class ObjectInfo : ContentInfo<StardewValley.Object>
    {
        public override StardewValley.Object TryConstructType()
        {
            throw new NotImplementedException();
        }
    }
}
