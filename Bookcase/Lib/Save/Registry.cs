using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;

namespace Bookcase.Lib.Save
{
    public class Registry
    {
        private int currentIDIndex = 10000;
        private int GetNextID()
        {
            return currentIDIndex++;
        }
        public List<Item> Items;
        /// <summary>
        /// Adds an Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public bool AddItem<T>() where T : StardewValley.Item, new()
        {
            if (typeof(T) is IIdentifiable)
            {
                T t = new T();
                IIdentifiable i = t as IIdentifiable;
                if(i.IsGameIDInteger)
                    i.GameID = GetNextID().ToString();
                Items.Add(t);
                return true;
            }
            else
                return false;//complain in future
        }
    }
}
