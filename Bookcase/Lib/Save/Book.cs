using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public class Book : StardewValley.Objects.Furniture, IIdentifiable
    {
        public string ModID => "MyModID";

        public Type ItemType => typeof(Book);

        public string GameID => "Book";

        public bool IsGameIDInteger => throw new NotImplementedException();
    }
}
