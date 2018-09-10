using Bookcase.Lib;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Objects
{
    class ObjectInformationAssetEditor : IAssetEditor
    {
        public bool CanEdit<T>(IAssetInfo asset)
        {
            return asset.AssetNameEquals("Data\\ObjectInformation");
        }

        public IDictionary<int, string> ObjectInformation;

        public void Edit<T>(IAssetData asset)
        {
            IDictionary<string, string> assetData = asset.AsDictionary<string, string>().Data;
            if (ObjectInformation == null || ObjectInformation.Count == 0)
            {
                //TODO actually write the logic which governs loading.
                ObjectInformation = null; //This will be set to all loaded mod objects. The index mapping wont matter at this point since it'll only be for mods.
            }
            foreach(KeyValuePair<string, string> kvp in ObjectInformation)
            {
                assetData.Add(kvp);
            }
        }
    }
}
