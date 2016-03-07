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

        static ViewModelLocator()
        {
            MainContainer = new UnityContainer();
            MainContainer.AddNewExtension<Interception>();
            MainContainer.RegisterType<MainViewModel>().Configure<Interception>().SetInterceptorFor<MainViewModel>(new VirtualMethodInterceptor());

        }

        public MainViewModel Main
        {
            get { return MainContainer.Resolve<MainViewModel>(); }
        }
    }
}
