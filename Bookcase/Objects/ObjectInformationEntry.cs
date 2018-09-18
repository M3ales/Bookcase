using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase.Objects
{
    struct ObjectInformationEntry
    {
        public int ParsentSheetIndex;
        public string Name;
        public int Price;
        public int Edibility;
        public string Type;
        public string Category;
        public string DisplayName;
        public string Description;
        public bool hasBuffs;
        public string FoodOrDrink;
        public string Buffs;
        public int BuffDuration;

        public string CompileEntry()
        {
            if(!hasBuffs)
                return $"{Name}/{Price}/{Edibility}/{Type} {Category}/{DisplayName}/{Description}";
            return $"{Name}/{Price}/{Edibility}/{Type} {Category}/{DisplayName}/{Description}/{FoodOrDrink}/{Buffs}/{BuffDuration}";
        }

        /*public ObjectInformationEntry(string toParse)
        {
            string[] data = toParse.Split("/");
            Name = data[0];
            Price = int.Parse(data[1]);
            Edibility = int.Parse(data[2]);
            Type = data[3];
            Category = int.Parse(data[4]);
            DisplayName = data[5];
            Description = data[6];
        }*/
    }
}
