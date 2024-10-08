using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Ninject;
using Ninject.Web.Common;

namespace DovizPro.Dependency
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
       
        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop() 
        {
            bootstrapper.ShutDown();
        }
        private static IKernel CreateKernel() //burada hata mesajı var bilmiyorum bağımlılık yönetimi
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<ICurrencyDataService>().To<CurrencyDataManager>().InRequestScope();
                kernel.Bind<ICurrencyInternetService>().To<CurrencyInternetManager>().InRequestScope();
            }
            catch (Exception ex)
            {
                kernel.Dispose();
                throw;
            }
        }
    }
}