﻿using StardewModdingAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Events {
    public static class SMAPIEventWrapper {
        /// <summary>
        /// Subscribes Post methods of relevant BookcaseEvents to SMAPI events. Should be called once from BookcaseMod.Entry().
        /// </summary>
        public static void SubscribeToSMAPIEvents() {
            GameEvents.FirstUpdateTick += (o, e) => { BookcaseEvents.FirstGameTick.Post(new Event()); };
            GameEvents.QuarterSecondTick += (o, e) => { BookcaseEvents.GameQuaterSecondTick.Post(new Event()); };
            GameEvents.HalfSecondTick += (o, e) => { BookcaseEvents.GameHalfSecondTick.Post(new Event()); };
            GameEvents.OneSecondTick += (o, e) => { BookcaseEvents.GameFullSecondTick.Post(new Event()); };
        }
    }
}
