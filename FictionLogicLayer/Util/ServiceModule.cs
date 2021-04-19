using FictionDataLayer.Interfaces;
using FictionDataLayer.Implementations;
using Ninject.Modules;

namespace FictionLogicLayer.Util
{
    class ServiceModule : NinjectModule
    {
        public ServiceModule()
        {
        }
        public override void Load()
        {
            Bind<RepositoryAbstractFabric>().To<EFRepositoryAbstractFabric>();
        }
    }
}
