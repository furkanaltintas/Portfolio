using Autofac;
using Autofac.Extras.DynamicProxy;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Business.Services.Github;
using Portfolio.Core.Utilities.Interceptors;
using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Concrete;

namespace Portfolio.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<GithubApiService>().As<IGithubApiService>();
        builder.RegisterType<Repository>().As<IRepository>();
        builder.RegisterType<Service>().As<IService>();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}