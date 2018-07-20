using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Lib.Save
{
    public class Registry
    {
        public List<BookcaseTool> Tools;//Specific
        public List<BookcaseObject> Objects;//General
        public List<BookcaseItem> Items;//Literally Anything

        private int currentIDIndex = 10000;
        private int GetNextID()
        {
            return currentIDIndex++;
        }

        public bool Add(IIdentifiable i)
        {
            if (i is BookcaseTool)
            {
                Tools.Add(i as BookcaseTool);
                if (i.Identifier is ObjectIdentifier)
                    ((ObjectIdentifier)i).GameID = GetNextID();
                i.Identifier.Registered = false;
                return true;
            }
            if (i is BookcaseObject)
            {
                Objects.Add(i as BookcaseObject);
                if (i.Identifier is ObjectIdentifier)
                    ((ObjectIdentifier)i).GameID = GetNextID();
                i.Identifier.Registered = false;
                return true;
            }
            else if (i is BookcaseItem)
            {
                Items.Add(i as BookcaseItem);
                if (i.Identifier is ObjectIdentifier)
                    ((ObjectIdentifier)i).GameID = GetNextID();
                i.Identifier.Registered = false;
                return true;
            }
            return false;
        }
        public void HookOntoFactories()
        {
            //Do factory hooks
        }
    }
}
