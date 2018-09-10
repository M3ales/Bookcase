using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public interface ISaveHandler
    {
        Type TargetModel { get; }
        ISemanticVersion Version { get; }
        string FilePath { get; }
        bool IsValidModel();
        T LoadData<T>();
        void SaveData<T>(T Data);
    }
}
