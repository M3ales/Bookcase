using StardewModdingAPI;
using Bookcase.Lib;
using Bookcase.Patches;
using System;
using Bookcase.Objects;
using System.Drawing;
using System.Collections.Generic;

namespace Bookcase {

    public class BookcaseMod : Mod {

        internal static IModHelper modHelper;
        internal static IReflectionHelper reflection;
        internal static Log logger;
        internal static Random random;
        private Bitmap testSprite = new Bitmap("H:\\test.jpg");
        public override void Entry(IModHelper helper) {

            modHelper = helper;
            reflection = helper.Reflection;
            logger = new Log(this);
            random = new Random();

            StardewModHooksWrapper.CreateWrapper();
            PatchManager patchManager = new PatchManager();
            SpriteStitcher s = new SpriteStitcher("Maps\\springobjects", new List<Bitmap>() { testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite, testSprite }, lastRowSpriteIndex: 12);
            s.PreLoad();
            s = new SpriteStitcher("TileSheets\\tools", new List<Bitmap>() { testSprite, testSprite, testSprite, testSprite }, tileSizeX:16, tileSizeY:32, lastRowSpriteIndex:0);
            s.PreLoad();
        }
    }
}