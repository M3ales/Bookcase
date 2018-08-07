using StardewValley;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Drawing.Imaging;

namespace Bookcase.Objects
{
    public class SpriteStitcher : IAssetLoader
    {
        public SpriteStitcher(string baseSpriteSheetName, List<Bitmap> sprites, int tileSizeX = 16, int tileSizeY = 16, int lastRowSpriteIndex = 0)
        {
            this.baseSpriteSheetName = baseSpriteSheetName;
            this.sprites = sprites;
            this.tileSizeX = tileSizeX;
            this.tileSizeY = tileSizeY;
            this.lastRowSpriteIndex = lastRowSpriteIndex;
        }
        public List<Bitmap> sprites;
        public int tileSizeX;
        public int tileSizeY;
        public int lastRowSpriteIndex;
        public string baseSpriteSheetName;
        public void PreLoad()
        {
            Texture2D loaded = BookcaseMod.modHelper.Content.Load<Texture2D>(baseSpriteSheetName,ContentSource.GameContent);
            using (MemoryStream m = new MemoryStream())
            {
                loaded.SaveAsPng(m, loaded.Width, loaded.Height);
                Image map = Bitmap.FromStream(m);
                int countX = map.Width / tileSizeX;
                int countY = map.Height / tileSizeY;
                int toAdd = sprites.Count;
                BookcaseMod.logger.Debug($"Calculating size of final with {toAdd} new sprites.");
                toAdd -= (countX - lastRowSpriteIndex);
                for (;toAdd > 0; toAdd -= countX)
                    countY++;
                BookcaseMod.logger.Debug($"Found {countX} tiles in X plane.");
                BookcaseMod.logger.Debug($"Found {countY} tiles in Y plane.");
                Bitmap final = new Bitmap(map.Width, countY * tileSizeY);
                BookcaseMod.logger.Debug($"Creating new Sheet with dimensions {final.Width}x{final.Height} (Original {map.Width}x{map.Height})");
                using (Graphics g = Graphics.FromImage(final))
                {
                    BookcaseMod.logger.Debug($"Drawing original sheet.");
                    g.DrawImage(map, new Point(0, 0));
                    int posY = map.Height - tileSizeY;
                    int posX = lastRowSpriteIndex*tileSizeX;
                    foreach(Image i in sprites)
                    {
                        BookcaseMod.logger.Debug($"Stitching sprite {i.GetHashCode()} to sheet at ({posX}, {posY})");
                        g.DrawImage(i, posX, posY);
                        posX += tileSizeX;
                        if(posX > map.Width)
                        {
                            posX = 0;
                            posY += tileSizeY;
                        }
                    }
                }
                using (MemoryStream memory = new MemoryStream())
                {
                    if(!Directory.Exists(BookcaseMod.modHelper.DirectoryPath + "\\" + baseSpriteSheetName.Split('\\')[0]))
                        Directory.CreateDirectory(BookcaseMod.modHelper.DirectoryPath + "\\" + baseSpriteSheetName.Split('\\')[0]);
                    using (FileStream fs = new FileStream(BookcaseMod.modHelper.DirectoryPath + "\\" + baseSpriteSheetName + ".png", FileMode.Create, FileAccess.ReadWrite))
                    {
                        final.Save(memory, ImageFormat.Png);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                final.Dispose();
            }
        }
        public bool CanLoad<T>(IAssetInfo asset)
        {
            return asset.AssetNameEquals(baseSpriteSheetName);
        }

        public T Load<T>(IAssetInfo asset)
        {
            return BookcaseMod.modHelper.Content.Load<T>(baseSpriteSheetName, ContentSource.ModFolder);
        }
    }
}