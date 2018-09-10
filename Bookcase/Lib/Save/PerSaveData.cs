using System;
using System.Collections.Generic;
using System.IO;
using StardewModdingAPI;
using StardewValley;

namespace Bookcase.Lib.Save
{
    public class PerSaveData
    {
        public ISemanticVersion bookcaseVersion;
        public ISemanticVersion modVersion;
        public ISemanticVersion smapiVersion;
        public string gameVersion;
        public Dictionary<string, object> modSaveData;
        /*
        public PerSaveData() : this(BookcaseMod.modManifest.Version, null, Constants.ApiVersion, Game1.version, new Dictionary<string, object>())
        {

        }*/

        public PerSaveData(ISemanticVersion bookcaseVersion, ISemanticVersion modVersion, ISemanticVersion smapiVersion, string gameVersion, Dictionary<string, object> modSaveData)
        {
            this.bookcaseVersion = bookcaseVersion;
            this.modVersion = modVersion;
            this.smapiVersion = smapiVersion;
            this.gameVersion = gameVersion;
            this.modSaveData = modSaveData;
        }

        public T GetEntry<T>(string key) where T : class
        {
            if(modSaveData.ContainsKey(key))
                return modSaveData[key] as T;
            throw new ArgumentException($"Could not find entry with key '{key}'");
        }

        public void AddEntry<T>(string key, T entry)
        {
            modSaveData.Add(key, entry);
        }

    }
}
