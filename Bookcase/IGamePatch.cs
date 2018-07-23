using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bookcase
{
    internal interface IGamePatch
    {
        void OnRegistered();
        Type TargetType { get; }
        MethodInfo TargetMethod { get; }
    }
}
