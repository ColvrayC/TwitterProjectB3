using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterProjectB3.ViewModel;
using TwitterProjectB3.ViewModel.DataLogin;
using TwitterProjectB3.ViewModel.DataMain;
using TwitterProjectB3.ViewModel.DataTimeLine;
using TwitterProjectB3.ViewModel.DataTweet;

namespace TwitterProjectB3.Helpers
{
    public class ViewModelLocator
    {
        static IUnityContainer MainContainer;
        static IUnityContainer LoginContainer;
        static IUnityContainer TimeLineContainer;
        static IUnityContainer TweetContainer;

        static ViewModelLocator()
        {
            MainContainer = new UnityContainer();
            MainContainer.AddNewExtension<Interception>();
            MainContainer.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager()).Configure<Interception>().SetInterceptorFor<MainViewModel>(new VirtualMethodInterceptor());


            LoginContainer = new UnityContainer();
            LoginContainer.AddNewExtension<Interception>();
            LoginContainer.RegisterType<LoginViewModel>().Configure<Interception>().SetInterceptorFor<LoginViewModel>(new VirtualMethodInterceptor());

            TimeLineContainer = new UnityContainer();
            TimeLineContainer.AddNewExtension<Interception>();
            TimeLineContainer.RegisterType<TimeLineViewModel>().Configure<Interception>().SetInterceptorFor<TimeLineViewModel>(new VirtualMethodInterceptor());

            TweetContainer = new UnityContainer();
            TweetContainer.AddNewExtension<Interception>();
            TweetContainer.RegisterType<TweetViewModel>().Configure<Interception>().SetInterceptorFor<TweetViewModel>(new VirtualMethodInterceptor());

        }

        public MainViewModel Main
        {
            get { return MainContainer.Resolve<MainViewModel>(); }
        }

        public LoginViewModel Login
        {
            get { return LoginContainer.Resolve<LoginViewModel>(); }
        }

        public TimeLineViewModel TimeLine
        {
            get { return TimeLineContainer.Resolve<TimeLineViewModel>(); }
        }

        public TweetViewModel Tweet
        {
            get { return TweetContainer.Resolve<TweetViewModel>(); }
        }
    }
}
