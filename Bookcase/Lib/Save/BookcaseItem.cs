﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace Bookcase.Lib.Save
{
    public abstract class BookcaseItem : Item, IIdentifiable
    {
        public Identifier Identifier => identifier;
        private ObjectIdentifier identifier;
    }
}
