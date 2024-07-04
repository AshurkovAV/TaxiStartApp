using Autofac;
using Core.Attributes;
using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [Module(Name = "Ядро приложения", ClassType = typeof(InitCommand), Priority = ModulePriority.Normal, Order = 1)]
    public class InitCommand : IModuleActivator
    {
        public void Run()
        {
            
        }
    }
}
