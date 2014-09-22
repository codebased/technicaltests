

namespace CBA.Movie.WebHost
{
    using CBA.Movie.Data.Interface;
    using CBA.Movie.WebApi.Core.Service;
    using Ninject;
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    public class NInjectServiceFactory: ServiceHostFactory
    {
        private IKernel MyDIKernel;

        public NInjectServiceFactory()
        {
            MyDIKernel = new StandardKernel();
            this.AddBindings();
        }

        private void AddBindings()
        {
            
        }


        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return serviceType == null ? null : new ServiceHost(MyDIKernel.Get(serviceType), baseAddresses);
        }
    }
}