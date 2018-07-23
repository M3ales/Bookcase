using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;

namespace Bookcase.Lib
{
    class TimePatch
    {
        Dictionary<int, Action> Times;
        public void Replacement()
        {
            if(Times.TryGetValue(Game1.timeOfDay, out Action action))
            {
                action();
            }
        }
    }
    public enum Priority
    {
        Low, Medium, Lots, TooMuch, PlsNo
    }
}
