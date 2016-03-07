using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterProjectB3.ViewModel;

namespace TwitterProjectB3.Helpers
{
    public class ViewModelLocator
    {
        static IUnityContainer MainContainer;
        static IUnityContainer LoginContainer;

        static ViewModelLocator()
        {
            MainContainer = new UnityContainer();
            MainContainer.AddNewExtension<Interception>();
            MainContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager()).Configure<Interception>().SetInterceptorFor<MainViewModel>(new VirtualMethodInterceptor());


            LoginContainer = new UnityContainer();
            LoginContainer.AddNewExtension<Interception>();
            LoginContainer.RegisterType<LoginViewModel>().Configure<Interception>().SetInterceptorFor<LoginViewModel>(new VirtualMethodInterceptor());

        }

        public MainViewModel Main
        {
            get { return MainContainer.Resolve<MainViewModel>(); }
        }

        public MainViewModel Login
        {
            get { return LoginContainer.Resolve<LoginViewModel>(); }
        }
    }
}
