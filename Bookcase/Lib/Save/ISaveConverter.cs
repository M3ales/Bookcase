using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public interface ISaveConverter
    {
        ISemanticVersion SaveVersion { get; }
        ISemanticVersion ConversionVersion { get; }
        TFinal Convert<TInitial, TFinal>(TInitial Initial);
    }
}
