using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public class SaveManager
    {
        List<ISaveConverter> Converters;
        List<ISaveHandler> Handlers;
        public T LoadData<T>()
        {
            foreach(ISaveHandler h in Handlers.OrderBy(x=>x.Version))
            {
                if(File.Exists(h.FilePath))
                {
                    using (Stream s = new FileStream(h.FilePath, FileMode.Open))
                    {
                        if (h.IsValidModel()

                    }
                }
            }
        }
    }
}
