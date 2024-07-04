using Autofac;
using Core.Attributes;
using Core.Infrastructure;
using Core.Services;
using DataCore.Cache;
using DataCore.Http;
using DataCore.Service;

namespace Core
{
    [Module(Name = "Ядро данных", ClassType = typeof(InitCommand), Priority = ModulePriority.Normal, Order = 2)]
    public class InitCommand : IModuleActivator
    {
        public void Run()
        {
            var builder = new ContainerBuilder();    
           
            Di.Update(builder);
        }
    }
}
