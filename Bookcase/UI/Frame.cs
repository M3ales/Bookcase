using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley.Menus;
using Microsoft.Xna.Framework;

namespace Bookcase.UI
{
    public class Frame
    {
        public int localX;
        public int localY;
        public int GlobalX
        {
            get
            {
                if (parent == null)
                    return localX;
                //anchor logic here
                return parent.GlobalX + localX + AnchorPointX(this, anchor);
            }
        }
        public int GlobalY
        {
            get
            {
                if (parent == null)
                    return localY;
                //anchor logic here
                return parent.GlobalY + localY + AnchorPointY(this, anchor);
            }
        }
        public int AnchorPointX(Frame frame, FrameAnchor anchor)
        {
            if (frame == null)
                return 0;
            switch(anchor)
            {
                case FrameAnchor.TopMid:
                case FrameAnchor.MidMid:
                case FrameAnchor.BottomMid:
                    {
                        return frame.width / 2;
                    }
                case FrameAnchor.TopRight:
                case FrameAnchor.MidRight:
                case FrameAnchor.BottomRight:
                    {
                        return frame.width;
                    }
                case FrameAnchor.TopLeft:
                case FrameAnchor.MidLeft:
                case FrameAnchor.BottomLeft:
                    {
                        return 0;
                    }
            }
            return 0;
        }
        public int AnchorPointY(Frame frame, FrameAnchor anchor)
        {
            if (frame == null)
                return 0;
            switch (anchor)
            {
                case FrameAnchor.TopMid:
                case FrameAnchor.TopLeft:
                case FrameAnchor.TopRight:
                    {
                        return 0;
                    }
                case FrameAnchor.MidRight:
                case FrameAnchor.MidMid:
                case FrameAnchor.MidLeft:
                    {
                        return frame.height / 2;
                    }
                case FrameAnchor.BottomLeft:
                case FrameAnchor.BottomRight:
                case FrameAnchor.BottomMid:
                    {
                        return frame.height;
                    }
            }
            return 0;
        }
        public int height;
        public int width;
        Color color;

        public Frame parent;
        public List<Frame> children;
        public FrameAnchor snapToAnchor;
        public FrameAnchor anchor = FrameAnchor.TopLeft;

        public void Draw(SpriteBatch b, Frame parent)
        {
            if(parent != null)
                IClickableMenu.drawTextureBox(b, parent.GlobalX + AnchorPointX(parent, snapToAnchor) + localX, parent.GlobalY + AnchorPointY(parent, snapToAnchor) + localY, width, height, color);
            else
                IClickableMenu.drawTextureBox(b, localX + AnchorPointX(this,anchor), localY + AnchorPointY(this, anchor), width, height, color);
            foreach (Frame f in children)
            {
                f.Draw(b, this);
            }
        }
    }
    public enum FrameAnchor
    {
        TopLeft,TopMid,TopRight,
        MidLeft,MidMid,MidRight,
        BottomLeft,BottomMid,BottomRight
    }
}
