using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase
{
    public delegate void OnPickHitOre(int tile, object pickaxe);
    public class TestPatch : IGamePatch
    {
        public Type TargetType => throw new NotImplementedException();

        public MethodInfo TargetMethod => throw new NotImplementedException();

        public void OnRegistered()
        {

        }
    }
}
