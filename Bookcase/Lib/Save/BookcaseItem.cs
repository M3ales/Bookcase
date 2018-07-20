using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace Bookcase.Lib.Save
{
    public class BookcaseItem : Item
    {
        public Identifier Identifier;

        public override string DisplayName { get; set; }
        public override int Stack { get; set ; }

        public override int addToStack(int amount)
        {
            throw new NotImplementedException();
        }

        public override void drawInMenu(SpriteBatch spriteBatch, Vector2 location, float scaleSize, float transparency, float layerDepth, bool drawStackNumber, Color color, bool drawShadow)
        {
            throw new NotImplementedException();
        }

        public override string getDescription()
        {
            throw new NotImplementedException();
        }

        public override Item getOne()
        {
            throw new NotImplementedException();
        }

        public override int getStack()
        {
            throw new NotImplementedException();
        }

        public override bool isPlaceable()
        {
            throw new NotImplementedException();
        }

        public override int maximumStackSize()
        {
            throw new NotImplementedException();
        }
    }
}
