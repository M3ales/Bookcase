using StardewModdingAPI;
using Bookcase.Lib;
using Bookcase.Patches;
using System;
using Bookcase.Objects;
using System.Collections.Generic;

namespace Bookcase {

    public class BookcaseMod : Mod {

        internal static IModHelper modHelper;
        internal static IReflectionHelper reflection;
        internal static Log logger;
        internal static Random random;
        internal static IManifest modManifest;

        public static ObjectTypeRegistry ObjectTypeRegistry { get; private set; }
        internal static ObjectIndexRegistry ObjectIndexRegistry { get; private set; }
        internal static ObjectReservedRegistry ObjectReservedRegistry { get; private set; }

        public override void Entry(IModHelper helper) {

            modHelper = helper;
            modManifest = ModManifest;
            reflection = helper.Reflection;
            logger = new Log(this);
            random = new Random();

            ObjectTypeRegistry = new ObjectTypeRegistry();
            ObjectIndexRegistry = new ObjectIndexRegistry();
            ObjectReservedRegistry = new ObjectReservedRegistry();
            ObjectReservedRegistry.CreateDefaultMappings(Helper.Content.Load<IDictionary<int, string>>("Data\\objectInformation.xnb",ContentSource.GameContent));

            StardewModHooksWrapper.CreateWrapper();
            PatchManager patchManager = new PatchManager();
            Events.SMAPIEventWrapper.SubscribeToSMAPIEvents();
        }
    }
}